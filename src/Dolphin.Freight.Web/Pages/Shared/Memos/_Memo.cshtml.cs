using Dolphin.Freight.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages.Shared.Memos
{
    public class _MemoModel : AbpPageModel
    {

        public Guid RandomId { get; }
        public Guid SourceId { get; }
        public FreightPageType FType { get; }
        public string AddButtonId { get; set; }
        public string MemoTableId { get; set; }
        public string MemoContentId { get; set; }
        public string MemoTableClass { get; set; } = "";

        public _MemoModel(Guid sourceId, FreightPageType fType)
        {
            RandomId = Guid.NewGuid();
            AddButtonId = RandomId + "-" + "add-button";
            MemoTableId = RandomId + "-" + "memo-table";
            MemoContentId = RandomId + "-" + "memo-content";
            SourceId = sourceId;
            FType = fType;
        }

        public void OnGet()
        {

        }
    }
}
