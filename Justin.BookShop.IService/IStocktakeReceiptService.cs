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
    public interface IStocktakeReceiptService : IService
    {
        [OperationContract]
        StocktakeReceipt GetTemporaryReceipt(Guid id);
        [OperationContract]
        IEnumerable<StocktakeReceipt> GetTemporaryReceiptList();
        [OperationContract]
        void RemoveTemporaryReceipt(Guid id);
        [OperationContract]
        void SubmitTemporaryReceipt(StocktakeReceipt receipt, IEnumerable<StocktakeReceiptDeatil> details = null);
        [OperationContract]
        void UpdateTemporaryReceipt(StocktakeReceipt receipt, IEnumerable<StocktakeReceiptDeatil> details = null);
        [OperationContract]
        void AuditReceipt(Guid receiptId, Guid auditId);
        [OperationContract]
        IEnumerable<StocktakeReceipt> GetAuditedReceiptList(string fromNO, string toNO);
        [OperationContract]
        StocktakeReceipt GetAuditedReceipt(Guid receiptID);
    }
}
