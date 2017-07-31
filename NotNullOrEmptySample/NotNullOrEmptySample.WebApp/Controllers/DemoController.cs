using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotNullOrEmptySample.Services;

namespace NotNullOrEmptySample.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : Controller
    {

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get([FromServices]IAppService appService)
        {
            var results = CheckNotNullOrEmpty(appService);
            return results;
        }

        static List<string> CheckNotNullOrEmpty(IAppService appService)
        {
            List<string> results = new List<string>();

            results.Add(appService.CheckString(null));
            results.Add(appService.CheckString(string.Empty));
            results.Add(appService.CheckString("str"));

            results.Add(appService.CheckObject(null));
            results.Add(appService.CheckObject(new object()));

            int? nullableInteger = null;
            results.Add(appService.CheckNullalble(nullableInteger));
            nullableInteger = 1;
            results.Add(appService.CheckNullalble(nullableInteger));
            return results;
        }
    }
}
