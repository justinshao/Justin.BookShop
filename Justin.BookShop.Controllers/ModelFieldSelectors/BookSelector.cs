using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    public class BookSelector : IModelFieldSelector<Book>
    {
        private List<IModelFieldSelector<Book>> _fieldSelectors;

        public List<IModelFieldSelector<Book>> FieldSelectors
        {
            get
            {
                if (_fieldSelectors == null)
                    _fieldSelectors = new List<IModelFieldSelector<Book>>();
                return _fieldSelectors;
            }
        }

        public bool IsMatch(Book model)
        {
            foreach (var m in FieldSelectors)
            {
                if (!m.IsMatch(model))
                    return false;
            }
            return true;
        }
    }

    class BookNameSelector : IModelFieldSelector<Book>
    {
        string _name;

        public BookNameSelector(string name)
        {
            this._name = name;
        }

        public bool IsMatch(Book model)
        {
            return model.Name.ToLower().Contains(_name.ToLower());
        }
    }

    class BookIsbnSelector : IModelFieldSelector<Book>
    {
        string _isbn;

        public BookIsbnSelector(string isbn)
        {
            this._isbn = isbn;
        }

        public bool IsMatch(Book model)
        {
            return string.IsNullOrEmpty(_isbn) || model.ISBN.Equals(_isbn, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    class BookAuthorSelector : IModelFieldSelector<Book>
    {
        string _author;

        public BookAuthorSelector(string author)
        {
            this._author = author;
        }

        public bool IsMatch(Book model)
        {
            return model.Authors.Any(a => a.Name.ToLower().Contains(_author.ToLower()));
        }
    }

    class BookPressSelector : IModelFieldSelector<Book>
    {
        string _press;

        public BookPressSelector(string press)
        {
            this._press = press;
        }

        public bool IsMatch(Book model)
        {
            return model.Presses.Any(p => p.Name.ToLower().Contains(_press));
        }
    }

}
