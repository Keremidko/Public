using System.Web;
using System.Web.Mvc;

namespace Requirements_and_Design_environment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
