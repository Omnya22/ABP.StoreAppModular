using StoreApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace StoreApp.Permissions
{
    public class StoreAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(StoreAppPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(StoreAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<StoreAppResource>(name);
        }
    }
}
