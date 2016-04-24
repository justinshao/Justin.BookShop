using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.ModelFieldSelectors
{
    public interface IModelFieldSelector<TModel>
    {
        Boolean IsMatch(TModel model);
    }
}
