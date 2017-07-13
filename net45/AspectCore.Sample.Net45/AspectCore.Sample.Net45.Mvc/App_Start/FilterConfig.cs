using System.Web;
using System.Web.Mvc;

namespace AspectCore.Sample.Net45.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
