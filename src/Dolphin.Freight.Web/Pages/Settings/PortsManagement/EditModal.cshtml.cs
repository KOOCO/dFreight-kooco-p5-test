using Dolphin.Freight.Settings.ItNoRanges;
using Dolphin.Freight.Settings.PortsManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.PortsManagement
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdatePortsManagementDto PortsManagement { get; set; }

        private readonly IPortsManagementAppService _portsManagementAppService;

        public EditModalModel(IPortsManagementAppService portsManagementAppService)
        {
            _portsManagementAppService = portsManagementAppService;
        }

        public async Task OnGetAsync()
        {
            var portsManagementDTO = await _portsManagementAppService.GetAsync(Id);
            PortsManagement = ObjectMapper.Map<PortsManagementDTO, CreateUpdatePortsManagementDto>(portsManagementDTO);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _portsManagementAppService.UpdateAsync(Id, PortsManagement);
            return NoContent();
        }
    }
}
