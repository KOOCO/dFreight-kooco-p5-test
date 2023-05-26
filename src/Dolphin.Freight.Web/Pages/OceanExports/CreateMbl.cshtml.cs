
using Dolphin.Freight.Common;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Settinngs.SysCodes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dolphin.Freight.Web.Pages.OceanExports
{
    public class CreateMblModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }
        [BindProperty]
        public CreateUpdateOceanExportMblDto? OceanExportMbl { get; set; }
        [BindProperty]
        public CreateUpdateOceanExportHblDto? OceanExportHbl { get; set; }
        [BindProperty]
        public int AddHbl { get; set; } = 0;
        private readonly IOceanExportHblAppService _oceanExportHblAppService;
        private readonly IOceanExportMblAppService _oceanExportMblAppService;
        private readonly ISysCodeAppService _sysCodeAppService;
        public CreateMblModel( IOceanExportMblAppService oceanExportMblAppService,IOceanExportHblAppService oceanExportHblAppService, ISysCodeAppService sysCodeAppService)
        {
            _oceanExportMblAppService = oceanExportMblAppService;
            _oceanExportHblAppService = oceanExportHblAppService;
            _sysCodeAppService = sysCodeAppService;
        }
        public void OnGet()
        {
            OceanExportHbl = new CreateUpdateOceanExportHblDto();
            OceanExportMbl = new CreateUpdateOceanExportMblDto();
        }
        public async Task<JsonResult> OnPostAsync()
        {
            if (OceanExportMbl.PolEtd == null) OceanExportMbl.PostDate = DateTime.Now;
            else OceanExportMbl.PostDate = OceanExportMbl.PolEtd;
            OceanExportMbl.FilingNo = await _sysCodeAppService.GetSystemNoAsync(new (){ QueryType= "OceanExportMbl_FilingNo" });
            var mbl = await _oceanExportMblAppService.CreateAsync(OceanExportMbl);
            OceanExportHbl.MblId = mbl.Id;
            Id = mbl.Id;
            if (AddHbl == 1)
            {
                if (OceanExportHbl.IsCreateBySystem)
                {
                    OceanExportHbl.HblNo = await _sysCodeAppService.GetSystemNoAsync(new() { QueryType = "OceanExportHbl_HblNo" });
                }
                QueryDto query  = new QueryDto();
                query.QueryType = "CardColorId";
                var syscodes = await _sysCodeAppService.GetSysCodeDtosByTypeAsync(query);
                if (syscodes != null && syscodes.Count >0) 
                {
                    var syscode = syscodes[0];
                    OceanExportHbl.CardColorId = syscode.Id;
                }
                await _oceanExportHblAppService.CreateAsync(OceanExportHbl);

            }

            Dictionary<string, Guid> rs = new()
            {
                { "id", Id.Value }
            };
            return new JsonResult(rs);
        }
    }
}
