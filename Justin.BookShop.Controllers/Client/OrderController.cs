using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;

namespace Justin.BookShop.Controllers.Client
{
    public class OrderController : ClientController
    {
        [CheckClientLogin]
        public ActionResult List(Guid userId)
        {
            return View(LoginUser.Orders);
        }

        [HttpPost]
        [CheckClientLogin]
        public ActionResult SubmitCart(ShoppingCart cart)
        {
            var orderInfo = ResolveService<ICartService>().GetOrderInfo(cart);
            return View("SubmitOrder", orderInfo);
        }

        [HttpPost]
        [CheckClientLogin]
        public ActionResult SubmitOrder(DomainModels.Order order)
        {
            var _order = ResolveService<IOrderService>().SubmitOrder(LoginUser.ID, order);

            return View("SubmitOrderResult", new ViewModels.SubmitOrderResult
            {
                Success = true,
                Message = "已成功提交订单！",
                OrderID = _order.ID
            });
        }

        [CheckClientLogin]
        public ActionResult Detail(Guid orderId)
        {
            //return View(LoginUser.Orders.FirstOrDefault(o => o.ID == orderId));
            var order = ResolveService<IOrderService>().GetOrderById(orderId);
            return View(order);
        }
    }
}
