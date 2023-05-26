using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscitys
{
    public partial class Bscity : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { GroupId, Cmp, Stn, DepType, CntyCd, CityCd };
        }

        public string GetCityCdCntyCd()
        {
            return $"{CityCd}, {CntyCd}";
        }

        public string GroupId { get; set; }
        public string CityCd { get; set; }
        public string CityNm { get; set; }
        public string CntyCd { get; set; }
        public string Area { get; set; }
        public string Dep { get; set; }
        public string State { get; set; }
        public string SpecArea { get; set; }
        public string Timezone { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string AmsCode { get; set; }
        public string Inttra { get; set; }
        public string StateCd { get; set; }
        public string DepType { get; set; }
        public string Route { get; set; }
        /// <summary>
        /// 城市中文名稱
        /// </summary>
        public string CityCnm { get; set; }
    }
}
