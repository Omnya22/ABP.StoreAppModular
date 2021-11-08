using Volo.Abp.Settings;

namespace StoreApp.Settings
{
    public class StoreAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(StoreAppSettings.MySetting1));
        }
    }
}
