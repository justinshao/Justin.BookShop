using Justin.BookShop.Controllers.ModelBinders;
using Justin.BookShop.Controllers.ModelFieldSelectors;
using Justin.BookShop.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels = Justin.BookShop.Controllers.Models;
using DomainModels = Justin.BookShop.Entities;
using Justin.BookShop.IService;
using Justin.BookShop.Controllers.Comman;
using Justin.BookShop.Controllers.Filters;

namespace Justin.BookShop.Controllers.Admin
{
    public class PressController : UserController
    {
        [Menu]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List([ModelBinder(typeof(PaginationInfoBinder))]
                                            PaginationInfo pagination,
                                         [ModelBinder(typeof(PressSelectorBinder))]
                                            IModelFieldSelector<DomainModels.Press> selector)
        {
            var total = 0;
            var data = (from p in ResolveService<IPressService>().GetPagedPresses(pagination.PageIndex,
                                  pagination.PageSize, pagination.SortField, pagination.SortOrder, out total, 
                                  p => selector == null ? true : selector.IsMatch(p))
                        select p.CopyToViewModel()).ToList();

            return Json(new
            {
                total = total,
                data = data
            });
        }

        [HttpPost]
        public ActionResult SaveChanges(IEnumerable<ViewModels.Press> changedPresses)
        {
            var service = ResolveService<IPressService>();
            List<DomainModels.Press> pressesToSave = new List<DomainModels.Press>();
            foreach (var press in changedPresses)
            {
                DomainModels.Press pressToSave = new DomainModels.Press();
                if (press._state.Equals("modified", StringComparison.CurrentCultureIgnoreCase))
                    pressToSave = service.GetById(press.ID);

                pressesToSave.Add(press.CopyToDomainModel(pressToSave));
            }
            service.SaveChanges(pressesToSave);

            return Json(new JsonResultData
            {
                Success = true
            });
        }

        [HttpPost]
        public ActionResult FilterPress(string key)
        {
            var result = (from p in ResolveService<IPressService>().GetAll()
                          where p.Name.ToLower().Contains(key)
                          select p.CopyToViewModel()).ToList();

            return Json(result);
        }
    }
}
