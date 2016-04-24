using Justin.BookShop.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;
using Justin.BookShop.Common.IoCManagement;
using Justin.BookShop.IService;

namespace Justin.BookShop.Controllers.Comman
{
    public static class EntityExtension
    {
        public static DomainModels.Permission CopyToDomainModel(this ViewModels.Permission viewModel, DomainModels.Permission domainModel = null)
        {
            if(domainModel == null)
                domainModel = new DomainModels.Permission();

            domainModel.ID = viewModel.ID;
            domainModel.Name = viewModel.Name;
            domainModel.Controller = viewModel.ControllerName;
            domainModel.Action = viewModel.ActionName;
            domainModel.AlternateLink = viewModel.AlternateLink;
            domainModel.Type = (DomainModels.PermissionType)viewModel.TypeID;
            domainModel.Description = viewModel.Description;
            domainModel.Icon = viewModel.Icon;
            domainModel.Sort = viewModel.Sort;

            return domainModel;
        }

        public static DomainModels.User CopyToDomainModel(this ViewModels.User viewModel, DomainModels.User domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.User();

            domainModel.ID = viewModel.ID;
            domainModel.LoginName = viewModel.LoginName;
            domainModel.Password = viewModel.Password ?? Util.GetMD5("");
            domainModel.Name = viewModel.Name;
            domainModel.Age = viewModel.Age;
            domainModel.Gender = viewModel.Gender == 0 ? false : viewModel.Gender == 1 ? true : (bool?)null;
            domainModel.Email = viewModel.Email;
            domainModel.BirthDate = viewModel.BirthDate;
            domainModel.Married = viewModel.Married;
            domainModel.Phone = viewModel.Phone;
            domainModel.Position = viewModel.Position;
            domainModel.Salary = viewModel.Salary;
            domainModel.Education = viewModel.Education;
            domainModel.School = viewModel.School;
            domainModel.InUse = viewModel.InUse;
            domainModel.AddedTime = viewModel.AddedTime;
            domainModel.State = viewModel._state.Equals("added", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Add :
                viewModel._state.Equals("removed", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Delete : DomainModels.EntityState.Modify;

            return domainModel;
        }

        public static ViewModels.User CopyToViewModel(this DomainModels.User domainModel, ViewModels.User viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.User();

            viewModel.ID = domainModel.ID;
            viewModel.LoginName = domainModel.LoginName;
            viewModel.Name = domainModel.Name;
            viewModel.Password = domainModel.Password;
            viewModel.Age = domainModel.Age.GetValueOrDefault();
            viewModel.Gender = domainModel.Gender.HasValue ? Convert.ToInt32(domainModel.Gender.Value) : -1;
            viewModel.Email = domainModel.Email;
            viewModel.BirthDate = domainModel.BirthDate.GetValueOrDefault();
            viewModel.Married = domainModel.Married.GetValueOrDefault();
            viewModel.Phone = domainModel.Phone;
            viewModel.Position = domainModel.Position;
            viewModel.Salary = domainModel.Salary.GetValueOrDefault();
            viewModel.Education = domainModel.Education;
            viewModel.School = domainModel.School;
            viewModel.InUse = domainModel.InUse;
            viewModel.IsAdmin = domainModel.IsAdmin;
            viewModel.AddedTime = domainModel.AddedTime;
            viewModel.DepartmentID = domainModel.Department == null ? -1 : domainModel.Department.ID;
            viewModel.DepartmentName = domainModel.Department == null ? "" : domainModel.Department.Name;

            return viewModel;
        }

        public static DomainModels.UserRole CopyToDomainModel(this ViewModels.Role viewModel, DomainModels.UserRole domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.UserRole();

            domainModel.ID = viewModel.ID;
            domainModel.Name = viewModel.Name;
            domainModel.Description = viewModel.Description;
            domainModel.State = viewModel._state.Equals("added", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Add :
                viewModel._state.Equals("removed", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Delete : DomainModels.EntityState.Modify;

            return domainModel;
        }

        public static ViewModels.Role CopyToViewModel(this DomainModels.UserRole domainModel, ViewModels.Role viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.Role();

            viewModel.ID = domainModel.ID;
            viewModel.Name = domainModel.Name;
            viewModel.Description = domainModel.Description;

            return viewModel;
        }

        public static ViewModels.Book CopyToViewModel(this DomainModels.Book domainModel, ViewModels.Book viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.Book();

            viewModel.ID = domainModel.ID;
            viewModel.Name = domainModel.Name;
            viewModel.MainTitle = domainModel.MainTitle;
            viewModel.MinorTitle = domainModel.MinorTitle;
            viewModel.OfficialPrice = domainModel.OfficialPrice;
            viewModel.SellingPrice = domainModel.SellingPrice.GetValueOrDefault();
            viewModel.AccountPrice = domainModel.AccountPrice.GetValueOrDefault();
            viewModel.PublicationDate = domainModel.PublicationDate;
            viewModel.PrintingTime = domainModel.PublicationDate;
            viewModel.ISBN = domainModel.ISBN;
            viewModel.Picture = domainModel.Picture;
            viewModel.Thumbnail = domainModel.Thumbnail;
            viewModel.PageNum = domainModel.PageNum;
            viewModel.Language = domainModel.Language;
            viewModel.SalesVolume = domainModel.SalesVolume.GetValueOrDefault();
            viewModel.Introduction = domainModel.Introduction;
            viewModel.Catalog = domainModel.Catalog;
            viewModel.Digest = domainModel.Digest;
            viewModel.PromotedOnFront = domainModel.PromotedOnFront;
            viewModel.ShowOnBanner = domainModel.ShowOnBanner;
            viewModel.OnSale = domainModel.OnSale;
            viewModel.AddedTime = domainModel.AddedTime.GetValueOrDefault();
            viewModel.StorageTime = domainModel.StorageTime.GetValueOrDefault();

            viewModel.AuthorIDs = domainModel.Authors == null ? null : (from a in domainModel.Authors select a.ID).ToArray();
            viewModel.AuthorNames = domainModel.Authors == null ? null : (from a in domainModel.Authors select a.Name).ToArray();
            viewModel.PressIDs = domainModel.Presses == null ? null :(from p in domainModel.Presses select p.ID).ToArray();
            viewModel.PressNames = domainModel.Presses == null ? null : (from p in domainModel.Presses select p.Name).ToArray();
            viewModel.CategoryID = domainModel.Category.ID;
            viewModel.Category = domainModel.Category.Name;

            return viewModel;
        }

        public static DomainModels.Book CopyToDomainModel(this ViewModels.Book viewModel, DomainModels.Book domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.Book();

            domainModel.ID = viewModel.ID;
            domainModel.Name = viewModel.Name;
            domainModel.MainTitle = viewModel.MainTitle;
            domainModel.MinorTitle = viewModel.MinorTitle;
            domainModel.OfficialPrice = viewModel.OfficialPrice;
            domainModel.SellingPrice = viewModel.SellingPrice;
            domainModel.PublicationDate = viewModel.PublicationDate;
            domainModel.PrintingTime = viewModel.PublicationDate;
            domainModel.ISBN = viewModel.ISBN;
            domainModel.Picture = viewModel.Picture;
            domainModel.Thumbnail = viewModel.Thumbnail;
            domainModel.PageNum = viewModel.PageNum;
            domainModel.Language = viewModel.Language;
            domainModel.Introduction = viewModel.Introduction;
            domainModel.Catalog = viewModel.Catalog;
            domainModel.Digest = viewModel.Digest;
            domainModel.State = viewModel._state.Equals("added", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Add :
                viewModel._state.Equals("removed", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Delete : DomainModels.EntityState.Modify;

            var service = ContainerManager.Current.Resolve<IBookService>();
            domainModel.Category = ContainerManager.Current.Resolve<IBookCategoryService>().GetByID(viewModel.CategoryID);
            domainModel.Presses = (from id in viewModel.PressIDs
                                  select ContainerManager.Current.Resolve<IPressService>().GetById(id)).ToList();
            domainModel.Authors = (from id in viewModel.AuthorIDs
                                   select ContainerManager.Current.Resolve<IAuthorService>().GetByID(id)).ToList();

            return domainModel;
        }

        public static ViewModels.BookCategory CopyToViewModel(this DomainModels.BookCategory domainModel, ViewModels.BookCategory viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.BookCategory();

            viewModel.ID = domainModel.ID;
            viewModel.Name = domainModel.Name;
            viewModel.ParentID = domainModel.Parent == null ? -1 : domainModel.Parent.ID;

            return viewModel;
        }

        public static DomainModels.BookCategory CopyToDomainModel(this ViewModels.BookCategory viewModel, DomainModels.BookCategory domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.BookCategory();

            domainModel.ID = viewModel.ID;
            domainModel.Name = viewModel.Name;
            domainModel.Parent = ContainerManager.Current.Resolve<IBookCategoryService>().GetByID(viewModel.ParentID);

            return domainModel;
        }

        public static ViewModels.Author CopyToViewModel(this DomainModels.Author domainModel, ViewModels.Author viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.Author();

            viewModel.ID = domainModel.ID;
            viewModel.Name = domainModel.Name;
            viewModel.Introduction = domainModel.Introduction;

            return viewModel;
        }

        public static DomainModels.Author CopyToDomainModel(this ViewModels.Author viewModel, DomainModels.Author domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.Author();

            domainModel.ID = viewModel.ID;
            domainModel.Name = viewModel.Name;
            domainModel.Introduction = viewModel.Introduction;
            domainModel.State = viewModel._state.Equals("added", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Add :
                viewModel._state.Equals("modified", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Modify : DomainModels.EntityState.Delete;

            return domainModel;
        }

        public static ViewModels.Press CopyToViewModel(this DomainModels.Press domainModel, ViewModels.Press viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.Press();

            viewModel.ID = domainModel.ID;
            viewModel.Name = domainModel.Name;
            viewModel.Address = domainModel.Address;
            viewModel.Contact = domainModel.Contact;

            return viewModel;
        }

        public static DomainModels.Press CopyToDomainModel(this ViewModels.Press viewModel, DomainModels.Press domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.Press();

            domainModel.ID = viewModel.ID;
            domainModel.Name = viewModel.Name;
            domainModel.Address = viewModel.Address;
            domainModel.Contact = viewModel.Contact;
            domainModel.State = viewModel._state.Equals("added", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Add :
                viewModel._state.Equals("modified", StringComparison.CurrentCultureIgnoreCase) ? DomainModels.EntityState.Modify : DomainModels.EntityState.Delete;

            return domainModel;
        }

        public static DomainModels.InStockReceipt CopyToDomainModel(this ViewModels.InStockReceipt viewModel, DomainModels.InStockReceipt domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.InStockReceipt();

            domainModel.ID = viewModel.ID;
            domainModel.NO = viewModel.NO;
            domainModel.PressNo = viewModel.PressNO;
            domainModel.Remark = viewModel.Remark;
            domainModel.PressID = viewModel.PressID;
            domainModel.Details = (from d in viewModel.Details
                                  select new DomainModels.InStockReceiptDetail
                                  {
                                      ID = d.ID,
                                      EntryQuantity = d.EntryQuantity,
                                      EntryUnitPrice = d.EntryUnitPrice,
                                      BookID = d.BookID
                                  }).ToList();

            return domainModel;
        }

        public static ViewModels.InStockReceipt CopyToViewModel(this DomainModels.InStockReceipt domainModel, ViewModels.InStockReceipt viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.InStockReceipt();

            viewModel.ID = domainModel.ID;
            viewModel.NO = domainModel.NO;
            viewModel.PressNO = domainModel.PressNo;
            viewModel.PressID = domainModel.PressID;
            viewModel.Remark = domainModel.Remark;
            viewModel.PressName = domainModel.Press.Name;
            viewModel.Details = (from d in domainModel.Details
                                select new ViewModels.InStockReceiptDetail
                                {
                                    ID = d.ID,
                                    EntryQuantity = d.EntryQuantity,
                                    EntryUnitPrice = d.EntryUnitPrice,
                                    AccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                                    BookID = d.BookID,
                                    ISBN = d.Book.ISBN,
                                    BookName = d.Book.Name
                                }).ToList();

            return viewModel;
        }

        public static ViewModels.OutStockReceipt CopyToViewModel(this DomainModels.OutStockReceipt domainModel, ViewModels.OutStockReceipt viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.OutStockReceipt();

            viewModel.ID = domainModel.ID;
            viewModel.NO = domainModel.NO;
            viewModel.Freight = domainModel.Freight;
            viewModel.OrderNO = domainModel.Order == null ? "" : domainModel.Order.NO;
            viewModel.Remark = domainModel.Remark;
            viewModel.Details = (from d in domainModel.Details
                                select new ViewModels.OutStockReceiptDetail
                                {
                                    ID = d.ID,
                                    OutQuantity = d.OutQuantity,
                                    OutUnitPrice = d.OutUnitPrice,
                                    AccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                                    BookID = d.BookID,
                                    ISBN = d.Book.ISBN,
                                    BookName = d.Book.Name
                                }).ToList();

            return viewModel;
        }

        public static DomainModels.OutStockReceipt CopyToDomainModel(this ViewModels.OutStockReceipt viewModel, DomainModels.OutStockReceipt domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.OutStockReceipt();

            domainModel.ID = viewModel.ID;
            domainModel.NO = viewModel.NO;
            domainModel.Freight = viewModel.Freight;
            domainModel.Remark = viewModel.Remark;
            domainModel.Details = (from d in viewModel.Details
                                   select new DomainModels.OutStockReceiptDetail
                                   {
                                       ID = d.ID,
                                       OutQuantity = d.OutQuantity,
                                       OutUnitPrice = d.OutUnitPrice,
                                       BookID = d.BookID
                                   }).ToList();

            return domainModel;
        }

        public static ViewModels.StocktakeReceipt CopyToViewModel(this DomainModels.StocktakeReceipt domainModel, ViewModels.StocktakeReceipt viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.StocktakeReceipt();

            viewModel.ID = domainModel.ID;
            viewModel.NO = domainModel.NO;
            viewModel.Remark = domainModel.Remark;
            viewModel.Details = (from d in domainModel.Details
                                select new StocktakeReceiptDetail
                                {
                                    ID = d.ID,
                                    TakeQuantity = d.TakeQuantity,
                                    AccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                                    BookID = d.BookID,
                                    ISBN = d.Book.ISBN,
                                    BookName = d.Book.Name
                                }).ToList();

            return viewModel;
        }

        public static DomainModels.StocktakeReceipt CopyToDomainModel(this ViewModels.StocktakeReceipt viewModel, DomainModels.StocktakeReceipt domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.StocktakeReceipt();

            domainModel.ID = viewModel.ID;
            domainModel.NO = viewModel.NO;
            domainModel.Remark = viewModel.Remark;
            domainModel.Details = (from d in viewModel.Details
                                  select new DomainModels.StocktakeReceiptDeatil
                                  {
                                      ID = viewModel.ID,
                                      TakeQuantity = d.TakeQuantity,
                                      BookID = d.BookID
                                  }).ToList();

            return domainModel;
        }

        public static ViewModels.StockDamagedReceipt CopyToViewModel(this DomainModels.StockDamagedReceipt domainModel, ViewModels.StockDamagedReceipt viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.StockDamagedReceipt();

            viewModel.ID = domainModel.ID;
            viewModel.NO = domainModel.NO;
            viewModel.Remark = domainModel.Remark;
            viewModel.Details = (from d in domainModel.Details
                                select new ViewModels.StockDamagedReceiptDetail
                                {
                                    ID = d.ID,
                                    DamagedQuantity = d.DamagedQuantity,
                                    AccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                                    BookID = d.BookID,
                                    ISBN = d.Book.ISBN,
                                    BookName = d.Book.Name
                                }).ToList();

            return viewModel;
        }

        public static DomainModels.StockDamagedReceipt CopyToDomainModel(this ViewModels.StockDamagedReceipt viewModel, DomainModels.StockDamagedReceipt domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.StockDamagedReceipt();

            domainModel.ID = viewModel.ID;
            domainModel.NO = viewModel.NO;
            domainModel.Remark = viewModel.Remark;
            domainModel.Details = (from d in viewModel.Details
                                  select new DomainModels.StockDamagedReceiptDetail
                                  {
                                      ID = viewModel.ID,
                                      DamagedQuantity = d.DamagedQuantity,
                                      BookID = d.BookID
                                  }).ToList();

            return domainModel;
        }

        public static ViewModels.PriceAdjustReceipt CopyToViewModel(this DomainModels.PriceAdjustReceipt domainModel, ViewModels.PriceAdjustReceipt viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.PriceAdjustReceipt();

            viewModel.ID = domainModel.ID;
            viewModel.NO = domainModel.NO;
            viewModel.Remark = domainModel.Remark;
            viewModel.Details = (from d in domainModel.Details
                                select new ViewModels.PriceAdjustReceiptDetail
                                {
                                    ID = d.ID,
                                    AdjustQuantity = d.Book.Stock == null ? 0 : d.Book.Stock.ThisPeriodQuantity,
                                    NewAccountPrice = d.NewAccountPrice,
                                    OldAccountPrice = d.Book.AccountPrice.GetValueOrDefault(),
                                    BookID = d.BookID,
                                    ISBN = d.Book.ISBN,
                                    BookName = d.Book.Name
                                }).ToList();

            return viewModel;
        }

        public static DomainModels.PriceAdjustReceipt CopyToDomainModel(this ViewModels.PriceAdjustReceipt viewModel, DomainModels.PriceAdjustReceipt domainModel = null)
        {
            if (domainModel == null)
                domainModel = new DomainModels.PriceAdjustReceipt();

            domainModel.ID = viewModel.ID;
            domainModel.NO = viewModel.NO;
            domainModel.Remark = viewModel.Remark;
            domainModel.Details = (from d in viewModel.Details
                                  select new DomainModels.PriceAdjustReceiptDetail
                                  {
                                      ID = d.ID,
                                      NewAccountPrice = d.NewAccountPrice,
                                      BookID = d.BookID
                                  }).ToList();

            return domainModel;
        }

        public static ViewModels.Order CopyToViewModel(this DomainModels.Order domainModel, ViewModels.Order viewModel = null)
        {
            if (viewModel == null)
                viewModel = new ViewModels.Order();

            viewModel.ID = domainModel.ID;
            viewModel.NO = domainModel.NO;
            viewModel.OrderPrice = domainModel.OrderPrice;
            viewModel.SubmitDate = domainModel.SubmitDate;
            viewModel.Freight = domainModel.Freight;

            return viewModel;
        }
    }
}
