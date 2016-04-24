using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class Department
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
    }
}
