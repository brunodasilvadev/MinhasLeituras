using BS.MinhasLeituras.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace BS.MinhasLeituras.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
