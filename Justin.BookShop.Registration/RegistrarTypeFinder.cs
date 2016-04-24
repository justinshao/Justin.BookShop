using Justin.BookShop.Common.IoCManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Registration
{
    public class RegistrarTypeFinder : IRegistrarTypeFinder
    {
        public IEnumerable<IRegistrar> FindRegistrar()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IRegistrar).IsAssignableFrom(t)).Select(t => Activator.CreateInstance(t) as IRegistrar);
        }
    }
}
