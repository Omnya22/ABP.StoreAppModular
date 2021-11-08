using StoreApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class StoreAppController : AbpController
    {
        protected StoreAppController()
        {
            LocalizationResource = typeof(StoreAppResource);
        }
    }
}