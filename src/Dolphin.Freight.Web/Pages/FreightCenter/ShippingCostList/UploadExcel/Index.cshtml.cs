using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Microsoft.Extensions.Localization;
using Dolphin.Freight.Localization;
using Volo.Abp.Users;
using Dolphin.Freight.iFreightDB.FreightCenters;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Newtonsoft.Json;

namespace Dolphin.Freight.Web.Pages.FreightCenter.ShippingCostList.UploadExcel
{
    public class IndexModel : FreightPageModel
    {

        [BindProperty]
        public UploadFileDto uploadFileDto { get; set; }
        public Models.NotificationMessage NotificationMessage { get; set; }

        private readonly IFreightCenterAppService _appService;

        public IndexModel(IFreightCenterAppService freightCenterAppService)
        {
            _appService = freightCenterAppService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string erroeMessage = string.Empty;

            if (uploadFileDto.File == null || uploadFileDto.File.Length == 0)
            {
                ModelState.AddModelError("File", "Please select a file");
                NotificationMessage = new(L["PleaseSelectAFile"], null, Models.MessageType.Error);
                TempData["NotificationMessage"] = JsonConvert.SerializeObject(NotificationMessage);
                return Redirect("/FreightCenter/ShippingCostList/UploadExcel");
            }

            // 參考這個：https://community.abp.io/posts/file-uploaddownload-with-blob-storage-system-in-asp.net-core-abp-framework-d01cbe12

            using (var memoryStream = new MemoryStream())
            {
                await uploadFileDto.File.CopyToAsync(memoryStream);

                NotificationMessage = await _appService.OceanShippingCostUploadAsync(
                    new OceanShippingExcelFileUploadDto
                    {
                        userId = CurrentUser.UserName,
                        fileContent = memoryStream.ToArray()
                    }
                );
            }

            TempData["NotificationMessage"] = JsonConvert.SerializeObject(NotificationMessage);
            return Redirect("/FreightCenter/ShippingCostList/UploadExcel");
            // return Page();

        }

        public class UploadFileDto
        {
            [Required]
            [Display(Name = "File")]
            public IFormFile File { get; set; }

            // [Required]
            [Display(Name = "Filename")]
            public string Name { get; set; }
        }

    }

}
