using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Common.IoCManagement
{
    public interface IRegistrarTypeFinder
    {
        IEnumerable<IRegistrar> FindRegistrar();
    }
}
