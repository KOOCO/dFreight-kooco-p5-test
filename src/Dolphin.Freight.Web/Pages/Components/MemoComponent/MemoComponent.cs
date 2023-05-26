
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dolphin.Freight.Web.Pages.Components
{
    [Widget(ScriptFiles = new[] { "/Pages/Components/MemoComponent/InitSelect.js" })]
    [ViewComponent(Name = "MemoComponent")]
    public class MemoComponent : AbpViewComponent
    {

        public IViewComponentResult Invoke(string TagName, string DefaultValue,int SelectType)
        {
            ComponentData componentData = new ComponentData() { TagName = TagName, DefaultValue = DefaultValue, SelectType = SelectType };

            return View("~/Pages/Components/MemoComponent/Index.cshtml", componentData);
        }
    }
}