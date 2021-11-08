using System.Threading.Tasks;

namespace StoreApp.Data
{
    public interface IStoreAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
