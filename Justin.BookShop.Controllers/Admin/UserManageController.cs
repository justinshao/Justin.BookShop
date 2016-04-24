using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;
using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Controllers.ModelBinders;

namespace Justin.BookShop.Controllers.Admin
{
    public class UserManageController : UserController
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
            var data = (from u in ResolveService<IUserService>().GetPagedSysUsers(pagination.PageIndex,
                                  pagination.PageSize, pagination.SortField, pagination.SortOrder, out total, 
                                  u => selector == null ? true : selector.IsMatch(u))
                        select u.CopyToViewModel()).ToList();

            return Json(new { 
                total = total,
                data = data
            });
        }

        [HttpPost]
        public ActionResult SaveChanges(IEnumerable<ViewModels.User> changedUsers)
        {
            var userService = ResolveService<IUserService>();
            var departmentService = ResolveService<IDepartmentService>();
            List<DomainModels.User> usersToSave = new List<DomainModels.User>();
            foreach (var user in changedUsers)
            {
                DomainModels.User userToSave = new DomainModels.User();
                if (user._state.Equals("modified", StringComparison.CurrentCultureIgnoreCase))
                {
                    userToSave = userService.GetUser(user.ID);
                    userToSave.Department = departmentService.GetById(user.DepartmentID);
                }
                if (user._state.Equals("added", StringComparison.CurrentCultureIgnoreCase))
                    userToSave.Department = departmentService.GetById(user.DepartmentID);
                usersToSave.Add(user.CopyToDomainModel(userToSave));
            }
            userService.SaveChanges(usersToSave);

            return Json(new JsonResultData { 
                Success = true
            });
        }

        [HttpPost]
        public ActionResult AddSysUser()
        {
            return null;
        }

        [HttpPost]
        public ActionResult ModifySysUser()
        {
            return null;
        }

        [HttpPost]
        public ActionResult ResetPassword(Guid userId, string newPassword)
        {
            var password = Util.GetMD5(newPassword);
            ResolveService<IUserService>().ResetPassword(userId, password);

            return Json(new JsonResultData { 
                Success = true
            });
        }
    }
}
