using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    public class PermissionNameSelector : IModelFieldSelector<Permission>
    {
        private string _name;

        public PermissionNameSelector(string name)
        {
            _name = name;
        }

        public bool IsMatch(Permission model)
        {
            return model.Name.ToLower().Contains(_name.ToLower());
        }
    }
}
