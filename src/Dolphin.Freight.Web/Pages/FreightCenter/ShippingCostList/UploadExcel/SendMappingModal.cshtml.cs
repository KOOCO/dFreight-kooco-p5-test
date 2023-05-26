using Dolphin.Freight.iFreightDB.FreightCenters;
using Dolphin.Freight.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace Dolphin.Freight.Web.Pages.FreightCenter.ShippingCostList.UploadExcel
{
    public class SendMappingModalModel : FreightPageModel
    {
        [BindProperty]
        public UploadFileDto uploadFileDto { get; set; }
        public Models.NotificationMessage NotificationMessage { get; set; }

        private readonly IFreightCenterAppService _appService;

        public SendMappingModalModel(ICurrentUser currentUser, IFreightCenterAppService freightCenterAppService)
        {
            _appService = freightCenterAppService;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
 
            if (uploadFileDto.File == null || uploadFileDto.File.Length == 0)
            {
                ModelState.AddModelError("File", "Please select a file");
                NotificationMessage = new(L["PleaseSelectAFile"], null, Models.MessageType.Error);
                return new JsonResult(new { message = NotificationMessage });
            }

            using (var memoryStream = new MemoryStream())
            {
                await uploadFileDto.File.CopyToAsync(memoryStream);

                NotificationMessage = await _appService.OceanShippingCostConvertToDatabaseAsync(
                    new OceanShippingExcelFileUploadDto
                    {
                        userId = CurrentUser.UserName,
                        fileContent = memoryStream.ToArray()
                    }
                );
            }

            return new JsonResult(new { message = NotificationMessage });

            // return NoContent();
            // return Redirect("/FreightCenter/ShippingCostList/UploadExcel");
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
