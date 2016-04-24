using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class Permission
    {
        public int ID { get; set; }
        public int ParentID{ get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string AlternateLink { get; set; }
        public int TypeID{ get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
    }
}
