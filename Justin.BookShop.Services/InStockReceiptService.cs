using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class InStockReceiptService : BaseService, IInStockReceiptService
    {
        public void RemoveTemporaryReceipt(Guid id)
        {
            var receipt = DbSession.InStockReceipts.All.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
            if(receipt == null)
                throw new Exception("不存在该单据");
            DbSession.InStockReceipts.Delete(receipt);
        }

        public void SubmitTemporaryReceipt(InStockReceipt receipt, IEnumerable<InStockReceiptDetail> details = null)
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
            receipt.AuditedBy = null;
            receipt.BeforeVoidReceipt = null;
            receipt.InvalidReceipt = null;
            receipt.IsAudited = false;
            //receipt.Press = DbSession.Presss.GetSingle(p => p.ID == receipt.PressID);

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
                if(useDetails)
                    receipt.Details.Add(d);
            }

            DbSession.InStockReceipts.Add(receipt);
        }

        public void UpdateTemporaryReceipt(InStockReceipt receipt, IEnumerable<InStockReceiptDetail> details = null)
        {
            if (receipt == null)
                throw new NullReferenceException("receipt参数为null");

            var useDetails = (details != null && details.Count() > 0);
            if (!useDetails && (receipt.Details == null || receipt.Details.Count <= 0))
                throw new ArgumentException("参数不合法", "receipt.Details");

            var receiptToUpdate = DbSession.InStockReceipts.All.Where(r => r.ID == receipt.ID && !r.IsAudited).SingleOrDefault();
            if (receiptToUpdate == null)
                throw new Exception("不存在该单据");

            // 单据头
            receiptToUpdate.PressNo = receipt.PressNo;
            receiptToUpdate.Remark = receipt.Remark;
            receiptToUpdate.PressID = receipt.PressID;
            receiptToUpdate.SubmittedBy = receipt.SubmittedBy;
            receiptToUpdate.SubmitDate = DateTime.Now;
            //receiptToUpdate.Press = DbSession.Presss.GetSingle(p => p.ID == receiptToUpdate.PressID);
            // 单据明细
            var td = DbSession.InStockReceiptDetails.Get(d => d.HeaderID == receiptToUpdate.ID);
            foreach (var d in td)
            {
                DbSession.InStockReceiptDetails.Delete(d, false);
            }
            var receiptDetails = useDetails ? details : receipt.Details;
            int sort = 1;
            foreach (var d in receiptDetails)
            {
                d.ID = Guid.NewGuid();
                d.Sort = sort++;

                receiptToUpdate.Details.Add(d);
            }

            DbSession.SaveChanges();
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            var period = DbSession.SysVariables.All.SingleOrDefault(v => v.Name.Equals("NY"));
            if (period == null)
                throw new Exception("取不到当前年月");

            if (!period.Value.Equals(DateTime.Now.ToString("yyMM")))
                throw new Exception("系统年月与当前年月不符，审核失败");

            var receiptToAudit = DbSession.InStockReceipts.All.Where(r => !r.IsAudited && r.ID == receiptId).SingleOrDefault();
            if (receiptToAudit == null)
                throw new Exception("不存在该单据");

            receiptToAudit.NO = GetNO(DateTime.Now.ToString("yyMMdd"));
            receiptToAudit.AuditDate = DateTime.Now;
            receiptToAudit.IsAudited = true;
            receiptToAudit.AuditedBy = DbSession.Users.All.Where(u => u.ID == auditId).Single();
            foreach (var d in receiptToAudit.Details)
            {
                d.AccountPrice = d.Book.AccountPrice;
                var stock = d.Book.Stock;
                int entryQuantity = d.EntryQuantity;
                decimal entryMoney = ((decimal)d.EntryQuantity) * d.Book.AccountPrice.GetValueOrDefault();
                if (stock == null)
                {
                    stock = new BookStock
                    {
                        ID = Guid.NewGuid(),
                        StockOf = d.Book,
                        PriorPeriodQuantity = 0,
                        PriorPeriodMoney = 0,
                        EntryQuantity = entryQuantity,
                        EntryMoney = entryMoney,
                        OutQuantity = 0,
                        OutMoney = 0,
                        StocktakeQuantity = 0,
                        StocktakeMoney = 0,
                        DamagedQuantity = 0,
                        DamagedMoney = 0,
                        AdjustMoney = 0,
                        ThisPeriodQuantity = entryQuantity,
                        ThisPeriodMoney = entryMoney
                    };
                    DbSession.BookStocks.Add(stock, false);
                }
                else
                {
                    stock.EntryQuantity += entryQuantity;
                    stock.EntryMoney += entryMoney;
                    stock.ThisPeriodQuantity += entryQuantity;
                    stock.ThisPeriodMoney += entryMoney;
                }
            }

            DbSession.SaveChanges();
        }

        private string GetLSNO()
        {
            var no = (from r in DbSession.InStockReceipts.All
                      where !r.IsAudited
                      select r.NO).Max();
            if (string.IsNullOrEmpty(no))
                return "000001";

            return (int.Parse(no) + 1).ToString("000000");
        }

        private string GetNO(string date)
        {
            string NO = DbSession.InStockReceipts.All.Where(r => r.IsAudited && 
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

            var theBeforeReceipt = DbSession.InStockReceipts.All.Where(r => r.IsAudited && r.ID == receiptId).SingleOrDefault();
            if (theBeforeReceipt == null)
                throw new Exception("不存在该单据");

            if (theBeforeReceipt.InvalidReceipt != null)
                throw new Exception("该单据已经作废");
            if (theBeforeReceipt.BeforeVoidReceipt != null)
                throw new Exception("该单据由作废单据产生，不能作废");

            var operatorUser = DbSession.Users.GetSingle(u => u.ID == operatorId);
            var invalidReceipt = new InStockReceipt
            {
                ID = Guid.NewGuid(),
                NO = GetNO(DateTime.Now.ToString("yyMMdd")),
                PressNo = theBeforeReceipt.PressNo,
                Remark = "作废入库单(" + theBeforeReceipt.NO + ")产生的红字单据",
                SubmitDate = DateTime.Now,
                AuditDate = DateTime.Now,
                IsAudited = true,
                PressID = theBeforeReceipt.PressID,

                //Press = DbSession.Presss.GetSingle(p => p.ID == theBeforeReceipt.PressID),
                SubmittedBy = operatorUser,
                AuditedBy = operatorUser,
                BeforeVoidReceipt = theBeforeReceipt,
            };
            invalidReceipt.Details =
                (from d in theBeforeReceipt.Details
                 select new InStockReceiptDetail
                 {
                     ID = Guid.NewGuid(),
                     Sort = d.Sort,
                     EntryQuantity = -d.EntryQuantity,
                     EntryUnitPrice = d.EntryUnitPrice,
                     AccountPrice = d.AccountPrice,
                     BookID = d.BookID,
                     ReceiptHeader = invalidReceipt,
                     Book = d.Book

                 }).ToList();
            theBeforeReceipt.InvalidReceipt = invalidReceipt;
            DbSession.InStockReceipts.Add(invalidReceipt, false);

            var istj = false;
            foreach (var d in theBeforeReceipt.Details)
            {
                var entryQuantity = -d.EntryQuantity;
                var entryMoney = -(d.EntryQuantity * (decimal)d.Book.AccountPrice);
                var stock = d.Book.Stock;
                if (stock == null)
                {
                    stock = new BookStock
                    {
                        ID = Guid.NewGuid(),
                        StockOf = d.Book,
                        PriorPeriodQuantity = 0,
                        PriorPeriodMoney = 0,
                        EntryQuantity = entryQuantity,
                        EntryMoney = entryMoney,
                        OutQuantity = 0,
                        OutMoney = 0,
                        StocktakeQuantity = 0,
                        StocktakeMoney = 0,
                        DamagedQuantity = 0,
                        DamagedMoney = 0,
                        AdjustMoney = 0,
                        ThisPeriodQuantity = entryQuantity,
                        ThisPeriodMoney = entryMoney
                    };
                    DbSession.BookStocks.Add(stock, false);
                }
                else
                {
                    stock.EntryQuantity += entryQuantity;
                    stock.EntryMoney += entryMoney;
                    stock.ThisPeriodQuantity += entryQuantity;
                    stock.ThisPeriodMoney += entryMoney;
                }
                if(!istj)
                    istj = (d.AccountPrice != d.Book.AccountPrice);
            }

            if (istj)
            {
                var priceAdjustReceipt = new PriceAdjustReceipt
                {
                    ID = Guid.NewGuid(),
                    NO = GetTJNO(DateTime.Now.ToString("yyMMdd")),
                    Remark = "作废入库单（" + theBeforeReceipt.NO + "）产生的调价单",
                    SubmitDate = DateTime.Now,
                    AuditDate = DateTime.Now,
                    IsAudited = true,
                    SubmittedBy = operatorUser,
                    AuditedBy = operatorUser,
                };

                int sort = 1;
                foreach (var d in theBeforeReceipt.Details)
                {
                    if (d.AccountPrice == d.Book.AccountPrice)
                        continue;

                    priceAdjustReceipt.Details.Add(new PriceAdjustReceiptDetail
                        {
                            ID = Guid.NewGuid(),
                            Sort = sort++,
                            AdjustQuantity = d.EntryQuantity,
                            NewAccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                            OldAccountPrice = d.AccountPrice,
                            BookID = d.BookID,
                            ReceiptHeader = priceAdjustReceipt,
                            Book = d.Book
                        });
                }

                DbSession.PriceAdjustReceipts.Add(priceAdjustReceipt, false);
            }

            DbSession.SaveChanges();
        }

        public InStockReceipt GetTemporaryReceipt(Guid id)
        {
            return DbSession.InStockReceipts.GetSingle(r => r.ID == id && !r.IsAudited);
        }

        public IEnumerable<InStockReceipt> GetTemporaryReceiptList()
        {
            return from r in DbSession.InStockReceipts.All
                   where !r.IsAudited
                   orderby r.NO
                   select r;
        }

        public IEnumerable<InStockReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return from r in DbSession.InStockReceipts.All
                   where r.IsAudited && ((fromNO == null || toNO == null) ? true : (r.NO.CompareTo(fromNO) >= 0 && r.NO.CompareTo(toNO) <= 0))
                   orderby r.NO
                   select r;
        }

        public InStockReceipt GetAuditedReceipt(Guid receiptID)
        {
            return (from r in DbSession.InStockReceipts.All
                    where r.IsAudited && r.ID == receiptID
                    select r).FirstOrDefault();
        }
    }
}
