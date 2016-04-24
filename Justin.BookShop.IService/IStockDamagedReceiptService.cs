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
    public interface IStockDamagedReceiptService : IService
    {
        [OperationContract]
        StockDamagedReceipt GetTemporaryReceipt(Guid id);
        [OperationContract]
        IEnumerable<StockDamagedReceipt> GetTemporaryReceiptList();
        [OperationContract]
        void RemoveTemporaryReceipt(Guid id);
        [OperationContract]
        void SubmitTemporaryReceipt(StockDamagedReceipt receipt, IEnumerable<StockDamagedReceiptDetail> details = null);
        [OperationContract]
        void UpdateTemporaryReceipt(StockDamagedReceipt receipt, IEnumerable<StockDamagedReceiptDetail> details = null);
        [OperationContract]
        void AuditReceipt(Guid receiptId, Guid auditId);
        [OperationContract]
        IEnumerable<StockDamagedReceipt> GetAuditedReceiptList(string fromNO, string toNO);
        [OperationContract]
        StockDamagedReceipt GetAuditedReceipt(Guid receiptID);
    }
}
