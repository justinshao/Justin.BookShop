using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Justin.BookShop.Entities;
using System.Data.Entity;

namespace Justin.BookShop.Entities.Util
{
    public class EntityTypeUtil
    {
        public static IEnumerable<Type> FindEntityTypes()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && !typeof(DbContext).IsAssignableFrom(t) && t.Namespace == "Justin.BookShop.Entities"
                    select t).ToList();
        }
    }
}
