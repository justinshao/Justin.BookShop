using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class AddCartResult
    {
        public bool Success { get; set; }
        public string PreUrl { get; set; }
        public string Message { get; set; }
    }
}
