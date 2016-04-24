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
    public interface IBookService : IService
    {
        [OperationContract]
        IEnumerable<Book> GetPagedBooks(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total, Func<Book, Boolean> where = null);
        [OperationContract]
        Book GetByID(Guid id);
        [OperationContract]
        Book GetByISBN(string isbn);
        [OperationContract]
        void SaveBook(Book book);
        [OperationContract]
        void Remove(Guid id);
        [OperationContract]
        IEnumerable<Book> GetBooksOnBanner();
        [OperationContract]
        IEnumerable<Book> GetPagedBooksOnFront(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total);
        [OperationContract]
        IEnumerable<Book> GetPagedCategoryBooks(int categoryId, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total);
        [OperationContract]
        IEnumerable<Book> GetPagedAuthorBooks(int authorId, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total);
        [OperationContract]
        IEnumerable<Book> GetPagedPressBooks(int pressId, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total);
        [OperationContract]
        IEnumerable<Book> GetPagedSearchBooks(string key, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total);
    }
}
