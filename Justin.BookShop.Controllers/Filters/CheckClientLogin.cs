using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IService;
using Justin.BookShop.Controllers.Models;

namespace Justin.BookShop.Controllers.Filters
{
    public class CheckClientLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Session["user"] as Justin.BookShop.Entities.User) == null)
            {
                if (filterContext.RouteData.GetRequiredString("controller").Equals("user", StringComparison.CurrentCultureIgnoreCase) &&
                filterContext.RouteData.GetRequiredString("action").Equals("login", StringComparison.CurrentCultureIgnoreCase))
                    return;

                var cusername = filterContext.HttpContext.Request.Cookies["username"];
                var cpassword = filterContext.HttpContext.Request.Cookies["password"];
                string error = null;
                if (cusername != null && cpassword != null)
                {
                    var user = ContainerManager.Current.Resolve<IUserService>().Login(cusername.Value, cpassword.Value, out error);
                    if (user == null)
                        filterContext.Result = new RedirectResult("~/user/login");
                    else
                    {
                        filterContext.HttpContext.Session["user"] = user;
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/user/login");
                }
            }
        }
    }
}
