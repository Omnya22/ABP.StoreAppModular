using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Localization;
using Volo.Abp.Application.Services;

namespace StoreApp
{
    /* Inherit your application services from this class.
     */
    public abstract class StoreAppAppService : ApplicationService
    {
        protected StoreAppAppService()
        {
            LocalizationResource = typeof(StoreAppResource);
        }
    }
}
