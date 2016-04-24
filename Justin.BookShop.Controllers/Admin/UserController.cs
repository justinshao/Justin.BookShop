using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Admin
{
    public class UserController : Justin.BookShop.Controllers.AdminController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            string error = string.Empty;
            Justin.BookShop.Entities.User user = null;
            string md5_pwd = Util.GetMD5(password);
            user = ResolveService<IUserService>().AdminLogin(name, md5_pwd, out error);

            var result = new JsonResultData
            { 
                Success = (user != null),
                ErrorMessage = error,
                RedirectUrl = (user == null) ? "/admin/user/login" : "/admin" 
            };

            if (result.Success)
                Session["user"] = user;

            return Json(result);
        }
    }
}
