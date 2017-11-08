using System.Reflection;
using System.Web.Mvc;
using AspectCore.Sample.Net45.Mvc.Interceptors;
using AspectCore.Sample.Net45.Mvc.Services;

namespace AspectCore.Sample.Net45.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult About([FromService]ICustomService customeService)
        {
            ViewBag.Message = customeService.GetAboutMessage();

            return View();
        }

        public virtual ActionResult Contact([FromService]ICustomService customeService)
        {
            ViewBag.Message = customeService.GetContactMessage();

            return View();
        }    
    }
}