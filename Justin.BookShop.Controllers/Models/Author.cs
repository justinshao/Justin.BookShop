using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Introduction { get; set; }

        public string _state { get; set; }
    }
}
