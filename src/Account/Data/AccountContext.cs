using Account.Models;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace Account.Data
{
    public class AccountContext : DbContext
    {
        public DbSet<User> User { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=database-1.c94i0zaglz9n.us-east-2.rds.amazonaws.com;database=dbFeiraOnlineDev;user=admin;password=feiraOnl1ne*");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserId);
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired();
            });

        }
    }
}