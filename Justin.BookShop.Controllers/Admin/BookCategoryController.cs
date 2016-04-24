using Justin.BookShop.Controllers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels = Justin.BookShop.Controllers.Models;
using Justin.BookShop.Controllers.Comman;
using DomainModels = Justin.BookShop.Entities;
using Justin.BookShop.IService;
using Justin.BookShop.Controllers.Models;

namespace Justin.BookShop.Controllers.Admin
{
    public class BookCategoryController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var result = (from c in ResolveService<IBookCategoryService>().GetAll()
                         select c.CopyToViewModel()).ToList();

            return Json(result);
        }

        [HttpPost]
        public ActionResult Add(ViewModels.BookCategory category)
        {
            ResolveService<IBookCategoryService>().Add(category.CopyToDomainModel());

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var error = ResolveService<IBookCategoryService>().Remove(id);

            return Json(new JsonResultData
            {
                Success = true,
                ErrorMessage = error
            });
        }

        [HttpPost]
        public ActionResult Rename(int id, string newName)
        {
            ResolveService<IBookCategoryService>().Rename(id, newName);

            return Json(new JsonResultData
            {
                Success = true
            });
        }
    }
}
