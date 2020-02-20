using System.Web;
using Abp.Auditing;

namespace AbpCompanyName.AbpProjectName.WebMpa
{
    //TODO:Remove temporary solution of https://github.com/aspnetboilerplate/aspnetboilerplate/pull/5308.
    public class AbpZeroTemplateClientInfoProvider : WebClientInfoProvider, IClientInfoProvider
    {
        public override HttpContextBase GetCurrentHttpContext()
        {
            return HttpContext.Current == null ? null : new HttpContextWrapper(HttpContext.Current);
        }
    }
}
