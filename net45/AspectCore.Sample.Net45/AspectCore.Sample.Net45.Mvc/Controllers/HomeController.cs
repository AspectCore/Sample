using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AspectCore.Abstractions;
using AspectCore.Sample.Net45.Mvc.Interceptors;
using AspectCore.Sample.Net45.Mvc.Services;

namespace AspectCore.Sample.Net45.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var type = this.GetType().GetTypeInfo();
            var method = type.GetMethod("About");
            var para = method.GetParameters();
            var att = para[0].CustomAttributes;
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