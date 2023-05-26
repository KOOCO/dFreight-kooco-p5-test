using Dolphin.Freight.Settings.SysCodes;
using Dolphin.Freight.Settinngs.SysCodes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dolphin.Freight.Web.Pages.Components
{
    [Widget(ScriptFiles = new[] { "/Pages/Components/SelectComponent/InitSelect.js" })]
    [ViewComponent(Name = "SelectComponent")]
    public class SelectComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(string TagName , string DefaultValue, string FieldName, bool IsShowLabel, bool IsRequired,string Disabled,int SelectType,string ShowFiledContentValue)
        {
            ComponentData componentData = new ComponentData() { TagName = TagName, DefaultValue = DefaultValue , FieldName = FieldName , IsRequired = IsRequired , IsShowLabel = IsShowLabel , Disabled = Disabled, SelectType= SelectType , ShowFiledContentValue = ShowFiledContentValue==null?"": ShowFiledContentValue };

            return View("~/Pages/Components/SelectComponent/Index.cshtml", componentData);
        }
    }
}