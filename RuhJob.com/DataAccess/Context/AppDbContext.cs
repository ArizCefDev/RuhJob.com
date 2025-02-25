using System.Data;
using Microsoft.EntityFrameworkCore;
using RuhJob.com.DataAccess.Entity;

namespace RuhJob.com.DataAccess.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
    }
}
