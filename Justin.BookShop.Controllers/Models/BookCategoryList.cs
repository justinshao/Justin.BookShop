using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class BookCategoryList
    {
        public Justin.BookShop.Entities.BookCategory Parent { get; set; }
        public Justin.BookShop.Entities.BookCategory SelectedCategory { get; set; }
        public IEnumerable<Justin.BookShop.Entities.BookCategory> Children { get; set; }
    }
}
