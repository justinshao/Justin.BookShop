using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class StockDamagedReceipt
    {
        public Guid ID { get; set; }
        public string NO { get; set; }
        public string Remark { get; set; }
        public List<StockDamagedReceiptDetail> Details { get; set; }
    }
}
