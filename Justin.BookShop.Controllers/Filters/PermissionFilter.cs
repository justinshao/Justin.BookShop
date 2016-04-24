using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Filters
{
    public class Permission : ActionFilterAttribute
    {
        public PermissionType Type { get; protected set; }

        public Permission(PermissionType type)
        {
            Type = type;
        }
    }
}
