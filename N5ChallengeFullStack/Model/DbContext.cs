using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace N5ChallengeFullStack.Model
{
    public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) :  base(options)
        {
            
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
