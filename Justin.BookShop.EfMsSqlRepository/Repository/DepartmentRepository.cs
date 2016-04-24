using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.EfMsSqlRepository
{
    public partial class DepartmentRepository
    {
        public IEnumerable<Department> GetDepartmentsWithChildren(int parentId)
        {
            var ret = from d in Set.Include("Children")
                   where parentId <= 0 ? d.Parent == null : d.Parent.ID == parentId
                   orderby d.Sort
                   select d;

            return (ret as IEnumerable<Department>) ?? new List<Department>();
        }
    }
}
