﻿using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class StockDamagedReceiptService : BaseService, IStockDamagedReceiptService
    {
        public void RemoveTemporaryReceipt(Guid id)
        {
            var receipt = DbSession.StockDamagedReceipts.All.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
            if (receipt == null)
                throw new Exception("不存在该单据");
            DbSession.StockDamagedReceipts.Delete(receipt);
        }

        public void SubmitTemporaryReceipt(Entities.StockDamagedReceipt receipt, IEnumerable<StockDamagedReceiptDetail> details = null)
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

            var receiptDetaols = useDetails ? details : receipt.Details;
            int sort = 1;
            if (useDetails)
                receipt.Details.Clear();
            foreach (var d in receiptDetaols)
            {
                d.ID = Guid.NewGuid();
                d.Sort = sort++;
                d.AccountPrice = null;
                //d.Book = DbSession.Books.GetSingle(b => b.ID == d.BookID);
                d.ReceiptHeader = receipt;
                if (useDetails)
                    receipt.Details.Add(d);
            }

            DbSession.StockDamagedReceipts.Add(receipt);
        }

        public void UpdateTemporaryReceipt(Entities.StockDamagedReceipt receipt, IEnumerable<StockDamagedReceiptDetail> details = null)
        {
            if (receipt == null)
                throw new NullReferenceException("receipt参数为null");

            var useDetails = (details != null && details.Count() > 0);
            if (!useDetails && (receipt.Details == null || receipt.Details.Count <= 0))
                throw new ArgumentException("参数不合法", "receipt.Details");

            var receiptToUpdate = DbSession.StockDamagedReceipts.All.Where(r => r.ID == receipt.ID && !r.IsAudited).SingleOrDefault();
            if (receiptToUpdate == null)
                throw new Exception("不存在该单据");

            // 单据头数据
            receiptToUpdate.Remark = receipt.Remark;
            receiptToUpdate.SubmitDate = DateTime.Now;
            receiptToUpdate.SubmittedBy = receipt.SubmittedBy;
            // 单据明细
            var td = DbSession.StockDamagedReceiptDetails.Get(d => d.HeaderID == receiptToUpdate.ID);
            foreach (var d in td)
            {
                DbSession.StockDamagedReceiptDetails.Delete(d, false);
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

            var receiptToAudit = DbSession.StockDamagedReceipts.All.Where(r => !r.IsAudited && r.ID == receiptId).SingleOrDefault();
            if (receiptToAudit == null)
                throw new Exception("不存在该单据");

            receiptToAudit.NO = GetNO(DateTime.Now.ToString("yyMMdd"));
            receiptToAudit.AuditDate = DateTime.Now;
            receiptToAudit.IsAudited = true;
            receiptToAudit.AuditedBy = DbSession.Users.All.Where(u => u.ID == auditId).Single();
            foreach (var d in receiptToAudit.Details)
            {
                d.AccountPrice = d.Book.AccountPrice.GetValueOrDefault();
                var stock = d.Book.Stock;
                var damagedQuantity = d.DamagedQuantity;
                var damagedMoney = ((decimal)d.DamagedQuantity) * d.Book.AccountPrice.GetValueOrDefault();
                stock.DamagedQuantity += damagedQuantity;
                stock.DamagedMoney += damagedMoney;
                stock.ThisPeriodQuantity -= damagedQuantity;
                stock.ThisPeriodMoney -= damagedMoney;
            }

            DbSession.SaveChanges();
        }

        private string GetLSNO()
        {
            var no = (from r in DbSession.StockDamagedReceipts.All
                      where !r.IsAudited
                      select r.NO).Max();
            if (string.IsNullOrEmpty(no))
                return "000001";

            return (int.Parse(no) + 1).ToString("000000");
        }

        private string GetNO(string date)
        {
            string NO = DbSession.StockDamagedReceipts.All.Where(r => r.IsAudited &&
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

        public StockDamagedReceipt GetTemporaryReceipt(Guid id)
        {
            return DbSession.StockDamagedReceipts.GetSingle(r => r.ID == id && !r.IsAudited);
        }

        public IEnumerable<StockDamagedReceipt> GetTemporaryReceiptList()
        {
            return from r in DbSession.StockDamagedReceipts.All
                   where !r.IsAudited
                   orderby r.NO
                   select r;
        }

        public IEnumerable<StockDamagedReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return from r in DbSession.StockDamagedReceipts.All
                   where r.IsAudited && ((fromNO == null || toNO == null) ? true : (r.NO.CompareTo(fromNO) >= 0 && r.NO.CompareTo(toNO) <= 0))
                   orderby r.NO
                   select r;
        }

        public StockDamagedReceipt GetAuditedReceipt(Guid receiptID)
        {
            return (from r in DbSession.StockDamagedReceipts.All
                    where r.IsAudited && r.ID == receiptID
                    select r).FirstOrDefault();
        }
    }
}
