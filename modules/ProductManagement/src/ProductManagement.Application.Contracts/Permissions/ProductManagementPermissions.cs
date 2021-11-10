using Volo.Abp.Reflection;

namespace ProductManagement.Permissions
{
    public class ProductManagementPermissions
    {
        public const string GroupName = "ProductManagement";

        public static class Product
        {
            public const string Default = GroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductManagementPermissions));
        }
    }
}