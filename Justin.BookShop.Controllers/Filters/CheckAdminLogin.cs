using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Filters
{
    public class CheckAdminLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Session["user"] as User) == null)
            {
                if (filterContext.RouteData.GetRequiredString("controller").Equals("user", StringComparison.CurrentCultureIgnoreCase) &&
                filterContext.RouteData.GetRequiredString("action").Equals("login", StringComparison.CurrentCultureIgnoreCase))
                    return;

                filterContext.RequestContext.HttpContext.Response.Redirect("~/admin/user/login");
            }
        }
    }
}
