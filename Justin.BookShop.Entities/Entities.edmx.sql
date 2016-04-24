
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/05/2014 14:26:43
-- Generated from EDMX file: C:\Users\justin\Desktop\Justin.BookShop\Justin.BookShop.Entities\Entities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookShopDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_R_User_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_UserRole] DROP CONSTRAINT [FK_R_User_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_UserRole_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_UserRole] DROP CONSTRAINT [FK_R_User_UserRole_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_R_UserRole_Permission_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserRole_Permission] DROP CONSTRAINT [FK_R_UserRole_Permission_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_R_UserRole_Permission_Permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserRole_Permission] DROP CONSTRAINT [FK_R_UserRole_Permission_Permission];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Department_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_R_Department_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Department_UserRole_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Department_UserRole] DROP CONSTRAINT [FK_R_Department_UserRole_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Department_UserRole_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Department_UserRole] DROP CONSTRAINT [FK_R_Department_UserRole_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_BookComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookComments] DROP CONSTRAINT [FK_R_User_BookComment];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Book_BookComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookComments] DROP CONSTRAINT [FK_R_Book_BookComment];
GO
IF OBJECT_ID(N'[dbo].[FK_R_BookPromotionInfo_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_R_BookPromotionInfo_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_PromotionInfo_BookCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_R_PromotionInfo_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_R_PromotionInfo_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Authors] DROP CONSTRAINT [FK_R_PromotionInfo_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Permission_Permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissions] DROP CONSTRAINT [FK_R_Permission_Permission];
GO
IF OBJECT_ID(N'[dbo].[FK_R_BookCategory_BookCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_R_BookCategory_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_R_BookCategory_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_R_BookCategory_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Press_Book_Press]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Press_Book] DROP CONSTRAINT [FK_R_Press_Book_Press];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Press_Book_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Press_Book] DROP CONSTRAINT [FK_R_Press_Book_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Book_Author_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Book_Author] DROP CONSTRAINT [FK_R_Book_Author_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Book_Author_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Book_Author] DROP CONSTRAINT [FK_R_Book_Author_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_R_CartItem_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartItems] DROP CONSTRAINT [FK_R_CartItem_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_ShoppingCart_CartItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartItems] DROP CONSTRAINT [FK_R_ShoppingCart_CartItem];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_Oder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Oders] DROP CONSTRAINT [FK_R_User_Oder];
GO
IF OBJECT_ID(N'[dbo].[FK_R_OderItem_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OderItems] DROP CONSTRAINT [FK_R_OderItem_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Oder_OderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OderItems] DROP CONSTRAINT [FK_R_Oder_OderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_ReceiptInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceiptInfos] DROP CONSTRAINT [FK_R_User_ReceiptInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Oder_ReceiptInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Oders] DROP CONSTRAINT [FK_R_Oder_ReceiptInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_OderTrace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OderTraces] DROP CONSTRAINT [FK_R_User_OderTrace];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Oder_OderTrace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OderTraces] DROP CONSTRAINT [FK_R_Oder_OderTrace];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Book_BookStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookStocks] DROP CONSTRAINT [FK_R_Book_BookStock];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Book_BookStockHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookStockHistorys] DROP CONSTRAINT [FK_R_Book_BookStockHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Press_InStockReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InStockReceipts] DROP CONSTRAINT [FK_R_Press_InStockReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_Submitted_InStockReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InStockReceipts] DROP CONSTRAINT [FK_R_User_Submitted_InStockReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_InStockReceipt_Audited]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InStockReceipts] DROP CONSTRAINT [FK_R_User_InStockReceipt_Audited];
GO
IF OBJECT_ID(N'[dbo].[FK_R_InStockReceipt_InStockReceiptDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InStockReceiptDetails] DROP CONSTRAINT [FK_R_InStockReceipt_InStockReceiptDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_R_InStockReceiptDetail_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InStockReceiptDetails] DROP CONSTRAINT [FK_R_InStockReceiptDetail_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Submitted_OutStockReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OutStockReceipts] DROP CONSTRAINT [FK_R_Submitted_OutStockReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_AuditedOutStockReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OutStockReceipts] DROP CONSTRAINT [FK_R_User_AuditedOutStockReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_R_OutStockReceipt_OutStockReceiptDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OutStockReceiptDetails] DROP CONSTRAINT [FK_R_OutStockReceipt_OutStockReceiptDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_R_OutStockReceiptDetail_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OutStockReceiptDetails] DROP CONSTRAINT [FK_R_OutStockReceiptDetail_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_SubmittedStocktakeReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StocktakeReceipts] DROP CONSTRAINT [FK_R_SubmittedStocktakeReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_AuditedStocktakeReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StocktakeReceipts] DROP CONSTRAINT [FK_R_AuditedStocktakeReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_StocktakeReceipt_StocktakeReceiptDeatil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StocktakeReceiptDeatils] DROP CONSTRAINT [FK_R_StocktakeReceipt_StocktakeReceiptDeatil];
GO
IF OBJECT_ID(N'[dbo].[FK_R_StocktakeReceiptDeatil_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StocktakeReceiptDeatils] DROP CONSTRAINT [FK_R_StocktakeReceiptDeatil_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_SubmittedStockDamagedReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockDamagedReceipts] DROP CONSTRAINT [FK_R_SubmittedStockDamagedReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_AuditedStockDamagedReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockDamagedReceipts] DROP CONSTRAINT [FK_R_AuditedStockDamagedReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_StockDamagedReceipt_StockDamagedReceiptDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockDamagedReceiptDetailss] DROP CONSTRAINT [FK_R_StockDamagedReceipt_StockDamagedReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_R_StockDamagedReceiptDetail_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockDamagedReceiptDetailss] DROP CONSTRAINT [FK_R_StockDamagedReceiptDetail_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_SubmittedPriceAdjustReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PriceAdjustReceipts] DROP CONSTRAINT [FK_R_SubmittedPriceAdjustReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_AuditedPriceAdjustReceipt_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PriceAdjustReceipts] DROP CONSTRAINT [FK_R_AuditedPriceAdjustReceipt_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_PriceAdjustReceipt_PriceAdjustReceiptDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PriceAdjustReceiptDetails] DROP CONSTRAINT [FK_R_PriceAdjustReceipt_PriceAdjustReceiptDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_R_PriceAdjustReceiptDetail_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PriceAdjustReceiptDetails] DROP CONSTRAINT [FK_R_PriceAdjustReceiptDetail_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_Department_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Departments] DROP CONSTRAINT [FK_R_Department_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_UserPermission_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_UserPermission] DROP CONSTRAINT [FK_R_User_UserPermission_User];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_UserPermission_Permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_User_UserPermission] DROP CONSTRAINT [FK_R_User_UserPermission_Permission];
GO
IF OBJECT_ID(N'[dbo].[FK_R_InStockReceipt_InStockReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InStockReceipts] DROP CONSTRAINT [FK_R_InStockReceipt_InStockReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_R_OutStockReceipt_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OutStockReceipts] DROP CONSTRAINT [FK_R_OutStockReceipt_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_R_OutStockReceipt_OutStockReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OutStockReceipts] DROP CONSTRAINT [FK_R_OutStockReceipt_OutStockReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_R_BookCategory_SpecialBook_BookCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_BookCategory_SpecialBook] DROP CONSTRAINT [FK_R_BookCategory_SpecialBook_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_R_BookCategory_SpecialBook_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_BookCategory_SpecialBook] DROP CONSTRAINT [FK_R_BookCategory_SpecialBook_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_ShoppingCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShoppingCarts] DROP CONSTRAINT [FK_R_User_ShoppingCart];
GO
IF OBJECT_ID(N'[dbo].[FK_R_User_AuditOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Oders] DROP CONSTRAINT [FK_R_User_AuditOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissions];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[BookComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookComments];
GO
IF OBJECT_ID(N'[dbo].[BookPromotionInfos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookPromotionInfos];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO
IF OBJECT_ID(N'[dbo].[Presses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Presses];
GO
IF OBJECT_ID(N'[dbo].[ShoppingCarts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShoppingCarts];
GO
IF OBJECT_ID(N'[dbo].[CartItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CartItems];
GO
IF OBJECT_ID(N'[dbo].[Oders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Oders];
GO
IF OBJECT_ID(N'[dbo].[OderItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OderItems];
GO
IF OBJECT_ID(N'[dbo].[ReceiptInfos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceiptInfos];
GO
IF OBJECT_ID(N'[dbo].[OderTraces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OderTraces];
GO
IF OBJECT_ID(N'[dbo].[BookStocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookStocks];
GO
IF OBJECT_ID(N'[dbo].[BookStockHistorys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookStockHistorys];
GO
IF OBJECT_ID(N'[dbo].[InStockReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InStockReceipts];
GO
IF OBJECT_ID(N'[dbo].[InStockReceiptDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InStockReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[OutStockReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OutStockReceipts];
GO
IF OBJECT_ID(N'[dbo].[OutStockReceiptDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OutStockReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[StocktakeReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StocktakeReceipts];
GO
IF OBJECT_ID(N'[dbo].[StocktakeReceiptDeatils]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StocktakeReceiptDeatils];
GO
IF OBJECT_ID(N'[dbo].[StockDamagedReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockDamagedReceipts];
GO
IF OBJECT_ID(N'[dbo].[StockDamagedReceiptDetailss]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockDamagedReceiptDetailss];
GO
IF OBJECT_ID(N'[dbo].[PriceAdjustReceipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PriceAdjustReceipts];
GO
IF OBJECT_ID(N'[dbo].[PriceAdjustReceiptDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PriceAdjustReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[SysVariables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysVariables];
GO
IF OBJECT_ID(N'[dbo].[R_User_UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_UserRole];
GO
IF OBJECT_ID(N'[dbo].[R_UserRole_Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_UserRole_Permission];
GO
IF OBJECT_ID(N'[dbo].[R_Department_UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_Department_UserRole];
GO
IF OBJECT_ID(N'[dbo].[R_Press_Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_Press_Book];
GO
IF OBJECT_ID(N'[dbo].[R_Book_Author]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_Book_Author];
GO
IF OBJECT_ID(N'[dbo].[R_User_UserPermission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_User_UserPermission];
GO
IF OBJECT_ID(N'[dbo].[R_BookCategory_SpecialBook]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_BookCategory_SpecialBook];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [State] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] uniqueidentifier  NOT NULL,
    [LoginName] nvarchar(30)  NOT NULL,
    [Password] nvarchar(40)  NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Age] int  NULL,
    [Gender] bit  NULL,
    [Email] nvarchar(50)  NULL,
    [BirthDate] datetime  NULL,
    [Married] bit  NULL,
    [Phone] nvarchar(50)  NULL,
    [Position] nvarchar(30)  NULL,
    [Salary] decimal(18,0)  NULL,
    [Education] nvarchar(30)  NULL,
    [School] nvarchar(50)  NULL,
    [InUse] bit  NOT NULL,
    [AddedTime] datetime  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [State] int  NULL,
    [Department_ID] int  NULL
);
GO

-- Creating table 'Permissions'
CREATE TABLE [dbo].[Permissions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Controller] nvarchar(30)  NULL,
    [Action] nvarchar(30)  NULL,
    [AlternateLink] nvarchar(max)  NULL,
    [Type] int  NOT NULL,
    [Description] nvarchar(50)  NULL,
    [Sort] int  NOT NULL,
    [Icon] nvarchar(20)  NULL,
    [Parent_ID] int  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Sort] int  NOT NULL,
    [Parent_ID] int  NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [ID] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [MainTitle] nvarchar(50)  NULL,
    [MinorTitle] nvarchar(max)  NULL,
    [OfficialPrice] decimal(18,0)  NOT NULL,
    [AccountPrice] decimal(18,0)  NULL,
    [SellingPrice] decimal(18,0)  NULL,
    [PublicationDate] datetime  NOT NULL,
    [ISBN] nvarchar(30)  NOT NULL,
    [Picture] nvarchar(max)  NULL,
    [Thumbnail] nvarchar(max)  NULL,
    [PrintingTime] datetime  NULL,
    [PageNum] int  NOT NULL,
    [Language] nvarchar(20)  NOT NULL,
    [SalesVolume] int  NULL,
    [Introduction] nvarchar(max)  NULL,
    [Catalog] nvarchar(max)  NULL,
    [Digest] nvarchar(max)  NULL,
    [AddedTime] datetime  NULL,
    [StorageTime] datetime  NULL,
    [OnSale] bit  NOT NULL,
    [PromotedOnFront] bit  NOT NULL,
    [ShowOnBanner] bit  NOT NULL,
    [State] int  NOT NULL,
    [Promotion_ID] uniqueidentifier  NULL,
    [Category_ID] int  NOT NULL
);
GO

-- Creating table 'BookComments'
CREATE TABLE [dbo].[BookComments] (
    [ID] uniqueidentifier  NOT NULL,
    [Score] int  NOT NULL,
    [Experience] nvarchar(max)  NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [CommentDate] datetime  NOT NULL,
    [Purchaser_ID] uniqueidentifier  NOT NULL,
    [CommentOf_ID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BookPromotionInfos'
CREATE TABLE [dbo].[BookPromotionInfos] (
    [ID] uniqueidentifier  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [Promotion_ID] uniqueidentifier  NULL,
    [Parent_ID] int  NULL
);
GO

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [Introduction] nvarchar(max)  NULL,
    [State] int  NOT NULL,
    [Promotion_ID] uniqueidentifier  NULL
);
GO

-- Creating table 'Presses'
CREATE TABLE [dbo].[Presses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [Contact] nvarchar(50)  NULL,
    [State] int  NOT NULL
);
GO

-- Creating table 'ShoppingCarts'
CREATE TABLE [dbo].[ShoppingCarts] (
    [UserID] uniqueidentifier  NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'CartItems'
CREATE TABLE [dbo].[CartItems] (
    [ID] uniqueidentifier  NOT NULL,
    [Quantity] int  NOT NULL,
    [Sort] int  NOT NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [ShoppingCart_UserID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Oders'
CREATE TABLE [dbo].[Oders] (
    [ID] uniqueidentifier  NOT NULL,
    [NO] nvarchar(max)  NOT NULL,
    [OrderPrice] decimal(18,0)  NOT NULL,
    [SubmitDate] datetime  NOT NULL,
    [State] int  NOT NULL,
    [Freight] decimal(18,0)  NOT NULL,
    [ShipDate] datetime  NULL,
    [ReceiptID] uniqueidentifier  NOT NULL,
    [UserID] uniqueidentifier  NOT NULL,
    [IsAudited] bit  NOT NULL,
    [AuditDate] datetime  NULL,
    [AuditUserID] uniqueidentifier  NULL
);
GO

-- Creating table 'OderItems'
CREATE TABLE [dbo].[OderItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [Quantity] int  NOT NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [OrderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ReceiptInfos'
CREATE TABLE [dbo].[ReceiptInfos] (
    [ID] uniqueidentifier  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [ReceiptName] nvarchar(30)  NOT NULL,
    [Phone] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [ReceiptOf_ID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'OderTraces'
CREATE TABLE [dbo].[OderTraces] (
    [ID] uniqueidentifier  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [SubmitTime] datetime  NOT NULL,
    [SubmittedUserID] uniqueidentifier  NOT NULL,
    [OrderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BookStocks'
CREATE TABLE [dbo].[BookStocks] (
    [ID] uniqueidentifier  NOT NULL,
    [PriorPeriodQuantity] int  NOT NULL,
    [PriorPeriodMoney] decimal(18,0)  NOT NULL,
    [EntryQuantity] int  NOT NULL,
    [EntryMoney] decimal(18,0)  NOT NULL,
    [OutQuantity] int  NOT NULL,
    [OutMoney] decimal(18,0)  NOT NULL,
    [StocktakeQuantity] int  NOT NULL,
    [StocktakeMoney] decimal(18,0)  NOT NULL,
    [DamagedQuantity] int  NOT NULL,
    [DamagedMoney] decimal(18,0)  NOT NULL,
    [AdjustMoney] decimal(18,0)  NOT NULL,
    [ThisPeriodQuantity] int  NOT NULL,
    [ThisPeriodMoney] decimal(18,0)  NOT NULL,
    [StockOf_ID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BookStockHistorys'
CREATE TABLE [dbo].[BookStockHistorys] (
    [ID] uniqueidentifier  NOT NULL,
    [Period] nvarchar(max)  NOT NULL,
    [PriorPeriodQuantity] int  NOT NULL,
    [PriorPeriodMoney] decimal(18,0)  NOT NULL,
    [EntryQuantity] int  NOT NULL,
    [EntryMoney] decimal(18,0)  NOT NULL,
    [OutQuantity] int  NOT NULL,
    [OutMoney] decimal(18,0)  NOT NULL,
    [StocktakeQuantity] int  NOT NULL,
    [StocktakeMoney] decimal(18,0)  NOT NULL,
    [DamagedQuantity] int  NOT NULL,
    [DamagedMoney] decimal(18,0)  NOT NULL,
    [AdjustMoney] decimal(18,0)  NOT NULL,
    [ThisPeriodQuantity] int  NOT NULL,
    [ThisPeriodMoney] decimal(18,0)  NOT NULL,
    [StockHistoryOf_ID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'InStockReceipts'
CREATE TABLE [dbo].[InStockReceipts] (
    [ID] uniqueidentifier  NOT NULL,
    [NO] nvarchar(12)  NOT NULL,
    [PressNo] nvarchar(12)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubmitDate] datetime  NOT NULL,
    [AuditDate] datetime  NULL,
    [IsAudited] bit  NOT NULL,
    [PressID] int  NOT NULL,
    [SubmittedBy_ID] uniqueidentifier  NOT NULL,
    [AuditedBy_ID] uniqueidentifier  NULL,
    [BeforeVoidReceipt_ID] uniqueidentifier  NULL
);
GO

-- Creating table 'InStockReceiptDetails'
CREATE TABLE [dbo].[InStockReceiptDetails] (
    [ID] uniqueidentifier  NOT NULL,
    [Sort] int  NOT NULL,
    [EntryQuantity] int  NOT NULL,
    [EntryUnitPrice] decimal(18,0)  NOT NULL,
    [AccountPrice] decimal(18,0)  NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [HeaderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'OutStockReceipts'
CREATE TABLE [dbo].[OutStockReceipts] (
    [ID] uniqueidentifier  NOT NULL,
    [NO] nvarchar(12)  NOT NULL,
    [Freight] decimal(18,0)  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubmitDate] datetime  NOT NULL,
    [AuditDate] datetime  NULL,
    [IsAudited] bit  NOT NULL,
    [OrderID] uniqueidentifier  NULL,
    [SubmittedBy_ID] uniqueidentifier  NOT NULL,
    [AuditedBy_ID] uniqueidentifier  NULL,
    [BeforeVoidReceipt_ID] uniqueidentifier  NULL
);
GO

-- Creating table 'OutStockReceiptDetails'
CREATE TABLE [dbo].[OutStockReceiptDetails] (
    [ID] uniqueidentifier  NOT NULL,
    [Sort] int  NOT NULL,
    [OutQuantity] int  NOT NULL,
    [OutUnitPrice] decimal(18,0)  NOT NULL,
    [AccountPrice] decimal(18,0)  NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [HeaderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'StocktakeReceipts'
CREATE TABLE [dbo].[StocktakeReceipts] (
    [ID] uniqueidentifier  NOT NULL,
    [NO] nvarchar(12)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubmitDate] datetime  NOT NULL,
    [AuditDate] datetime  NULL,
    [IsAudited] bit  NOT NULL,
    [SubmittedBy_ID] uniqueidentifier  NOT NULL,
    [AuditedBy_ID] uniqueidentifier  NULL
);
GO

-- Creating table 'StocktakeReceiptDeatils'
CREATE TABLE [dbo].[StocktakeReceiptDeatils] (
    [ID] uniqueidentifier  NOT NULL,
    [Sort] int  NOT NULL,
    [TakeQuantity] int  NOT NULL,
    [AccountPrice] decimal(18,0)  NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [HeaderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'StockDamagedReceipts'
CREATE TABLE [dbo].[StockDamagedReceipts] (
    [ID] uniqueidentifier  NOT NULL,
    [NO] nvarchar(12)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubmitDate] datetime  NOT NULL,
    [AuditDate] datetime  NULL,
    [IsAudited] bit  NOT NULL,
    [SubmittedBy_ID] uniqueidentifier  NOT NULL,
    [AuditedBy_ID] uniqueidentifier  NULL
);
GO

-- Creating table 'StockDamagedReceiptDetailss'
CREATE TABLE [dbo].[StockDamagedReceiptDetailss] (
    [ID] uniqueidentifier  NOT NULL,
    [Sort] int  NOT NULL,
    [DamagedQuantity] int  NOT NULL,
    [AccountPrice] decimal(18,0)  NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [HeaderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PriceAdjustReceipts'
CREATE TABLE [dbo].[PriceAdjustReceipts] (
    [ID] uniqueidentifier  NOT NULL,
    [NO] nvarchar(12)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubmitDate] datetime  NOT NULL,
    [AuditDate] datetime  NULL,
    [IsAudited] bit  NOT NULL,
    [SubmittedBy_ID] uniqueidentifier  NOT NULL,
    [AuditedBy_ID] uniqueidentifier  NULL
);
GO

-- Creating table 'PriceAdjustReceiptDetails'
CREATE TABLE [dbo].[PriceAdjustReceiptDetails] (
    [ID] uniqueidentifier  NOT NULL,
    [Sort] int  NOT NULL,
    [AdjustQuantity] int  NOT NULL,
    [NewAccountPrice] decimal(18,0)  NOT NULL,
    [OldAccountPrice] decimal(18,0)  NULL,
    [BookID] uniqueidentifier  NOT NULL,
    [HeaderID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'SysVariables'
CREATE TABLE [dbo].[SysVariables] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TraceInfos'
CREATE TABLE [dbo].[TraceInfos] (
    [UserID] uniqueidentifier  NOT NULL,
    [Info] nvarchar(max)  NULL
);
GO

-- Creating table 'R_User_UserRole'
CREATE TABLE [dbo].[R_User_UserRole] (
    [AuthorizedUsers_ID] uniqueidentifier  NOT NULL,
    [Roles_ID] int  NOT NULL
);
GO

-- Creating table 'R_UserRole_Permission'
CREATE TABLE [dbo].[R_UserRole_Permission] (
    [AuthorizedRoles_ID] int  NOT NULL,
    [Permissions_ID] int  NOT NULL
);
GO

-- Creating table 'R_Department_UserRole'
CREATE TABLE [dbo].[R_Department_UserRole] (
    [AuthorizedDepartments_ID] int  NOT NULL,
    [Roles_ID] int  NOT NULL
);
GO

-- Creating table 'R_Press_Book'
CREATE TABLE [dbo].[R_Press_Book] (
    [Presses_ID] int  NOT NULL,
    [Books_ID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'R_Book_Author'
CREATE TABLE [dbo].[R_Book_Author] (
    [Books_ID] uniqueidentifier  NOT NULL,
    [Authors_ID] int  NOT NULL
);
GO

-- Creating table 'R_User_UserPermission'
CREATE TABLE [dbo].[R_User_UserPermission] (
    [AuthorizedUsers_ID] uniqueidentifier  NOT NULL,
    [Permissions_ID] int  NOT NULL
);
GO

-- Creating table 'R_BookCategory_SpecialBook'
CREATE TABLE [dbo].[R_BookCategory_SpecialBook] (
    [SpecialCategories_ID] int  NOT NULL,
    [SpecialBooks_ID] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [PK_Permissions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookComments'
ALTER TABLE [dbo].[BookComments]
ADD CONSTRAINT [PK_BookComments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookPromotionInfos'
ALTER TABLE [dbo].[BookPromotionInfos]
ADD CONSTRAINT [PK_BookPromotionInfos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Presses'
ALTER TABLE [dbo].[Presses]
ADD CONSTRAINT [PK_Presses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserID] in table 'ShoppingCarts'
ALTER TABLE [dbo].[ShoppingCarts]
ADD CONSTRAINT [PK_ShoppingCarts]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [ID] in table 'CartItems'
ALTER TABLE [dbo].[CartItems]
ADD CONSTRAINT [PK_CartItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Oders'
ALTER TABLE [dbo].[Oders]
ADD CONSTRAINT [PK_Oders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OderItems'
ALTER TABLE [dbo].[OderItems]
ADD CONSTRAINT [PK_OderItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ReceiptInfos'
ALTER TABLE [dbo].[ReceiptInfos]
ADD CONSTRAINT [PK_ReceiptInfos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OderTraces'
ALTER TABLE [dbo].[OderTraces]
ADD CONSTRAINT [PK_OderTraces]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookStocks'
ALTER TABLE [dbo].[BookStocks]
ADD CONSTRAINT [PK_BookStocks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookStockHistorys'
ALTER TABLE [dbo].[BookStockHistorys]
ADD CONSTRAINT [PK_BookStockHistorys]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InStockReceipts'
ALTER TABLE [dbo].[InStockReceipts]
ADD CONSTRAINT [PK_InStockReceipts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InStockReceiptDetails'
ALTER TABLE [dbo].[InStockReceiptDetails]
ADD CONSTRAINT [PK_InStockReceiptDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OutStockReceipts'
ALTER TABLE [dbo].[OutStockReceipts]
ADD CONSTRAINT [PK_OutStockReceipts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OutStockReceiptDetails'
ALTER TABLE [dbo].[OutStockReceiptDetails]
ADD CONSTRAINT [PK_OutStockReceiptDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StocktakeReceipts'
ALTER TABLE [dbo].[StocktakeReceipts]
ADD CONSTRAINT [PK_StocktakeReceipts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StocktakeReceiptDeatils'
ALTER TABLE [dbo].[StocktakeReceiptDeatils]
ADD CONSTRAINT [PK_StocktakeReceiptDeatils]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StockDamagedReceipts'
ALTER TABLE [dbo].[StockDamagedReceipts]
ADD CONSTRAINT [PK_StockDamagedReceipts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StockDamagedReceiptDetailss'
ALTER TABLE [dbo].[StockDamagedReceiptDetailss]
ADD CONSTRAINT [PK_StockDamagedReceiptDetailss]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PriceAdjustReceipts'
ALTER TABLE [dbo].[PriceAdjustReceipts]
ADD CONSTRAINT [PK_PriceAdjustReceipts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PriceAdjustReceiptDetails'
ALTER TABLE [dbo].[PriceAdjustReceiptDetails]
ADD CONSTRAINT [PK_PriceAdjustReceiptDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysVariables'
ALTER TABLE [dbo].[SysVariables]
ADD CONSTRAINT [PK_SysVariables]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserID] in table 'TraceInfos'
ALTER TABLE [dbo].[TraceInfos]
ADD CONSTRAINT [PK_TraceInfos]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [AuthorizedUsers_ID], [Roles_ID] in table 'R_User_UserRole'
ALTER TABLE [dbo].[R_User_UserRole]
ADD CONSTRAINT [PK_R_User_UserRole]
    PRIMARY KEY NONCLUSTERED ([AuthorizedUsers_ID], [Roles_ID] ASC);
GO

-- Creating primary key on [AuthorizedRoles_ID], [Permissions_ID] in table 'R_UserRole_Permission'
ALTER TABLE [dbo].[R_UserRole_Permission]
ADD CONSTRAINT [PK_R_UserRole_Permission]
    PRIMARY KEY NONCLUSTERED ([AuthorizedRoles_ID], [Permissions_ID] ASC);
GO

-- Creating primary key on [AuthorizedDepartments_ID], [Roles_ID] in table 'R_Department_UserRole'
ALTER TABLE [dbo].[R_Department_UserRole]
ADD CONSTRAINT [PK_R_Department_UserRole]
    PRIMARY KEY NONCLUSTERED ([AuthorizedDepartments_ID], [Roles_ID] ASC);
GO

-- Creating primary key on [Presses_ID], [Books_ID] in table 'R_Press_Book'
ALTER TABLE [dbo].[R_Press_Book]
ADD CONSTRAINT [PK_R_Press_Book]
    PRIMARY KEY NONCLUSTERED ([Presses_ID], [Books_ID] ASC);
GO

-- Creating primary key on [Books_ID], [Authors_ID] in table 'R_Book_Author'
ALTER TABLE [dbo].[R_Book_Author]
ADD CONSTRAINT [PK_R_Book_Author]
    PRIMARY KEY NONCLUSTERED ([Books_ID], [Authors_ID] ASC);
GO

-- Creating primary key on [AuthorizedUsers_ID], [Permissions_ID] in table 'R_User_UserPermission'
ALTER TABLE [dbo].[R_User_UserPermission]
ADD CONSTRAINT [PK_R_User_UserPermission]
    PRIMARY KEY NONCLUSTERED ([AuthorizedUsers_ID], [Permissions_ID] ASC);
GO

-- Creating primary key on [SpecialCategories_ID], [SpecialBooks_ID] in table 'R_BookCategory_SpecialBook'
ALTER TABLE [dbo].[R_BookCategory_SpecialBook]
ADD CONSTRAINT [PK_R_BookCategory_SpecialBook]
    PRIMARY KEY NONCLUSTERED ([SpecialCategories_ID], [SpecialBooks_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AuthorizedUsers_ID] in table 'R_User_UserRole'
ALTER TABLE [dbo].[R_User_UserRole]
ADD CONSTRAINT [FK_R_User_UserRole_User]
    FOREIGN KEY ([AuthorizedUsers_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_ID] in table 'R_User_UserRole'
ALTER TABLE [dbo].[R_User_UserRole]
ADD CONSTRAINT [FK_R_User_UserRole_UserRole]
    FOREIGN KEY ([Roles_ID])
    REFERENCES [dbo].[UserRoles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_UserRole_UserRole'
CREATE INDEX [IX_FK_R_User_UserRole_UserRole]
ON [dbo].[R_User_UserRole]
    ([Roles_ID]);
GO

-- Creating foreign key on [AuthorizedRoles_ID] in table 'R_UserRole_Permission'
ALTER TABLE [dbo].[R_UserRole_Permission]
ADD CONSTRAINT [FK_R_UserRole_Permission_UserRole]
    FOREIGN KEY ([AuthorizedRoles_ID])
    REFERENCES [dbo].[UserRoles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Permissions_ID] in table 'R_UserRole_Permission'
ALTER TABLE [dbo].[R_UserRole_Permission]
ADD CONSTRAINT [FK_R_UserRole_Permission_Permission]
    FOREIGN KEY ([Permissions_ID])
    REFERENCES [dbo].[Permissions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_UserRole_Permission_Permission'
CREATE INDEX [IX_FK_R_UserRole_Permission_Permission]
ON [dbo].[R_UserRole_Permission]
    ([Permissions_ID]);
GO

-- Creating foreign key on [Department_ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_R_Department_User]
    FOREIGN KEY ([Department_ID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Department_User'
CREATE INDEX [IX_FK_R_Department_User]
ON [dbo].[Users]
    ([Department_ID]);
GO

-- Creating foreign key on [AuthorizedDepartments_ID] in table 'R_Department_UserRole'
ALTER TABLE [dbo].[R_Department_UserRole]
ADD CONSTRAINT [FK_R_Department_UserRole_Department]
    FOREIGN KEY ([AuthorizedDepartments_ID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_ID] in table 'R_Department_UserRole'
ALTER TABLE [dbo].[R_Department_UserRole]
ADD CONSTRAINT [FK_R_Department_UserRole_UserRole]
    FOREIGN KEY ([Roles_ID])
    REFERENCES [dbo].[UserRoles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Department_UserRole_UserRole'
CREATE INDEX [IX_FK_R_Department_UserRole_UserRole]
ON [dbo].[R_Department_UserRole]
    ([Roles_ID]);
GO

-- Creating foreign key on [Purchaser_ID] in table 'BookComments'
ALTER TABLE [dbo].[BookComments]
ADD CONSTRAINT [FK_R_User_BookComment]
    FOREIGN KEY ([Purchaser_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_BookComment'
CREATE INDEX [IX_FK_R_User_BookComment]
ON [dbo].[BookComments]
    ([Purchaser_ID]);
GO

-- Creating foreign key on [CommentOf_ID] in table 'BookComments'
ALTER TABLE [dbo].[BookComments]
ADD CONSTRAINT [FK_R_Book_BookComment]
    FOREIGN KEY ([CommentOf_ID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Book_BookComment'
CREATE INDEX [IX_FK_R_Book_BookComment]
ON [dbo].[BookComments]
    ([CommentOf_ID]);
GO

-- Creating foreign key on [Promotion_ID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_R_BookPromotionInfo_Book]
    FOREIGN KEY ([Promotion_ID])
    REFERENCES [dbo].[BookPromotionInfos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_BookPromotionInfo_Book'
CREATE INDEX [IX_FK_R_BookPromotionInfo_Book]
ON [dbo].[Books]
    ([Promotion_ID]);
GO

-- Creating foreign key on [Promotion_ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_R_PromotionInfo_BookCategory]
    FOREIGN KEY ([Promotion_ID])
    REFERENCES [dbo].[BookPromotionInfos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_PromotionInfo_BookCategory'
CREATE INDEX [IX_FK_R_PromotionInfo_BookCategory]
ON [dbo].[Categories]
    ([Promotion_ID]);
GO

-- Creating foreign key on [Promotion_ID] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [FK_R_PromotionInfo_Author]
    FOREIGN KEY ([Promotion_ID])
    REFERENCES [dbo].[BookPromotionInfos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_PromotionInfo_Author'
CREATE INDEX [IX_FK_R_PromotionInfo_Author]
ON [dbo].[Authors]
    ([Promotion_ID]);
GO

-- Creating foreign key on [Parent_ID] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [FK_R_Permission_Permission]
    FOREIGN KEY ([Parent_ID])
    REFERENCES [dbo].[Permissions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Permission_Permission'
CREATE INDEX [IX_FK_R_Permission_Permission]
ON [dbo].[Permissions]
    ([Parent_ID]);
GO

-- Creating foreign key on [Parent_ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_R_BookCategory_BookCategory]
    FOREIGN KEY ([Parent_ID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_BookCategory_BookCategory'
CREATE INDEX [IX_FK_R_BookCategory_BookCategory]
ON [dbo].[Categories]
    ([Parent_ID]);
GO

-- Creating foreign key on [Category_ID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_R_BookCategory_Book]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_BookCategory_Book'
CREATE INDEX [IX_FK_R_BookCategory_Book]
ON [dbo].[Books]
    ([Category_ID]);
GO

-- Creating foreign key on [Presses_ID] in table 'R_Press_Book'
ALTER TABLE [dbo].[R_Press_Book]
ADD CONSTRAINT [FK_R_Press_Book_Press]
    FOREIGN KEY ([Presses_ID])
    REFERENCES [dbo].[Presses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Books_ID] in table 'R_Press_Book'
ALTER TABLE [dbo].[R_Press_Book]
ADD CONSTRAINT [FK_R_Press_Book_Book]
    FOREIGN KEY ([Books_ID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Press_Book_Book'
CREATE INDEX [IX_FK_R_Press_Book_Book]
ON [dbo].[R_Press_Book]
    ([Books_ID]);
GO

-- Creating foreign key on [Books_ID] in table 'R_Book_Author'
ALTER TABLE [dbo].[R_Book_Author]
ADD CONSTRAINT [FK_R_Book_Author_Book]
    FOREIGN KEY ([Books_ID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authors_ID] in table 'R_Book_Author'
ALTER TABLE [dbo].[R_Book_Author]
ADD CONSTRAINT [FK_R_Book_Author_Author]
    FOREIGN KEY ([Authors_ID])
    REFERENCES [dbo].[Authors]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Book_Author_Author'
CREATE INDEX [IX_FK_R_Book_Author_Author]
ON [dbo].[R_Book_Author]
    ([Authors_ID]);
GO

-- Creating foreign key on [BookID] in table 'CartItems'
ALTER TABLE [dbo].[CartItems]
ADD CONSTRAINT [FK_R_CartItem_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_CartItem_Book'
CREATE INDEX [IX_FK_R_CartItem_Book]
ON [dbo].[CartItems]
    ([BookID]);
GO

-- Creating foreign key on [ShoppingCart_UserID] in table 'CartItems'
ALTER TABLE [dbo].[CartItems]
ADD CONSTRAINT [FK_R_ShoppingCart_CartItem]
    FOREIGN KEY ([ShoppingCart_UserID])
    REFERENCES [dbo].[ShoppingCarts]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_ShoppingCart_CartItem'
CREATE INDEX [IX_FK_R_ShoppingCart_CartItem]
ON [dbo].[CartItems]
    ([ShoppingCart_UserID]);
GO

-- Creating foreign key on [UserID] in table 'Oders'
ALTER TABLE [dbo].[Oders]
ADD CONSTRAINT [FK_R_User_Oder]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_Oder'
CREATE INDEX [IX_FK_R_User_Oder]
ON [dbo].[Oders]
    ([UserID]);
GO

-- Creating foreign key on [BookID] in table 'OderItems'
ALTER TABLE [dbo].[OderItems]
ADD CONSTRAINT [FK_R_OderItem_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_OderItem_Book'
CREATE INDEX [IX_FK_R_OderItem_Book]
ON [dbo].[OderItems]
    ([BookID]);
GO

-- Creating foreign key on [OrderID] in table 'OderItems'
ALTER TABLE [dbo].[OderItems]
ADD CONSTRAINT [FK_R_Oder_OderItem]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Oders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Oder_OderItem'
CREATE INDEX [IX_FK_R_Oder_OderItem]
ON [dbo].[OderItems]
    ([OrderID]);
GO

-- Creating foreign key on [ReceiptOf_ID] in table 'ReceiptInfos'
ALTER TABLE [dbo].[ReceiptInfos]
ADD CONSTRAINT [FK_R_User_ReceiptInfo]
    FOREIGN KEY ([ReceiptOf_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_ReceiptInfo'
CREATE INDEX [IX_FK_R_User_ReceiptInfo]
ON [dbo].[ReceiptInfos]
    ([ReceiptOf_ID]);
GO

-- Creating foreign key on [ReceiptID] in table 'Oders'
ALTER TABLE [dbo].[Oders]
ADD CONSTRAINT [FK_R_Oder_ReceiptInfo]
    FOREIGN KEY ([ReceiptID])
    REFERENCES [dbo].[ReceiptInfos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Oder_ReceiptInfo'
CREATE INDEX [IX_FK_R_Oder_ReceiptInfo]
ON [dbo].[Oders]
    ([ReceiptID]);
GO

-- Creating foreign key on [SubmittedUserID] in table 'OderTraces'
ALTER TABLE [dbo].[OderTraces]
ADD CONSTRAINT [FK_R_User_OderTrace]
    FOREIGN KEY ([SubmittedUserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_OderTrace'
CREATE INDEX [IX_FK_R_User_OderTrace]
ON [dbo].[OderTraces]
    ([SubmittedUserID]);
GO

-- Creating foreign key on [OrderID] in table 'OderTraces'
ALTER TABLE [dbo].[OderTraces]
ADD CONSTRAINT [FK_R_Oder_OderTrace]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Oders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Oder_OderTrace'
CREATE INDEX [IX_FK_R_Oder_OderTrace]
ON [dbo].[OderTraces]
    ([OrderID]);
GO

-- Creating foreign key on [StockOf_ID] in table 'BookStocks'
ALTER TABLE [dbo].[BookStocks]
ADD CONSTRAINT [FK_R_Book_BookStock]
    FOREIGN KEY ([StockOf_ID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Book_BookStock'
CREATE INDEX [IX_FK_R_Book_BookStock]
ON [dbo].[BookStocks]
    ([StockOf_ID]);
GO

-- Creating foreign key on [StockHistoryOf_ID] in table 'BookStockHistorys'
ALTER TABLE [dbo].[BookStockHistorys]
ADD CONSTRAINT [FK_R_Book_BookStockHistory]
    FOREIGN KEY ([StockHistoryOf_ID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Book_BookStockHistory'
CREATE INDEX [IX_FK_R_Book_BookStockHistory]
ON [dbo].[BookStockHistorys]
    ([StockHistoryOf_ID]);
GO

-- Creating foreign key on [PressID] in table 'InStockReceipts'
ALTER TABLE [dbo].[InStockReceipts]
ADD CONSTRAINT [FK_R_Press_InStockReceipt]
    FOREIGN KEY ([PressID])
    REFERENCES [dbo].[Presses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Press_InStockReceipt'
CREATE INDEX [IX_FK_R_Press_InStockReceipt]
ON [dbo].[InStockReceipts]
    ([PressID]);
GO

-- Creating foreign key on [SubmittedBy_ID] in table 'InStockReceipts'
ALTER TABLE [dbo].[InStockReceipts]
ADD CONSTRAINT [FK_R_User_Submitted_InStockReceipt]
    FOREIGN KEY ([SubmittedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_Submitted_InStockReceipt'
CREATE INDEX [IX_FK_R_User_Submitted_InStockReceipt]
ON [dbo].[InStockReceipts]
    ([SubmittedBy_ID]);
GO

-- Creating foreign key on [AuditedBy_ID] in table 'InStockReceipts'
ALTER TABLE [dbo].[InStockReceipts]
ADD CONSTRAINT [FK_R_User_InStockReceipt_Audited]
    FOREIGN KEY ([AuditedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_InStockReceipt_Audited'
CREATE INDEX [IX_FK_R_User_InStockReceipt_Audited]
ON [dbo].[InStockReceipts]
    ([AuditedBy_ID]);
GO

-- Creating foreign key on [HeaderID] in table 'InStockReceiptDetails'
ALTER TABLE [dbo].[InStockReceiptDetails]
ADD CONSTRAINT [FK_R_InStockReceipt_InStockReceiptDetail]
    FOREIGN KEY ([HeaderID])
    REFERENCES [dbo].[InStockReceipts]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_InStockReceipt_InStockReceiptDetail'
CREATE INDEX [IX_FK_R_InStockReceipt_InStockReceiptDetail]
ON [dbo].[InStockReceiptDetails]
    ([HeaderID]);
GO

-- Creating foreign key on [BookID] in table 'InStockReceiptDetails'
ALTER TABLE [dbo].[InStockReceiptDetails]
ADD CONSTRAINT [FK_R_InStockReceiptDetail_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_InStockReceiptDetail_Book'
CREATE INDEX [IX_FK_R_InStockReceiptDetail_Book]
ON [dbo].[InStockReceiptDetails]
    ([BookID]);
GO

-- Creating foreign key on [SubmittedBy_ID] in table 'OutStockReceipts'
ALTER TABLE [dbo].[OutStockReceipts]
ADD CONSTRAINT [FK_R_Submitted_OutStockReceipt_User]
    FOREIGN KEY ([SubmittedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Submitted_OutStockReceipt_User'
CREATE INDEX [IX_FK_R_Submitted_OutStockReceipt_User]
ON [dbo].[OutStockReceipts]
    ([SubmittedBy_ID]);
GO

-- Creating foreign key on [AuditedBy_ID] in table 'OutStockReceipts'
ALTER TABLE [dbo].[OutStockReceipts]
ADD CONSTRAINT [FK_R_User_AuditedOutStockReceipt]
    FOREIGN KEY ([AuditedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_AuditedOutStockReceipt'
CREATE INDEX [IX_FK_R_User_AuditedOutStockReceipt]
ON [dbo].[OutStockReceipts]
    ([AuditedBy_ID]);
GO

-- Creating foreign key on [HeaderID] in table 'OutStockReceiptDetails'
ALTER TABLE [dbo].[OutStockReceiptDetails]
ADD CONSTRAINT [FK_R_OutStockReceipt_OutStockReceiptDetail]
    FOREIGN KEY ([HeaderID])
    REFERENCES [dbo].[OutStockReceipts]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_OutStockReceipt_OutStockReceiptDetail'
CREATE INDEX [IX_FK_R_OutStockReceipt_OutStockReceiptDetail]
ON [dbo].[OutStockReceiptDetails]
    ([HeaderID]);
GO

-- Creating foreign key on [BookID] in table 'OutStockReceiptDetails'
ALTER TABLE [dbo].[OutStockReceiptDetails]
ADD CONSTRAINT [FK_R_OutStockReceiptDetail_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_OutStockReceiptDetail_Book'
CREATE INDEX [IX_FK_R_OutStockReceiptDetail_Book]
ON [dbo].[OutStockReceiptDetails]
    ([BookID]);
GO

-- Creating foreign key on [SubmittedBy_ID] in table 'StocktakeReceipts'
ALTER TABLE [dbo].[StocktakeReceipts]
ADD CONSTRAINT [FK_R_SubmittedStocktakeReceipt_User]
    FOREIGN KEY ([SubmittedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_SubmittedStocktakeReceipt_User'
CREATE INDEX [IX_FK_R_SubmittedStocktakeReceipt_User]
ON [dbo].[StocktakeReceipts]
    ([SubmittedBy_ID]);
GO

-- Creating foreign key on [AuditedBy_ID] in table 'StocktakeReceipts'
ALTER TABLE [dbo].[StocktakeReceipts]
ADD CONSTRAINT [FK_R_AuditedStocktakeReceipt_User]
    FOREIGN KEY ([AuditedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_AuditedStocktakeReceipt_User'
CREATE INDEX [IX_FK_R_AuditedStocktakeReceipt_User]
ON [dbo].[StocktakeReceipts]
    ([AuditedBy_ID]);
GO

-- Creating foreign key on [HeaderID] in table 'StocktakeReceiptDeatils'
ALTER TABLE [dbo].[StocktakeReceiptDeatils]
ADD CONSTRAINT [FK_R_StocktakeReceipt_StocktakeReceiptDeatil]
    FOREIGN KEY ([HeaderID])
    REFERENCES [dbo].[StocktakeReceipts]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_StocktakeReceipt_StocktakeReceiptDeatil'
CREATE INDEX [IX_FK_R_StocktakeReceipt_StocktakeReceiptDeatil]
ON [dbo].[StocktakeReceiptDeatils]
    ([HeaderID]);
GO

-- Creating foreign key on [BookID] in table 'StocktakeReceiptDeatils'
ALTER TABLE [dbo].[StocktakeReceiptDeatils]
ADD CONSTRAINT [FK_R_StocktakeReceiptDeatil_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_StocktakeReceiptDeatil_Book'
CREATE INDEX [IX_FK_R_StocktakeReceiptDeatil_Book]
ON [dbo].[StocktakeReceiptDeatils]
    ([BookID]);
GO

-- Creating foreign key on [SubmittedBy_ID] in table 'StockDamagedReceipts'
ALTER TABLE [dbo].[StockDamagedReceipts]
ADD CONSTRAINT [FK_R_SubmittedStockDamagedReceipt_User]
    FOREIGN KEY ([SubmittedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_SubmittedStockDamagedReceipt_User'
CREATE INDEX [IX_FK_R_SubmittedStockDamagedReceipt_User]
ON [dbo].[StockDamagedReceipts]
    ([SubmittedBy_ID]);
GO

-- Creating foreign key on [AuditedBy_ID] in table 'StockDamagedReceipts'
ALTER TABLE [dbo].[StockDamagedReceipts]
ADD CONSTRAINT [FK_R_AuditedStockDamagedReceipt_User]
    FOREIGN KEY ([AuditedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_AuditedStockDamagedReceipt_User'
CREATE INDEX [IX_FK_R_AuditedStockDamagedReceipt_User]
ON [dbo].[StockDamagedReceipts]
    ([AuditedBy_ID]);
GO

-- Creating foreign key on [HeaderID] in table 'StockDamagedReceiptDetailss'
ALTER TABLE [dbo].[StockDamagedReceiptDetailss]
ADD CONSTRAINT [FK_R_StockDamagedReceipt_StockDamagedReceiptDetails]
    FOREIGN KEY ([HeaderID])
    REFERENCES [dbo].[StockDamagedReceipts]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_StockDamagedReceipt_StockDamagedReceiptDetails'
CREATE INDEX [IX_FK_R_StockDamagedReceipt_StockDamagedReceiptDetails]
ON [dbo].[StockDamagedReceiptDetailss]
    ([HeaderID]);
GO

-- Creating foreign key on [BookID] in table 'StockDamagedReceiptDetailss'
ALTER TABLE [dbo].[StockDamagedReceiptDetailss]
ADD CONSTRAINT [FK_R_StockDamagedReceiptDetail_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_StockDamagedReceiptDetail_Book'
CREATE INDEX [IX_FK_R_StockDamagedReceiptDetail_Book]
ON [dbo].[StockDamagedReceiptDetailss]
    ([BookID]);
GO

-- Creating foreign key on [SubmittedBy_ID] in table 'PriceAdjustReceipts'
ALTER TABLE [dbo].[PriceAdjustReceipts]
ADD CONSTRAINT [FK_R_SubmittedPriceAdjustReceipt_User]
    FOREIGN KEY ([SubmittedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_SubmittedPriceAdjustReceipt_User'
CREATE INDEX [IX_FK_R_SubmittedPriceAdjustReceipt_User]
ON [dbo].[PriceAdjustReceipts]
    ([SubmittedBy_ID]);
GO

-- Creating foreign key on [AuditedBy_ID] in table 'PriceAdjustReceipts'
ALTER TABLE [dbo].[PriceAdjustReceipts]
ADD CONSTRAINT [FK_R_AuditedPriceAdjustReceipt_User]
    FOREIGN KEY ([AuditedBy_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_AuditedPriceAdjustReceipt_User'
CREATE INDEX [IX_FK_R_AuditedPriceAdjustReceipt_User]
ON [dbo].[PriceAdjustReceipts]
    ([AuditedBy_ID]);
GO

-- Creating foreign key on [HeaderID] in table 'PriceAdjustReceiptDetails'
ALTER TABLE [dbo].[PriceAdjustReceiptDetails]
ADD CONSTRAINT [FK_R_PriceAdjustReceipt_PriceAdjustReceiptDetail]
    FOREIGN KEY ([HeaderID])
    REFERENCES [dbo].[PriceAdjustReceipts]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_PriceAdjustReceipt_PriceAdjustReceiptDetail'
CREATE INDEX [IX_FK_R_PriceAdjustReceipt_PriceAdjustReceiptDetail]
ON [dbo].[PriceAdjustReceiptDetails]
    ([HeaderID]);
GO

-- Creating foreign key on [BookID] in table 'PriceAdjustReceiptDetails'
ALTER TABLE [dbo].[PriceAdjustReceiptDetails]
ADD CONSTRAINT [FK_R_PriceAdjustReceiptDetail_Book]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_PriceAdjustReceiptDetail_Book'
CREATE INDEX [IX_FK_R_PriceAdjustReceiptDetail_Book]
ON [dbo].[PriceAdjustReceiptDetails]
    ([BookID]);
GO

-- Creating foreign key on [Parent_ID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [FK_R_Department_Department]
    FOREIGN KEY ([Parent_ID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_Department_Department'
CREATE INDEX [IX_FK_R_Department_Department]
ON [dbo].[Departments]
    ([Parent_ID]);
GO

-- Creating foreign key on [AuthorizedUsers_ID] in table 'R_User_UserPermission'
ALTER TABLE [dbo].[R_User_UserPermission]
ADD CONSTRAINT [FK_R_User_UserPermission_User]
    FOREIGN KEY ([AuthorizedUsers_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Permissions_ID] in table 'R_User_UserPermission'
ALTER TABLE [dbo].[R_User_UserPermission]
ADD CONSTRAINT [FK_R_User_UserPermission_Permission]
    FOREIGN KEY ([Permissions_ID])
    REFERENCES [dbo].[Permissions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_UserPermission_Permission'
CREATE INDEX [IX_FK_R_User_UserPermission_Permission]
ON [dbo].[R_User_UserPermission]
    ([Permissions_ID]);
GO

-- Creating foreign key on [BeforeVoidReceipt_ID] in table 'InStockReceipts'
ALTER TABLE [dbo].[InStockReceipts]
ADD CONSTRAINT [FK_R_InStockReceipt_InStockReceipt]
    FOREIGN KEY ([BeforeVoidReceipt_ID])
    REFERENCES [dbo].[InStockReceipts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_InStockReceipt_InStockReceipt'
CREATE INDEX [IX_FK_R_InStockReceipt_InStockReceipt]
ON [dbo].[InStockReceipts]
    ([BeforeVoidReceipt_ID]);
GO

-- Creating foreign key on [OrderID] in table 'OutStockReceipts'
ALTER TABLE [dbo].[OutStockReceipts]
ADD CONSTRAINT [FK_R_OutStockReceipt_Order]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Oders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_OutStockReceipt_Order'
CREATE INDEX [IX_FK_R_OutStockReceipt_Order]
ON [dbo].[OutStockReceipts]
    ([OrderID]);
GO

-- Creating foreign key on [BeforeVoidReceipt_ID] in table 'OutStockReceipts'
ALTER TABLE [dbo].[OutStockReceipts]
ADD CONSTRAINT [FK_R_OutStockReceipt_OutStockReceipt]
    FOREIGN KEY ([BeforeVoidReceipt_ID])
    REFERENCES [dbo].[OutStockReceipts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_OutStockReceipt_OutStockReceipt'
CREATE INDEX [IX_FK_R_OutStockReceipt_OutStockReceipt]
ON [dbo].[OutStockReceipts]
    ([BeforeVoidReceipt_ID]);
GO

-- Creating foreign key on [SpecialCategories_ID] in table 'R_BookCategory_SpecialBook'
ALTER TABLE [dbo].[R_BookCategory_SpecialBook]
ADD CONSTRAINT [FK_R_BookCategory_SpecialBook_BookCategory]
    FOREIGN KEY ([SpecialCategories_ID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SpecialBooks_ID] in table 'R_BookCategory_SpecialBook'
ALTER TABLE [dbo].[R_BookCategory_SpecialBook]
ADD CONSTRAINT [FK_R_BookCategory_SpecialBook_Book]
    FOREIGN KEY ([SpecialBooks_ID])
    REFERENCES [dbo].[Books]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_BookCategory_SpecialBook_Book'
CREATE INDEX [IX_FK_R_BookCategory_SpecialBook_Book]
ON [dbo].[R_BookCategory_SpecialBook]
    ([SpecialBooks_ID]);
GO

-- Creating foreign key on [UserID] in table 'ShoppingCarts'
ALTER TABLE [dbo].[ShoppingCarts]
ADD CONSTRAINT [FK_R_User_ShoppingCart]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AuditUserID] in table 'Oders'
ALTER TABLE [dbo].[Oders]
ADD CONSTRAINT [FK_R_User_AuditOrder]
    FOREIGN KEY ([AuditUserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_User_AuditOrder'
CREATE INDEX [IX_FK_R_User_AuditOrder]
ON [dbo].[Oders]
    ([AuditUserID]);
GO

-- Creating foreign key on [UserID] in table 'TraceInfos'
ALTER TABLE [dbo].[TraceInfos]
ADD CONSTRAINT [FK_R_User_TraceInfo]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------