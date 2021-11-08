using Volo.Abp.Modularity;

namespace StoreApp
{
    [DependsOn(
        typeof(StoreAppApplicationModule),
        typeof(StoreAppDomainTestModule)
        )]
    public class StoreAppApplicationTestModule : AbpModule
    {

    }
}