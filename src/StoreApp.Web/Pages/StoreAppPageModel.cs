using StoreApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace StoreApp.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class StoreAppPageModel : AbpPageModel
    {
        protected StoreAppPageModel()
        {
            LocalizationResourceType = typeof(StoreAppResource);
        }
    }
}