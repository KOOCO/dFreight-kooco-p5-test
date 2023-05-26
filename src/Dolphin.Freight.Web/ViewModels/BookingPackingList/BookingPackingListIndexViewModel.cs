using System;
using System.Collections.Generic;

namespace Dolphin.Freight.Web.ViewModels.BookingPackingList
{
    public class BookingPackingListIndexViewModel
    {
        public string BaseUrl { get; set; }
        public string shipper_name { get; set; }
        public string shipper_address { get; set; }
        public string consignee_name { get; set; }
        public string consignee_address { get; set; }
        public string inv_no { get; set; }
        public string issue_date { get; set; }
        public string POL_location { get; set; }
        public string POD_location { get; set; }

        public string net_weight_unit { get; set; }
        public string gross_weight_unit { get; set; }


        public string total_package { get; set; }
        public string total_pcs { get; set; }
        public string total_net_weight { get; set; }
        public string total_gross_weight { get; set; }
        public string total_amount { get; set; }
        public List<BookingPackingListContainerList> ContainerList { get; set; }


    }
    public class BookingPackingListContainerList
    {
        public string chk { get; set; }
        public string booking_no { get; set; }
        public string package { get; set; }
        public string pkg { get; set; }
        public string description { get; set; }
        public string hts { get; set; }
        public string pcs { get; set; }
        public string net_weight { get; set; }
        public string net_weight_kg { get; set; }
        public string net_weight_lb { get; set; }
        public string gross_weight { get; set; }
        public string gross_weight_kg { get; set; }
        public string gross_weight_lb { get; set; }
        public string price { get; set; }
        public string amount { get; set; }
        public string details { get; set; }
    }
}
