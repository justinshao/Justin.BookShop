using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Justin.BookShop.Common.IoCManagement;

namespace Justin.BookShop.WcfRegistration
{
    public class RegistrarTypeFinder : IRegistrarTypeFinder
    {
        public IEnumerable<IRegistrar> FindRegistrar()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IRegistrar).IsAssignableFrom(t)).Select(t => Activator.CreateInstance(t) as IRegistrar);
        }
    }
}
