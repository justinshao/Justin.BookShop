using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public enum ReceiptType
    {
        InStock = 1,
        OutStock = 2,
        Stocktake = 3,
        StockDamaged = 4,
        PriceAdjust = 5
    }
}
