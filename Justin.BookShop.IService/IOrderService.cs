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
    public interface IOrderService : IService
    {
        [OperationContract]
        Order SubmitOrder(Guid userId, Order order);
        [OperationContract]
        IEnumerable<Order> GetNonAuditedOrders();
        [OperationContract]
        Order GetOrder(Guid orderId);
        [OperationContract]
        void AuditOrder(Guid orderId, Guid auditorId);
        [OperationContract]
        void AddOrderTrace(string orderNO, Guid userId);
        [OperationContract]
        Order GetOrderById(Guid orderId);
    }
}
