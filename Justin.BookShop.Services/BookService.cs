using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class BookService : BaseService, IBookService
    {
        public IEnumerable<Entities.Book> GetPagedBooks(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Book, Boolean> where = null)
        {
            return GetSortPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total, b => b.Name, where);
        }

        /// <summary>
        /// 取经过排序的分页数据
        /// </summary>
        /// <typeparam name="TKey">总体排序字段</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="sortField">结果集的排序字段</param>
        /// <param name="sortOrder">结果集的排序方式</param>
        /// <param name="order">总体的排序方式</param>
        /// <param name="where">总体的筛选条件</param>
        /// <returns></returns>
        private IEnumerable<Book> GetSortPagedBooks<TKey>(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Book, TKey> order, Func<Book, bool> @where = null)
        {
            var ret = (from b in DbSession.Books.All
                       where (@where != null ? @where(b) : true)
                       orderby  order(b)
                       select b);
            var desc = sortOrder == SortOrder.Desc;

            if (sortField != null)
            {
                switch (sortField.ToLower())
                {
                    case "name":
                        ret = desc ? ret.OrderByDescending(b => b.Name) : ret.OrderBy(b => b.Name);
                        break;
                    case "maintitle":
                        ret = desc ? ret.OrderByDescending(b => b.MainTitle) : ret.OrderBy(b => b.MainTitle);
                        break;
                    case "sellingprice":
                        ret = desc ? ret.OrderByDescending(b => b.SellingPrice) : ret.OrderBy(b => b.SellingPrice);
                        break;
                    case "officialprice":
                        ret = desc ? ret.OrderByDescending(b => b.OfficialPrice) : ret.OrderBy(b => b.OfficialPrice);
                        break;
                    case "publicationdate":
                        ret = desc ? ret.OrderByDescending(b => b.PublicationDate) : ret.OrderBy(b => b.PublicationDate);
                        break;
                    case "printingtime":
                        ret = desc ? ret.OrderByDescending(b => b.PrintingTime) : ret.OrderBy(b => b.PrintingTime);
                        break;
                    case "pagenum":
                        ret = desc ? ret.OrderByDescending(b => b.PageNum) : ret.OrderBy(b => b.PageNum);
                        break;
                    case "language":
                        ret = desc ? ret.OrderByDescending(b => b.Language) : ret.OrderBy(b => b.Language);
                        break;
                    case "addedtime":
                        ret = desc ? ret.OrderByDescending(b => b.AddedTime) : ret.OrderBy(b => b.AddedTime);
                        break;
                    case "storagetime":
                        ret = desc ? ret.OrderByDescending(b => b.StorageTime) : ret.OrderBy(b => b.StorageTime);
                        break;
                    case "salesvolume":
                        ret = desc ? ret.OrderByDescending(b => b.SalesVolume) : ret.OrderBy(b => b.SalesVolume);
                        break;
                    case "promotedonfront":
                        ret = desc ? ret.OrderByDescending(b => b.PromotedOnFront) : ret.OrderBy(b => b.PromotedOnFront);
                        break;
                    case "onsale":
                        ret = desc ? ret.OrderByDescending(b => b.OnSale) : ret.OrderBy(b => b.OnSale);
                        break;
                    case "showonbanner":
                        ret = desc ? ret.OrderByDescending(b => b.OnSale) : ret.OrderBy(b => b.OnSale);
                        break;
                    default:
                        ret = desc ? ret.OrderByDescending(b => b.Name) : ret.OrderBy(b => b.Name);
                        break;
                }
            }

            total = ret.Count();

            return ret.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public Book GetByID(Guid id)
        {
            return DbSession.Books.GetSingle(b => b.ID == id);
        }

        public void SaveBook(Book book)
        {
            var session = DbSession.Books;
            switch (book.State)
            {
                case EntityState.Add:
                    book.ID = Guid.NewGuid();
                    book.AddedTime = null;
                    book.StorageTime = null;
                    book.SalesVolume = null;
                    book.SalesVolume = 0;
                    book.PromotedOnFront = false;
                    book.OnSale = false;
                    book.ShowOnBanner = false;
                    session.Add(book);
                    break;
                case EntityState.Delete:
                    var at = session.GetSingle(b => b.ID == book.ID);
                    if (at != null)
                        session.Delete(book);
                    break;
                case EntityState.Modify:
                    session.Update(book);
                    break;
                default:
                    break;
            }
        }

        public void Remove(Guid id)
        {
            var book = DbSession.Books.GetSingle(b => b.ID == id);
            if (book != null)
                DbSession.Books.Delete(book);
        }

        public Book GetByISBN(string isbn)
        {
            return DbSession.Books.GetSingle(b => b.ISBN.Equals(isbn, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Book> GetBooksOnBanner()
        {
            return from b in DbSession.Books.All
                   where b.ShowOnBanner
                   select b;
        }

        public IEnumerable<Book> GetPagedBooksOnFront(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total)
        {
            return GetSortPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total, b => b.SalesVolume, b => b.OnSale && b.PromotedOnFront);
        }

        public IEnumerable<Book> GetPagedCategoryBooks(int categoryId, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total)
        {
            var category = DbSession.BookCategorys.GetSingle(c => c.ID == categoryId);
            return GetSortPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total,
                order: b => (b.Category.ID != categoryId), 
                where: b => b.OnSale && (b.Category.ID == categoryId || b.SpecialCategories.Contains(category)));
        }

        public IEnumerable<Book> GetPagedAuthorBooks(int authorId, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total)
        {
            var author = DbSession.Authors.GetSingle(a => a.ID == authorId);
            return GetSortPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total,
                order: b => b.SalesVolume,
                where: b => b.OnSale && b.Authors.Contains(author));
        }

        public IEnumerable<Book> GetPagedPressBooks(int pressId, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total)
        {
            var press = DbSession.Presss.GetSingle(p => p.ID == pressId);
            return GetSortPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total,
                order: b => b.SalesVolume,
                where: b => b.OnSale && b.Presses.Contains(press));
        }

        public IEnumerable<Book> GetPagedSearchBooks(string key, int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total)
        {
            return GetSortPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total,
                order: b => b.SalesVolume,
                where: b => b.OnSale && b.Name.ToLower().Contains(key));
        }
    }
}
