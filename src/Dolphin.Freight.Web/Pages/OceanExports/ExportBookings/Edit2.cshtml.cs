using Dolphin.Freight.Accounting.Invoices;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.ImportExport.OceanExports.ExportBookings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.OceanExports.ExportBookings
{
    public class Edit2Model : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public string SoNo { get; set; }
        [BindProperty]
        public IList<InvoiceDto> m0invoiceDtos { get; set; }
        [BindProperty]
        public IList<InvoiceDto> m1invoiceDtos { get; set; }
        [BindProperty]
        public IList<InvoiceDto> m2invoiceDtos { get; set; }
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly IExportBookingAppService _exportBookingAppService;
        public Edit2Model(IInvoiceAppService invoiceAppService,IExportBookingAppService exportBookingAppService)
        {
            _exportBookingAppService = exportBookingAppService;
            _invoiceAppService = invoiceAppService;
        }
        public async Task OnGetAsync()
        {
            var exportBooking = await _exportBookingAppService.GetAsync(Id);
            SoNo = exportBooking.SoNo;
            QueryInvoiceDto qidto = new QueryInvoiceDto() { QueryType = 2, ParentId = Id };
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
