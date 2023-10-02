using Domain.Data.Mappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=localhost; Initial Catalog=ContaCorrente; User=sa; Password=P@55w0rd; MultipleActiveResultSets=True; TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(x => x.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            modelBuilder.Entity<Movement>()
                .HasOne(x => x.Account)
                .WithMany(x => x.Movements)
                .HasForeignKey(x => x.AccountId)
                .IsRequired();

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new MovementMap());
        }
    }
}
