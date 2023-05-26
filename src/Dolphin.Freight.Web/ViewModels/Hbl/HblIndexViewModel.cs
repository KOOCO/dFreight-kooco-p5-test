using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace Dolphin.Freight.Web.ViewModels.Hbl
{
    public class HblIndexViewModel
    {
        public string Header_Consignee { get; set; }
        public string Header_Notify { get; set; }
        public string Header_Shipper { get; set; }
        public string Header_Consignee_Url { get; set; }
        public string Header_Notify_Url { get; set; }
        public string Header_Shipper_Url { get; set; }
        public string Show_Container_Rider { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }

        public string addition_mark { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Include_BL_Clause { get; set; }
        public string Show_Address_and_Contact { get; set; }
        public string OTI_No { get; set; }
        public string SHIPPER_EXPORTER { get; set; }
        public string DOCUMENT_NO { get; set; }
        public string BL_NO { get; set; }
        public string REF_NO { get; set; }
        public string EXPORT_REFERENCES { get; set; }
        public string CONSIGNEE { get; set; }
        public string FORWARDING_AGENT_REFERENCES { get; set; }
        public string POINT_AND_COUNTRY_OF_ORIGIN { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string domestic_instructions_title { get; set; }
        public string domestic_instructions { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public string EXPORTING_CARRIER { get; set; }
        public string PORT_OF_LOADING { get; set; }
        public string ONWARD_INLAND_ROUTING { get; set; }
        public string PORT_OF_DISCHARGE { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string FOR_TRANSHIPMENT_TO { get; set; }
        public string CARGO_INSURANCE_THRU_CARRIER { get; set; }
        public string COVERED { get; set; }
        public string NOT_COVERED { get; set; }
        public string Display_Unit { get; set; }
        public string MARKS_AND_NUMBERS { get; set; }
        public string NO_OF_PKGS { get; set; }
        public string DESCRIPTION_OF_PACKAGES_AND_GOODS { get; set; }
        public string GROSS_WEIGHT { get; set; }
        public string MEASUREMENT { get; set; }
        public string show_on_board_watermark { get; set; }
        public string on_board_watermark { get; set; }
        public string Show_Container_Information { get; set; }
        public string freight_term { get; set; }
        public string show_no_of_original_bill { get; set; }
        public string no_of_original_bill { get; set; }
        public string Show_Freight { get; set; }
        public List<HblFreightList> FreightList { get; set; }
        public string Total_PREPAID { get; set; }
        public string Total_COLLECT { get; set; }
        public string show_hbl_export_remark { get; set; }
        public string hbl_export_remark { get; set; }
        public string by_who { get; set; }
        public string issue_date { get; set; }
        public string show_declared_value { get; set; }
        public string declared_value { get; set; }
        public List<HblContainerList> ContainerList { get; set; }
        public string TOTAL_PKGS { get; set; }
        public string TOTAL_UNIT { get; set; }

        public string TOTAL_WEIGHT_KGS { get; set; }
        public string TOTAL_WEIGHT_LBS { get; set; }
        public string TOTAL_MEASUREMENT_CBM { get; set; }
        public string TOTAL_MEASUREMENT_CFT { get; set; }

        public string CONTAINER_NO { get; set; }
        public string TYPE { get; set; }
        public string SEAL_NO { get; set; }
        public string PKG { get; set; }
        public string KG { get; set; }
        public string LB { get; set; }
        public string CBM { get; set; }
        public string CFT { get; set; }

        public string BaseUrl { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }

    public class HblContainerList
    {
        public string CONTAINER_NO { get; set; }
        public string TYPE { get; set; }
        public string SEAL_NO { get; set; }
        public string PICKUP_NO { get; set; }
        public string LFD { get; set; }
        public string PKGS { get; set; }
        public string UNIT { get; set; }
        public string WEIGHT_KGS { get; set; }
        public string WEIGHT_LBS { get; set; }
        public string MEASUREMENT_CBM { get; set; }
        public string MEASUREMENT_CFT { get; set; }
    }

    public class HblFreightList
    {
        public string ITEM { get; set; }
        public string PREPAID { get; set; }
        public string COLLECT { get; set; }
    }
}
