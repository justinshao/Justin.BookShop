using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IService;

namespace Justin.BookShop.WcfRegistration
{
    public class ServiceAdapterRegistrar : IRegistrar
    {
        public void Register(IContainer container)
        {
            container.RegisterType<IUserService, UserServiceAdapter>();
            container.RegisterType<IDepartmentService, DepartmentServiceAdapter>();
            container.RegisterType<IUserRoleService, UserRoleServiceAdapter>();
            container.RegisterType<IPermissionService, PermissionServiceAdapter>();
            container.RegisterType<IBookCategoryService, BookCategoryServiceAdapter>();
            container.RegisterType<IAuthorService, AuthorServiceAdapter>();
            container.RegisterType<IPressService, PressServiceAdapter>();
            container.RegisterType<IBookService, BookServiceAdapter>();
            container.RegisterType<IBookStockService, BookStockServiceAdapter>();
            container.RegisterType<IInStockReceiptService, InStockReceiptServiceAdapter>();
            container.RegisterType<IOutStockReceiptService, OutStockReceiptServiceAdapter>();
            container.RegisterType<IPriceAdjustReceiptService, PriceAdjustReceiptServiceAdapter>();
            container.RegisterType<IStockDamagedReceiptService, StockDamagedReceiptServiceAdapter>();
            container.RegisterType<IStocktakeReceiptService, StocktakeReceiptServiceAdapter>();
            container.RegisterType<ISaleService, SaleServiceAdapter>();
            container.RegisterType<ICartService, CartServiceAdapter>();
            container.RegisterType<IOrderService, OrderServiceAdapter>();
        }
    }
}
