using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscodes
{
    public partial class Bscode : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { GroupId, CdType, Cd, Cmp, Stn, Dep, };
        }

        public string GroupId { get; set; }
        public string CdType { get; set; }
        public string Cd { get; set; }
        public string CdDescp { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string AmsCode { get; set; }
        public string Inttra { get; set; }
        public string ArCd { get; set; }
        public string ApCd { get; set; }
        public string Dep { get; set; }
        public string Apply { get; set; }
    }
}
