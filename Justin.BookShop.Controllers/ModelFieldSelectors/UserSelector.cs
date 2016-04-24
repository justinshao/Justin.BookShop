using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    class UserSelector : IModelFieldSelector<User>
    {
        private List<IModelFieldSelector<User>> _fieldSelectors;

        public List<IModelFieldSelector<User>> FieldSelectors
        {
            get
            {
                if (_fieldSelectors == null)
                    _fieldSelectors = new List<IModelFieldSelector<User>>();
                return _fieldSelectors;
            }
        }

        public bool IsMatch(User model)
        {
            foreach (var m in FieldSelectors)
            {
                if (!m.IsMatch(model))
                    return false;
            }
            return true;
        }
    }

    class UserDepartmentSelector : IModelFieldSelector<User>
    {
        private int _deptID;
        public UserDepartmentSelector(int departmentID)
        {
            _deptID = departmentID;
        }

        public bool IsMatch(User model)
        {
            return (model.Department != null && model.Department.ID == _deptID);
        }
    }

    class UserLoginNameSelector : IModelFieldSelector<User>
    {
        private string _loginName;

        public UserLoginNameSelector(string loginName)
        {
            _loginName = loginName;
        }

        public bool IsMatch(User model)
        {
            return model.LoginName.Equals(_loginName, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    class UserNameSelector : IModelFieldSelector<User>
    {
        public UserNameSelector(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public bool IsMatch(User model)
        {
            return model.Name.ToLower().Contains(Value.ToLower());
        }
    }
}
