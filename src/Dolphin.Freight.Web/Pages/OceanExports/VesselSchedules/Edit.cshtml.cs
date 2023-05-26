using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.ImportExport.OceanExports.VesselScheduleas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.Web.Pages.OceanExports.VesselSchedules
{
    public class EditModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool ShowMsg { get; set; } = false;
        [BindProperty]
        public CreateUpdateVesselScheduleDto VesselSchedule { get; set; }
        private readonly IVesselScheduleAppService _vesselScheduleAppService;
        public EditModel(VesselScheduleAppService vesselScheduleAppService)
        {
            _vesselScheduleAppService = vesselScheduleAppService;
        }
        public async Task OnGetAsync()
        {
            var vesselSchedule = await _vesselScheduleAppService.GetAsync(Id);
            VesselSchedule  = ObjectMapper.Map<VesselScheduleDto, CreateUpdateVesselScheduleDto>(vesselSchedule);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _vesselScheduleAppService.UpdateAsync(Id, VesselSchedule);
            return NoContent();
        }
    }
}
