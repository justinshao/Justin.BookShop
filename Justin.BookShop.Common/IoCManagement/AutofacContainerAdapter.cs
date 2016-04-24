using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac.Integration.Mvc;

namespace Justin.BookShop.Common.IoCManagement
{
    public class AutofacContainerAdapter : Justin.BookShop.Common.IoCManagement.IContainer
    {
        Autofac.IContainer _container;
        public AutofacContainerAdapter(Autofac.IContainer container)
        {
            _container = container;
        }

        #region Justin.BookShop.Common.IoCManagement.IContainer
        public IContainer RegisterType<TService, TImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.LifetimeScope) where TImplementation : class, TService
        {
            Type serviceType = typeof(TService);
            Type implementType = typeof(TImplementation);

            return UpdateContainer(c =>
            {
                var serviceTypes = new List<Type> { serviceType };

                if (serviceType.IsGenericType)
                {
                    var temp = c.RegisterGeneric(implementType).As(
                        serviceTypes.ToArray()).PerLifeStyle(lifeStyle);
                }
                else
                {
                    var temp = c.RegisterType(implementType).As(
                        serviceTypes.ToArray()).PerLifeStyle(lifeStyle);
                }
            });
        }
        public IContainer RegisterInstance<TService, TImplementation>(TImplementation instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.LifetimeScope) where TImplementation : class, TService
        {
            return UpdateContainer(x =>
            {
                var registration = x.RegisterInstance(instance).As(typeof(TService)).PerLifeStyle(lifeStyle);
            });
        }
        public TService Resolve<TService>()
        {
            return Scope().Resolve<TService>();
        }
        public bool TryResolve<TService>(out TService instance)
        {
            return Scope().TryResolve<TService>(out instance);
        }
        public bool IsRegistered<TService>()
        {
            return Scope().IsRegistered<TService>();
        } 
        #endregion

        private IContainer UpdateContainer(Action<ContainerBuilder> action)
        {
            var builder = new ContainerBuilder();
            action.Invoke(builder);
            builder.Update(_container);
            return this;
        }
        private ILifetimeScope Scope()
        {
            try
            {
                return AutofacRequestLifetimeHttpModule.GetLifetimeScope(_container, null);
            }
            catch
            {
                return _container;
            }
        }
    }

    static class AutofacContainerExtensions
    {
        public static Autofac.Builder.IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> PerLifeStyle<TLimit, TActivatorData, TRegistrationStyle>(this Autofac.Builder.IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder, ComponentLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ComponentLifeStyle.LifetimeScope:
                    return HttpContext.Current != null ? builder.InstancePerHttpRequest() : builder.InstancePerLifetimeScope();
                case ComponentLifeStyle.Transient:
                    return builder.InstancePerDependency();
                case ComponentLifeStyle.Singleton:
                    return builder.SingleInstance();
                default:
                    return builder.SingleInstance();
            }
        }
    }
}
