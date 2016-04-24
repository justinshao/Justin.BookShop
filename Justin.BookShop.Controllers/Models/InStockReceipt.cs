using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class InStockReceipt
    {
        public Guid ID { get; set; }
        public string NO { get; set; }
        public string PressNO { get; set; }
        public string Remark { get; set; }
        public string PressName { get; set; }
        public int PressID { get; set; }
        public List<InStockReceiptDetail> Details { get; set; }
    }
}
