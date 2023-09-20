using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using App.Models;
using App.Seeder;

namespace App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().HasData(
                RoleSeeder.Seed()
            );
            builder.Entity<Genre>().HasData(
                GenreSeeder.Seed()
            );
            builder.Entity<Customer>().HasData(
                CustomerSeeder.Seed()
            );
            builder.Entity<User>().HasData(
                UserSeeder.Seed()
            );

            // Username must be unique
            builder.Entity<User>().HasIndex(x => x.UserName).IsUnique();

            builder.Entity<Ad>()
            .HasOne<Customer>(a => a.Author)
            .WithMany(c => c.Ads)
            .HasForeignKey(a => a.AuthorId);

            builder.Entity<Ad>()
            .HasOne<User>(a => a.ApovedUser)
            .WithMany()
            .HasForeignKey(a => a.AprovedUserId);

            builder.Entity<Ad>()
            .HasMany<Customer>(a => a.FavoredCustomers)
            .WithMany(c => c.FavorAds);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }

    }
}