using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        public IEnumerable<Entities.Author> GetPagedAuthors(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Author, Boolean> @where = null)
        {
            var ret = (from a in DbSession.Authors.All
                       where (@where == null ? true : @where(a))
                       select a);
            var desc = sortOrder == SortOrder.Desc;

            switch (sortField.ToLower())
            {
                case "name":
                    ret = desc ? ret.OrderByDescending(a => a.Name) : ret.OrderBy(a => a.Name);
                    break;
                default:
                    ret = desc ? ret.OrderByDescending(u => u.Name) : ret.OrderBy(u => u.Name);
                    break;
            }
            total = ret.Count();

            return ret.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public Author GetByID(int id)
        {
            return DbSession.Authors.GetSingle(a => a.ID == id);
        }

        public void SaveAuthor(Author author)
        {
            var session = DbSession.Authors;
            switch (author.State)
            {
                case EntityState.Add:
                    session.Add(author);
                    break;
                case EntityState.Delete:
                    var at = session.GetSingle(a => a.ID == author.ID);
                    if(at != null)
                        session.Delete(author);
                    break;
                case EntityState.Modify:
                    session.Update(author);
                    break;
                default:
                    break;
            }
        }

        public void Remove(int id)
        {
            var author = DbSession.Authors.GetSingle(a => a.ID == id);
            if (author != null)
                DbSession.Authors.Delete(author);
        }

        public IEnumerable<Author> GetAll()
        {
            return DbSession.Authors.All;
        }
    }
}
