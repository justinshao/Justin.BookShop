using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Justin.BookShop.Entities;

namespace Justin.BookShop.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All { get; }
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity Add(TEntity entity, bool saveChanges = true);
        TEntity Update(TEntity entity, bool saveChanges = true);
        void Delete(TEntity entity, bool saveChanges = true);
    }

    public partial interface IAuthorRepository : IRepository<Author> { }
    public partial interface IBookRepository : IRepository<Book> { }
    public partial interface IBookCategoryRepository : IRepository<BookCategory> { }
    public partial interface IBookCommentRepository : IRepository<BookComment> { }
    public partial interface IBookStockRepository : IRepository<BookStock> { }
    public partial interface IBookStockHistoryRepository : IRepository<BookStockHistory> { }
    public partial interface ICartItemRepository : IRepository<CartItem> { }
    public partial interface IDepartmentRepository : IRepository<Department> { }
    public partial interface IInStockReceiptRepository : IRepository<InStockReceipt> { }
    public partial interface IInStockReceiptDetailRepository : IRepository<InStockReceiptDetail> { }
    public partial interface IOderTraceRepository : IRepository<OderTrace> { }
    public partial interface IOrderRepository : IRepository<Order> { }
    public partial interface IOrderItemRepository : IRepository<OrderItem> { }
    public partial interface IOutStockReceiptRepository : IRepository<OutStockReceipt> { }
    public partial interface IOutStockReceiptDetailRepository : IRepository<OutStockReceiptDetail> { }
    public partial interface IPermissionRepository : IRepository<Permission> { }
    public partial interface IPressRepository : IRepository<Press> { }
    public partial interface IPriceAdjustReceiptRepository : IRepository<PriceAdjustReceipt> { }
    public partial interface IPriceAdjustReceiptDetailRepository : IRepository<PriceAdjustReceiptDetail> { }
    public partial interface IPromotionInfoRepository : IRepository<PromotionInfo> { }
    public partial interface IReceiptInfoRepository : IRepository<ReceiptInfo> { }
    public partial interface IShoppingCartRepository : IRepository<ShoppingCart> { }
    public partial interface IStockDamagedReceiptRepository : IRepository<StockDamagedReceipt> { }
    public partial interface IStockDamagedReceiptDetailRepository : IRepository<StockDamagedReceiptDetail> { }
    public partial interface IStocktakeReceiptRepository : IRepository<StocktakeReceipt> { }
    public partial interface IStocktakeReceiptDeatilRepository : IRepository<StocktakeReceiptDeatil> { }
    public partial interface ISysVariableRepository : IRepository<SysVariable> { }
    public partial interface IUserRepository : IRepository<User> { }
    public partial interface IUserRoleRepository : IRepository<UserRole> { }
}