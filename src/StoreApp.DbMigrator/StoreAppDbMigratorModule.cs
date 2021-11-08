using StoreApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace StoreApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(StoreAppEntityFrameworkCoreModule),
        typeof(StoreAppApplicationContractsModule)
        )]
    public class StoreAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
