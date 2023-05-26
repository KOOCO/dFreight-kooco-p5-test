using AutoMapper.Internal.Mappers;
using Dolphin.Freight.Common;
using Dolphin.Freight.ImportExport.OceanImports;
using Dolphin.Freight.Settings.PackageUnits;
using Dolphin.Freight.Settinngs.PackageUnits;
using Dolphin.Freight.Settinngs.SysCodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dolphin.Freight.Permissions.SettingsPermissions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dolphin.Freight.Web.Pages.OceanImports
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool ShowMsg { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public Guid? Hid { get; set; }
        public bool IsShowHbl { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public int NewHbl { get; set; } = 0;
        [BindProperty]
        public int AddHbl { get; set; } = 0;
        [BindProperty]
        public string CardClass { get; set; }
        [BindProperty]
        public CreateUpdateOceanImportMblDto OceanImportMbl { get; set; }
        [BindProperty]
        public CreateUpdateOceanImportHblDto OceanImportHbl { get; set; }
        public IList<OceanImportHblDto> OceanImportHbls { get; set; }
        private readonly IOceanImportHblAppService _oceanImportHblAppService;
        private readonly IOceanImportMblAppService _oceanImportMblAppService;
        private readonly ISysCodeAppService _sysCodeAppService;
        public EditModalModel(IOceanImportMblAppService oceanImportMblAppService, IOceanImportHblAppService oceanImportHblAppService, ISysCodeAppService sysCodeAppService)
        {
            _oceanImportMblAppService = oceanImportMblAppService;
            _oceanImportHblAppService = oceanImportHblAppService;
            _sysCodeAppService = sysCodeAppService;
        }
        public async Task OnGetAsync()
        {
            OceanImportMbl = await _oceanImportMblAppService.GetCreateUpdateOceanImportMblDtoById(Id);
            QueryHblDto query = new QueryHblDto() { MblId = Id };
            OceanImportHbls = await _oceanImportHblAppService.QueryListByMidAsync(query);
            QueryHblDto queryHbl = new QueryHblDto();
            if (Hid == null || Hid == new Guid())
            {
                if (NewHbl == 1)
                {
                    OceanImportHbl = new CreateUpdateOceanImportHblDto();
                    QueryDto cquery = new QueryDto();
                    cquery.QueryType = "CardColorId";
                    var syscodes = await _sysCodeAppService.GetSysCodeDtosByTypeAsync(cquery);
                    if (OceanImportHbls != null && OceanImportHbls.Count > 0)
                    {
                        int index =  OceanImportHbls.Count % syscodes.Count ;
                        OceanImportHbl.CardColorId = syscodes[index].Id;
                        OceanImportHbl.CardColorValue = syscodes[index].CodeValue;
                        CardClass = syscodes[index].CodeValue;
                    }
                    else 
                    {
                        OceanImportHbl.CardColorId = syscodes[0].Id;
                        OceanImportHbl.CardColorValue = syscodes[0].CodeValue;
                        CardClass = syscodes[0].CodeValue;
                    }
                    
                }
                else 
                {
                    OceanImportHbl = new CreateUpdateOceanImportHblDto();
                    if (OceanImportHbls != null && OceanImportHbls.Count > 0)
                    {
                        OceanImportHbl = ObjectMapper.Map<OceanImportHblDto, CreateUpdateOceanImportHblDto>(OceanImportHbls[0]);
                        IsShowHbl = true;
                    }
                }
 
            }
            else {
                queryHbl.Id = Hid;
                OceanImportHbl = await _oceanImportHblAppService.GetHblById(queryHbl);
                IsShowHbl = true;


            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Hid != null && Hid != Guid.Empty) await _oceanImportHblAppService.UpdateAsync(Hid.Value, OceanImportHbl);
            else 
            {
                if (NewHbl == 1) {
                    OceanImportHbl.MblId = Id;
                    if (OceanImportHbl.HblNo == null || OceanImportHbl.HblNo.Equals(""))
                    {
                        OceanImportHbl.HblNo = await _sysCodeAppService.GetSystemNoAsync(new() { QueryType = "OceanImportHbl_HblNo" });
                    }
                    /*
                    QueryDto query = new QueryDto();
                    query.QueryType = "CardColorId";
                    var syscodes = await _sysCodeAppService.GetSysCodeDtosByTypeAsync(query);
                    if (syscodes != null && syscodes.Count > 0)
                    {
                        var syscode = syscodes[0];
                        OceanImportHbl.CardColorId = syscode.Id;
                    }*/
                    var hbl = await _oceanImportHblAppService.CreateAsync(OceanImportHbl);
                    Hid = hbl.Id;
                } 
            } 
            var boceanImportMbl = await _oceanImportMblAppService.GetAsync(Id);
            if (boceanImportMbl != null) 
            {
                OceanImportMbl.PostDate = boceanImportMbl.PostDate;
                OceanImportMbl.FilingNo = boceanImportMbl.FilingNo;
                await _oceanImportMblAppService.UpdateAsync(Id, OceanImportMbl);
            }

            return new ObjectResult(new { status = "success",Hid = Hid,Id=Id });
        }
    }
}
