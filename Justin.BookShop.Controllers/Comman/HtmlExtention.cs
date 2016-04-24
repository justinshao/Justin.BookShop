using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Comman
{
    public static class HtmlExtention
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, object htmlAttributes)
        {
            if (helper == null)
                throw new ArgumentException("参数为null", "helper");

            return null;
        }
    }
}
