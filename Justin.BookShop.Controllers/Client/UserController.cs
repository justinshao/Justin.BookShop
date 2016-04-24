using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Entities;

namespace Justin.BookShop.Controllers.Client
{
    public class UserController : ClientController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Justin.BookShop.Controllers.Models.UserLoginInfo loginInfo)
        {
            Justin.BookShop.Entities.User user = null;
            string error = string.Empty;
            string md5_pwd = Util.GetMD5(loginInfo.Password);
            //string md5_pwd = "26588e932c7ccfa1df309280702fe1b5";
            user = ResolveService<IUserService>().Login(loginInfo.UserName, md5_pwd, out error);
            if (user == null)
            {
                loginInfo.LoginError = error;
                return View(loginInfo);
            }
            else
            {
                if (loginInfo.Remember)
                {
                    Response.Cookies.Add(new System.Web.HttpCookie("username", loginInfo.UserName));
                    Response.Cookies.Add(new System.Web.HttpCookie("password", md5_pwd));
                }
                Session["user"] = user;
                return Redirect("~/Book/CategoryList");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Password = Util.GetMD5(user.Password);
            string error = ResolveService<IUserService>().ClientRegister(user);
            if (string.IsNullOrEmpty(error))
            {
                Session["user"] = user;
                return Redirect("~/Book/CategoryList");
            }
            else
            {
                ViewBag.Error = error;
                return View(user);
            }            
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return Redirect("~/Book/CategoryList");
        }

        [CheckClientLogin]
        public ActionResult Info(Guid userId)
        {
            return View();
        }
    }
}
