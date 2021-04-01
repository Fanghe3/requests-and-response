
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data
{
     public class gCoreDbContext : DbContext
    {
        public gCoreDbContext(DbContextOptions<gCoreDbContext> options) : base(options) { }
/* 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(@"Data Source=C:\blogging.db");
 */
        public DbSet<Customer> Customers { get; set; }
    }
}