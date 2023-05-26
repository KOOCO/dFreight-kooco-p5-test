using System;

namespace Dolphin.Freight.Web.ViewModels.HblPackageLabel
{
    public class HblPackageLabelIndexViewModel
    {
        public string Office { get; set; }
        public string To { get; set; }
        public string MblNo { get; set; }
        public string HblNo { get; set; }
        public string Pieces { get; set; }
        public string Destination { get; set; }
        public string TotalPieces { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }
}
