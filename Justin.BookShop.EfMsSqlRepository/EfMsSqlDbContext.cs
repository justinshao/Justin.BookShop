using Justin.BookShop.Entities;
using Justin.BookShop.IRepository;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Justin.BookShop.EfMsSqlRepository
{
    public class EfMsSqlDbContext : EfDbContext
    {
        static EfMsSqlDbContext()
        {
            //Database.DefaultConnectionFactory = new SqlConnectionFactory();
            //Database.SetInitializer(new Justin.BookShop.IRepository.DropCreateDatabaseIfModelChanges<EfMsSqlDbContext>());
        }

        public EfMsSqlDbContext(string connectionString)
            : base(connectionString) { }
    }
}
