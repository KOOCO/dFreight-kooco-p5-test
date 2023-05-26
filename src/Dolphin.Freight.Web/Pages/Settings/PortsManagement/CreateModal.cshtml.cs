using Dolphin.Freight.Settings.PortsManagement;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.PortsManagement
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdatePortsManagementDto PortsManagement { get; set; }

        private readonly IPortsManagementAppService _portsManagementAppService;

        public CreateModalModel(IPortsManagementAppService portsManagementAppService)
        {
            _portsManagementAppService = portsManagementAppService;
        }

        public void OnGet()
        {
            PortsManagement = new CreateUpdatePortsManagementDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _portsManagementAppService.CreateAsync(PortsManagement);
            return NoContent();
        }
    }
}
