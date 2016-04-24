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
    public interface IUserService : IService
    {
        [OperationContract]
        User Login(string loginName, string password, out string error);
        [OperationContract]
        User AdminLogin(string loginName, string password, out string error);
        [OperationContract]
        IEnumerable<Permission> GetAuthorizedPermissions(Guid userId, PermissionType? permissionType = null);
        [OperationContract]
        User GetUser(Guid userId);
        [OperationContract]
        IEnumerable<User> GetSysUsers();
        [OperationContract]
        IEnumerable<User> GetPagedSysUsers(int pageIndex, int pageSize, string sortField, SortOrder sortOrder, out int total, Func<User, Boolean> where = null);
        [OperationContract]
        void SaveChanges(IEnumerable<User> changedUsers);
        [OperationContract]
        void ResetPassword(Guid userId, string newPassword);
        [OperationContract]
        void AuthorizeRoles(Guid userID, int[] roleIDs);
        [OperationContract]
        void AuthorizePermissions(Guid userID, int[] permissionIDs);
        [OperationContract]
        string ClientRegister(User user);
        [OperationContract]
        IEnumerable<Permission> GetUserCenterMenu(Guid userId);
        [OperationContract]
        void SetTraceInfo(string traceInfo, Guid userId);
        [OperationContract]
        IEnumerable<Permission> GetAuthorizedMenue(Guid userId);
    }
}
