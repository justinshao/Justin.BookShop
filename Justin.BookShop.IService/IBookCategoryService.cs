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
    public interface IBookCategoryService : IService
    {
        [OperationContract]
        IEnumerable<BookCategory> GetAll();
        [OperationContract]
        BookCategory GetByID(int id);
        [OperationContract]
        void Add(BookCategory category);
        [OperationContract]
        string Remove(int id);
        [OperationContract]
        void Rename(int id, string newName);
    }
}
