using UserManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.DatabaseContext
{
    public class UserManageDBContext : DbContext
    {
         public UserManageDBContext(DbContextOptions<UserManageDBContext>options) : base(options)
         {
             Database.Migrate();
         }

        public DbSet<AppRole> AppRole {get;set;}

        public DbSet<IdentityUser> IdentityUser {get;set;}

        public DbSet<Users> Users {get;set;}

    }
}