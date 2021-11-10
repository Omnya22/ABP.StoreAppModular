using ProductManagement.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace ProductManagement.Web.Menus
{
    public class ProductManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {

            var l = context.GetLocalizer<ProductManagementResource>();
            
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "ProductManagement",
                    displayName:l["Menu:ProductManagement"],
                    icon: "fa fa-globe")
                .AddItem(
                new ApplicationMenuItem(
                    "ProductManagement.Products",
                    displayName:l["Menu:Products"],
                    url: "/ProductManagement/Products")));

            return Task.CompletedTask;
        }
    }
}