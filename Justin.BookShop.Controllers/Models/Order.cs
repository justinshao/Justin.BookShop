using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public string NO { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime SubmitDate { get; set; }
        public decimal Freight { get; set; }
    }
}
