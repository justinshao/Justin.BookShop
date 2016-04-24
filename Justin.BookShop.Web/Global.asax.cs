using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Justin.BookShop.Controllers.Client;
using Justin.BookShop.Common.IoCManagement;

namespace Justin.BookShop.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // IoC config
            var manager = Justin.BookShop.Common.IoCManagement.ContainerManager.Current;
            //TODO: 用程序集反射的方式注册
            var registrationAssemblyName = ConfigurationManager.AppSettings["RegistrationAssembly"];
            var registrationAssembly = System.Reflection.Assembly.Load(registrationAssemblyName);
            Type finderType = registrationAssembly.GetTypes().Where(t => typeof(IRegistrarTypeFinder).IsAssignableFrom(t)).FirstOrDefault();
            IRegistrarTypeFinder finder = Activator.CreateInstance(finderType) as IRegistrarTypeFinder;
            manager.RunRegistrars(finder.FindRegistrar());

            // FileServer config
            WebConfig.FileServer = ConfigurationManager.AppSettings["FileServer"];
            WebConfig.BookImageFileServer = WebConfig.FileServer + ConfigurationManager.AppSettings["BookImageFileServer"];
            WebConfig.BookImageUploadServer = WebConfig.FileServer + ConfigurationManager.AppSettings["BookImageUploadServer"];
            WebConfig.ScriptFileServer = WebConfig.FileServer + ConfigurationManager.AppSettings["ScriptFileServer"];
            WebConfig.BookPageSize = int.Parse(ConfigurationManager.AppSettings["BookPageSize"]);
        }
    }
}