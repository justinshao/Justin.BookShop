using Justin.BookShop.Entities;
using Justin.BookShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Services
{
    public class PressService : BaseService, IPressService
    {
        public IEnumerable<Entities.Press> GetPagedPresses(int pageIndex, int pageSize, string sortField, Entities.SortOrder sortOrder, out int total, Func<Press, Boolean> @where = null)
        {
            var ret = (from p in DbSession.Presss.All
                       where (@where == null ? true : @where(p))
                       select p);
            var desc = sortOrder == SortOrder.Desc;

            switch (sortField.ToLower())
            {
                case "name":
                    ret = desc ? ret.OrderByDescending(p => p.Name) : ret.OrderBy(p => p.Name);
                    break;
                default:
                    ret = desc ? ret.OrderByDescending(p => p.Name) : ret.OrderBy(p => p.Name);
                    break;
            }
            total = ret.Count();

            return ret.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public Press GetById(int id)
        {
            return DbSession.Presss.GetSingle(p => p.ID == id);
        }

        public void SaveChanges(IEnumerable<Press> changedPresses)
        {
            var session = DbSession.Presss;
            foreach (var press in changedPresses)
            {
                switch (press.State)
                {
                    case Justin.BookShop.Entities.EntityState.Add:
                        session.Add(press, false);
                        break;
                    case Justin.BookShop.Entities.EntityState.Delete:
                        var tmp = session.GetSingle(u => u.ID == press.ID);
                        if (tmp != null)
                            session.Delete(tmp, false);
                        break;
                    case Justin.BookShop.Entities.EntityState.Modify:
                        session.Update(press, false);
                        break;
                    default:
                        break;
                }
            }
            DbSession.SaveChanges();
        }

        public IEnumerable<Press> GetAll()
        {
            return DbSession.Presss.All;
        }
    }
}
