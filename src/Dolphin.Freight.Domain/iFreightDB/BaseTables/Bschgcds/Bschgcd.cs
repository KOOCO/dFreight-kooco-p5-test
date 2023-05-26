using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bschgcds
{
    public partial class Bschgcd : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { GroupId, Cmp, Stn, Dep, ChgCd };
        }

        public string GroupId { get; set; }
        public string Dep { get; set; }
        public string ChgCd { get; set; }
        public string ChgEnm { get; set; }
        public string ChgCnm { get; set; }
        public string ClAccid { get; set; }
        public string CfAccid { get; set; }
        public string DlAccid { get; set; }
        public string DfAccid { get; set; }
        public string Gui { get; set; }
        public string Rmk { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ChgType { get; set; }
        public string AccountTitle { get; set; }
        public string AccountCost { get; set; }
        public string VatFlag { get; set; }
        public string Traxon { get; set; }
        public string InAccountTitle { get; set; }
        public string InAccountCost { get; set; }
        public string GuiRmk { get; set; }
        public decimal? TaxRate { get; set; }
        public string ChgUnit { get; set; }
        public Guid Rowid { get; set; }
        public Guid UId { get; set; }
        public string ShareBy { get; set; }
        /// <summary>
        /// 鼎新WorkFlow國內支出科目
        /// </summary>
        public string WfclAccid { get; set; }
        /// <summary>
        /// 鼎新WorkFlow國外支出科目
        /// </summary>
        public string WfcfAccid { get; set; }
        /// <summary>
        /// 鼎新WorkFlow國內收入科目
        /// </summary>
        public string WfdlAccid { get; set; }
        /// <summary>
        /// 鼎新WorkFlow國外收入科目
        /// </summary>
        public string WfdfAccid { get; set; }
    }
}
