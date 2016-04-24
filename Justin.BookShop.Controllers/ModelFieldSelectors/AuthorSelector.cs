using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    public class AuthorSelector : IModelFieldSelector<Author>
    {
        private List<IModelFieldSelector<Author>> _fieldSelectors;

        public List<IModelFieldSelector<Author>> FieldSelectors
        {
            get
            {
                if (_fieldSelectors == null)
                    _fieldSelectors = new List<IModelFieldSelector<Author>>();
                return _fieldSelectors;
            }
        }

        public bool IsMatch(Author model)
        {
            foreach (var m in FieldSelectors)
            {
                if (!m.IsMatch(model))
                    return false;
            }
            return true;
        }
    }

    class AuthorNameSelector : IModelFieldSelector<Author>
    {
        string _name;

        public AuthorNameSelector(string name)
        {
            _name = name;
        }

        public bool IsMatch(Author model)
        {
            return model.Name.ToLower().StartsWith(_name.ToLower());
        }
    }
}
