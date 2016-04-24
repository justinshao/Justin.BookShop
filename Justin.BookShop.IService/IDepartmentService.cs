using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.IService
{
    [ServiceContract]
    public interface IDepartmentService : IService
    {
        [OperationContract]
        IEnumerable<Department> GetDepartmentsWithChildren(int parentId);
        [OperationContract]
        Department GetById(int id);
        [OperationContract]
        Department Add(Department newDepartment);
        [OperationContract]
        String Remove(int id);
        [OperationContract]
        String Rename(int id, string newName);
        [OperationContract]
        String Reoder(int id, int sort, int newParentID);
        [OperationContract]
        IEnumerable<Department> GetAll();
        [OperationContract]
        void AuthorizeRoles(int departmentID, int[] roleIDs);
    }
}
