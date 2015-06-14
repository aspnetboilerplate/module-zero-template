using Abp.Application.Services;

namespace AbpZeroSample
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AbpZeroSampleAppServiceBase : ApplicationService
    {
        protected AbpZeroSampleAppServiceBase()
        {
            LocalizationSourceName = AbpZeroSampleConsts.LocalizationSourceName;
        }
    }
}