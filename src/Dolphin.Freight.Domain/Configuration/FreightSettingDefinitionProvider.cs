using Volo.Abp.Settings;

namespace Dolphin.Freight.Settings;

public class FreightSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FreightSettings.MySetting1));
    }
}
