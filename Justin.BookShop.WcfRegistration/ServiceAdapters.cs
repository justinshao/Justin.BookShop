using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Justin.BookShop.IService;

namespace Justin.BookShop.WcfRegistration
{
    public class AuthorServiceAdapter : IAuthorService
    {
        IAuthorService _service;

        public AuthorServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IAuthorService>();
        }

        public IEnumerable<Justin.BookShop.Entities.Author> GetPagedAuthors(int pageIndex, int pageSize, string sortField, Justin.BookShop.Entities.SortOrder sortOrder, out int total, Func<Justin.BookShop.Entities.Author, bool> where = null)
        {
            return _service.GetPagedAuthors(pageIndex, pageSize, sortField, sortOrder, out total, where);
        }

        public Justin.BookShop.Entities.Author GetByID(int id)
        {
            return _service.GetByID(id);
        }

        public void SaveAuthor(Justin.BookShop.Entities.Author author)
        {
            _service.SaveAuthor(author);
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public IEnumerable<Justin.BookShop.Entities.Author> GetAll()
        {
            return _service.GetAll();
        }
    }

    public class BookCategoryServiceAdapter : IBookCategoryService
    {
        IBookCategoryService _service;

        public BookCategoryServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IBookCategoryService>();
        }

        public IEnumerable<Entities.BookCategory> GetAll()
        {
            return _service.GetAll();
        }

        public Entities.BookCategory GetByID(int id)
        {
            return _service.GetByID(id);
        }

        public void Add(Entities.BookCategory category)
        {
            _service.Add(category);
        }

        public string Remove(int id)
        {
            return _service.Remove(id);
        }

        public void Rename(int id, string newName)
        {
            _service.Rename(id, newName);
        }
    }

    public class BookServiceAdapter : IBookService
    {
        IBookService _service;

        public BookServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IBookService>();
        }

        public IEnumerable<Entities.Book> GetPagedBooks(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Entities.Book, bool> where = null)
        {
            return _service.GetPagedBooks(pageIndex, pageSize, sortField, sortOrder, out total, where);
        }

        public Entities.Book GetByID(Guid id)
        {
            return _service.GetByID(id);
        }

        public Entities.Book GetByISBN(string isbn)
        {
            return _service.GetByISBN(isbn);
        }

        public void SaveBook(Entities.Book book)
        {
            _service.SaveBook(book);
        }

        public void Remove(Guid id)
        {
            _service.Remove(id);
        }

        public IEnumerable<Entities.Book> GetBooksOnBanner()
        {
            return _service.GetBooksOnBanner();
        }

        public IEnumerable<Entities.Book> GetPagedBooksOnFront(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total)
        {
            return _service.GetPagedBooksOnFront(pageIndex, pageSize, sortField, sortOrder, out total);
        }

        public IEnumerable<Entities.Book> GetPagedCategoryBooks(int categoryId, int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total)
        {
            return _service.GetPagedCategoryBooks(categoryId, pageIndex, pageSize, sortField, sortOrder, out total);
        }

        public IEnumerable<Entities.Book> GetPagedAuthorBooks(int authorId, int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total)
        {
            return GetPagedAuthorBooks(authorId, pageIndex, pageSize, sortField, sortOrder, out total);
        }

        public IEnumerable<Entities.Book> GetPagedPressBooks(int pressId, int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total)
        {
            return _service.GetPagedPressBooks(pressId, pageIndex, pageSize, sortField, sortOrder, out total);
        }

        public IEnumerable<Entities.Book> GetPagedSearchBooks(string key, int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total)
        {
            return _service.GetPagedSearchBooks(key, pageIndex, pageSize, sortField, sortOrder, out total);
        }
    }

    public class BookStockServiceAdapter : IBookStockService
    {
        IBookStockService _service;

        public BookStockServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IBookStockService>();
        }

        public void CloseAccount(string period)
        {
            _service.CloseAccount(period);
        }
    }

    public class InStockReceiptServiceAdapter : IInStockReceiptService
    {
        IInStockReceiptService _service;

        public InStockReceiptServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IInStockReceiptService>();
        }

        public Entities.InStockReceipt GetTemporaryReceipt(Guid id)
        {
            return _service.GetTemporaryReceipt(id);
        }

        public IEnumerable<Entities.InStockReceipt> GetTemporaryReceiptList()
        {
            return _service.GetTemporaryReceiptList();
        }

        public void RemoveTemporaryReceipt(Guid id)
        {
            _service.RemoveTemporaryReceipt(id);
        }

        public void SubmitTemporaryReceipt(Entities.InStockReceipt receipt, IEnumerable<Entities.InStockReceiptDetail> details = null)
        {
            _service.SubmitTemporaryReceipt(receipt, details);
        }

        public void UpdateTemporaryReceipt(Entities.InStockReceipt receipt, IEnumerable<Entities.InStockReceiptDetail> details = null)
        {
            _service.UpdateTemporaryReceipt(receipt, details);
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            _service.AuditReceipt(receiptId, auditId);
        }

        public void InvalidReceipt(Guid receiptId, Guid operatorId)
        {
            _service.InvalidReceipt(receiptId, operatorId);
        }

        public IEnumerable<Entities.InStockReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return _service.GetAuditedReceiptList(fromNO, toNO);
        }

        public Entities.InStockReceipt GetAuditedReceipt(Guid receiptID)
        {
            return _service.GetAuditedReceipt(receiptID);
        }
    }

    public class CartServiceAdapter : ICartService
    {
        ICartService _service;

        public CartServiceAdapter()
        {
            _service = ServiceFactory.CreateService<ICartService>();
        }

        public void AddCartItem(Guid userId, Guid bookId, int count)
        {
            _service.AddCartItem(userId, bookId, count);
        }

        public void RemoveCartItem(Guid userId, Guid bookId)
        {
            _service.RemoveCartItem(userId, bookId);
        }

        public Entities.Order GetOrderInfo(Entities.ShoppingCart cart)
        {
            return _service.GetOrderInfo(cart);
        }
    }

    public class DepartmentServiceAdapter : IDepartmentService
    {
        IDepartmentService _service;

        public DepartmentServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IDepartmentService>();
        }

        public IEnumerable<Entities.Department> GetDepartmentsWithChildren(int parentId)
        {
            return _service.GetDepartmentsWithChildren(parentId);
        }

        public Entities.Department GetById(int id)
        {
            return _service.GetById(id);
        }

        public Entities.Department Add(Entities.Department newDepartment)
        {
            return _service.Add(newDepartment);
        }

        public string Remove(int id)
        {
            return _service.Remove(id);
        }

        public string Rename(int id, string newName)
        {
            return _service.Rename(id, newName);
        }

        public string Reoder(int id, int sort, int newParentID)
        {
            return _service.Reoder(id, sort, newParentID);
        }

        public IEnumerable<Entities.Department> GetAll()
        {
            return _service.GetAll();
        }

        public void AuthorizeRoles(int departmentID, int[] roleIDs)
        {
            _service.AuthorizeRoles(departmentID, roleIDs);
        }
    }

    public class OrderServiceAdapter : IOrderService
    {
        IOrderService _service;

        public OrderServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IOrderService>();
        }

        public Entities.Order SubmitOrder(Guid userId, Entities.Order order)
        {
            return _service.SubmitOrder(userId, order);
        }

        public IEnumerable<Entities.Order> GetNonAuditedOrders()
        {
            return _service.GetNonAuditedOrders();
        }

        public Entities.Order GetOrder(Guid orderId)
        {
            return _service.GetOrder(orderId);
        }

        public void AuditOrder(Guid orderId, Guid auditorId)
        {
            _service.AuditOrder(orderId, auditorId);
        }

        public void AddOrderTrace(string orderNO, Guid userId)
        {
            _service.AddOrderTrace(orderNO, userId);
        }

        public Entities.Order GetOrderById(Guid orderId)
        {
            return _service.GetOrderById(orderId);
        }
    }

    public class OutStockReceiptServiceAdapter : IOutStockReceiptService
    {
        IOutStockReceiptService _service;

        public OutStockReceiptServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IOutStockReceiptService>();
        }

        public Entities.OutStockReceipt GetTemporaryReceipt(Guid id)
        {
            return _service.GetTemporaryReceipt(id);
        }

        public IEnumerable<Entities.OutStockReceipt> GetTemporaryReceiptList()
        {
            return _service.GetTemporaryReceiptList();
        }

        public void RemoveTemporaryReceipt(Guid id)
        {
            _service.RemoveTemporaryReceipt(id);
        }

        public void SubmitTemporaryReceipt(Entities.OutStockReceipt receipt, IEnumerable<Entities.OutStockReceiptDetail> details = null)
        {
            _service.SubmitTemporaryReceipt(receipt, details);
        }

        public void UpdateTemporaryReceipt(Entities.OutStockReceipt receipt, IEnumerable<Entities.OutStockReceiptDetail> details = null)
        {
            _service.UpdateTemporaryReceipt(receipt, details);
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            _service.AuditReceipt(receiptId, auditId);
        }

        public void InvalidReceipt(Guid receiptId, Guid operatorId)
        {
            _service.InvalidReceipt(receiptId, operatorId);
        }

        public IEnumerable<Entities.OutStockReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return _service.GetAuditedReceiptList(fromNO, toNO);
        }

        public Entities.OutStockReceipt GetAuditedReceipt(Guid receiptID)
        {
            return _service.GetAuditedReceipt(receiptID);
        }
    }

    public class PermissionServiceAdapter : IPermissionService
    {
        IPermissionService _service;

        public PermissionServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IPermissionService>();
        }

        public IEnumerable<Entities.Permission> GetAll()
        {
            return _service.GetAll();
        }

        public Entities.Permission AddNew(Entities.Permission newPermission)
        {
            return _service.AddNew(newPermission);
        }

        public Entities.Permission GetById(int id)
        {
            return _service.GetById(id);
        }

        public string Remove(int id)
        {
            return _service.Remove(id);
        }

        public Entities.Permission Update(Entities.Permission permission)
        {
            return _service.Update(permission);
        }
    }

    public class PressServiceAdapter : IPressService
    {
        IPressService _service;

        public PressServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IPressService>();
        }

        public IEnumerable<Entities.Press> GetPagedPresses(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Entities.Press, bool> where = null)
        {
            return _service.GetPagedPresses(pageIndex, pageSize, sortField, sortOrder, out total, where);
        }

        public Entities.Press GetById(int id)
        {
            return _service.GetById(id);
        }

        public void SaveChanges(IEnumerable<Entities.Press> changedPresses)
        {
            _service.SaveChanges(changedPresses);
        }

        public IEnumerable<Entities.Press> GetAll()
        {
            return _service.GetAll();
        }
    }

    public class PriceAdjustReceiptServiceAdapter : IPriceAdjustReceiptService
    {
        IPriceAdjustReceiptService _service;

        public PriceAdjustReceiptServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IPriceAdjustReceiptService>();
        }

        public Entities.PriceAdjustReceipt GetTemporaryReceipt(Guid id)
        {
            return _service.GetTemporaryReceipt(id);
        }

        public IEnumerable<Entities.PriceAdjustReceipt> GetTemporaryReceiptList()
        {
            return _service.GetTemporaryReceiptList();
        }

        public void RemoveTemporaryReceipt(Guid id)
        {
            _service.RemoveTemporaryReceipt(id);
        }

        public void SubmitTemporaryReceipt(Entities.PriceAdjustReceipt receipt, IEnumerable<Entities.PriceAdjustReceiptDetail> details = null)
        {
            _service.SubmitTemporaryReceipt(receipt, details);
        }

        public void UpdateTemporaryReceipt(Entities.PriceAdjustReceipt receipt, IEnumerable<Entities.PriceAdjustReceiptDetail> details = null)
        {
            _service.UpdateTemporaryReceipt(receipt, details);
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            _service.AuditReceipt(receiptId, auditId);
        }

        public IEnumerable<Entities.PriceAdjustReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return _service.GetAuditedReceiptList(fromNO, toNO);
        }

        public Entities.PriceAdjustReceipt GetAuditedReceipt(Guid receiptID)
        {
            return _service.GetAuditedReceipt(receiptID);
        }
    }

    public class StockDamagedReceiptServiceAdapter : IStockDamagedReceiptService
    {
        IStockDamagedReceiptService _service;

        public StockDamagedReceiptServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IStockDamagedReceiptService>();
        }

        public Entities.StockDamagedReceipt GetTemporaryReceipt(Guid id)
        {
            return _service.GetTemporaryReceipt(id);
        }

        public IEnumerable<Entities.StockDamagedReceipt> GetTemporaryReceiptList()
        {
            return _service.GetTemporaryReceiptList();
        }

        public void RemoveTemporaryReceipt(Guid id)
        {
            _service.RemoveTemporaryReceipt(id);
        }

        public void SubmitTemporaryReceipt(Entities.StockDamagedReceipt receipt, IEnumerable<Entities.StockDamagedReceiptDetail> details = null)
        {
            _service.SubmitTemporaryReceipt(receipt, details);
        }

        public void UpdateTemporaryReceipt(Entities.StockDamagedReceipt receipt, IEnumerable<Entities.StockDamagedReceiptDetail> details = null)
        {
            _service.UpdateTemporaryReceipt(receipt, details);
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            _service.AuditReceipt(receiptId, auditId);
        }

        public IEnumerable<Entities.StockDamagedReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return _service.GetAuditedReceiptList(fromNO, toNO);
        }

        public Entities.StockDamagedReceipt GetAuditedReceipt(Guid receiptID)
        {
            return _service.GetAuditedReceipt(receiptID);
        }
    }

    public class StocktakeReceiptServiceAdapter : IStocktakeReceiptService
    {
        IStocktakeReceiptService _service;

        public StocktakeReceiptServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IStocktakeReceiptService>();
        }

        public Entities.StocktakeReceipt GetTemporaryReceipt(Guid id)
        {
            return _service.GetTemporaryReceipt(id);
        }

        public IEnumerable<Entities.StocktakeReceipt> GetTemporaryReceiptList()
        {
            return _service.GetTemporaryReceiptList();
        }

        public void RemoveTemporaryReceipt(Guid id)
        {
            _service.RemoveTemporaryReceipt(id);
        }

        public void SubmitTemporaryReceipt(Entities.StocktakeReceipt receipt, IEnumerable<Entities.StocktakeReceiptDeatil> details = null)
        {
            _service.SubmitTemporaryReceipt(receipt, details);
        }

        public void UpdateTemporaryReceipt(Entities.StocktakeReceipt receipt, IEnumerable<Entities.StocktakeReceiptDeatil> details = null)
        {
            _service.UpdateTemporaryReceipt(receipt, details);
        }

        public void AuditReceipt(Guid receiptId, Guid auditId)
        {
            _service.AuditReceipt(receiptId, auditId);
        }

        public IEnumerable<Entities.StocktakeReceipt> GetAuditedReceiptList(string fromNO, string toNO)
        {
            return _service.GetAuditedReceiptList(fromNO, toNO);
        }

        public Entities.StocktakeReceipt GetAuditedReceipt(Guid receiptID)
        {
            return _service.GetAuditedReceipt(receiptID);
        }
    }

    public class SaleServiceAdapter : ISaleService
    {
        ISaleService _service;

        public SaleServiceAdapter()
        {
            _service = ServiceFactory.CreateService<ISaleService>();
        }

        public void SetPrice(Guid bookId, decimal sellingPrice)
        {
            _service.SetPrice(bookId, sellingPrice);
        }

        public void SetOffSale(Guid bookId)
        {
            _service.SetOffSale(bookId);
        }

        public void SetOnSale(Guid bookId, bool showOnBanner, bool showOnFront, IEnumerable<int> specialCategoryIds)
        {
            _service.SetOnSale(bookId, showOnBanner, showOnFront, specialCategoryIds);
        }
    }

    public class UserRoleServiceAdapter : IUserRoleService
    {
        IUserRoleService _service;

        public UserRoleServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IUserRoleService>();
        }

        public IEnumerable<Entities.UserRole> GetAllRoles()
        {
            return _service.GetAllRoles();
        }

        public Entities.UserRole GetById(int id)
        {
            return _service.GetById(id);
        }

        public void SaveChanges(IEnumerable<Entities.UserRole> changedRoles)
        {
            _service.SaveChanges(changedRoles);
        }

        public void AuthorizePermission(int roleID, int[] permissionIDs)
        {
            _service.AuthorizePermission(roleID, permissionIDs);
        }
    }

    public class UserServiceAdapter : IUserService
    {
        IUserService _service;

        public UserServiceAdapter()
        {
            _service = ServiceFactory.CreateService<IUserService>();
        }

        public Entities.User Login(string loginName, string password, out string error)
        {
            try
            {
                return _service.Login(loginName, password, out error);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public Entities.User AdminLogin(string loginName, string password, out string error)
        {
            return _service.AdminLogin(loginName, password, out error);
        }

        public IEnumerable<Entities.Permission> GetAuthorizedPermissions(Guid userId, Entities.PermissionType? permissionType = null)
        {
            return _service.GetAuthorizedPermissions(userId, permissionType);
        }

        public Entities.User GetUser(Guid userId)
        {
            return _service.GetUser(userId);
        }

        public IEnumerable<Entities.User> GetSysUsers()
        {
            return _service.GetSysUsers();
        }

        public IEnumerable<Entities.User> GetPagedSysUsers(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Entities.User, bool> where = null)
        {
            return _service.GetPagedSysUsers(pageIndex, pageSize, sortField, sortOrder, out total, where);
        }

        public void SaveChanges(IEnumerable<Entities.User> changedUsers)
        {
            _service.SaveChanges(changedUsers);
        }

        public void ResetPassword(Guid userId, string newPassword)
        {
            _service.ResetPassword(userId, newPassword);
        }

        public void AuthorizeRoles(Guid userID, int[] roleIDs)
        {
            _service.AuthorizeRoles(userID, roleIDs);
        }

        public void AuthorizePermissions(Guid userID, int[] permissionIDs)
        {
            _service.AuthorizePermissions(userID, permissionIDs);
        }

        public string ClientRegister(Entities.User user)
        {
            return _service.ClientRegister(user);
        }

        public IEnumerable<Entities.Permission> GetUserCenterMenu(Guid userId)
        {
            return _service.GetUserCenterMenu(userId);
        }

        public void SetTraceInfo(string traceInfo, Guid userId)
        {
            _service.SetTraceInfo(traceInfo, userId);
        }

        public IEnumerable<Entities.Permission> GetAuthorizedMenue(Guid userId)
        {
            return _service.GetAuthorizedMenue(userId);
        }
    }
}
