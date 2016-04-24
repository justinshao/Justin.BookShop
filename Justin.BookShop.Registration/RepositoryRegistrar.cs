using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Registration
{
    public class RepositoryRegistrar : IRegistrar
    {
        public void Register(IContainer container)
        {
            container.RegisterInstance<IDbContext, EfMsSqlRepository.EfMsSqlDbContext>(new EfMsSqlRepository.EfMsSqlDbContext("EntitiesContainer"), ComponentLifeStyle.Singleton);

            //manager.RegisterInstance<IDbContext, Justin.BookShop.Entities.EntitiesContainer>(new Justin.BookShop.Entities.EntitiesContainer("EntitiesContainer"), ComponentLifeStyle.Singleton);
            container.RegisterType<IDbSession, EfMsSqlRepository.DbSession>();
        }
    }
}
