using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class OutStockReceiptDetail
    {
        public Guid ID { get; set; }
        public int OutQuantity { get; set; }
        public decimal OutUnitPrice { get; set; }
        public decimal AccountPrice { get; set; }
        public Guid BookID { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
    }
}
