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
    public interface IOutStockReceiptService : IService
    {
        [OperationContract]
        OutStockReceipt GetTemporaryReceipt(Guid id);
        [OperationContract]
        IEnumerable<OutStockReceipt> GetTemporaryReceiptList();
        [OperationContract]
        void RemoveTemporaryReceipt(Guid id);
        [OperationContract]
        void SubmitTemporaryReceipt(OutStockReceipt receipt, IEnumerable<OutStockReceiptDetail> details = null);
        [OperationContract]
        void UpdateTemporaryReceipt(OutStockReceipt receipt, IEnumerable<OutStockReceiptDetail> details = null);
        [OperationContract]
        void AuditReceipt(Guid receiptId, Guid auditId);
        [OperationContract]
        void InvalidReceipt(Guid receiptId, Guid operatorId);
        [OperationContract]
        IEnumerable<OutStockReceipt> GetAuditedReceiptList(string fromNO, string toNO);
        [OperationContract]
        OutStockReceipt GetAuditedReceipt(Guid receiptID);
    }
}
