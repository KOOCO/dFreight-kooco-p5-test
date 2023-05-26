using Dolphin.Freight.ImportExport.Containers;
using System;
using System.Collections.Generic;

namespace Dolphin.Freight.Web.ViewModels.Manifest
{
    public class ManifestIndexViewModel
    {
        public string BaseUrl { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string DateTime { get; set; }

        public string cargo_title { get; set; }
        public string from_trade_partner { get; set; }
        public string to_trade_partner_area { get; set; }
        public string MblNo { get; set; }
        public string filing_no { get; set; }
        public string BookingNo { get; set; }
        public string Carrier { get; set; }
        public string vessel_name { get; set; }
        public string voyage { get; set; }
        public string POL_location { get; set; }
        public string ETD { get; set; }
        public string POD_location { get; set; }
        public string ETA { get; set; }
        public string CNTR_NO_SEAL_SIZE { get; set; }
        public string po_nos_text { get; set; }
        public string CargoReadyDate { get; set; }
        public string remarks { get; set; }

        public List<ManifestContainerList> ContainerList { get; set; }

        public string total_PACKAGE { get; set; }
        public string total_GROSS_WEIGHT_KGS { get; set; }
        public string total_GROSS_WEIGHT_LBS { get; set; }
        public string total_MEASUREMENT_CBM { get; set; }
        public string total_MEASUREMENT_CFT { get; set; }
        public string total_count { get; set; }

        public string mark { get; set; }
        public string description { get; set; }
        public string is_show_pcs_and_amount { get; set; }
        public string show_mark_and_description { get; set; }
    }
    public class ManifestContainerList
    {
        public string chk { get; set; }

        public string CONTAINER_NO { get; set; }
        public string SEAL_NO { get; set; }
        public string CONTAINER_SIZE { get; set; }
        public string SHIPPER { get; set; }
        public string CONSIGNEE { get; set; }
        public string BL_NO { get; set; }

        public string PACKAGE { get; set; }
        public string GROSS_WEIGHT_KGS { get; set; }
        public string GROSS_WEIGHT_LBS { get; set; }
        public string MEASUREMENT_CBM { get; set; }
        public string MEASUREMENT_CFT { get; set; }


        public string shipper { get; set; }
        public string consignee { get; set; }
        public string good_items { get; set; }
        public string good_items_without_pcs_and_amount { get; set; }
        public string good_items_with_pcs_and_amount { get; set; }
        public string show_non_stackable { get; set; }
        public string remark { get; set; }
    }
}
