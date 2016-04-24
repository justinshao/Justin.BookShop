using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class CartService : BaseService, ICartService
    {
        public void AddCartItem(Guid userId, Guid bookId, int count)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId);
            if (user == null)
                throw new Exception("不存在该用户");
            if (count <= 0)
                throw new Exception("商品数量小于0");

            if (user.ShoppingCart == null)
            {
                var cart = new ShoppingCart { UserID = user.ID };
                DbSession.ShoppingCarts.Add(cart, false);
            }

            CartItem item = user.ShoppingCart.CartItems.FirstOrDefault(i => i.BookID == bookId);
            if (item == null)
            {
                item = new CartItem
                {
                    ID = Guid.NewGuid(),
                    BookID = bookId,
                    Quantity = count,
                };
                user.ShoppingCart.CartItems.Add(item);
            }
            else
            {
                item.Quantity += count;
            }

            DbSession.SaveChanges();
        }

        public void RemoveCartItem(Guid userId, Guid bookId)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId);
            if (user == null)
                throw new Exception("不存在该用户");

            if (user.ShoppingCart == null)
                return;

            var item = user.ShoppingCart.CartItems.FirstOrDefault(i => i.BookID == bookId);
            if (item == null)
                return;
            DbSession.CartItems.Delete(item, false);

            DbSession.SaveChanges();
        }

        public Order GetOrderInfo(ShoppingCart cart)
        {
            decimal cart_total = 0;
            decimal freight = 10;
            
            foreach (var item in cart.CartItems)
            {
                var book = DbSession.Books.GetSingle(b => b.ID == item.BookID);
                cart_total += ((decimal)item.Quantity * book.SellingPrice.GetValueOrDefault());
            }
            if (cart_total >= 78)
                freight = 0;

            var order = new Order
            {
                Freight = freight,
                OrderPrice = cart_total + freight,
                OrderItems = (from i in cart.CartItems
                             let book = DbSession.Books.GetSingle(b => b.ID == i.BookID)
                             select new OrderItem
                             {
                                 Book = book,
                                 BookID = book.ID,
                                 Quantity = i.Quantity,
                                 UnitPrice = book.SellingPrice.GetValueOrDefault()
                             }).ToList()
            };

            return order;
        }
    }
}
