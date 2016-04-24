using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class OutStockReceiptService : BaseService, IOutStockReceiptService
    {
        public void RemoveTemporaryReceipt(Guid id)
        {
            var receipt = DbSession.OutStockReceipts.All.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
            if (receipt == null)
                throw new Exception("不存在该单据");
            DbSession.OutStockReceipts.Delete(receipt);
        }

        public void SubmitTemporaryReceipt(OutStockReceipt receipt, IEnumerable<OutStockReceiptDetail> details = null)
        {
            if (receipt == null)
                throw new NullReferenceException("receipt参数为null");

            var useDetails = (details != null && details.Count() > 0);
            if (!useDetails && (receipt.Details == null || receipt.Details.Count <= 0))
                throw new ArgumentException("参数不合法", "receipt.Details");

            receipt.ID = Guid.NewGuid();
            receipt.NO = GetLSNO();
            receipt.SubmitDate = DateTime.Now;
            receipt.AuditDate = null;
            receipt.IsAudited = false;
            receipt.AuditedBy = null;
            receipt.BeforeVoidReceipt = null;
            receipt.InvalidReceipt = null;

            var receiptDetaols = useDetails ? details : receipt.Details;
            int sort = 1;
            if (useDetails)
                receipt.Details.Clear();
            foreach (var d in receiptDetaols)
            {
                d.ID = Guid.NewGuid();
                d.Sort = sort++;
                d.AccountPrice = null;
                d.ReceiptHeader = receipt;
                if (useDetails)
                    receipt.Details.Add(d);
            }

            DbSession.OutStockReceipts.Add(receipt);
        }

        public void UpdateTemporaryReceipt(OutStockReceipt receipt, IEnumerable<OutStockReceiptDetail> details = null)
        {
            if (receipt == null)
                throw new NullReferenceException("receipt参数为null");

            var useDetails = (details != null && details.Count() > 0);
            if (!useDetails && (receipt.Details == null || receipt.Details.Count <= 0))
                throw new ArgumentException("参数不合法", "receipt.Details");

            var receiptToUpdate = DbSession.OutStockReceipts.All.Where(r => r.ID == receipt.ID && !r.IsAudited).SingleOrDefault();
            if (receiptToUpdate == null)
                throw new Exception("不存在该单据");

            // 单据头数据
            receiptToUpdate.Freight = receipt.Freight;
            receiptToUpdate.Remark = receipt.Remark;
            receiptToUpdate.OrderID = receipt.OrderID;
            //receiptToUpdate.Order = DbSession.Orders.GetSingle(o => o.ID == receipt.OrderID);
            receiptToUpdate.SubmittedBy = receipt.SubmittedBy;
            receiptToUpdate.SubmitDate = DateTime.Now;
            // 单据明细
            //receiptToUpdate.Details.Clear();
            var td = DbSession.OutStockReceiptDetails.Get(d => d.HeaderID == receiptToUpdate.ID);
            foreach (var d in td)
            {
                DbSession.OutStockReceiptDetails.Delete(d, false);
            }
            var receiptDetails = useDetails ? details : receipt.Details;
            int sort = 1;
            foreach (var d in receiptDetails)
            {
                d.ID = Guid.NewGuid();
                d.Sort = sort++;
                //d.Book = DbSession.Books.GetSingle(b => b.ID == d.BookID);
                receiptToUpdate.Details.Add(d);
            }

            DbSession.SaveChanges();
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            var period = DbSession.SysVariables.All.SingleOrDefault(v => v.Name.Equals("NY"));
            if (period == null)
                throw new Exception("取不到当前账期信息");

            if (!period.Value.Equals(DateTime.Now.ToString("yyMM")))
                throw new Exception("系统年月与当前年月不符，审核失败");

            var receiptToAudit = DbSession.OutStockReceipts.All.Where(r => !r.IsAudited && r.ID == receiptId).SingleOrDefault();
            if (receiptToAudit == null)
                throw new Exception("不存在该单据");

            receiptToAudit.NO = GetNO(DateTime.Now.ToString("yyMMdd"));
            receiptToAudit.AuditDate = DateTime.Now;
            receiptToAudit.IsAudited = true;
            receiptToAudit.AuditedBy = DbSession.Users.All.Where(u => u.ID == auditId).SingleOrDefault();
            foreach (var d in receiptToAudit.Details)
            {
                d.AccountPrice = d.Book.AccountPrice;
                var stock = d.Book.Stock;
                var outQuantity = d.OutQuantity;
                var outMoney = ((decimal)d.OutQuantity) * d.Book.AccountPrice.GetValueOrDefault();

                stock.OutQuantity += outQuantity;
                stock.OutMoney += outMoney;
                stock.ThisPeriodQuantity -= outQuantity;
                stock.ThisPeriodMoney -= outMoney;
            }

            DbSession.SaveChanges();
        }

        private string GetLSNO()
        {
            var no = (from r in DbSession.OutStockReceipts.All
                      where !r.IsAudited
                      select r.NO).Max();
            if (string.IsNullOrEmpty(no))
                return "000001";

            return (int.Parse(no) + 1).ToString("000000");
        }

        private string GetNO(string date)
        {
            string NO = DbSession.OutStockReceipts.All.Where(r => r.IsAudited &&
                r.NO.CompareTo(date + "000001") >= 0 &&
                r.NO.CompareTo(date + "999999") <= 0).Max(r => r.NO);
            if (string.IsNullOrEmpty(NO))
            {
                NO = date + "000001";
            }
            else
            {
                NO = date + (Convert.ToInt32(NO.Substring(NO.Length - 6)) + 1).ToString("000000");
            }
            return NO;
        }

        private string GetTJNO(string date)
        {
            string NO = DbSession.PriceAdjustReceipts.All.Where(r => r.IsAudited &&
                r.NO.CompareTo(date + "000001") >= 0 &&
                r.NO.CompareTo(date + "999999") <= 0).Max(r => r.NO);
            if (string.IsNullOrEmpty(NO))
            {
                NO = date + "000001";
            }
            else
            {
                NO = date + (Convert.ToInt32(NO.Substring(NO.Length - 6)) + 1).ToString("000000");
            }
            return NO;
        }

        public void InvalidReceipt(Guid receiptId, Guid operatorId)
        {
            var period = DbSession.SysVariables.All.SingleOrDefault(v => v.Name.Equals("NY"));
            if (period == null)
                throw new Exception("取不到当前年月");

            if (!period.Value.Equals(DateTime.Now.ToString("yyMM")))
                throw new Exception("系统年月与当前年月不符，审核失败");

            var theBeforeReceipt = DbSession.OutStockReceipts.All.Where(r => r.IsAudited && r.ID == receiptId).SingleOrDefault();
            if (theBeforeReceipt == null)
                throw new Exception("不存在该单据");

            if (theBeforeReceipt.InvalidReceipt != null)
                throw new Exception("该单据已经作废");
            if (theBeforeReceipt.BeforeVoidReceipt != null)
                throw new Exception("该单据由作废单据产生，不能作废");

            var operatorUser = DbSession.Users.GetSingle(u => u.ID == operatorId);
            var invalidReceipt = new OutStockReceipt
            {
                ID = Guid.NewGuid(),
                NO = GetNO(DateTime.Now.ToString("yyMMdd")),
                Freight = -theBeforeReceipt.Freight,
                Remark = "作废出库单（" + theBeforeReceipt.NO + "）产生的红字单据",
                SubmitDate = DateTime.Now,
                AuditDate = DateTime.Now,
                IsAudited = true,
                OrderID = theBeforeReceipt.OrderID,

                SubmittedBy = operatorUser,
                AuditedBy = operatorUser,
                Order = theBeforeReceipt.Order,
                BeforeVoidReceipt = theBeforeReceipt
            };
            invalidReceipt.Details =
                (from d in theBeforeReceipt.Details
                select new OutStockReceiptDetail
                {
                    ID = Guid.NewGuid(),
                    Sort = d.Sort,
                    OutQuantity = -d.OutQuantity,
                    OutUnitPrice = d.OutUnitPrice,
                    AccountPrice = d.AccountPrice,
                    BookID = d.BookID,
                    ReceiptHeader = invalidReceipt,
                    Book = d.Book
                }).ToList();
            theBeforeReceipt.InvalidReceipt = invalidReceipt;
            DbSession.OutStockReceipts.Add(invalidReceipt, false);

            bool istj = false;
            foreach (var d in theBeforeReceipt.Details)
            {
                var stock = d.Book.Stock;
                var outQuantity = -d.OutQuantity;
                var outMoney = -(d.OutQuantity * (decimal)d.Book.AccountPrice);
                if (stock == null)
                {
                    stock = new BookStock
                    {
                        ID = Guid.NewGuid(),
                        StockOf = d.Book,
                        PriorPeriodQuantity = 0,
                        PriorPeriodMoney = 0,
                        EntryQuantity = 0,
                        EntryMoney = 0,
                        OutQuantity = outQuantity,
                        OutMoney = outMoney,
                        StocktakeQuantity = 0,
                        StocktakeMoney = 0,
                        DamagedQuantity = 0,
                        DamagedMoney = 0,
                        AdjustMoney = 0,
                        ThisPeriodQuantity = -outQuantity,
                        ThisPeriodMoney = -outMoney
                    };
                    DbSession.BookStocks.Add(stock, false);
                }
                else
                { 
                    stock.OutQuantity += outQuantity;
                    stock.OutMoney += outMoney;
                    stock.ThisPeriodQuantity -= outQuantity;
                    stock.ThisPeriodMoney -= outMoney;
                }
                if (!istj)
                    istj = (d.Book.AccountPrice != d.AccountPrice);
            }

            if (istj)
            {
                var priceAdjustReceipt = new PriceAdjustReceipt
                {
                    ID = Guid.NewGuid(),
                    NO = GetTJNO(DateTime.Now.ToString("yyMMdd")),
                    Remark = "作废出库单（" + theBeforeReceipt.NO + "）产生的调价单",
                    SubmitDate = DateTime.Now,
                    AuditDate = DateTime.Now,
                    IsAudited = true,

                    SubmittedBy = operatorUser,
                    AuditedBy = operatorUser
                };

                int sort = 1;
                foreach (var d in theBeforeReceipt.Details)
                {
                    priceAdjustReceipt.Details.Add(new PriceAdjustReceiptDetail { 
                        ID = Guid.NewGuid(),
                        Sort = sort++,
                        AdjustQuantity = d.OutQuantity,
                        NewAccountPrice = d.AccountPrice.GetValueOrDefault(),
                        OldAccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                        BookID = d.BookID,
                        ReceiptHeader = priceAdjustReceipt,
                        Book = d.Book
                    });
                }
                DbSession.PriceAdjustReceipts.Add(priceAdjustReceipt, false);
            }

            DbSession.SaveChanges();
        }

        public OutStockReceipt GetTemporaryReceipt(Guid id)
        {
            return DbSession.OutStockReceipts.GetSingle(r => r.ID == id && !r.IsAudited);
        }

        public IEnumerable<OutStockReceipt> GetTemporaryReceiptList()
        {
            return from r in DbSession.OutStockReceipts.All
                   where !r.IsAudited
                   orderby r.NO
                   select r;
        }

        public IEnumerable<OutStockReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return from r in DbSession.OutStockReceipts.All
                   where r.IsAudited && ((fromNO == null || toNO == null) ? true : (r.NO.CompareTo(fromNO) >= 0 && r.NO.CompareTo(toNO) <= 0))
                   orderby r.NO
                   select r;
        }

        public OutStockReceipt GetAuditedReceipt(Guid receiptID)
        {
            return (from r in DbSession.OutStockReceipts.All
                    where r.IsAudited && r.ID == receiptID
                    select r).FirstOrDefault();
        }
    }
}
