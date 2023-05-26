using Dolphin.Freight.TradePartners;
using Dolphin.Freight.Web.Helpers;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Users;
using static System.Net.WebRequestMethods;


namespace Dolphin.Freight.Web.Pages.Sales.TradePartner
{
    public class DocumentModel : AbpPageModel
    {
        // 接收網址傳來的參數
        [BindProperty(SupportsGet = true)]
        public string TPCode { get; set; }
        [BindProperty(SupportsGet = true)]
        public Guid TPId { get; set; }

        // 畫面上的物件
        [BindProperty]
        public DocumentUploadViewModel DocumentUploadModel { get; set; }

        private readonly string _folder;
        private readonly ITradePartnerAttachmentAppService _tradePartnerAttachmentAppService;

        public DocumentModel(IWebHostEnvironment env, ITradePartnerAttachmentAppService tradePartnerAttachmentAppService)
        {
            // 上傳目錄設為: wwwroot\mediaUpload\tradepartner\doc
            _folder = $@"{env.WebRootPath}\mediaUpload\tradepartner\doc";
            _tradePartnerAttachmentAppService = tradePartnerAttachmentAppService;
        }

        public void OnGet()
        {
            DocumentUploadModel = new DocumentUploadViewModel();
            DocumentUploadModel.TPId = TPId;
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            //try
            //{
            //    ValidateModel();

                // TODO: 判斷檔名是否有重複(目前是會蓋過)

                // 將檔案寫入指定的檔案位置
                if (DocumentUploadModel.FromFile != null && DocumentUploadModel.FromFile.Length > 0)
                {
                    var path = $@"{_folder}\{DocumentUploadModel.FromFile.FileName}";
                    using var stream = new FileStream(path, FileMode.Create);
                    await DocumentUploadModel.FromFile.CopyToAsync(stream);

                    // 將檔案資訊寫入資料庫
                    var dto = new CreateUpdateTradePartnerAttachmentDto();
                    dto.AttachmentName = DocumentUploadModel.FromFile.FileName;
                    dto.AttachmentSize = DocumentUploadModel.FromFile.Length;
                    dto.AttachmentUploadTime = DateTime.Now;
                    dto.TPId = TPId;
                    await _tradePartnerAttachmentAppService.CreateAsync(dto);

                    return NoContent();

                    //return new OkObjectResult(new
                    //{
                    //    name = DocumentUploadModel.FromFile.FileName, // 檔案名稱
                    //    size = DocumentUploadModel.FromFile.Length,
                    //    date = Clock.Now.ClearTime().ToString("yyyy-MM-dd HH:mm"),
                    //    tpId = TPId
                    //});
                }
                else
                {
                    return Page();
                }
            //}
            //catch (Exception ex)
            //{
            //    return Page();
            //}

        }

        #region DocumentUploadViewModel
        public class DocumentUploadViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            
            [Required]
            [StringLength(TradePartnerAttachmentConsts.MaxNameLength, MinimumLength = TradePartnerAttachmentConsts.MinNameLength)]
            public string AttachmentName { get; set; }

            [CanBeNull]
            [DataType(DataType.Upload)]
            [MaxFileSize(TradePartnerAttachmentConsts.MaxAttachmentFileSize)]
            public IFormFile FromFile { get; set; }

            [DataType(DataType.Date)]
            public DateTime AttachmentUploadTime { get; set; }

            public double AttachmentSize { get; set; }
            public Guid UserId { get; set; }
            public Guid TPId { get; set; }
        }
        #endregion
    }
}
