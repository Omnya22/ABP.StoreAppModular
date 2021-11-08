using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace StoreApp.Data
{
    /* This is used if database provider does't define
     * IStoreAppDbSchemaMigrator implementation.
     */
    public class NullStoreAppDbSchemaMigrator : IStoreAppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}