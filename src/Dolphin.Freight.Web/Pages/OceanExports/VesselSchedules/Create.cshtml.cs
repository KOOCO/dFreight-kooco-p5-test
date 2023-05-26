using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.ImportExport.OceanExports.VesselScheduleas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Dolphin.Freight.Web.Pages.OceanExports.VesselScheduleas
{
    public class CreateModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdateVesselScheduleDto VesselSchedule { get; set; }
        private readonly IVesselScheduleAppService _vesselScheduleAppService;
        public CreateModel(VesselScheduleAppService vesselScheduleAppService) 
        {
            _vesselScheduleAppService = vesselScheduleAppService;
        }
        public void OnGet()
        {
            VesselSchedule = new CreateUpdateVesselScheduleDto();
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var vesselSchedule = await _vesselScheduleAppService.CreateAsync(VesselSchedule);
            Dictionary<string, Guid> rs = new Dictionary<string, Guid>
            {
                { "id", vesselSchedule.Id }
            };
            return new JsonResult(rs);
        }
    }
}
