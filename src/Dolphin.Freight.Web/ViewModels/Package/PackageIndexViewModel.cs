using System;
using System.Collections.Generic;

namespace Dolphin.Freight.Web.ViewModels.Package
{
    public class PackageIndexViewModel
    {
        public string Office { get; set; }
        public string To { get; set; }
        public string MblNo { get; set; }
        public string HblNo { get; set; }
        public string Pieces { get; set; }
        public string Destination { get; set; }
        public string TotalPieces { get; set; }      
        public string HblList { get; set; }
        public List<HblPDFListModel> HblPDFList { get; set; }
        //ReportLog
        public Guid ReportId { get; set; }
    }
    public class HblPDFListModel
    {
        public string Office { get; set; }
        public string To { get; set; }
        public string MblNo { get; set; }
        public string HblNo { get; set; }
        public string Pieces { get; set; }
        public string Destination { get; set; }
        public string TotalPieces { get; set; }
    }
}
