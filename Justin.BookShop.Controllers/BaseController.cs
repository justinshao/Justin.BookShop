using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers
{
    public class BaseController : Controller
    {
        public TService ResolveService<TService>() where TService : IService.IService
        {
            return ContainerManager.Current.Resolve<TService>();
        }
    }
}
