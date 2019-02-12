using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TravelApp.Configuration;
using TravelApp.Web;

namespace TravelApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TravelAppDbContextFactory : IDesignTimeDbContextFactory<TravelAppDbContext>
    {
        public TravelAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TravelAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TravelAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TravelAppConsts.ConnectionStringName));

            return new TravelAppDbContext(builder.Options);
        }
    }
}
