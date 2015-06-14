using Abp.Web.Mvc.Controllers;

namespace AbpZeroSample.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class AbpZeroSampleControllerBase : AbpController
    {
        protected AbpZeroSampleControllerBase()
        {
            LocalizationSourceName = AbpZeroSampleConsts.LocalizationSourceName;
        }
    }
}