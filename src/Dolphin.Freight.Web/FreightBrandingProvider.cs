using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Dolphin.Freight.Web;

[Dependency(ReplaceServices = true)]
public class FreightBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Dolphin.Freight";
}
