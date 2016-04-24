using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public IEnumerable<Entities.Department> GetDepartmentsWithChildren(int parentId)
        {
            var ret = DbSession.Departments.GetDepartmentsWithChildren(parentId);
            if (ret == null)
                return new List<Department>();
            return ret;
        }

        public Entities.Department GetById(int id)
        {
            return DbSession.Departments.GetSingle(d => d.ID == id);
        }

        public Entities.Department Add(Entities.Department newDepartment)
        {
            return DbSession.Departments.Add(newDepartment);
        }

        public String Remove(int id)
        {
            string error = string.Empty;

            var departmentToRemove = DbSession.Departments.GetSingle(d => d.ID == id);
            if (departmentToRemove.Children.Count() > 0)
                error = "该部门下还有其他子部门，不允许删除。";
            else
                DbSession.Departments.Delete(departmentToRemove);

            return error;
        }

        public string Rename(int id, string newName)
        {
            string error = string.Empty;
            try
            {
                var departmentToEdit = DbSession.Departments.GetSingle(d => d.ID == id);
                departmentToEdit.Name = newName; DbSession.Departments.Update(departmentToEdit);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }

        public string Reoder(int id, int sort, int newParentID)
        {
            string error = string.Empty;
            try
            {
                var repository = DbSession.Departments;
                var departmentToEdit = repository.GetSingle(d => d.ID == id);
                departmentToEdit.Sort = sort;
                var newParent = repository.GetSingle(d => d.ID == newParentID);
                departmentToEdit.Parent = newParent;
                repository.Update(departmentToEdit);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }

        public IEnumerable<Department> GetAll()
        {
            return DbSession.Departments.All;
        }

        public void AuthorizeRoles(int departmentID, int[] roleIDs)
        {
            var dept = DbSession.Departments.GetSingle(d => d.ID == departmentID);
            dept.Roles.Clear();
            foreach (var roleID in roleIDs)
            {
                var role = DbSession.UserRoles.GetSingle(r => r.ID == roleID);
                if (role != null)
                    dept.Roles.Add(role);
            }
            DbSession.SaveChanges();
        }
    }
}
