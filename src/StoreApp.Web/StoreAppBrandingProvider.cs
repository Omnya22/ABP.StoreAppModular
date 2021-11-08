using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace StoreApp.Web
{
    [Dependency(ReplaceServices = true)]
    public class StoreAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "StoreApp";
    }
}
