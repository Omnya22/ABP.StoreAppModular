using StoreApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace StoreApp
{
    [DependsOn(
        typeof(StoreAppEntityFrameworkCoreTestModule)
        )]
    public class StoreAppDomainTestModule : AbpModule
    {

    }
}