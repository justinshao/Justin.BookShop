using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        public IEnumerable<Entities.UserRole> GetAllRoles()
        {
            return DbSession.UserRoles.All;
        }

        public Entities.UserRole GetById(int id)
        {
            return DbSession.UserRoles.GetSingle(r => r.ID == id);
        }

        public void SaveChanges(IEnumerable<Entities.UserRole> changedRoles)
        {
            var session = DbSession.UserRoles;
            foreach (var role in changedRoles)
            {
                switch (role.State)
                {
                    case Justin.BookShop.Entities.EntityState.Add:
                        role.Description = role.Description ?? "";
                        session.Add(role, false);
                        break;
                    case Justin.BookShop.Entities.EntityState.Delete:
                        var tmp = session.GetSingle(u => u.ID == role.ID);
                        if (tmp != null)
                            session.Delete(tmp, false);
                        break;
                    case Justin.BookShop.Entities.EntityState.Modify:
                        role.Description = role.Description ?? "";
                        session.Update(role, false);
                        break;
                    default:
                        break;
                }
            }
            DbSession.SaveChanges();
        }

        public void AuthorizePermission(int roleID, int[] permissionIDs)
        {
            var role = DbSession.UserRoles.GetSingle(r => r.ID == roleID);
            role.Permissions.Clear();
            foreach (var id in permissionIDs)
            {
                var permission = DbSession.Permissions.GetSingle(p => p.ID == id);
                role.Permissions.Add(permission);
            }
            DbSession.SaveChanges();
        }
    }
}
