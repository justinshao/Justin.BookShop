using Justin.BookShop.IRepository;
using Justin.BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Justin.BookShop.IRepository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IDbContext _context;
        private DbSet<TEntity> _set;

        public EfRepository() { }

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        #region CRUD
        public virtual IEnumerable<TEntity> All
        {
            get { return Set; }
        }

        public TEntity GetSingle(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return this.Set.FirstOrDefault(filter);
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return this.Set.Where(filter);
        }

        public virtual TEntity Add(TEntity entity, bool saveChanges = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Set.Add(entity);
                if(saveChanges)
                    this._context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GenerateValidationError(dbEx);
            }
        }

        public virtual TEntity Update(TEntity entity, bool saveChanges = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                //Set.Attach(entity);
                //Context.Entry(entity).State = EntityState.Modified;

                if (saveChanges)
                    this._context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GenerateValidationError(dbEx);
            }
        }

        public virtual void Delete(TEntity entity, bool saveChanges = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Set.Remove(entity);
                if (saveChanges)
                    this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GenerateValidationError(dbEx);
            }
            catch
            {
                throw;
            }
        } 
	    #endregion

        protected DbSet<TEntity> Set
        {
            get
            {
                if(_set == null)
                    _set = _context.Set<TEntity>() as DbSet<TEntity>;
                return _set;
            }
        }

        protected DbContext Context
        {
            get 
            {
                return _context as DbContext; 
            }
        }

        private static Exception GenerateValidationError(DbEntityValidationException error)
        {
            var msg = string.Empty;

            foreach (var validationErrors in error.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            return new Exception(msg, error);
        }
    }
}
