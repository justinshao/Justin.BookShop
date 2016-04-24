using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;
using System.Web.Mvc;
using Justin.BookShop.IService;
using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Controllers.Filters;

namespace Justin.BookShop.Controllers.Admin
{
    public class UserPermsController : UserController
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
                         u => (selector == null ? true : selector.IsMatch(u)))
                          select new
                          {
                              ID = u.ID,
                              LoginName = u.LoginName,
                              Name = u.Name,
                              Gender = u.Gender,
                              DepartmentName = u.Department == null ? "" : u.Department.Name,
                              Position = u.Position,
                              IsAdmin = u.IsAdmin,
                              Permissions = (from p in u.Permissions where p.Type == DomainModels.PermissionType.Comman
                                             select p.Name)
                          }).ToList();

            return Json(new
            {
                total = total,
                data = result
            });
        }

        public ActionResult SelectForm(Guid userID)
        {
            var ids = from p in ResolveService<IUserService>().GetUser(userID).Permissions 
                      where p.Type == DomainModels.PermissionType.Comman
                      select p.ID;

            ViewBag.SelectedPermsIDs = Util.SerializeToJson(ids);
            ViewBag.UserID = userID;

            return View();
        }

        public ActionResult AuthorizePermission(Guid userID, int[] permissionIDs)
        {
            if(permissionIDs == null)
                permissionIDs = new int[0];
            ResolveService<IUserService>().AuthorizePermissions(userID, permissionIDs);

            return Json(new ViewModels.JsonResultData{
                Success = true
            });
        }
    }
}
