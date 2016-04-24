using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Controllers.Comman;
using DomainModels = Justin.BookShop.Entities;
using ViewModels = Justin.BookShop.Controllers.Models;
using Justin.BookShop.Controllers.Filters;

namespace Justin.BookShop.Controllers.Admin
{
    public class AuthorController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([ModelBinder(typeof(PaginationInfoBinder))]
                                            PaginationInfo pagination,
                                         [ModelBinder(typeof(AuthorSelectorBinder))]
                                            IModelFieldSelector<DomainModels.Author> selector)
        {
            var total = 0;
            var data = (from a in ResolveService<IAuthorService>().GetPagedAuthors(pagination.PageIndex,
                                  pagination.PageSize, pagination.SortField, pagination.SortOrder, out total,
                                  a => selector == null ? true : selector.IsMatch(a))
                        select a.CopyToViewModel()).ToList();

            return Json(new
            {
                total = total,
                data = data
            });
        }

        public ActionResult GetAuthorByID(int id)
        {
            var author = ResolveService<IAuthorService>().GetByID(id);
            if (author == null)
                return Json(new ViewModels.Author(), JsonRequestBehavior.AllowGet);

            return Json(author.CopyToViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveAuthor(ViewModels.Author author)
        {
            var service = ResolveService<IAuthorService>();
            var saveAuthor = service.GetByID(author.ID);
            saveAuthor = author.CopyToDomainModel(saveAuthor);
            service.SaveAuthor(saveAuthor);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            ResolveService<IAuthorService>().Remove(id);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult FilterAuthor(string key)
        {
            var result = (from a in ResolveService<IAuthorService>().GetAll()
                          where a.Name.ToLower().StartsWith(key.ToLower())
                          select a.CopyToViewModel()).ToList();

            return Json(result);
        }
    }
}
