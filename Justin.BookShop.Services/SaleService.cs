using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class SaleService : BaseService, ISaleService
    {
        public void SetPrice(Guid bookId, decimal sellingPrice)
        {
            var book = DbSession.Books.GetSingle(b => b.ID == bookId);
            if(bookId == null)
                throw new Exception("不存在该书籍");
            if (sellingPrice < 0)
                throw new ArgumentException("售价不能为负", "sellingPrice");

            book.SellingPrice = sellingPrice;
            DbSession.SaveChanges();
        }

        public void SetOffSale(Guid bookId)
        {
            var book = DbSession.Books.GetSingle(b => b.ID == bookId);
            if (bookId == null)
                throw new Exception("不存在该书籍");

            book.OnSale = false;
            DbSession.SaveChanges();
        }

        public void SetOnSale(Guid bookId, bool showOnBanner, bool showOnFront, IEnumerable<int> specialCategoryIds)
        {
            var book = DbSession.Books.GetSingle(b => b.ID == bookId);
            if (bookId == null)
                throw new Exception("不存在该书籍");

            book.OnSale = true;
            book.ShowOnBanner = showOnBanner;
            book.PromotedOnFront = showOnFront;
            book.AddedTime = DateTime.Now;
            if (specialCategoryIds != null)
            {
                book.SpecialCategories.Clear();
                foreach (var cid in specialCategoryIds)
                {
                    var bc = DbSession.BookCategorys.GetSingle(c => c.ID == cid);
                    if (bc != null)
                        book.SpecialCategories.Add(bc);
                }
            }
            DbSession.SaveChanges();
        }
    }
}
