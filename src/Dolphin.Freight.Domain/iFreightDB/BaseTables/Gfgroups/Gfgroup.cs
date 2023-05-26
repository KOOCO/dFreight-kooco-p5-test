using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Gfgroups
{
    public partial class Gfgroup : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { GroupId };
        }

        public string GroupId { get; set; }
        public string GroupCnm { get; set; }
        public string GroupNm { get; set; }
        public string GroupCaddr { get; set; }
        public string GroupAddr { get; set; }
        public string GroupRmk { get; set; }
        public string GroupUseglobal { get; set; }
        public string LimitType { get; set; }
    }
}
