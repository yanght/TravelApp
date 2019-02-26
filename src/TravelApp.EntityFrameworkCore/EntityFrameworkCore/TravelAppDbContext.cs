using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TravelApp.Authorization.Roles;
using TravelApp.Authorization.Users;
using TravelApp.MultiTenancy;
using TravelApp.Travel;
using TravelApp.Travel.Categorys;
using TravelApp.Travel.Projects;
using TravelApp.EntityMapper.Projects;

namespace TravelApp.EntityFrameworkCore
{
    public class TravelAppDbContext : AbpZeroDbContext<Tenant, Role, User, TravelAppDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Project> Project { get; set; }
    }
}
