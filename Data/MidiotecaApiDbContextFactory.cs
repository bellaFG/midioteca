using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MidiotecaApi.Data
{
    public class MidiotecaApiDbContextFactory : IDesignTimeDbContextFactory<MidiotecaApiDbContext>
    {
        public MidiotecaApiDbContext CreateDbContext(string[] args)
        {
            // Lê appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MidiotecaApiDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MidiotecaApiDbContext(optionsBuilder.Options);
        }
    }
}
