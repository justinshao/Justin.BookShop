using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.IService
{
    [ServiceContract]
    public interface IPriceAdjustReceiptService : IService
    {
        [OperationContract]
        PriceAdjustReceipt GetTemporaryReceipt(Guid id);
        [OperationContract]
        IEnumerable<PriceAdjustReceipt> GetTemporaryReceiptList();
        [OperationContract]
        void RemoveTemporaryReceipt(Guid id);
        [OperationContract]
        void SubmitTemporaryReceipt(PriceAdjustReceipt receipt, IEnumerable<PriceAdjustReceiptDetail> details = null);
        [OperationContract]
        void UpdateTemporaryReceipt(PriceAdjustReceipt receipt, IEnumerable<PriceAdjustReceiptDetail> details = null);
        [OperationContract]
        void AuditReceipt(Guid receiptId, Guid auditId);
        [OperationContract]
        IEnumerable<PriceAdjustReceipt> GetAuditedReceiptList(string fromNO, string toNO);
        [OperationContract]
        PriceAdjustReceipt GetAuditedReceipt(Guid receiptID);
    }
}
