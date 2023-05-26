using Dolphin.Freight.ImportExport.OceanImports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Dolphin.Freight.Accounting.Invoices;
using System.Collections.Generic;
using Dolphin.Freight.Common;
using Dolphin.Freight.Settinngs.SysCodes;
using Dolphin.Freight.ImportExport.AirExports;

namespace Dolphin.Freight.Web.Pages.AirExports
{
    public class EditModal3 : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public Guid Hid { get; set; }
        
        [BindProperty]
        public AirExportMawbDto AirExportMawbDto { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public IList<InvoiceDto> m0invoiceDtos { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public IList<InvoiceDto> m1invoiceDtos { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public IList<InvoiceDto> m2invoiceDtos { get; set; }

        [BindProperty(SupportsGet = true)]
        public int NewHbl { get; set; } = 0;
        
        public string CardClass { get; set; }
        
        public bool IsShowHbl { get; set; } = false;

        private readonly IAirExportMawbAppService _airExportMawbAppService;
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly ISysCodeAppService _sysCodeAppService;

        public EditModal3(IAirExportMawbAppService airExportMawbAppService, IInvoiceAppService invoiceAppService, ISysCodeAppService sysCodeAppService)
        {
            _airExportMawbAppService = airExportMawbAppService;
            _invoiceAppService = invoiceAppService;
            _sysCodeAppService = sysCodeAppService;
        }

        public async Task OnGetAsync()
        {
            AirExportMawbDto = await _airExportMawbAppService.GetAsync(Id);

            QueryInvoiceDto qidto = new QueryInvoiceDto() { QueryType = 3, ParentId = Id };
            var invoiceDtos = await _invoiceAppService.QueryInvoicesAsync(qidto);
            m0invoiceDtos = new List<InvoiceDto>();
            m1invoiceDtos = new List<InvoiceDto>();
            m2invoiceDtos = new List<InvoiceDto>();
            if (invoiceDtos != null && invoiceDtos.Count > 0) 
            {
                foreach (var dto in invoiceDtos) 
                {
                    switch (dto.InvoiceType) 
                    { 
                        default:
                            m0invoiceDtos.Add(dto);
                            break;
                        case 1:
                            m1invoiceDtos.Add(dto);
                            break;
                        case 2:
                            m2invoiceDtos.Add(dto);
                            break;
                    }
                }
            }
        }
    }
}
