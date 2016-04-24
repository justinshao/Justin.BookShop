using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class PaginationInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortField { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
