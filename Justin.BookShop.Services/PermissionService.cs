using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class PermissionService : BaseService, IPermissionService
    {
        public IEnumerable<Entities.Permission> GetAll()
        {
            return DbSession.Permissions.All.OrderBy(p => p.Sort);
        }

        public Permission AddNew(Permission newPermission)
        {
            return DbSession.Permissions.Add(newPermission);
        }

        public Permission GetById(int id)
        {
            return DbSession.Permissions.GetSingle(p => p.ID == id);
        }

        public string Remove(int id)
        {
            string error = string.Empty;

            var permissionToDelete = DbSession.Permissions.GetSingle(p => p.ID == id);
            if (permissionToDelete.Children.Count > 0)
                error = "该项下还有其他子项，不允许删除。";
            else
                DbSession.Permissions.Delete(permissionToDelete);

            return error;
        }

        public Permission Update(Permission permission)
        {
            return DbSession.Permissions.Update(permission);
        }
    }
}
