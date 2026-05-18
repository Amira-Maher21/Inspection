using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Inspection.Infrastructure.DataContext
{
    //public class DbInspectionContextFactory : IDesignTimeDbContextFactory<DbInspectionContext>
    //{
    //    public DbInspectionContext CreateDbContext(string[] args)
    //    {
    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Inspection.API.Main"))
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<DbInspectionContext>();
    //        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

    //        return new DbInspectionContext(optionsBuilder.Options);
    //    }
    //}
    public class DbInspectionContextFactory : IDesignTimeDbContextFactory<DbInspectionContext>
    {
        public DbInspectionContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("Inspection");

            var optionsBuilder = new DbContextOptionsBuilder<DbInspectionContext>();
            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure();
            });

            return new DbInspectionContext(optionsBuilder.Options, config);
        }
    }
}