using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ApplicationDbContext dbContext;
        private readonly IConfiguration Config;

        public DbFactory(IConfiguration configuration)
        {
            Config = configuration;
        }
        public ApplicationDbContext Init()
        {
            return dbContext ?? (dbContext = CreateDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            string connectionString = Config.GetConnectionString("OLXDbConnectionStrings");

            optionsBuilder.UseSqlServer(connectionString);


            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
