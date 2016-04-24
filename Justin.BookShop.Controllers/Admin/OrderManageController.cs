using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.Controllers.Filters;

namespace Justin.BookShop.Controllers.Admin
{
    public class OrderManageController : AdminController
    {
        [Menu]
        public ActionResult AuditIndex()
        {
            return View();
        }

        public ActionResult NonAuditedList()
        {
            var orders = (from o in ResolveService<IOrderService>().GetNonAuditedOrders()
                         select o.CopyToViewModel()).ToList();

            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrder(Guid orderId)
        {
            var order = ResolveService<IOrderService>().GetOrder(orderId);

            return View("OrderDetail", order);
        }

        public ActionResult AuditOrder(Guid orderId)
        {
            ResolveService<IOrderService>().AuditOrder(orderId, LoginUser.ID);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [Menu]
        public ActionResult SetOrderTrace()
        {
            return View("SetTraceInfo", LoginUser.TraceInfo);
        }

        [HttpPost]
        public ActionResult SetOrderTrace(string traceInfo)
        {
            ResolveService<IUserService>().SetTraceInfo(traceInfo, LoginUser.ID);

            return Json(new JsonResultData{
                Success = true
            });
        }

        [Menu]
        public ActionResult PositionInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetPositionInfo(string orderNO)
        {
            ResolveService<IOrderService>().AddOrderTrace(orderNO, LoginUser.ID);

            return Json(new JsonResultData { 
                Success = true
            });
        }
    }
}
