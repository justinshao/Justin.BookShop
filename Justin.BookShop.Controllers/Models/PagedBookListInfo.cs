using Justin.BookShop.Controllers.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class PagedBookListInfo
    {
        public PaginationInfo Pagination { get;set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string PageParamName { get; set; }
        public object PageParamValue { get; set; }
        public int Total { get; set; }
        public IEnumerable<Justin.BookShop.Entities.Book> Books { get; set; }
    }
}
