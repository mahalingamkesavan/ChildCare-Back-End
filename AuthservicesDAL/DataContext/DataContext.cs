using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace AuthservicesDAL.DataContext
{
    public class DtContext : IdentityDbContext<ApplicationUser>
    {
        public DtContext(DbContextOptions<DtContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    /* public class AuthDbContext : DbContext
     {
         public AuthDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
         public DbSet<ResetPasswordSaveOtpModule> ResetPasswordSaveTokens { get; set; }
     }*/
}

