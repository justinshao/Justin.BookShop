using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Admin
{
    public class SaleController : AdminController
    {
        [Menu]
        public ActionResult Price()
        {
            return View();
        }

        [Menu]
        public ActionResult OnAndOffSale()
        {
            return View();
        }

        [Menu]
        public ActionResult Promotion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetOffSale(Guid bookId)
        {
            ResolveService<ISaleService>().SetOffSale(bookId);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult SetOnSale(Guid bookId, bool showOnBanner, bool showOnFront, int[] specialCategoryIds)
        {
            ResolveService<ISaleService>().SetOnSale(bookId, showOnBanner, showOnFront, specialCategoryIds);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult SetPrice(Guid bookId, decimal sellingPrice)
        {
            string error = string.Empty;
            try
            {
                ResolveService<ISaleService>().SetPrice(bookId, sellingPrice);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new JsonResultData { 
                Success = string.IsNullOrEmpty(error),
                ErrorMessage = error
            });
        }
    }
}
