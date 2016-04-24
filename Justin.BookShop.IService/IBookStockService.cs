using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.IService
{
    [ServiceContract]
    public interface IBookStockService : IService
    {
        [OperationContract]
        void CloseAccount(string period);
    }
}
