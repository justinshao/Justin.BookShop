using Justin.BookShop.Controllers.Filters;
using Justin.BookShop.Controllers.Models;
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
    public class DepManageController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Children(int ID)
        {
            // 以下两个操作延迟
            var departments = ResolveService<IDepartmentService>().GetDepartmentsWithChildren(ID);
            var jsonData = from d in departments
                           let isLeaf = d.Children.Count <= 0
                           select new
                           {
                               ID = d.ID,
                               ParentID = d.Parent == null ? -1 : d.Parent.ID,
                               Name = d.Name,
                               Sort = d.Sort,
                               iconCls = isLeaf ? "icon-cdept" : "icon-dept",
                               isLeaf = isLeaf,  // 测试是否区分大小写
                               expanded = isLeaf ? true : false,
                               asyncLoad = false
                           };

            return Json(jsonData);
        }

        public ActionResult AllDepartment()
        {
            var result = from d in ResolveService<IDepartmentService>().GetAll()
                         let isLeaf = d.Children.Count <= 0
                         orderby d.Sort
                         select new
                         {
                             ID = d.ID,
                             ParentID = d.Parent == null ? -1 : d.Parent.ID,
                             Name = d.Name,
                             iconCls = isLeaf ? "icon-cdept" :"icon-dept"
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(ViewModels.Department postDepartment)
        {
            var departmentService = ResolveService<IDepartmentService>();
            var parentDepartment = departmentService.GetById(postDepartment.ParentID);
            var newDepartment = new DomainModels.Department
            {
                Name = postDepartment.Name,
                Sort = postDepartment.Sort,
                Parent = parentDepartment
            };
            var addedDepartment = departmentService.Add(newDepartment);

            var jsonData = new
            {
                Success = addedDepartment != null,
                ErrorMessage = "操作失败",
                Department = new
                {
                    ID = addedDepartment.ID,
                    ParentID = addedDepartment.Parent == null ? -1 : addedDepartment.Parent.ID,
                    Name = addedDepartment.Name,
                    Sort = addedDepartment.Sort
                }
            };
            return Json(jsonData);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var ret = ResolveService<IDepartmentService>().Remove(id);
            var jsonData = new JsonResultData
            {
                Success = string.IsNullOrEmpty(ret),
                ErrorMessage = ret
            };

            return Json(jsonData);
        }

        [HttpPost]
        public ActionResult Rename(int id, string newName)
        {
            string ret = ResolveService<IDepartmentService>().Rename(id, newName);
            var jsonData = new JsonResultData
            {
                Success = string.IsNullOrEmpty(ret),
                ErrorMessage = ret
            };
            return Json(jsonData);
        }

        [HttpPost]
        public ActionResult Reorder(int id, int sort, int newParentID)
        {
            string ret = ResolveService<IDepartmentService>().Reoder(id, sort, newParentID);
            var jsonData = new JsonResultData
            {
                Success = string.IsNullOrEmpty(ret),
                ErrorMessage = ret
            };
            return Json(jsonData);
        }
    }
}
