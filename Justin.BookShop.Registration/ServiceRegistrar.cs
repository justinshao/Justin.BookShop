using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IService;
using Justin.BookShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Registration
{
    public class ServiceRegistrar : IRegistrar
    {
        public void Register(IContainer container)
        {
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IUserRoleService, UserRoleService>();
            container.RegisterType<IPermissionService, PermissionService>();
            container.RegisterType<IBookCategoryService, BookCategoryService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IPressService, PressService>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IBookStockService, BookStockService>();
            container.RegisterType<IInStockReceiptService, InStockReceiptService>();
            container.RegisterType<IOutStockReceiptService, OutStockReceiptService>();
            container.RegisterType<IPriceAdjustReceiptService, PriceAdjustReceiptService>();
            container.RegisterType<IStockDamagedReceiptService, StockDamagedReceiptService>();
            container.RegisterType<IStocktakeReceiptService, StocktakeReceiptService>();
            container.RegisterType<ISaleService, SaleService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IOrderService, OrderService>();
        }
    }
}
