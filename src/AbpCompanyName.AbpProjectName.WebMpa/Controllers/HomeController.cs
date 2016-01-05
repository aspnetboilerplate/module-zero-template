using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace AbpCompanyName.AbpProjectName.WebMpa.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpProjectNameControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}