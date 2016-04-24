using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Controllers.Comman;

namespace Justin.BookShop.Controllers.Admin
{
    public class HomeController : UserController
    {
        public ActionResult Index()
        {
            return View();
        }

        public string MenuData()
        {
            var menus = (from p in ResolveService<IUserService>().GetAuthorizedMenue(LoginUser.ID)
                         select new
                         {
                             ID = p.ID,
                             ParentID = p.Parent == null ? -1 : p.Parent.ID,
                             Text = p.Name,
                             Icon = p.Icon ?? "",
                             Url = string.IsNullOrEmpty(p.Controller) ? p.AlternateLink : string.Format("/Admin/{0}/{1}", p.Controller, p.Action ?? "")
                         }).ToList();
            return Util.SerializeToJson(menus);

            //string data = System.IO.File.ReadAllText(HttpContext.Server.MapPath("~/Content/menu.txt"));
            //return data;
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return View();
        }
    }
}