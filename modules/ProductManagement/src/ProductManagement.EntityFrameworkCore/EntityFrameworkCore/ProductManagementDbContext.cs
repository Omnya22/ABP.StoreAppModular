using Microsoft.EntityFrameworkCore;
using ProductManagement.Categories;
using ProductManagement.Products;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ProductManagement.EntityFrameworkCore
{
    [ConnectionStringName(ProductManagementDbProperties.ConnectionStringName)]
    public class ProductManagementDbContext : AbpDbContext<ProductManagementDbContext>, IProductManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProductManagement();
        }
    }
}