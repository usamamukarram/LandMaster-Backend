using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Society>Societies { get; set; }
        public DbSet<SocietyBlocks> societyBlocks { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<PlotSize> PlotSizes { get; set; }
        public DbSet<Buyyer> Buyyers { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany().HasForeignKey(r=>r.RoleId);
        }
    }
}
