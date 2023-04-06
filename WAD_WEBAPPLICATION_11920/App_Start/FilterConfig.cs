using System.Web;
using System.Web.Mvc;

namespace WAD_WEBAPPLICATION_11920
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
