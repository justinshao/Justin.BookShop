using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IRepository;

namespace Justin.BookShop.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // IoC注册数据库连接
            var container = ContainerManager.Current;
            container.RegisterInstance<IDbContext, EfMsSqlRepository.EfMsSqlDbContext>(new EfMsSqlRepository.EfMsSqlDbContext("EntitiesContainer"), ComponentLifeStyle.Singleton);
            //manager.RegisterInstance<IDbContext, Justin.BookShop.Entities.EntitiesContainer>(new Justin.BookShop.Entities.EntitiesContainer("EntitiesContainer"), ComponentLifeStyle.Singleton);
            container.RegisterType<IDbSession, EfMsSqlRepository.DbSession>();



            // 寄宿服务
            string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Justin.BookShop.ServiceHost.exe");
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(exePath);
            var serviceModel = System.ServiceModel.Configuration.ServiceModelSectionGroup.GetSectionGroup(config);
            Assembly ass = Assembly.Load("Justin.BookShop.Services");
            var hosts = new List<System.ServiceModel.ServiceHost>();

            foreach (ServiceElement serviceElement in serviceModel.Services.Services)
            {
                string typeName = serviceElement.Name;
                Type type = ass.GetType(typeName);
                var host = new System.ServiceModel.ServiceHost(type);
                host.Opened += delegate
                {
                    Console.WriteLine("服务 {0} 已经启动...", type.ToString());
                };
                host.Open();
                hosts.Add(host);
            }

            Console.ReadKey();
        }
    }
}
