using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.Models;
using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Controllers.Comman;
using DomainModels = Justin.BookShop.Entities;
using ViewModels = Justin.BookShop.Controllers.Models;
using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.ModelFieldSelectors;

namespace Justin.BookShop.Controllers.Admin
{
    public class RoleManageController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([ModelBinder(typeof(RoleSelectorBinder))]
                                            IModelFieldSelector<DomainModels.UserRole> selector)
        {
            var result = (from r in ResolveService<IUserRoleService>().GetAllRoles()
                          where (selector == null ? true : selector.IsMatch(r))
                          select r.CopyToViewModel()).ToList();

            return Json(new { 
                total = result.Count,
                data = result
            });
        }

        [HttpPost]
        public ActionResult SaveChanges(IEnumerable<ViewModels.Role> changedRoles)
        {
            var roleService = ResolveService<IUserRoleService>();
            List<DomainModels.UserRole> rolesToSave = new List<DomainModels.UserRole>();
            foreach (var role in changedRoles)
            {
                DomainModels.UserRole roleToSave = new DomainModels.UserRole();
                if (role._state.Equals("modified", StringComparison.CurrentCultureIgnoreCase))
                    roleToSave = roleService.GetById(role.ID);

                rolesToSave.Add(role.CopyToDomainModel(roleToSave));
            }
            roleService.SaveChanges(rolesToSave);

            return Json(new JsonResultData
            {
                Success = true
            });
        }
    }
}
