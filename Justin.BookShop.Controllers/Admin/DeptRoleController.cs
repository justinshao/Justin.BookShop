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
using Justin.BookShop.Controllers.Filters;

namespace Justin.BookShop.Controllers.Admin
{
    public class DeptRoleController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllDepartment()
        {
            var result = (from d in ResolveService<IDepartmentService>().GetAll()
                         orderby d.Sort
                         select new
                         {
                             ID = d.ID,
                             ParentID = d.Parent == null ? -1 : d.Parent.ID,
                             Name = d.Name,
                             Roles = from r in d.Roles select r.Name
                         }).ToList();

            return Json(result);
        }

        public ActionResult SelectForm(int deptID)
        {
            var dept = ResolveService<IDepartmentService>().GetById(deptID);
            var ids = from r in dept.Roles select r.ID;

            ViewBag.SelectedRoleIDs = Util.SerializeToJson(ids);
            ViewBag.DeptID = deptID;

            return View();
        }

        public ActionResult AuthorizeRoles(int deptID, int[] roleIDs)
        {
            if(roleIDs == null)
                roleIDs = new int[0];
            ResolveService<IDepartmentService>().AuthorizeRoles(deptID, roleIDs);

            return Json(new ViewModels.JsonResultData
            {
                Success = true
            });
        }
    }
}
