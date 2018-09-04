using System.Web;
using System.Web.Mvc;

namespace MVCReview
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());  // redirects user to error page
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute()); // application only avaialble on https
        }
    }
}
