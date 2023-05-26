
using Dolphin.Freight.Common;
using Dolphin.Freight.ImportExport.OceanImports;
using Dolphin.Freight.Settinngs.SysCodes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dolphin.Freight.Web.Pages.OceanImports
{
    public class CreateMblModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }
        [BindProperty]
        public CreateUpdateOceanImportMblDto? OceanImportMbl { get; set; }
        [BindProperty]
        public CreateUpdateOceanImportHblDto? OceanImportHbl { get; set; }
        [BindProperty]
        public int AddHbl { get; set; } = 0;
        private readonly IOceanImportHblAppService _oceanImportHblAppService;
        private readonly IOceanImportMblAppService _oceanImportMblAppService;
        private readonly ISysCodeAppService _sysCodeAppService;
        public CreateMblModel( IOceanImportMblAppService oceanImportMblAppService,IOceanImportHblAppService oceanImportHblAppService, ISysCodeAppService sysCodeAppService)
        {
            _oceanImportMblAppService = oceanImportMblAppService;
            _oceanImportHblAppService = oceanImportHblAppService;
            _sysCodeAppService = sysCodeAppService;
        }
        public void OnGet()
        {
            OceanImportHbl = new CreateUpdateOceanImportHblDto();
            OceanImportMbl = new CreateUpdateOceanImportMblDto();
        }
        public async Task<JsonResult> OnPostAsync()
        {
            if (OceanImportMbl.PolEtd == null) OceanImportMbl.PostDate = DateTime.Now;
            else OceanImportMbl.PostDate = OceanImportMbl.PolEtd;
            OceanImportMbl.FilingNo = await _sysCodeAppService.GetSystemNoAsync(new (){ QueryType= "OceanImportMbl_FilingNo" });
            var mbl = await _oceanImportMblAppService.CreateAsync(OceanImportMbl);
            OceanImportHbl.MblId = mbl.Id;
            Id = mbl.Id;
            if (AddHbl == 1)
            {
                if (OceanImportHbl.IsCreateBySystem)
                {
                    OceanImportHbl.HblNo = await _sysCodeAppService.GetSystemNoAsync(new() { QueryType = "OceanImportHbl_HblNo" });
                }
                QueryDto query  = new QueryDto();
                query.QueryType = "CardColorId";
                var syscodes = await _sysCodeAppService.GetSysCodeDtosByTypeAsync(query);
                if (syscodes != null && syscodes.Count >0) 
                {
                    var syscode = syscodes[0];
                    OceanImportHbl.CardColorId = syscode.Id;
                }
                await _oceanImportHblAppService.CreateAsync(OceanImportHbl);

            }

            Dictionary<string, Guid> rs = new()
            {
                { "id", Id.Value }
            };
            return new JsonResult(rs);
        }
    }
}
