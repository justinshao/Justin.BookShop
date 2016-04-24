using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class Press
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public string _state { get; set; }
    }
}
