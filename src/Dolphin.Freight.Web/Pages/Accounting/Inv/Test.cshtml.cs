using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dolphin.Freight.Web.Pages.Accounting.Inv
{
    public class TestModel : PageModel
    {
        public void OnGet()
        {
            ViewData["PId"] = "9449F3D7-DC8D-4443-B26D-285EBE69F18A";
        }
    }
}
