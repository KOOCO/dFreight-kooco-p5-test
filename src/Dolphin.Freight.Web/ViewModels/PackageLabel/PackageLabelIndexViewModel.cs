using System;

namespace Dolphin.Freight.Web.ViewModels.PackageLabel
{
    public class PackageLabelIndexViewModel
    {
        public string Office { get; set; }
        public string To { get; set; }
        public string MblNo { get; set; }
        public string CarrierBookingNo { get; set; }
        public string Pieces { get; set; }
        public string Destination { get; set; }
        public string TotalPieces { get; set; }

        public string DataSource { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }
}
