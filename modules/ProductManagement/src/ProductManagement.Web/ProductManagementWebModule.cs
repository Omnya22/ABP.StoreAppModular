using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Localization;
using ProductManagement.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using ProductManagement.Permissions;
using Volo.Abp.AspNetCore.Mvc;

namespace ProductManagement.Web
{
    [DependsOn(
        typeof(ProductManagementHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ProductManagementWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(ProductManagementResource), typeof(ProductManagementWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductManagementWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new ProductManagementMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProductManagementWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<ProductManagementWebModule>();
            
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ProductManagementWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/ProductManagement/Products/Delete", ProductManagementPermissions.Product.Delete);
                options.Conventions.AuthorizePage("/ProductManagement/Products/Create", ProductManagementPermissions.Product.Create);
                options.Conventions.AuthorizePage("/ProductManagement/Products/Edit", ProductManagementPermissions.Product.Edit);
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(ProductManagementApplicationModule).Assembly);
            });

        }
    }
}
