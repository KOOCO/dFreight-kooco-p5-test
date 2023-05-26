using System;

namespace Dolphin.Freight.Web.ViewModels.Telexrelease
{
    public class TelexreleaseIndexViewModel
    {
        public string Office { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email_U { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        //Cosco
        public string Date_M { get; set; }
        public string DateTime { get; set; }
        public string To { get; set; }
        //Default
        public string Attn { get; set; }
        //Default
        public string From { get; set; }
        public string Vessel { get; set; }
        //Cosco
        public string Voyage { get; set; }
        //Cosco
        public string Pol { get; set; }
        public string Pod { get; set; }
        public string Mbl { get; set; }
        //Default
        public string Cnee { get; set; }
        //Cosco
        public string Consignee { get; set; }
        public string TextArea { get; set; }
        //Default
        public string Find_Check { get; set; }
        //Cosco
        public string to_vessel_voyage { get; set; }
        //Cosco
        public string vessel_voyage { get; set; }
        //Cosco
        public string LD_ports { get; set; }

        //Cosco
        public string cargo { get; set; }

        //Cosco
        public string bills_of_lading { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }
}
