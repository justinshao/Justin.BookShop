using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers
{
    [CheckAdminLogin]
    public class AdminController : BaseController
    {
        protected const string _sysIconCacheKey = "sysIcons";
        protected const string _sysControllerCacheKey = "controllers";

        static AdminController()
        {
            CacheSysIcons();
            CacheSysControllers();
        }

        private static void CacheSysControllers()
        {
            IEnumerable<Type> controllers = (IEnumerable<Type>)CacheHelper.GetCache(_sysControllerCacheKey);
            if (controllers == null)
            {
                controllers = (from t in Assembly.GetExecutingAssembly().GetTypes()
                               where typeof(AdminController).IsAssignableFrom(t) && t != typeof(AdminController)
                               select t).ToList();

                CacheHelper.SetCache(_sysControllerCacheKey, controllers);
            }
        }

        private static void CacheSysIcons()
        {
            IEnumerable<string> icons = (IEnumerable<string>)CacheHelper.GetCache(_sysIconCacheKey);
            if (icons == null)
            {
                string iconDirPath1 = System.Web.HttpContext.Current.Server.MapPath(@"~/Content/themes/my_icons");
                string iconDirPath2 = System.Web.HttpContext.Current.Server.MapPath(@"~/Content/themes/mini/icons");
                DirectoryInfo dirInfo1 = new DirectoryInfo(iconDirPath1);
                DirectoryInfo dirInfo2 = new DirectoryInfo(iconDirPath2);
                icons = (from f1 in dirInfo1.GetFiles()
                         where f1.Name.StartsWith("icon")
                         select "icon-" + f1.Name.Substring("icon_".Length, f1.Name.Length - "icon_".Length - f1.Extension.Length)).Union(
                        from f2 in dirInfo2.GetFiles()
                        select "icon-" + f2.Name.Substring(0, f2.Name.Length - f2.Extension.Length)).ToList();

                CacheHelper.SetCache(_sysIconCacheKey, icons, new TimeSpan(0, 20, 0));
            }
        }

        public User LoginUser
        {
            get { return Session["user"] as User; }
        }
    }
}
