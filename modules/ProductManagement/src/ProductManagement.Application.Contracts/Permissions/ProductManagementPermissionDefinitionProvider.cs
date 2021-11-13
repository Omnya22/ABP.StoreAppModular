using ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManagement.Permissions
{
    public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProductManagementPermissions.GroupName, L("Permission:ProductManagement"));

            var productsPermission = myGroup.AddPermission(ProductManagementPermissions.Product.Default, L("Permission:Products"));
            productsPermission.AddChild(ProductManagementPermissions.Product.Create, L("Permission:Products.Create"));
            productsPermission.AddChild(ProductManagementPermissions.Product.Edit, L("Permission:Products.Edit"));
            productsPermission.AddChild(ProductManagementPermissions.Product.Delete, L("Permission:Products.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductManagementResource>(name);
        }
    }
}