using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TravelApp.EntityFrameworkCore
{
    public static class TravelAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TravelAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TravelAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
