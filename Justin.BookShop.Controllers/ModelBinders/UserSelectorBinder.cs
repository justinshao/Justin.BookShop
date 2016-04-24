using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Entities;

namespace Justin.BookShop.Controllers.ModelBinders
{
    public class UserSelectorBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(IModelFieldSelector<User>))
                return null;

            var keyStr = bindingContext.ValueProvider.GetValue("key");
            if (keyStr == null)
                return null;
            string[] keys = ((string)keyStr.ConvertTo(typeof(string))).Split(',');
            if (keys.Count() <= 0)
                return null;

            var selector = new UserSelector();
            foreach (var key in keys)
            {
                var keyData = key.Split('-');
                if (keyData.Count() < 2)
                    continue;

                var field = keyData[0];
                var value = keyData[1];
                switch (field)
                {
                    case "loginname":
                        selector.FieldSelectors.Add(new UserLoginNameSelector(value));
                        break;
                    case "name":
                        selector.FieldSelectors.Add(new UserNameSelector(value));
                        break;
                    case "department":
                        selector.FieldSelectors.Add(new UserDepartmentSelector(Convert.ToInt32(value)));
                        break;
                }
            }

            return selector;
        }
    }
}
