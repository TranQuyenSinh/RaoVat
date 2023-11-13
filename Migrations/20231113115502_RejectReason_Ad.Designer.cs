﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231113115502_RejectReason_Ad")]
    partial class RejectReason_Ad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AprovedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte>("AprovedStatus")
                        .HasColumnType("tinyint");

                    b.Property<int?>("AprovedUserId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Display")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AprovedUserId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("App.Models.AdGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("GenreId");

                    b.ToTable("AdGenre");
                });

            modelBuilder.Entity("App.Models.AdImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("AdImage");
                });

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            Slug = "do-dien-tu",
                            Title = "Đồ điện tử"
                        },
                        new
                        {
                            Id = 2,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 1,
                            Slug = "dien-thoai",
                            Title = "Điện thoại"
                        },
                        new
                        {
                            Id = 3,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 1,
                            Slug = "may-tinh-bang",
                            Title = "Máy tính bảng"
                        },
                        new
                        {
                            Id = 4,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 1,
                            Slug = "laptop",
                            Title = "Laptop"
                        },
                        new
                        {
                            Id = 5,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            Slug = "do-gia-dung",
                            Title = "Đồ gia dụng"
                        },
                        new
                        {
                            Id = 6,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 5,
                            Slug = "giuong-chan-ga",
                            Title = "Giường, chăn ga"
                        },
                        new
                        {
                            Id = 7,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 5,
                            Slug = "dung-cu-bep",
                            Title = "Dụng cụ bếp"
                        },
                        new
                        {
                            Id = 8,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 5,
                            Slug = "den",
                            Title = "Đèn"
                        });
                });

            modelBuilder.Entity("App.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Censor"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Guest"
                        });
                });

            modelBuilder.Entity("App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "5M2",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 11, 13, 18, 55, 2, 300, DateTimeKind.Local).AddTicks(3288),
                            DateOfBirth = new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "ABC",
                            District = "Thành phố Long Xuyên",
                            Email = "admin@gmail.com",
                            FullName = "Trần Quyền Sinh",
                            Gender = true,
                            Password = "fZUXCj2fj3PrCxNsPAs7IIKSJ2o1HsqhIx7BrBJkc3Oiuc0w",
                            Phone = "0818283714",
                            Province = "Tỉnh An Giang",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 1,
                            Ward = "Phường Mỹ Long"
                        },
                        new
                        {
                            Id = 2,
                            Address = "60C",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 11, 13, 18, 55, 2, 304, DateTimeKind.Local).AddTicks(2373),
                            DateOfBirth = new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "XYZ",
                            District = "Thành phố Long Xuyên",
                            Email = "censor@gmail.com",
                            FullName = "Hồ Minh Nguyên",
                            Gender = true,
                            Password = "0nL2jGwM1Vglzii98kXPtLf2zgvJFfBsJWugCf1Nh7aNz6nr",
                            Phone = "0913615294",
                            Province = "Tỉnh An Giang",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 2,
                            Ward = "Phường Mỹ Bình"
                        },
                        new
                        {
                            Id = 3,
                            Address = "30/12A",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 11, 13, 18, 55, 2, 308, DateTimeKind.Local).AddTicks(782),
                            DateOfBirth = new DateTime(2002, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "ABCXYZ",
                            District = "Thành phố Rạch Giá",
                            Email = "guest@gmail.com",
                            FullName = "Nguyễn Thị Kim Nguyệt",
                            Gender = false,
                            Password = "7w/RGRiFDGBDQg49Ri+yu8ZHEMuawsJtz+D+d85vcCcnOS0a",
                            Phone = "0941482144",
                            Province = "Tỉnh Kiên Giang",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 3,
                            Ward = "Phường Vĩnh Quang"
                        });
                });

            modelBuilder.Entity("App.Models.User_Ad_Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Ad_Favorite");
                });

            modelBuilder.Entity("App.Models.User_Shop_Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Shop_Follow");
                });

            modelBuilder.Entity("App.Models.Ad", b =>
                {
                    b.HasOne("App.Models.User", "ApovedUser")
                        .WithMany()
                        .HasForeignKey("AprovedUserId");

                    b.HasOne("App.Models.User", "Author")
                        .WithMany("OwnAds")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApovedUser");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("App.Models.AdGenre", b =>
                {
                    b.HasOne("App.Models.Ad", "Ad")
                        .WithMany("AdGenre")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Genre", "Genre")
                        .WithMany("AdGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("App.Models.AdImage", b =>
                {
                    b.HasOne("App.Models.Ad", null)
                        .WithMany("Images")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.HasOne("App.Models.Genre", "Parent")
                        .WithMany("ChildrenGenres")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("App.Models.User", b =>
                {
                    b.HasOne("App.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("App.Models.User_Ad_Favorite", b =>
                {
                    b.HasOne("App.Models.Ad", "Ad")
                        .WithMany("UserAd")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.User", "User")
                        .WithMany("UserAd")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Models.User_Shop_Follow", b =>
                {
                    b.HasOne("App.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Models.Ad", b =>
                {
                    b.Navigation("AdGenre");

                    b.Navigation("Images");

                    b.Navigation("UserAd");
                });

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.Navigation("AdGenre");

                    b.Navigation("ChildrenGenres");
                });

            modelBuilder.Entity("App.Models.User", b =>
                {
                    b.Navigation("OwnAds");

                    b.Navigation("UserAd");
                });
#pragma warning restore 612, 618
        }
    }
}
