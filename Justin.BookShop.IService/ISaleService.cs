using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.IService
{
    [ServiceContract]
    public interface ISaleService : IService
    {
        [OperationContract]
        void SetPrice(Guid bookId, decimal sellingPrice);
        [OperationContract]
        void SetOffSale(Guid bookId);
        [OperationContract]
        void SetOnSale(Guid bookId, bool showOnBanner, bool showOnFront, IEnumerable<int> specialCategoryIds);
    }
}
