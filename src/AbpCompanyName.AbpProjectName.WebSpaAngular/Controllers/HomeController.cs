using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace AbpCompanyName.AbpProjectName.WebSpaAngular.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpProjectNameControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}