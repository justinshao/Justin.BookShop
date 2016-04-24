using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class PriceAdjustReceiptDetail
    {
        public Guid ID { get; set; }
        public int AdjustQuantity { get; set; }
        public decimal NewAccountPrice { get; set; }
        public decimal OldAccountPrice { get; set; }
        public Guid BookID { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
    }
}
