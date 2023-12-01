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

            // seed data
            builder.Entity<Role>().HasData(RoleSeeder.Seed());
            builder.Entity<Genre>().HasData(GenreSeeder.Seed());
            builder.Entity<User>().HasData(UserSeeder.Seed());

            // config column
            builder.Entity<Genre>().HasIndex(x => x.Slug).IsUnique();
            builder.Entity<User>().HasIndex(x => x.Email).IsUnique();


            // many to many: Users - Users (Follow shop of User)
            builder.Entity<User>()
                .HasMany<User>(x => x.Followers)
                .WithMany(x => x.Followed)
                .UsingEntity<User_Shop_Follow>(
                    left => left.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction),
                    right => right.HasOne<User>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.NoAction)
                );

            // many to many: Ads - Users (Favorite Ads of User)
            builder.Entity<User_Ad_Favorite>()
                .HasOne(ua => ua.Ad)
                .WithMany(a => a.UserAd)
                .HasForeignKey(ua => ua.AdId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User_Ad_Favorite>()
                .HasOne(ua => ua.User)
                .WithMany(g => g.UserAd)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // many to many: Ads - Genres (Genres of Ad)
            builder.Entity<AdGenre>()
               .HasOne(ag => ag.Ad)
               .WithMany(a => a.AdGenre)
               .HasForeignKey(ag => ag.AdId);

            builder.Entity<AdGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(g => g.AdGenre)
                .HasForeignKey(ag => ag.GenreId);

            // one to many: User - Ads (Ads of User)
            builder.Entity<User>()
                .HasMany<Ad>(user => user.OwnAds)
                .WithOne(ad => ad.Author)
                .HasForeignKey(ad => ad.AuthorId);

            // one to many: User - Ads (one User can aprove many Ads)
            builder.Entity<Ad>()
                .HasOne<User>(a => a.ApovedUser)
                .WithMany()
                .HasForeignKey(a => a.AprovedUserId);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdGenre> AdGenre { get; set; }
        public DbSet<AdImage> AdImages { get; set; }
        public DbSet<User_Ad_Favorite> User_Ad_Favorite { get; set; }
        public DbSet<User_Shop_Follow> User_Shop_Follow { get; set; }

    }
}