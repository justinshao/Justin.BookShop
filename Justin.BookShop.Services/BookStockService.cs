using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class BookStockService : BaseService, IBookStockService
    {
        public void CloseAccount(string period)
        {
            // 取新的账期
            string new_period = period.Substring(2, 2) == "12" ?
                (int.Parse(period.Substring(0, 2)) + 1).ToString("00") + "01" :
                (int.Parse(period) + 1).ToString("0000");

            var sysPeriod = DbSession.SysVariables.All.Where(v => v.Name == "NY").Single();
            if (sysPeriod == null)
                throw new Exception("找不到系统账期");

            sysPeriod.Value = new_period;

            var historyStockSession = DbSession.BookStockHistorys;
            var stockHistories =
                from s in DbSession.BookStocks.All
                select new BookStockHistory
                {
                    ID = s.ID,
                    Period = period,
                    PriorPeriodQuantity = s.PriorPeriodQuantity,
                    PriorPeriodMoney = s.PriorPeriodMoney,
                    EntryQuantity = s.EntryQuantity,
                    EntryMoney = s.EntryMoney,
                    OutQuantity = s.OutQuantity,
                    OutMoney = s.OutMoney,
                    StocktakeQuantity = s.StocktakeQuantity,
                    StocktakeMoney = s.StocktakeMoney,
                    DamagedQuantity = s.DamagedQuantity,
                    DamagedMoney = s.DamagedMoney,
                    AdjustMoney = s.AdjustMoney,
                    ThisPeriodQuantity = s.ThisPeriodQuantity,
                    ThisPeriodMoney = s.ThisPeriodMoney,
                    StockHistoryOf = s.StockOf
                };
            foreach (var s in stockHistories)
            {
                historyStockSession.Add(s, false);
            }

            var stockSession = DbSession.BookStocks;
            foreach (var s in DbSession.BookStocks.All)
            {
                if(s.ThisPeriodQuantity == 0)
                {
                }
            }
        }
    }
}
