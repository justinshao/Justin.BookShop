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
    public interface IAuthorService : IService
    {
        [OperationContract]
        IEnumerable<Author> GetPagedAuthors(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total, Func<Author, Boolean> where = null);
        [OperationContract]
        Author GetByID(int id);
        [OperationContract]
        void SaveAuthor(Author author);
        [OperationContract]
        void Remove(int id);
        [OperationContract]
        IEnumerable<Author> GetAll();
    }
}
