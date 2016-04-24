using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Justin.BookShop.Entities;

namespace Justin.BookShop.IRepository
{
    public class EfDbContext : DbContext, IDbContext
    {
        public EfDbContext(string connectionString)
            : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var entityTypes = EntityTypeUtil.FindEntityTypes();
            //foreach (var type in entityTypes)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}

            //modelBuilder.Entity<User>().HasOptional(u => u.Department).WithMany(d => d.Users).WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }

        #region Methods
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IEnumerable<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }
        #endregion
    }
}
