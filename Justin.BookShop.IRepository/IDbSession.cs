namespace Justin.BookShop.IRepository
{
    public interface IDbSession
    {
        #region Repository
        IAuthorRepository Authors{ get; }
        IBookRepository Books{ get; }
        IBookCategoryRepository BookCategorys{ get; }
        IBookCommentRepository BookComments{ get; }
        IBookStockRepository BookStocks{ get; }
        IBookStockHistoryRepository BookStockHistorys{ get; }
        ICartItemRepository CartItems{ get; }
        IDepartmentRepository Departments{ get; }
        IInStockReceiptRepository InStockReceipts{ get; }
        IInStockReceiptDetailRepository InStockReceiptDetails{ get; }
        IOderTraceRepository OderTraces{ get; }
        IOrderRepository Orders{ get; }
        IOrderItemRepository OrderItems{ get; }
        IOutStockReceiptRepository OutStockReceipts{ get; }
        IOutStockReceiptDetailRepository OutStockReceiptDetails{ get; }
        IPermissionRepository Permissions{ get; }
        IPressRepository Presss{ get; }
        IPriceAdjustReceiptRepository PriceAdjustReceipts{ get; }
        IPriceAdjustReceiptDetailRepository PriceAdjustReceiptDetails{ get; }
        IPromotionInfoRepository PromotionInfos{ get; }
        IReceiptInfoRepository ReceiptInfos{ get; }
        IShoppingCartRepository ShoppingCarts{ get; }
        IStockDamagedReceiptRepository StockDamagedReceipts{ get; }
        IStockDamagedReceiptDetailRepository StockDamagedReceiptDetails{ get; }
        IStocktakeReceiptRepository StocktakeReceipts{ get; }
        IStocktakeReceiptDeatilRepository StocktakeReceiptDeatils{ get; }
        ISysVariableRepository SysVariables{ get; }
        IUserRepository Users{ get; }
        IUserRoleRepository UserRoles{ get; }
        #endregion

        void SaveChanges();
    }
}