using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ODDESTODDS.Persistence.Context;
using System.IO;
namespace ODDESTODDS
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Persistence.Context.ApplicatioDBContext>
    {
        public ApplicatioDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var builder = new DbContextOptionsBuilder<ApplicatioDBContext>();
            var connectionString = configuration.GetConnectionString("SqliteConnectionString");
            var currentDirectoryPath = Directory.GetCurrentDirectory();
            var envSettingsPath = Path.Combine(currentDirectoryPath, "oddestodds.db");
            builder.UseSqlite($"Data Source={envSettingsPath}");
            return new ApplicatioDBContext(builder.Options);
        }
    }
}
