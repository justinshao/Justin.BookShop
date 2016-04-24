using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.IService
{
    public abstract class BaseService
    {
        private IDbSession _session;

        public IDbSession DbSession
        {
            get 
            {
                if(_session == null)
                    _session = ContainerManager.Current.Resolve<IDbSession>();
                return _session;
            }
        }
    }
}
