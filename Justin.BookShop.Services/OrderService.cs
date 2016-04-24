using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public Entities.Order SubmitOrder(Guid userId, Entities.Order order)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId);
            if (user == null)
                throw new Exception("当前用户不存在");

            // 计算运费
            decimal freight = 10;
            decimal books_total = 0;
            foreach (var item in order.OrderItems)
            {
                var book = DbSession.Books.GetSingle(b => b.ID == item.BookID);
                books_total += book.SellingPrice.GetValueOrDefault() * (decimal)item.Quantity;
            }
            if (books_total >= 78)
                freight = 0;

            // 处理订单地址
            ReceiptInfo receipt = DbSession.ReceiptInfos.GetSingle(r => r.ID == order.Receipt.ID);
            if(receipt == null)
            {
                receipt = new ReceiptInfo
                {
                    ID = Guid.NewGuid(),
                    Address = order.Receipt.Address,
                    ReceiptName = order.Receipt.ReceiptName,
                    Phone = order.Receipt.Phone,
                    Email = order.Receipt.Email
                };
                user.Receipts.Add(receipt);
            }

            // 生成订单主体
            var newOrder = new Order
            {
                ID = Guid.NewGuid(),
                NO = DateTime.Now.ToString("yyyyMMddHHmm") + new Random().Next(0, 100),
                Freight = freight,
                OrderPrice = books_total + freight,
                SubmitDate = DateTime.Now,
                State = OrderState.Submitted,
                ReceiptID = receipt.ID,
                UserID = user.ID,
                ShipDate = null,
                IsAudited = false,
                AuditDate = null,
                AuditUserID = null
            };
            DbSession.Orders.Add(newOrder, false);

            // 生成订单明细
            newOrder = user.Orders.FirstOrDefault(o => o.ID == newOrder.ID);
            foreach (var item in order.OrderItems)
            {
                var book = DbSession.Books.GetSingle(b => b.ID == item.BookID);
                var newItem = new OrderItem
                {
                    BookID = book.ID,
                    Quantity = item.Quantity,
                    UnitPrice = book.SellingPrice.GetValueOrDefault()
                };
                newOrder.OrderItems.Add(newItem);
            }

            // 生成订单跟踪
            OderTrace trace = new OderTrace
            {
                ID = Guid.NewGuid(),
                Description = "客户" + user.Name + "提交了订单",
                SubmittedUserID = user.ID,
                SubmitTime = DateTime.Now
            };
            newOrder.Traces.Add(trace);
            
            // 删除购物车商品
            foreach (var item in order.OrderItems)
            {
                var cartItem = user.ShoppingCart.CartItems.FirstOrDefault(i => i.BookID == item.BookID);
                if (cartItem == null)
                    continue;
                DbSession.CartItems.Delete(cartItem, false);
            }

            DbSession.SaveChanges();

            return newOrder;
        }

        public IEnumerable<Order> GetNonAuditedOrders()
        {
            return from o in DbSession.Orders.All
                   orderby o.SubmitDate
                   where !o.IsAudited
                   select o;
        }

        public Order GetOrder(Guid orderId)
        {
            return DbSession.Orders.GetSingle(o => o.ID == orderId);
        }

        private string GetLSNO()
        {
            var no = (from r in DbSession.OutStockReceipts.All
                      where !r.IsAudited
                      select r.NO).Max();
            if (string.IsNullOrEmpty(no))
                return "000001";

            return (int.Parse(no) + 1).ToString("000000");
        }

        public void AuditOrder(Guid orderId, Guid auditorId)
        {
            var order = DbSession.Orders.All.Where(o => !o.IsAudited).FirstOrDefault(o => o.ID == orderId);
            if (order == null)
                throw new Exception("不存在该订单，订单号：" + orderId);

            order.IsAudited = true;
            order.AuditDate = DateTime.Now;
            order.AuditUserID = auditorId;

            // 产生临时出库单
            OutStockReceipt receipt = new OutStockReceipt();
            receipt.ID = Guid.NewGuid();
            receipt.NO = GetLSNO();
            receipt.OrderID = orderId;
            receipt.Remark = "由购物订单产生的出库单，订单号：" + order.NO;
            receipt.SubmitDate = DateTime.Now;
            receipt.AuditDate = null;
            receipt.IsAudited = false;
            receipt.AuditedBy = null;
            receipt.BeforeVoidReceipt = null;
            receipt.InvalidReceipt = null;
            receipt.Freight = order.Freight;
            receipt.SubmittedBy = DbSession.Users.GetSingle(u => u.ID == auditorId);

            int sort = 1;
            foreach (var item in order.OrderItems)
            {
                var newDetail = new OutStockReceiptDetail
                {
                    ID = Guid.NewGuid(),
                    Sort = sort++,
                    AccountPrice = null,
                    ReceiptHeader = receipt,
                    OutQuantity = item.Quantity,
                    BookID = item.BookID,
                    OutUnitPrice = item.UnitPrice
                };

                receipt.Details.Add(newDetail);
            }

            DbSession.OutStockReceipts.Add(receipt);
        }

        public void AddOrderTrace(string orderNO, Guid userId)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId);
            if(user == null)
                throw new Exception("当前用户不存在");

            var order = DbSession.Orders.All.Where(o => (o.State != OrderState.Cancel && o.State != OrderState.Completed) && o.NO.Equals(orderNO)).FirstOrDefault();
            if (order == null)
                throw new Exception("不存在该订单，订单可能被取消或订单已完成交易");

            var trace = new OderTrace
            {
                ID = Guid.NewGuid(),
                OrderID = order.ID,
                SubmittedBy = user,
                SubmittedUserID = user.ID,
                SubmitTime = DateTime.Now,
                TraceOf = order,
                Description = user.TraceInfo == null ? "无到站信息" : user.TraceInfo.Info
            };
            order.Traces.Add(trace);

            DbSession.SaveChanges();
        }

        public Order GetOrderById(Guid orderId)
        {
            return DbSession.Orders.GetSingle(o => o.ID == orderId);
        }
    }
}
