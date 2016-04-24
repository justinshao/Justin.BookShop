using Justin.BookShop.Entities;
using Justin.BookShop.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.EfMsSqlRepository
{
    public partial class UserRepository
    {
        public User GetUserWithDeptAndRolesInfo(Guid id)
        {
            return Set.Include("Department").Include("Roles").Where(u => u.ID == id).FirstOrDefault();
        }
    }
}
