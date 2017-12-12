using System.Web;
using System.Web.Mvc;

namespace MBDVC.WAPISecurity.GoogleAuthentication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
