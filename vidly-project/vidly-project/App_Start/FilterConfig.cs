using System.Web;
using System.Web.Mvc;

namespace vidly_project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // [Authorise] has been added globally to the application - require login of user
            filters.Add(new AuthorizeAttribute());
        }
    }
}
