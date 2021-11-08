using System;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Categories;
using ProductManagement.Products;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ProductManagement.EntityFrameworkCore
{
    public static class ProductManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureProductManagement(
            this ModelBuilder builder,
            Action<ProductManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ProductManagementModelBuilderConfigurationOptions(
                ProductManagementDbProperties.DbTablePrefix,
                ProductManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. */

            builder.Entity<Product>(b =>
            {
                //Configure table & schema name
                b.ToTable("Products", options.Schema);
                    
                b.ConfigureByConvention();

                //Properties
                b.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(ProductConsts.MaxTitleLength);
                
                b.Property(p => p.Price)
                    .IsRequired();

                //Relations
                b.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId);

            });

            builder.Entity<Category>(c =>
            {
                //Configure table & schema name
                c.ToTable("Categories", options.Schema);

                c.ConfigureByConvention();

                //Properties
                c.Property(p => p.Name)
                    .IsRequired();
            });
        }
    }
}