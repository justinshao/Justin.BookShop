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
    public class BookSelectorBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(IModelFieldSelector<Book>))
                return null;

            var keyStr = bindingContext.ValueProvider.GetValue("key");
            if (keyStr == null)
                return null;
            string[] keys = ((string)keyStr.ConvertTo(typeof(string))).Split(',');
            if (keys.Count() <= 0)
                return null;

            var selector = new BookSelector();
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
                        selector.FieldSelectors.Add(new BookNameSelector(value));
                        break;
                    case "isbn":
                        selector.FieldSelectors.Add(new BookIsbnSelector(value));
                        break;
                    case "author":
                        selector.FieldSelectors.Add(new BookAuthorSelector(value));
                        break;
                    case "press":
                        selector.FieldSelectors.Add(new BookPressSelector(value));
                        break;
                }
            }

            return selector;
        }
    }
}
