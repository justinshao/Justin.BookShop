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
    public class AuthorSelectorBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(IModelFieldSelector<Author>))
                return null;

            var keyStr = bindingContext.ValueProvider.GetValue("key");
            if (keyStr == null)
                return null;
            string[] keys = ((string)keyStr.ConvertTo(typeof(string))).Split(',');
            if (keys.Count() <= 0)
                return null;

            var selector = new AuthorSelector();
            foreach (var key in keys)
            {
                var keyData = key.Split('-');
                if (keyData.Count() < 2)
                    continue;

                var field = keyData[0];
                var value = keyData[1];
                switch (field)
                {
                    case "name":
                        selector.FieldSelectors.Add(new AuthorNameSelector(value));
                        break;
                }
            }

            return selector;
        }
    }
}
