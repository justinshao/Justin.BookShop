using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    public class PressSelector : IModelFieldSelector<Press>
    {
        private List<IModelFieldSelector<Press>> _fieldSelectors;

        public List<IModelFieldSelector<Press>> FieldSelectors
        {
            get
            {
                if (_fieldSelectors == null)
                    _fieldSelectors = new List<IModelFieldSelector<Press>>();
                return _fieldSelectors;
            }
        }

        public bool IsMatch(Press model)
        {
            foreach (var m in FieldSelectors)
            {
                if (!m.IsMatch(model))
                    return false;
            }
            return true;
        }
    }

    class PressNameSelector : IModelFieldSelector<Press>
    {
        string _name;

        public PressNameSelector(string name)
        {
            _name = name;
        }

        public bool IsMatch(Press model)
        {
            return model.Name.ToLower().Contains(_name.ToLower());
        }
    }
}
