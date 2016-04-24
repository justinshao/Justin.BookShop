using Justin.BookShop.Controllers.Models;
using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.ModelBinders
{
    public class PaginationInfoBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(PaginationInfo))
                return null;

            try
            {
                PaginationInfo info = new PaginationInfo
                    {
                        PageIndex = (Int32)bindingContext.ValueProvider.GetValue("pageIndex").ConvertTo(typeof(Int32)),
                        PageSize = (Int32)bindingContext.ValueProvider.GetValue("pageSize").ConvertTo(typeof(Int32)),
                        SortField = (string)bindingContext.ValueProvider.GetValue("sortField").ConvertTo(typeof(string)),
                        SortOrder = ((string)bindingContext.ValueProvider.GetValue("sortOrder").ConvertTo(typeof(string)))
                                    .Equals("desc", StringComparison.CurrentCultureIgnoreCase) ? SortOrder.Desc : SortOrder.Asc
                    };

                return info;
            }
            catch
            {
                return null;
            }
        }
    }
}
