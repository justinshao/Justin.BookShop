using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class JsonResultData
    {
        public bool Success { get; set; }
        public String ErrorMessage { get; set; }
        public string RedirectUrl { get; set; }
        public object Data { get; set; }
    }
}
