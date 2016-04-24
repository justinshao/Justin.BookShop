using Justin.BookShop.IRepository;
using Justin.BookShop.Common.IoCManagement;

namespace Justin.BookShop.EfMsSqlRepository
{
    public class DbSession : IDbSession
    {
        IDbContext _context;
        public DbSession(IDbContext context)
        {
            _context = context;
        }
        
        #region Repository
        private IAuthorRepository _Authors;
        public IAuthorRepository Authors
        { 
            get
            {
                if(_Authors == null) 
                    _Authors = new AuthorRepository(_context); 
                return _Authors;
            }
        }

        private IBookRepository _Books;
        public IBookRepository Books
        { 
            get
            {
                if(_Books == null) 
                    _Books = new BookRepository(_context); 
                return _Books;
            }
        }

        private IBookCategoryRepository _BookCategorys;
        public IBookCategoryRepository BookCategorys
        { 
            get
            {
                if(_BookCategorys == null) 
                    _BookCategorys = new BookCategoryRepository(_context); 
                return _BookCategorys;
            }
        }

        private IBookCommentRepository _BookComments;
        public IBookCommentRepository BookComments
        { 
            get
            {
                if(_BookComments == null) 
                    _BookComments = new BookCommentRepository(_context); 
                return _BookComments;
            }
        }

        private IBookStockRepository _BookStocks;
        public IBookStockRepository BookStocks
        { 
            get
            {
                if(_BookStocks == null) 
                    _BookStocks = new BookStockRepository(_context); 
                return _BookStocks;
            }
        }

        private IBookStockHistoryRepository _BookStockHistorys;
        public IBookStockHistoryRepository BookStockHistorys
        { 
            get
            {
                if(_BookStockHistorys == null) 
                    _BookStockHistorys = new BookStockHistoryRepository(_context); 
                return _BookStockHistorys;
            }
        }

        private ICartItemRepository _CartItems;
        public ICartItemRepository CartItems
        { 
            get
            {
                if(_CartItems == null) 
                    _CartItems = new CartItemRepository(_context); 
                return _CartItems;
            }
        }

        private IDepartmentRepository _Departments;
        public IDepartmentRepository Departments
        { 
            get
            {
                if(_Departments == null) 
                    _Departments = new DepartmentRepository(_context); 
                return _Departments;
            }
        }

        private IInStockReceiptRepository _InStockReceipts;
        public IInStockReceiptRepository InStockReceipts
        { 
            get
            {
                if(_InStockReceipts == null) 
                    _InStockReceipts = new InStockReceiptRepository(_context); 
                return _InStockReceipts;
            }
        }

        private IInStockReceiptDetailRepository _InStockReceiptDetails;
        public IInStockReceiptDetailRepository InStockReceiptDetails
        { 
            get
            {
                if(_InStockReceiptDetails == null) 
                    _InStockReceiptDetails = new InStockReceiptDetailRepository(_context); 
                return _InStockReceiptDetails;
            }
        }

        private IOderTraceRepository _OderTraces;
        public IOderTraceRepository OderTraces
        { 
            get
            {
                if(_OderTraces == null) 
                    _OderTraces = new OderTraceRepository(_context); 
                return _OderTraces;
            }
        }

        private IOrderRepository _Orders;
        public IOrderRepository Orders
        { 
            get
            {
                if(_Orders == null) 
                    _Orders = new OrderRepository(_context); 
                return _Orders;
            }
        }

        private IOrderItemRepository _OrderItems;
        public IOrderItemRepository OrderItems
        { 
            get
            {
                if(_OrderItems == null) 
                    _OrderItems = new OrderItemRepository(_context); 
                return _OrderItems;
            }
        }

        private IOutStockReceiptRepository _OutStockReceipts;
        public IOutStockReceiptRepository OutStockReceipts
        { 
            get
            {
                if(_OutStockReceipts == null) 
                    _OutStockReceipts = new OutStockReceiptRepository(_context); 
                return _OutStockReceipts;
            }
        }

        private IOutStockReceiptDetailRepository _OutStockReceiptDetails;
        public IOutStockReceiptDetailRepository OutStockReceiptDetails
        { 
            get
            {
                if(_OutStockReceiptDetails == null) 
                    _OutStockReceiptDetails = new OutStockReceiptDetailRepository(_context); 
                return _OutStockReceiptDetails;
            }
        }

        private IPermissionRepository _Permissions;
        public IPermissionRepository Permissions
        { 
            get
            {
                if(_Permissions == null) 
                    _Permissions = new PermissionRepository(_context); 
                return _Permissions;
            }
        }

        private IPressRepository _Presss;
        public IPressRepository Presss
        { 
            get
            {
                if(_Presss == null) 
                    _Presss = new PressRepository(_context); 
                return _Presss;
            }
        }

        private IPriceAdjustReceiptRepository _PriceAdjustReceipts;
        public IPriceAdjustReceiptRepository PriceAdjustReceipts
        { 
            get
            {
                if(_PriceAdjustReceipts == null) 
                    _PriceAdjustReceipts = new PriceAdjustReceiptRepository(_context); 
                return _PriceAdjustReceipts;
            }
        }

        private IPriceAdjustReceiptDetailRepository _PriceAdjustReceiptDetails;
        public IPriceAdjustReceiptDetailRepository PriceAdjustReceiptDetails
        { 
            get
            {
                if(_PriceAdjustReceiptDetails == null) 
                    _PriceAdjustReceiptDetails = new PriceAdjustReceiptDetailRepository(_context); 
                return _PriceAdjustReceiptDetails;
            }
        }

        private IPromotionInfoRepository _PromotionInfos;
        public IPromotionInfoRepository PromotionInfos
        { 
            get
            {
                if(_PromotionInfos == null) 
                    _PromotionInfos = new PromotionInfoRepository(_context); 
                return _PromotionInfos;
            }
        }

        private IReceiptInfoRepository _ReceiptInfos;
        public IReceiptInfoRepository ReceiptInfos
        { 
            get
            {
                if(_ReceiptInfos == null) 
                    _ReceiptInfos = new ReceiptInfoRepository(_context); 
                return _ReceiptInfos;
            }
        }

        private IShoppingCartRepository _ShoppingCarts;
        public IShoppingCartRepository ShoppingCarts
        { 
            get
            {
                if(_ShoppingCarts == null) 
                    _ShoppingCarts = new ShoppingCartRepository(_context); 
                return _ShoppingCarts;
            }
        }

        private IStockDamagedReceiptRepository _StockDamagedReceipts;
        public IStockDamagedReceiptRepository StockDamagedReceipts
        { 
            get
            {
                if(_StockDamagedReceipts == null) 
                    _StockDamagedReceipts = new StockDamagedReceiptRepository(_context); 
                return _StockDamagedReceipts;
            }
        }

        private IStockDamagedReceiptDetailRepository _StockDamagedReceiptDetails;
        public IStockDamagedReceiptDetailRepository StockDamagedReceiptDetails
        { 
            get
            {
                if(_StockDamagedReceiptDetails == null) 
                    _StockDamagedReceiptDetails = new StockDamagedReceiptDetailRepository(_context); 
                return _StockDamagedReceiptDetails;
            }
        }

        private IStocktakeReceiptRepository _StocktakeReceipts;
        public IStocktakeReceiptRepository StocktakeReceipts
        { 
            get
            {
                if(_StocktakeReceipts == null) 
                    _StocktakeReceipts = new StocktakeReceiptRepository(_context); 
                return _StocktakeReceipts;
            }
        }

        private IStocktakeReceiptDeatilRepository _StocktakeReceiptDeatils;
        public IStocktakeReceiptDeatilRepository StocktakeReceiptDeatils
        { 
            get
            {
                if(_StocktakeReceiptDeatils == null) 
                    _StocktakeReceiptDeatils = new StocktakeReceiptDeatilRepository(_context); 
                return _StocktakeReceiptDeatils;
            }
        }

        private ISysVariableRepository _SysVariables;
        public ISysVariableRepository SysVariables
        { 
            get
            {
                if(_SysVariables == null) 
                    _SysVariables = new SysVariableRepository(_context); 
                return _SysVariables;
            }
        }

        private IUserRepository _Users;
        public IUserRepository Users
        { 
            get
            {
                if(_Users == null) 
                    _Users = new UserRepository(_context); 
                return _Users;
            }
        }

        private IUserRoleRepository _UserRoles;
        public IUserRoleRepository UserRoles
        { 
            get
            {
                if(_UserRoles == null) 
                    _UserRoles = new UserRoleRepository(_context); 
                return _UserRoles;
            }
        }

        #endregion

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }
    }
}
