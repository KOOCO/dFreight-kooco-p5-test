using System;

namespace Dolphin.Freight.Web.ViewModels.UsdaHeatTreatment
{
    public class UsdaHeatTreatmentIndexViewModel
    {
        public string BaseUrl { get; set; }


        public string NameAndAddressOfExporte { get; set; }
        public string NameAndAddressOfConsignee { get; set; }
        public string SignatureOfExporter { get; set; }
        public string DescriptionOfConsignment1 { get; set; }
        public string DescriptionOfConsignment2 { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }
}
