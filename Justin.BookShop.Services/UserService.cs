using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class UserService : BaseService, IUserService
    {
        public User Login(string loginName, string password, out string error)
        {
            error = string.Empty;
            var user = DbSession.Users.GetSingle(u => u.LoginName == loginName && !u.IsAdmin && u.InUse);
            if (user == null)
            {
                error = "用户名不存在";
                return null;
            }
            if (user.Password != password)
            {
                error = "密码错误";
                return null;
            }
            return user;
        }

        public User AdminLogin(string loginName, string password, out string error)
        {
            error = string.Empty;
            var user = DbSession.Users.GetSingle(u => u.LoginName == loginName && u.IsAdmin && u.InUse);
            if (user == null)
            {
                error = "用户名不存在";
                return null;
            }
            if (user.Password != password)
            {
                error = "密码错误";
                return null;
            }
            return user;
        }

        public IEnumerable<Permission> GetAuthorizedPermissions(Guid userId, PermissionType? permissionType = null)
        {
            return  from u in DbSession.Users.All
                    from p in
                        u.Permissions
                            .Union(from r in u.Roles from rp in r.Permissions select rp)
                            .Union(from dr in u.Department.Roles from drp in dr.Permissions select drp)
                    where u.ID == userId && (permissionType.HasValue && p.Type == permissionType)
                    select p;
        }

        public User GetUser(Guid userId)
        {
            return DbSession.Users.GetUserWithDeptAndRolesInfo(userId);
        }

        public IEnumerable<User> GetSysUsers()
        {
            return (from u in DbSession.Users.All
                   where u.IsAdmin
                   select u).ToList();
        }

        public void SaveChanges(IEnumerable<User> changedUsers)
        {
            var session = DbSession.Users;
            foreach (var user in changedUsers)
            {
                switch (user.State)
                {
                    case Justin.BookShop.Entities.EntityState.Add:
                        user.ID = Guid.NewGuid();
                        user.AddedTime = DateTime.Now;
                        user.IsAdmin = true;
                        user.InUse = true;
                        session.Add(user, false);
                        break;
                    case Justin.BookShop.Entities.EntityState.Delete:
                        var tmp = session.GetSingle(u => u.ID == user.ID);
                        if(tmp != null)
                            session.Delete(tmp, false);
                        break;
                    case Justin.BookShop.Entities.EntityState.Modify:
                        session.Update(user, false);
                        break;
                    default:
                        break;
                }
            }
            DbSession.SaveChanges();
        }

        public IEnumerable<User> GetPagedSysUsers(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total, Func<User, Boolean> @where = null)
        {
            var ret = (from u in DbSession.Users.All
                       where u.IsAdmin && (@where == null ? true : @where(u))
                       select u);
            var desc = sortOrder == SortOrder.Desc;

            switch (sortField.ToLower())
            {
                case "loginname":
                    ret = desc ? ret.OrderByDescending(u => u.LoginName) : ret.OrderBy(u => u.LoginName);
                    break;
                case "name":
                    ret = desc ? ret.OrderByDescending(u => u.Name) : ret.OrderBy(u => u.Name);
                    break;
                case "age":
                    ret = desc ? ret.OrderByDescending(u => u.Age) : ret.OrderBy(u => u.Age);
                    break;
                case "gender":
                    ret = desc ? ret.OrderByDescending(u => u.Gender) : ret.OrderBy(u => u.Gender);
                    break;
                case "email":
                    ret = desc ? ret.OrderByDescending(u => u.Email) : ret.OrderBy(u => u.Email);
                    break;
                case "birthdate":
                    ret = desc ? ret.OrderByDescending(u => u.BirthDate) : ret.OrderBy(u => u.BirthDate);
                    break;
                case "married":
                    ret = desc ? ret.OrderByDescending(u => u.Married) : ret.OrderBy(u => u.Married);
                    break;
                case "phone":
                    ret = desc ? ret.OrderByDescending(u => u.Phone) : ret.OrderBy(u => u.Phone);
                    break;
                case "position":
                    ret = desc ? ret.OrderByDescending(u => u.Position) : ret.OrderBy(u => u.Position);
                    break;
                case "salary":
                    ret = desc ? ret.OrderByDescending(u => u.Salary) : ret.OrderBy(u => u.Salary);
                    break;
                case "education":
                    ret = desc ? ret.OrderByDescending(u => u.Education) : ret.OrderBy(u => u.Education);
                    break;
                case "school":
                    ret = desc ? ret.OrderByDescending(u => u.School) : ret.OrderBy(u => u.School);
                    break;
                case "inuse":
                    ret = desc ? ret.OrderByDescending(u => u.InUse) : ret.OrderBy(u => u.InUse);
                    break;
                case "addedtime":
                    ret = desc ? ret.OrderByDescending(u => u.AddedTime) : ret.OrderBy(u => u.AddedTime);
                    break;
                case "isadmin":
                    ret = desc ? ret.OrderByDescending(u => u.IsAdmin) : ret.OrderBy(u => u.IsAdmin);
                    break;
                default:
                    ret = desc ? ret.OrderByDescending(u => u.Name) : ret.OrderBy(u => u.Name);
                    break;
            }
            total = ret.Count();

            return ret.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public void AuthorizeRoles(Guid userID, int[] roleIDs)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userID);
            user.Roles.Clear();
            foreach (var roleID in roleIDs)
            {
                var role = DbSession.UserRoles.GetSingle(r => r.ID == roleID);
                if (role != null)
                    user.Roles.Add(role);
            }
            DbSession.SaveChanges();
        }

        public void AuthorizePermissions(Guid userID, int[] permissionIDs)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userID);
            user.Permissions.Clear();
            foreach (var id in permissionIDs)
            {
                var permission = DbSession.Permissions.GetSingle(p => p.ID == id);
                if (permission != null)
                    user.Permissions.Add(permission);
            }
            DbSession.SaveChanges();
        }

        public void ResetPassword(Guid userId, string newPassword)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId && u.IsAdmin);
            if (user == null)
                throw new Exception("不存在该用户");

            user.Password = newPassword;
            DbSession.SaveChanges();
        }

        public string ClientRegister(User user)
        {
            string error = string.Empty;
            if (user == null)
                throw new ArgumentNullException("user为null", "user");
            if (string.IsNullOrEmpty(user.LoginName))
                throw new Exception("用户名不能为空");
            if (string.IsNullOrEmpty(user.Password))
                throw new Exception("密码不能为空");

            var _u = DbSession.Users.All.Where(u => u.LoginName.Equals(user.LoginName)).FirstOrDefault();
            if (_u != null)
            {
                error = "用户名已存在";
                return error;
            }

            user.ID = Guid.NewGuid();
            user.Name = user.Name ?? "";
            user.InUse = true;
            user.AddedTime = DateTime.Now;
            user.IsAdmin = false;

            try
            {
                DbSession.Users.Add(user);
                DbSession.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public IEnumerable<Permission> GetUserCenterMenu(Guid userId)
        {
            return new List<Permission> { 
                new Permission
                {
                    Name = "我的订单",
                    Controller = "Order",
                    Action = "List",
                },
                new Permission
                {
                    Name = "我的购物车",
                    Controller = "Cart",
                    Action = "List",
                },
                new Permission
                {
                    Name = "基本信息",
                    Controller = "User",
                    Action = "Info",
                }
            };
        }

        public void SetTraceInfo(string traceInfo, Guid userId)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId);
            user.TraceInfo = new TraceInfo
            {
                UserID = user.ID,
                Info = traceInfo
            };

            DbSession.SaveChanges();
        }

        public IEnumerable<Permission> GetAuthorizedMenue(Guid userId)
        {
            var user = DbSession.Users.GetSingle(u => u.ID == userId);
            if (user == null)
                throw new Exception("未知的用户身份");

            var p_dept = from r in user.Department.Roles
                         from p in r.Permissions
                         where p.Type == PermissionType.Menu
                         select p;

            var p_role = from r in user.Roles
                         from p in r.Permissions
                         where p.Type == PermissionType.Menu
                         select p;

            var p_user = from p in user.Permissions
                         where p.Type == PermissionType.Menu
                         select p;

            return p_dept.Union(p_role).Union(p_user);
        }
    }
}
