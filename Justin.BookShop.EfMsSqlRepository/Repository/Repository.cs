using Justin.BookShop.Entities;
using Justin.BookShop.IRepository;

namespace Justin.BookShop.EfMsSqlRepository
{
    public partial class AuthorRepository : EfRepository<Author>, IAuthorRepository 
    {
        public AuthorRepository(IDbContext context) : base(context) { } 
    }

    public partial class BookRepository : EfRepository<Book>, IBookRepository 
    {
        public BookRepository(IDbContext context) : base(context) { } 
    }

    public partial class BookCategoryRepository : EfRepository<BookCategory>, IBookCategoryRepository 
    {
        public BookCategoryRepository(IDbContext context) : base(context) { } 
    }

    public partial class BookCommentRepository : EfRepository<BookComment>, IBookCommentRepository 
    {
        public BookCommentRepository(IDbContext context) : base(context) { } 
    }

    public partial class BookStockRepository : EfRepository<BookStock>, IBookStockRepository 
    {
        public BookStockRepository(IDbContext context) : base(context) { } 
    }

    public partial class BookStockHistoryRepository : EfRepository<BookStockHistory>, IBookStockHistoryRepository 
    {
        public BookStockHistoryRepository(IDbContext context) : base(context) { } 
    }

    public partial class CartItemRepository : EfRepository<CartItem>, ICartItemRepository 
    {
        public CartItemRepository(IDbContext context) : base(context) { } 
    }

    public partial class DepartmentRepository : EfRepository<Department>, IDepartmentRepository 
    {
        public DepartmentRepository(IDbContext context) : base(context) { } 
    }

    public partial class InStockReceiptRepository : EfRepository<InStockReceipt>, IInStockReceiptRepository 
    {
        public InStockReceiptRepository(IDbContext context) : base(context) { } 
    }

    public partial class InStockReceiptDetailRepository : EfRepository<InStockReceiptDetail>, IInStockReceiptDetailRepository 
    {
        public InStockReceiptDetailRepository(IDbContext context) : base(context) { } 
    }

    public partial class OderTraceRepository : EfRepository<OderTrace>, IOderTraceRepository 
    {
        public OderTraceRepository(IDbContext context) : base(context) { } 
    }

    public partial class OrderRepository : EfRepository<Order>, IOrderRepository 
    {
        public OrderRepository(IDbContext context) : base(context) { } 
    }

    public partial class OrderItemRepository : EfRepository<OrderItem>, IOrderItemRepository 
    {
        public OrderItemRepository(IDbContext context) : base(context) { } 
    }

    public partial class OutStockReceiptRepository : EfRepository<OutStockReceipt>, IOutStockReceiptRepository 
    {
        public OutStockReceiptRepository(IDbContext context) : base(context) { } 
    }

    public partial class OutStockReceiptDetailRepository : EfRepository<OutStockReceiptDetail>, IOutStockReceiptDetailRepository 
    {
        public OutStockReceiptDetailRepository(IDbContext context) : base(context) { } 
    }

    public partial class PermissionRepository : EfRepository<Permission>, IPermissionRepository 
    {
        public PermissionRepository(IDbContext context) : base(context) { } 
    }

    public partial class PressRepository : EfRepository<Press>, IPressRepository 
    {
        public PressRepository(IDbContext context) : base(context) { } 
    }

    public partial class PriceAdjustReceiptRepository : EfRepository<PriceAdjustReceipt>, IPriceAdjustReceiptRepository 
    {
        public PriceAdjustReceiptRepository(IDbContext context) : base(context) { } 
    }

    public partial class PriceAdjustReceiptDetailRepository : EfRepository<PriceAdjustReceiptDetail>, IPriceAdjustReceiptDetailRepository 
    {
        public PriceAdjustReceiptDetailRepository(IDbContext context) : base(context) { } 
    }

    public partial class PromotionInfoRepository : EfRepository<PromotionInfo>, IPromotionInfoRepository 
    {
        public PromotionInfoRepository(IDbContext context) : base(context) { } 
    }

    public partial class ReceiptInfoRepository : EfRepository<ReceiptInfo>, IReceiptInfoRepository 
    {
        public ReceiptInfoRepository(IDbContext context) : base(context) { } 
    }

    public partial class ShoppingCartRepository : EfRepository<ShoppingCart>, IShoppingCartRepository 
    {
        public ShoppingCartRepository(IDbContext context) : base(context) { } 
    }

    public partial class StockDamagedReceiptRepository : EfRepository<StockDamagedReceipt>, IStockDamagedReceiptRepository 
    {
        public StockDamagedReceiptRepository(IDbContext context) : base(context) { } 
    }

    public partial class StockDamagedReceiptDetailRepository : EfRepository<StockDamagedReceiptDetail>, IStockDamagedReceiptDetailRepository 
    {
        public StockDamagedReceiptDetailRepository(IDbContext context) : base(context) { } 
    }

    public partial class StocktakeReceiptRepository : EfRepository<StocktakeReceipt>, IStocktakeReceiptRepository 
    {
        public StocktakeReceiptRepository(IDbContext context) : base(context) { } 
    }

    public partial class StocktakeReceiptDeatilRepository : EfRepository<StocktakeReceiptDeatil>, IStocktakeReceiptDeatilRepository 
    {
        public StocktakeReceiptDeatilRepository(IDbContext context) : base(context) { } 
    }

    public partial class SysVariableRepository : EfRepository<SysVariable>, ISysVariableRepository 
    {
        public SysVariableRepository(IDbContext context) : base(context) { } 
    }

    public partial class UserRepository : EfRepository<User>, IUserRepository 
    {
        public UserRepository(IDbContext context) : base(context) { } 
    }

    public partial class UserRoleRepository : EfRepository<UserRole>, IUserRoleRepository 
    {
        public UserRoleRepository(IDbContext context) : base(context) { } 
    }

}