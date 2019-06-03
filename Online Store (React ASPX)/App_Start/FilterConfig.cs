using System.Web;
using System.Web.Mvc;

namespace Online_Store__React_ASPX_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
