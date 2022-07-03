using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoftwareStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(p => p.Softwares)
                .WithMany(b => b.Accounts);
            modelBuilder.Entity<Software>()
                .HasMany(p => p.Reviews)
                .WithOne(b => b.Software);
        }
    }
}
