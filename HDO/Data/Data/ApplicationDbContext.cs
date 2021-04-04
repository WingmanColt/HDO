using Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HDO.Data
{
    public class BaseDbContext : ApiAuthorizationDbContext<User>
    {
        public BaseDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public DbSet<Statistics> Statistics { get; set; }
    }
}
