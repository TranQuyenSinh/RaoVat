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
    [Migration("20230918112408_Create_Genre")]
    partial class Create_Genre
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.AllType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TypeKey")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("AllType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "ROLE",
                            TypeKey = "R1",
                            TypeName = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Type = "ROLE",
                            TypeKey = "R2",
                            TypeName = "Censor"
                        },
                        new
                        {
                            Id = 3,
                            Type = "GENDER",
                            TypeKey = "GD1",
                            TypeName = "Nam"
                        },
                        new
                        {
                            Id = 4,
                            Type = "GENDER",
                            TypeKey = "GD2",
                            TypeName = "Nữ"
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

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.HasOne("App.Models.Genre", "Parent")
                        .WithMany("ChildGenres")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("App.Models.Genre", b =>
                {
                    b.Navigation("ChildGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
