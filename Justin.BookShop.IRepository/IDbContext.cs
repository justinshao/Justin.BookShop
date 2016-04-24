using Justin.BookShop.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Justin.BookShop.IRepository
{
    public interface IDbContext
    {
        IEnumerable<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
    }
}
