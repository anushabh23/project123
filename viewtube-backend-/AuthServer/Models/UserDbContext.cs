using Microsoft.EntityFrameworkCore;

namespace AuthServer.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() { }
        public UserDbContext(DbContextOptions options) : base(options) 
        { 
            Database.EnsureCreated(); 
        }
        public DbSet<User> Users { get; set; }
    }
}
