using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class BookCategoryService : BaseService, IBookCategoryService
    {
        public IEnumerable<Entities.BookCategory> GetAll()
        {
            return DbSession.BookCategorys.All;
        }

        public void Add(Entities.BookCategory category)
        {
            DbSession.BookCategorys.Add(category);
        }

        public string Remove(int id)
        {
            string error = string.Empty;

            var categoryToRemove = DbSession.BookCategorys.GetSingle(c => c.ID == id);
            if (categoryToRemove.Children.Count() > 0)
                error = "该类别下还有子类别，不允许删除。";
            else
                DbSession.BookCategorys.Delete(categoryToRemove);

            return error;
        }

        public void Rename(int id, string newName)
        {
            var categoryToEdit = DbSession.BookCategorys.GetSingle(c => c.ID == id);
            categoryToEdit.Name = newName; 
            DbSession.BookCategorys.Update(categoryToEdit);
        }

        public Entities.BookCategory GetByID(int id)
        {
            return DbSession.BookCategorys.GetSingle(c => c.ID == id);
        }
    }
}
