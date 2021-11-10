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

            var booksPermission = myGroup.AddPermission(ProductManagementPermissions.Product.Default, L("Permission:Books"));
            booksPermission.AddChild(ProductManagementPermissions.Product.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(ProductManagementPermissions.Product.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(ProductManagementPermissions.Product.Delete, L("Permission:Books.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductManagementResource>(name);
        }
    }
}