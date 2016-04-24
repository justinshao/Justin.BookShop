using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class Role
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public string _state { get; set; }
    }
}
