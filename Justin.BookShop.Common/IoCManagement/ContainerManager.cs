using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Common.IoCManagement
{
    public class ContainerManager
    {
        protected IContainer _container;
        private static IContainer _defaultContainer;
        private static ContainerManager _innerManager;

        static ContainerManager()
        {
            Autofac.ContainerBuilder builder = new Autofac.ContainerBuilder();
            _defaultContainer = new AutofacContainerAdapter(builder.Build());
            _innerManager = new ContainerManager();
        }
        protected ContainerManager() : this(null) { }
        protected ContainerManager(IContainer container)
        {
            _container = container ?? _defaultContainer;
        }
        public static ContainerManager Current { get { return _innerManager; } }
        public static void SetContainer(IContainer container)
        {
            _innerManager._container = container;
        }
        public void RunRegistrars(IEnumerable<IRegistrar> registrars)
        {
            foreach (var registrar in registrars)
            {
                registrar.Register(_innerManager._container);
            }
        }

        public IContainer RegisterType<TService, TImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.LifetimeScope) where TImplementation :class, TService
        {
            return _container.RegisterType<TService, TImplementation>(lifeStyle);
        }
        public IContainer RegisterInstance<TService, TImplementation>(TImplementation instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.LifetimeScope) where TImplementation : class, TService
        {
            return _container.RegisterInstance<TService, TImplementation>(instance, lifeStyle);
        }
        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }
        public bool TryResolve<TService>(out TService instance)
        {
            return _container.TryResolve<TService>(out instance);
        }
        public bool IsRegistered<TService>()
        {
            return _container.IsRegistered<TService>();
        }
    }
}
