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
    [Migration("20230919071127_Update_Customer_CreatedAt")]
    partial class Update_Customer_CreatedAt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "5M2, Mỹ Long, Long Xuyên, An Giang",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 9, 19, 14, 11, 27, 707, DateTimeKind.Local).AddTicks(8633),
                            DateOfBirth = new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "ABC",
                            Email = "tqsinh_21th@student.agu.edu.vn",
                            FullName = "Trần Quyền Sinh",
                            Gender = true,
                            Password = "123123",
                            Phone = "0818283714"
                        },
                        new
                        {
                            Id = 2,
                            Address = "60C, Mỹ Bình, Long Xuyên, An Giang",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 9, 19, 14, 11, 27, 707, DateTimeKind.Local).AddTicks(8661),
                            DateOfBirth = new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "XYZ",
                            Email = "hmnguyen_21th@student.agu.edu.vn",
                            FullName = "Hồ Minh Nguyên",
                            Gender = true,
                            Password = "123123",
                            Phone = "0913615294"
                        },
                        new
                        {
                            Id = 3,
                            Address = "30/12A, Mỹ Phước, Long Xuyên, An Giang",
                            Avatar = "customerAvatar.jpg",
                            CreatedAt = new DateTime(2023, 9, 19, 14, 11, 27, 707, DateTimeKind.Local).AddTicks(8665),
                            DateOfBirth = new DateTime(2002, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "ABCXYZ",
                            Email = "ntknguyet_21th@student.agu.edu.vn",
                            FullName = "Nguyễn Thị Kim Nguyệt",
                            Gender = false,
                            Password = "123123",
                            Phone = "0941482144"
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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            Title = "Đồ điện tử"
                        },
                        new
                        {
                            Id = 2,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 1,
                            Title = "Điện thoại"
                        },
                        new
                        {
                            Id = 3,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 1,
                            Title = "Máy tính bảng"
                        },
                        new
                        {
                            Id = 4,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 1,
                            Title = "Laptop"
                        },
                        new
                        {
                            Id = 5,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            Title = "Đồ gia dụng"
                        },
                        new
                        {
                            Id = 6,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 5,
                            Title = "Giường, chăn ga"
                        },
                        new
                        {
                            Id = 7,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 5,
                            Title = "Dụng cụ bếp"
                        },
                        new
                        {
                            Id = 8,
                            Description = "ABC",
                            Icon = "genreicon.png",
                            Image = "genreimage.png",
                            ParentId = 5,
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

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.Navigation("ChildGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
