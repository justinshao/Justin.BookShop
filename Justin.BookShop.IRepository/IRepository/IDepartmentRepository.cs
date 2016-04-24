using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.IRepository
{
    public partial interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartmentsWithChildren(int parentId);
    }
}
