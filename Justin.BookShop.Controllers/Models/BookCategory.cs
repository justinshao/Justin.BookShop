using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class BookCategory
    {
        public int ID { get; set; }
        public Int32 ParentID { get; set; }
        public string Name { get; set; }
    }
}
