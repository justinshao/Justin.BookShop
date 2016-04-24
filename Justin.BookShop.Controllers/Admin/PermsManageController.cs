using Justin.BookShop.Controllers.Models;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Filters;
using System.Reflection;
using Filters = Justin.BookShop.Controllers.Filters;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Controllers.ModelBinders;

namespace Justin.BookShop.Controllers.Admin
{
    public class PermsManageController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([ModelBinder(typeof(PermissionSelectorBinder))]
            IModelFieldSelector<DomainModels.Permission> selector)
        {
            var allPermissions = ResolveService<IPermissionService>().GetAll();
            var jsonData = from p in allPermissions
                           where (selector == null ? true : selector.IsMatch(p))
                           orderby p.Sort
                           select new
                           {
                               ID = p.ID,
                               ParentID = p.Parent == null ? -1 : p.Parent.ID,
                               Name = p.Name,
                               Icon = p.Icon,
                               Controller = p.Controller,
                               Action = p.Action,
                               AlternateLink = p.AlternateLink,
                               TypeID = (int)p.Type,
                               Description = p.Description,
                               Sort = p.Sort,
                               iconCls = p.Icon
                           };

            return Json(jsonData);
        }

        [HttpPost]
        public ActionResult Update(ViewModels.Permission postPermission)
        {
            var result = new JsonResultData();

            var permsService = ResolveService<IPermissionService>();
            var permissionToUpdate = permsService.GetById(postPermission.ID);
            if (permissionToUpdate == null)
            {
                result.Success = false;
                result.ErrorMessage = "数据库不存在要更新的记录";
            }
            else
            {
                postPermission.CopyToDomainModel(permissionToUpdate);
                var updatedPermission = permsService.Update(permissionToUpdate);

                result.Success = true;
            }
            
            return Json(result);
        }

        [HttpPost]
        public ActionResult Add(ViewModels.Permission postPermission)
        {
            var result = new JsonResultData();

            var permsService = ResolveService<IPermissionService>();
            var parentPermission = permsService.GetById(postPermission.ParentID);
            var newPermission = postPermission.CopyToDomainModel();
            newPermission.Parent = parentPermission;
            var addedPermission = permsService.AddNew(newPermission);

            result.Success = true;

            return Json(result);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var ret = ResolveService<IPermissionService>().Remove(id);

            var result = new JsonResultData 
            { 
                Success = string.IsNullOrEmpty(ret),
                ErrorMessage = ret
            };
            return Json(result);
        }

        public ActionResult SysIcons()
        {
            IEnumerable<string> icons = (IEnumerable<string>)CacheHelper.GetCache(_sysIconCacheKey);
            var jsonData = from i in icons
                       select new { iconCls = i };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Controllers()
        {
            var controllerTypes = CacheHelper.GetCache(_sysControllerCacheKey) as IEnumerable<Type>;
            var jsonData = from c in controllerTypes
                           select new
                           {
                               Controller = c.Name.Substring(0, c.Name.Length - "controller".Length)
                           };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Actions(string controllerName)
        {
            if (!controllerName.EndsWith("controller", StringComparison.CurrentCultureIgnoreCase))
                controllerName += "Controller";

            var jsonData = from c in CacheHelper.GetCache(_sysControllerCacheKey) as IEnumerable<Type>
                           where c.Name.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase)
                           from a in c.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                           let isMenu = a.IsDefined(typeof(Filters.Menu))
                           select new { Action = a.Name, IsMenu = isMenu };
            
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
