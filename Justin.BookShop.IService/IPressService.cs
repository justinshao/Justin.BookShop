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
    public interface IPressService : IService
    {
        [OperationContract]
        IEnumerable<Press> GetPagedPresses(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total, Func<Press, Boolean> where = null);
        [OperationContract]
        Press GetById(int id);
        [OperationContract]
        void SaveChanges(IEnumerable<Press> changedPresses);
        [OperationContract]
        IEnumerable<Press> GetAll();
    }
}
