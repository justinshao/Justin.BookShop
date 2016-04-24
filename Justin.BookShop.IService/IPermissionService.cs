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
    public interface IPermissionService : IService
    {
        [OperationContract]
        IEnumerable<Permission> GetAll();
        [OperationContract]
        Permission AddNew(Permission newPermission);
        [OperationContract]
        Permission GetById(Int32 id);
        [OperationContract]
        String Remove(Int32 id);
        [OperationContract]
        Permission Update(Permission permission);
    }
}
