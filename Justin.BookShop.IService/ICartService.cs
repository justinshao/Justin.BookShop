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
    public interface ICartService : IService
    {
        [OperationContract]
        void AddCartItem(Guid userId, Guid bookId, int count);
        [OperationContract]
        void RemoveCartItem(Guid userId, Guid bookId);
        [OperationContract]
        Order GetOrderInfo(ShoppingCart cart);
    }
}
