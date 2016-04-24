using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers
{
    public class ClientController : BaseController
    {
        public User LoginUser
        {
            get { return Session["user"] as User; }
        }
    }
}
