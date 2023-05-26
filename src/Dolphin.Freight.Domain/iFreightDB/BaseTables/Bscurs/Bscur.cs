using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscurs
{
    public partial class Bscur : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { GroupId, Cmp, Stn, Cur };
        }

        public string GroupId { get; set; }
        public string Cur { get; set; }
        public string CurDescp { get; set; }
        public decimal? RoundType { get; set; }
        public decimal? DecimalPoint { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
