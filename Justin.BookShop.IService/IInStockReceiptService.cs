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
    public interface IInStockReceiptService : IService
    {
        [OperationContract]
        InStockReceipt GetTemporaryReceipt(Guid id);
        [OperationContract]
        IEnumerable<InStockReceipt> GetTemporaryReceiptList();
        [OperationContract]
        void RemoveTemporaryReceipt(Guid id);
        [OperationContract]
        void SubmitTemporaryReceipt(InStockReceipt receipt, IEnumerable<InStockReceiptDetail> details = null);
        [OperationContract]
        void UpdateTemporaryReceipt(InStockReceipt receipt, IEnumerable<InStockReceiptDetail> details = null);
        [OperationContract]
        void AuditReceipt(Guid receiptId, Guid auditId);
        [OperationContract]
        void InvalidReceipt(Guid receiptId, Guid operatorId);
        [OperationContract]
        IEnumerable<InStockReceipt> GetAuditedReceiptList(string fromNO, string toNO);
        [OperationContract]
        InStockReceipt GetAuditedReceipt(Guid receiptID);
    }
}
