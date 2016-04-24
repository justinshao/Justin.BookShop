using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DomainModels = Justin.BookShop.Entities;
using ViewModels = Justin.BookShop.Controllers.Models;

namespace Justin.BookShop.Controllers.Admin
{
    public class RolePermsController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoleList([ModelBinder(typeof(RoleSelectorBinder))]
                                            IModelFieldSelector<DomainModels.UserRole> selector)
        {
            var result = (from r in ResolveService<IUserRoleService>().GetAllRoles()
                          where (selector == null ? true : selector.IsMatch(r))
                          select new 
                          {
                              ID = r.ID,
                              Name = r.Name,
                              Description = r.Description,
                              Permissions = (from p in r.Permissions select p.Name).ToList()
                          }).ToList();

            return Json(new
            {
                total = result.Count,
                data = result
            });
        }

        public ActionResult SelectForm(int roleID)
        {
            var ids = (from p in ResolveService<IUserRoleService>().GetById(roleID).Permissions
                      where p.Type == DomainModels.PermissionType.Comman
                      select p.ID).ToList();

            ViewBag.SelectedPermsIDs = Util.SerializeToJson(ids);
            ViewBag.RoleID = roleID;

            return View();
        }

        public ActionResult AuthorizePermission(int roleID, int[] permissionIDs)
        {
            ResolveService<IUserRoleService>().AuthorizePermission(roleID, permissionIDs);

            return Json(new ViewModels.JsonResultData { 
                Success = true
            });
        }
    }
}
