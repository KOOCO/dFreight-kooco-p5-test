using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace Dolphin.Freight.Web.ViewModels.ForwarderCargoReceipt
{
    public class ForwarderCargoReceiptIndexViewModel
    {
        public string Show_Container_Rider { get; set; }
        public string SUPPLIER_VENDOR { get; set; }
        public string FCR_No { get; set; }
        public string PORT_AND_COUNTRY_ORIGIN { get; set; }
        public string DATE_OF_RECEIPT_OF_GOODS { get; set; }
        public string CONSIGNEE { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string VESSEL_VOYAGE { get; set; }
        public string SAILING_DATE { get; set; }
        public string NUMBER_OF_ORIGINAL_FCR { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public string PORT_OF_LOADING { get; set; }
        public string PORT_OF_DISCHARGE { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }

        public string MARKS_AND_NUMBERS { get; set; }
        public string NUMBER_AND_KIND_OF_PACKAGES { get; set; }
        public string DESCRIPTION_AND_GOODS { get; set; }
        public string GROSS_WEIGHT { get; set; }
        public string MEASUREMENT { get; set; }

        public string addition_mark { get; set; }
        public string signature { get; set; }
        public string current_date { get; set; }
        public string REF_NO { get; set; }
        public string BL_NO { get; set; }


        public List<ForwarderCargoReceiptContainerList> ContainerList { get; set; }

        public string TOTAL_PKGS { get; set; }
        public string TOTAL_UNIT { get; set; }
        public string TOTAL_WEIGHT { get; set; }
        public string TOTAL_MEASUREMENT { get; set; }

        public string BaseUrl { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }

    public class ForwarderCargoReceiptContainerList
    {
        public string CONTAINER_NO { get; set; }
        public string TYPE { get; set; }
        public string SEAL_NO { get; set; }
        public string PICKUP_NO { get; set; }
        public string LFD { get; set; }
        public string PKGS { get; set; }
        public string UNIT { get; set; }
        public string WEIGHT { get; set; }
        public string MEASUREMENT { get; set; }

    }
}
