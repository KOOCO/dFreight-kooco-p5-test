using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Dolphin.Freight.Web.Pages.OceanImports.PrintImport
{
    public class MblPrintModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }
        public void OnGet()
        {
            var a = Id;
            var b = 2;
        }
    }
}
