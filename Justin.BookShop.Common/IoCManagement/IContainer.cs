using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Common.IoCManagement
{
    public interface IContainer
    {
        IContainer RegisterType<TService, TImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.LifetimeScope) where TImplementation :class, TService;
        IContainer RegisterInstance<TService, TImplementation>(TImplementation instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.LifetimeScope) where TImplementation : class, TService;
        TService Resolve<TService>();
        bool TryResolve<TService>(out TService instance);
        bool IsRegistered<TService>();
    }
}
