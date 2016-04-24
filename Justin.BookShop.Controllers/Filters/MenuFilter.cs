using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Filters
{
    public class Menu : Permission
    {
        public Menu()
            : base(PermissionType.Menu) { }
    }
}
