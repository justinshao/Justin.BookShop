using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    public class RoleNameSelector : IModelFieldSelector<UserRole>
    {
        private string _name;

        public RoleNameSelector(String name)
        {
            _name = name;
        }

        public bool IsMatch(UserRole model)
        {
            return model.Name.ToLower().Contains(_name.ToLower());
        }
    }
}
