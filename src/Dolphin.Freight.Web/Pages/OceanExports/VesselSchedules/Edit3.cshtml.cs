using Dolphin.Freight.ImportExport.Attachments;
using Dolphin.Freight.ImportExport.OceanExports.ExportBookings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Dolphin.Freight.ImportExport.OceanExports.VesselScheduleas;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Dolphin.Freight.Web.Pages.OceanExports.VesselSchedules
{
    public class Edit3Model : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public string SoNo { get; set; }
        public CreateUpdateVesselScheduleDto VesselSchedule { get; set; }
        private readonly IVesselScheduleAppService _vesselScheduleAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IAttachmentAppService _attachmentAppService;
        public Edit3Model(IVesselScheduleAppService vesselScheduleAppService, IWebHostEnvironment webHostEnvironment, IAttachmentAppService attachmentAppService)
        {
            _vesselScheduleAppService = vesselScheduleAppService;
            _attachmentAppService = attachmentAppService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task OnGetAsync()
        {
            var vesselSchedule = await _vesselScheduleAppService.GetAsync(Id);
            SoNo = vesselSchedule.ReferenceNo;
        }
        public async Task<IActionResult> OnPostMyUploader(IFormFile MyUploader, Guid fid)
        {
            string fname = "";
            if (MyUploader != null)
            {

                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "mediaUpload");
                if (!Directory.Exists(uploadsFolder))
                {
                    DirectoryInfo folder = Directory.CreateDirectory(uploadsFolder);
                }
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }
                fname = MyUploader.FileName;
                CreateUpdateAttachmentDto dto = new CreateUpdateAttachmentDto() { FileName = fname, ShowName = fname, Ftype = 9, Fid = fid, Size = MyUploader.Length / 1024 };
                await _attachmentAppService.CreateAsync(dto);
                return new ObjectResult(new { status = "success", fname = fname, udate = DateTime.Now.ToString("yyyy-MM-dd"), size = MyUploader.Length / 1024 });
            }
            return new ObjectResult(new { status = "fail" });

        }
        public async Task<IActionResult> OnGetDownload(string filename)
        {
            if (filename == null)
                return Content("filename is not availble");
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "mediaUpload");
            var path = Path.Combine(uploadsFolder, filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        // Get content type
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
                {
                    {".txt", "text/plain"},
                    {".pdf", "application/pdf"},
                    {".doc", "application/vnd.ms-word"},
                    {".docx", "application/vnd.ms-word"},
                    {".xls", "application/vnd.ms-excel"},
                    {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                    {".png", "image/png"},
                    {".jpg", "image/jpeg"},
                    {".jpeg", "image/jpeg"},
                    {".gif", "image/gif"},
                    {".csv", "text/csv"}
                };
        }

    }
}
