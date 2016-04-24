using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DomainModels = Justin.BookShop.Entities;

namespace Justin.BookShop.Controllers.Admin
{
    public class UserRoleController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SysUserList([ModelBinder(typeof(PaginationInfoBinder))]
                                            PaginationInfo pagination,
                                         [ModelBinder(typeof(UserSelectorBinder))]
                                            IModelFieldSelector<DomainModels.User> selector)
        {
            var total = 0;
            var result = (from u in ResolveService<IUserService>().GetPagedSysUsers(pagination.PageIndex, pagination.PageSize,
                         pagination.SortField, pagination.SortOrder, out total, 
                         u => selector == null ? true : selector.IsMatch(u))
                         select new
                         {
                             ID = u.ID,
                             LoginName = u.LoginName,
                             Name = u.Name,
                             Gender = u.Gender,
                             DepartmentName = u.Department == null ? "" : u.Department.Name,
                             Position = u.Position,
                             IsAdmin = u.IsAdmin,
                             Roles = (from r in u.Roles select r.Name)
                         }).ToList();

            return Json(new { 
                total = total,
                data = result
            });
        }

        public ActionResult SelectForm(Guid userID)
        {
            var user = ResolveService<IUserService>().GetUser(userID);
            var ids = from r in user.Roles select r.ID;

            ViewBag.SelectedRoleIDs = Util.SerializeToJson(ids);
            ViewBag.UserID = userID;

            return View();
        }

        public ActionResult AuthorizeRoles(Guid userID, int[] roleIDs)
        {
            if (roleIDs == null)
                roleIDs = new int[0];
            ResolveService<IUserService>().AuthorizeRoles(userID, roleIDs);

            return Json(new JsonResultData { 
                Success = true
            });
        }
    }
}
