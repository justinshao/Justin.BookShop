using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.ModelBinders
{
    public class RoleSelectorBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(IModelFieldSelector<UserRole>))
                return null;

            var key = bindingContext.ValueProvider.GetValue("key");
            if (key == null)
                return null;
            string[] keyData = ((string)key.ConvertTo(typeof(string))).Split('-');
            if (keyData.Count() < 2)
                return null;

            var field = keyData[0];
            var value = keyData[1];
            IModelFieldSelector<UserRole> selector = null;
            try
            {
                switch (field)
                {
                    case "name":
                        selector = new RoleNameSelector(value);
                        break;
                }
            }
            catch
            {
                selector = null;
            }
            return selector;
        }
    }
}
