using Abp.Web.Mvc.Views;

namespace AbpZeroSample.Web.Views
{
    public abstract class AbpZeroSampleWebViewPageBase : AbpZeroSampleWebViewPageBase<dynamic>
    {

    }

    public abstract class AbpZeroSampleWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected AbpZeroSampleWebViewPageBase()
        {
            LocalizationSourceName = AbpZeroSampleConsts.LocalizationSourceName;
        }
    }
}