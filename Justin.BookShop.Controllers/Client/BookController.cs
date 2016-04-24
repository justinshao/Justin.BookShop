using Justin.BookShop.Controllers.Models;
using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Client
{
    public class BookController : ClientController
    {
        public ActionResult CategoryList(int? categoryId, string sortField, int pageIndex = 1, SortOrder sortOrder = SortOrder.Desc)
        {
            sortField = sortField ?? "salesvolume";
            BookCategoryList categoryList = new BookCategoryList();
            PagedBookListInfo pagedBooksInfo = new PagedBookListInfo
            {
                Pagination = new PaginationInfo
                {
                    PageIndex = pageIndex,
                    SortField = sortField,
                    PageSize = WebConfig.BookPageSize,
                    SortOrder = sortOrder
                },
                ActionName = "CategoryList",
                ControllerName = "Book",
                PageParamName = "categoryId",
                PageParamValue = categoryId.HasValue ? (object)categoryId.Value : null
            };

            // 分类列表
            if (categoryId == null)
            {
                categoryList.Children = (from c in ResolveService<IBookCategoryService>().GetAll()
                                     where c.Parent == null
                                     select c).ToList();
            }
            else
            {
                var parent = ResolveService<IBookCategoryService>().GetByID(categoryId.Value);
                categoryList.SelectedCategory = parent;
                if (parent.Children.Count <= 0)
                {
                    categoryList.Parent = parent.Parent;
                    categoryList.Children = parent.Parent == null ? 
                        (from c in ResolveService<IBookCategoryService>().GetAll()
                                     where c.Parent == null
                                     select c).ToList(): 
                                     parent.Parent.Children.ToList();
                }
                else
                {
                    categoryList.Parent = parent;
                    categoryList.Children = parent.Children.ToList();
                }
            }

            // 图书列表
            int total;
            if (categoryId == null)
            {
                pagedBooksInfo.Books = ResolveService<IBookService>().GetPagedBooksOnFront(pageIndex - 1, WebConfig.BookPageSize, sortField, sortOrder, out total);
            }
            else
            {
                pagedBooksInfo.Books = ResolveService<IBookService>().GetPagedCategoryBooks(categoryId.Value, pageIndex - 1, WebConfig.BookPageSize, sortField, sortOrder, out total);
            }
            pagedBooksInfo.Total = total;

            ViewBag.BookCategoryList = categoryList;

            return View("BookList", pagedBooksInfo);
        }

        public ActionResult AuthorList(int authorId, string sortField, int pageIndex = 1, SortOrder sortOrder = SortOrder.Asc)
        {
            BookCategoryList categoryList = new BookCategoryList();
            PagedBookListInfo pagedBooksInfo = new PagedBookListInfo
            {
                Pagination = new PaginationInfo
                {
                    PageIndex = pageIndex,
                    SortField = sortField,
                    PageSize = WebConfig.BookPageSize,
                    SortOrder = sortOrder
                },
                ActionName = "AuthorList",
                ControllerName = "Book",
                PageParamName = "authorId",
                PageParamValue = authorId
            };

            

            // 图书列表
            int total;
            pagedBooksInfo.Books = ResolveService<IBookService>().GetPagedAuthorBooks(authorId, pageIndex - 1, WebConfig.BookPageSize, sortField, sortOrder, out total);
            pagedBooksInfo.Total = total;

            ViewBag.BookCategoryList = categoryList;

            return View("BookList", pagedBooksInfo);
        }

        public ActionResult PressList(int pressId, string sortField, int pageIndex = 1, SortOrder sortOrder = SortOrder.Asc)
        {
            BookCategoryList categoryList = new BookCategoryList();
            PagedBookListInfo pagedBooksInfo = new PagedBookListInfo
            {
                Pagination = new PaginationInfo
                {
                    PageIndex = pageIndex,
                    SortField = sortField,
                    PageSize = WebConfig.BookPageSize,
                    SortOrder = sortOrder
                },
                ActionName = "PressList",
                ControllerName = "Book",
                PageParamName = "pressId",
                PageParamValue = pressId
            };

            // 图书列表
            int total;
            pagedBooksInfo.Books = ResolveService<IBookService>().GetPagedPressBooks(pressId, pageIndex - 1, WebConfig.BookPageSize, sortField, sortOrder, out total);
            pagedBooksInfo.Total = total;

            ViewBag.BookCategoryList = categoryList;

            return View("BookList", pagedBooksInfo);
        }

        public ActionResult SearchList(string key, string sortField, int pageIndex = 1, SortOrder sortOrder = SortOrder.Asc)
        {
            key = key ?? "";
            BookCategoryList categoryList = new BookCategoryList();
            PagedBookListInfo pagedBooksInfo = new PagedBookListInfo
            {
                Pagination = new PaginationInfo
                {
                    PageIndex = pageIndex,
                    SortField = sortField,
                    PageSize = WebConfig.BookPageSize,
                    SortOrder = sortOrder
                },
                ActionName = "SearchList",
                ControllerName = "Book",
                PageParamName = "key",
                PageParamValue = key
            };

            // 图书列表
            int total;
            pagedBooksInfo.Books = ResolveService<IBookService>().GetPagedSearchBooks(key, pageIndex - 1, WebConfig.BookPageSize, sortField, sortOrder, out total);
            pagedBooksInfo.Total = total;

            ViewBag.BookCategoryList = categoryList;

            return View("BookList", pagedBooksInfo);
        }

        public ActionResult Detail(Guid bookId)
        {
            var book = ResolveService<IBookService>().GetByID(bookId);
            return View(book);
        }

        public ActionResult Comments(Guid bookId)
        {
            return View();
        }
    }
}
