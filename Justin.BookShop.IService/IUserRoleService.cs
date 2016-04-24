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
    public interface IUserRoleService : IService
    {
        [OperationContract]
        IEnumerable<UserRole> GetAllRoles();
        [OperationContract]
        UserRole GetById(int id);
        [OperationContract]
        void SaveChanges(IEnumerable<UserRole> changedRoles);
        [OperationContract]
        void AuthorizePermission(int roleID, int[] permissionIDs);
    }
}
