using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.IService;
using Justin.BookShop.Controllers.Comman;
using System.Web;
using Justin.BookShop.Controllers.Filters;

namespace Justin.BookShop.Controllers.Admin
{
    public class BookController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([ModelBinder(typeof(PaginationInfoBinder))]
                                            PaginationInfo pagination,
                                         [ModelBinder(typeof(BookSelectorBinder))]
                                            IModelFieldSelector<DomainModels.Book> selector)
        {
            var total = 0;
            var data = (from b in ResolveService<IBookService>().GetPagedBooks(pagination.PageIndex,
                                  pagination.PageSize, pagination.SortField, pagination.SortOrder, out total, 
                                  b => selector == null ? true : selector.IsMatch(b))
                        select b.CopyToViewModel()).ToList();

            return Json(new
            {
                total = total,
                data = data
            });
        }

        [HttpPost]
        public ActionResult SaveBook(ViewModels.Book book)
        {
            DomainModels.Book bookToSave = null;
            var service = ResolveService<IBookService>();
            if(book._state.Equals("modified", StringComparison.CurrentCultureIgnoreCase))
                bookToSave = service.GetByID(book.ID);
            service.SaveBook(book.CopyToDomainModel(bookToSave));

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult Remove(Guid id)
        {
            ResolveService<IBookService>().Remove(id);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        public ActionResult GetByID(Guid? bookId)
        {
            if (bookId == null)
                return Content("{}");

            var book = ResolveService<IBookService>().GetByID(bookId.Value).CopyToViewModel();

            return Json(new JsonResultData { 
                Success = true,
                Data = book
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByISBN(string isbn)
        {
            if (isbn == null)
                return Content("{}");

            var book = ResolveService<IBookService>().GetByISBN(isbn);

            return Json(new JsonResultData
            {
                Success = true,
                Data = book == null ? null : book.CopyToViewModel()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWithStock(string isbn)
        {
            if (isbn == null)
                return Content("{}");

            var book = ResolveService<IBookService>().GetByISBN(isbn);

            return Json(new JsonResultData
            {
                Success = true,
                Data = new { 
                    Book = book.CopyToViewModel(),
                    StockQuantity = book.Stock == null ? 0 : book.Stock.ThisPeriodQuantity
                }
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetPicture()
        {
            HttpPostedFileBase picture = Request.Files[0];
            string dir = Request.MapPath("~/Content/images/book/");
            string ext = System.IO.Path.GetExtension(picture.FileName);
            string name = Guid.NewGuid().ToString() + DateTime.Now.ToString("_yyyyMMdd-hhmmss") + ext;
            string path = string.Format(@"{0}{1}", dir, name);
            picture.SaveAs(path);

            return Content("http://" + Request.Url.Host + ":" + Request.Url.Port + "/Content/images/book/" + name);
        }
    }
}
