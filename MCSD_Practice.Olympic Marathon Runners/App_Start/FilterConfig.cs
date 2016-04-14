using System.Web;
using System.Web.Mvc;

namespace MCSD_Practice.Olympic_Marathon_Runners
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
