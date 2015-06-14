using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace AbpZeroSample.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpZeroSampleControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}