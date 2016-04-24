using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class StocktakeReceipt
    {
        public Guid ID { get; set; }
        public string NO { get; set; }
        public string Remark { get; set; }
        public List<StocktakeReceiptDetail> Details { get; set; }
    }
}
