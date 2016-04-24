using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class PriceAdjustReceiptService : BaseService, IPriceAdjustReceiptService
    {
        public void RemoveTemporaryReceipt(Guid id)
        {
            var receipt = DbSession.PriceAdjustReceipts.All.Where(r => r.ID == id && !r.IsAudited).SingleOrDefault();
            if (receipt == null)
                throw new Exception("不存在该单据");
            DbSession.PriceAdjustReceipts.Delete(receipt);
        }

        public void SubmitTemporaryReceipt(Entities.PriceAdjustReceipt receipt, IEnumerable<PriceAdjustReceiptDetail> details = null)
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
                d.OldAccountPrice = null;
                d.ReceiptHeader = receipt;
                if (useDetails)
                    receipt.Details.Add(d);
            }

            DbSession.PriceAdjustReceipts.Add(receipt);
        }

        public void UpdateTemporaryReceipt(Entities.PriceAdjustReceipt receipt, IEnumerable<PriceAdjustReceiptDetail> details = null)
        {
            if (receipt == null)
                throw new NullReferenceException("receipt参数为null");

            var useDetails = (details != null && details.Count() > 0);
            if (!useDetails && (receipt.Details == null || receipt.Details.Count <= 0))
                throw new ArgumentException("参数不合法", "receipt.Details");

            var receiptToUpdate = DbSession.PriceAdjustReceipts.All.Where(r => r.ID == receipt.ID && !r.IsAudited).SingleOrDefault();
            if (receiptToUpdate == null)
                throw new Exception("不存在该单据");

            // 单据头数据
            receiptToUpdate.Remark = receipt.Remark;
            receiptToUpdate.SubmitDate = DateTime.Now;
            receiptToUpdate.SubmittedBy = receipt.SubmittedBy;
            // 单据明细
            //receiptToUpdate.Details.Clear();
            var td = DbSession.PriceAdjustReceiptDetails.Get(d => d.HeaderID == receiptToUpdate.ID);
            foreach (var d in td)
            {
                d.ReceiptHeader = null;
                DbSession.PriceAdjustReceiptDetails.Delete(d, false);
            }

            var receiptDetails = useDetails ? details : receipt.Details;
            int sort = 1;
            foreach (var d in receiptDetails)
            {
                d.ID = Guid.NewGuid();
                d.Sort = sort++;
                d.OldAccountPrice = null;
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

            var receiptToAudit = DbSession.PriceAdjustReceipts.All.Where(r => !r.IsAudited && r.ID == receiptId).SingleOrDefault();
            if (receiptToAudit == null)
                throw new Exception("不存在该单据");

            receiptToAudit.NO = GetNO(DateTime.Now.ToString("yyMMdd"));
            receiptToAudit.AuditDate = DateTime.Now;
            receiptToAudit.AuditedBy = DbSession.Users.All.Where(u => u.ID == auditId).Single();
            receiptToAudit.IsAudited = true;
            foreach (var d in receiptToAudit.Details)
            {
                var stock = d.Book.Stock;
                d.OldAccountPrice = d.Book.AccountPrice;
                d.AdjustQuantity = 0;
                d.Book.AccountPrice = d.NewAccountPrice;
                if (stock != null)
                {
                    d.AdjustQuantity = stock.ThisPeriodQuantity;
                    var difPrice = d.NewAccountPrice - d.OldAccountPrice.GetValueOrDefault();
                    stock.AdjustMoney += difPrice * (decimal)d.AdjustQuantity;
                    stock.ThisPeriodMoney += difPrice * (decimal)d.AdjustQuantity;
                }
            }

            DbSession.SaveChanges();
        }

        private string GetLSNO()
        {
            var no = (from r in DbSession.PriceAdjustReceipts.All
                      where !r.IsAudited
                      select r.NO).Max();
            if (string.IsNullOrEmpty(no))
                return "000001";

            return (int.Parse(no) + 1).ToString("000000");
        }

        private string GetNO(string date)
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

        public PriceAdjustReceipt GetTemporaryReceipt(Guid id)
        {
            return DbSession.PriceAdjustReceipts.GetSingle(r => r.ID == id && !r.IsAudited);
        }

        public IEnumerable<PriceAdjustReceipt> GetTemporaryReceiptList()
        {
            return from r in DbSession.PriceAdjustReceipts.All
                   where !r.IsAudited
                   orderby r.NO
                   select r;
        }

        public IEnumerable<PriceAdjustReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return from r in DbSession.PriceAdjustReceipts.All
                   where r.IsAudited && ((fromNO == null || toNO == null) ? true : (r.NO.CompareTo(fromNO) >= 0 && r.NO.CompareTo(toNO) <= 0))
                   orderby r.NO
                   select r;
        }

        public PriceAdjustReceipt GetAuditedReceipt(Guid receiptID)
        {
            return (from r in DbSession.PriceAdjustReceipts.All
                    where r.IsAudited && r.ID == receiptID
                    select r).FirstOrDefault();
        }
    }
}
