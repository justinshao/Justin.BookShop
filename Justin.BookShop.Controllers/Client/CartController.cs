using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Client
{
    public class CartController : ClientController
    {
        [CheckClientLogin]
        public ActionResult List(Guid userId)
        {
            var cart = LoginUser.ShoppingCart;
            return View(cart);
        }

        [CheckClientLogin]
        public ActionResult AddCartItem(Guid bookId, int count)
        {
            ResolveService<ICartService>().AddCartItem(LoginUser.ID, bookId, count);

            return View("AddCartResult", new AddCartResult { 
                Success = true,
                Message = "商品已成功加入购物车！",
                PreUrl = Request.UrlReferrer.AbsoluteUri
            });
        }

        [CheckClientLogin]
        public ActionResult RemoveCartItem(Guid bookId)
        {
            ResolveService<ICartService>().RemoveCartItem(LoginUser.ID, bookId);

            return View("List", LoginUser.ShoppingCart);
        }
    }
}
