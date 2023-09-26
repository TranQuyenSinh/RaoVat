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
    [Migration("20230926115218_Add_ProvinceCode_DistrictCode_WardCode_Customer")]
    partial class Add_ProvinceCode_DistrictCode_WardCode_Customer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdCustomer", b =>
                {
                    b.Property<int>("FavorAdsId")
                        .HasColumnType("int");

                    b.Property<int>("FavoredCustomersId")
                        .HasColumnType("int");

                    b.HasKey("FavorAdsId", "FavoredCustomersId");

                    b.HasIndex("FavoredCustomersId");

                    b.ToTable("AdCustomer");
                });

            modelBuilder.Entity("AdGenre", b =>
                {
                    b.Property<int>("AdsId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("AdsId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("AdGenre");
                });

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

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

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

            modelBuilder.Entity("App.Models.AdImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("AdImage");
                });

            modelBuilder.Entity("App.Models.Customer", b =>
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

                    b.Property<int>("DistrictCode")
                        .HasColumnType("int");

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

                    b.Property<int>("ProvinceCode")
                        .HasColumnType("int");

                    b.Property<int>("WardCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "5M2, Mỹ Long, Long Xuyên, An Giang",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2180),
                            DateOfBirth = new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "ABC",
                            DistrictCode = 82,
                            Email = "tqsinh_21th@student.agu.edu.vn",
                            FullName = "Trần Quyền Sinh",
                            Gender = true,
                            Password = "123123",
                            Phone = "0818283714",
                            ProvinceCode = 10,
                            WardCode = 2683
                        },
                        new
                        {
                            Id = 2,
                            Address = "60C, Mỹ Bình, Long Xuyên, An Giang",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2207),
                            DateOfBirth = new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "XYZ",
                            DistrictCode = 883,
                            Email = "hmnguyen_21th@student.agu.edu.vn",
                            FullName = "Hồ Minh Nguyên",
                            Gender = true,
                            Password = "123123",
                            Phone = "0913615294",
                            ProvinceCode = 89,
                            WardCode = 30280
                        },
                        new
                        {
                            Id = 3,
                            Address = "30/12A, Mỹ Phước, Long Xuyên, An Giang",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2211),
                            DateOfBirth = new DateTime(2002, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "ABCXYZ",
                            DistrictCode = 1,
                            Email = "ntknguyet_21th@student.agu.edu.vn",
                            FullName = "Nguyễn Thị Kim Nguyệt",
                            Gender = false,
                            Password = "123123",
                            Phone = "0941482144",
                            ProvinceCode = 1,
                            WardCode = 4
                        });
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
                        });
                });

            modelBuilder.Entity("App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Trần Quyền Sinh",
                            Password = "123123",
                            RoleId = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Nguyễn Phước Tài",
                            Password = "123123",
                            RoleId = 1,
                            UserName = "admin2"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Đặng Hào Phong",
                            Password = "123123",
                            RoleId = 2,
                            UserName = "censor"
                        });
                });

            modelBuilder.Entity("CustomerGenre", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("FavorGenresId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "FavorGenresId");

                    b.HasIndex("FavorGenresId");

                    b.ToTable("CustomerGenre");
                });

            modelBuilder.Entity("AdCustomer", b =>
                {
                    b.HasOne("App.Models.Ad", null)
                        .WithMany()
                        .HasForeignKey("FavorAdsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("FavoredCustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdGenre", b =>
                {
                    b.HasOne("App.Models.Ad", null)
                        .WithMany()
                        .HasForeignKey("AdsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Models.Ad", b =>
                {
                    b.HasOne("App.Models.User", "ApovedUser")
                        .WithMany()
                        .HasForeignKey("AprovedUserId");

                    b.HasOne("App.Models.Customer", "Author")
                        .WithMany("Ads")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApovedUser");

                    b.Navigation("Author");
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
                        .WithMany("ChildGenres")
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

            modelBuilder.Entity("CustomerGenre", b =>
                {
                    b.HasOne("App.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("FavorGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Models.Ad", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("App.Models.Customer", b =>
                {
                    b.Navigation("Ads");
                });

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.Navigation("ChildGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
