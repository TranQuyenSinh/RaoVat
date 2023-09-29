using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Genre_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AprovedUserId = table.Column<int>(type: "int", nullable: true),
                    AprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AprovedStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ad_User_AprovedUserId",
                        column: x => x.AprovedUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ad_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Genre_Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Genre_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Genre_Favorite_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Genre_Favorite_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdGenre_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdImage_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Ad_Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Ad_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Ad_Favorite_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Ad_Favorite_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Icon", "Image", "ParentId", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "ABC", "genreicon.png", "genreimage.png", null, "do-dien-tu", "Đồ điện tử" },
                    { 5, "ABC", "genreicon.png", "genreimage.png", null, "do-gia-dung", "Đồ gia dụng" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Censor" },
                    { 3, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Icon", "Image", "ParentId", "Slug", "Title" },
                values: new object[,]
                {
                    { 2, "ABC", "genreicon.png", "genreimage.png", 1, "dien-thoai", "Điện thoại" },
                    { 3, "ABC", "genreicon.png", "genreimage.png", 1, "may-tinh-bang", "Máy tính bảng" },
                    { 4, "ABC", "genreicon.png", "genreimage.png", 1, "laptop", "Laptop" },
                    { 6, "ABC", "genreicon.png", "genreimage.png", 5, "giuong-chan-ga", "Giường, chăn ga" },
                    { 7, "ABC", "genreicon.png", "genreimage.png", 5, "dung-cu-bep", "Dụng cụ bếp" },
                    { 8, "ABC", "genreicon.png", "genreimage.png", 5, "den", "Đèn" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "CreatedAt", "DateOfBirth", "Description", "District", "Email", "FullName", "Gender", "Password", "Phone", "Province", "RoleId", "Ward" },
                values: new object[,]
                {
                    { 1, "5M2", "customerAvatar.jpg", new DateTime(2023, 9, 29, 20, 19, 3, 984, DateTimeKind.Local).AddTicks(8681), new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC", "Thành phố Long Xuyên", "admin@gmail.com", "Trần Quyền Sinh", true, "123123", "0818283714", "Tỉnh An Giang", 1, "Phường Mỹ Long" },
                    { 2, "60C", "customerAvatar.jpg", new DateTime(2023, 9, 29, 20, 19, 3, 984, DateTimeKind.Local).AddTicks(8711), new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ", "Thành phố Long Xuyên", "censor@gmail.com", "Hồ Minh Nguyên", true, "123123", "0913615294", "Tỉnh An Giang", 2, "Phường Mỹ Bình" },
                    { 3, "30/12A", "customerAvatar.jpg", new DateTime(2023, 9, 29, 20, 19, 3, 984, DateTimeKind.Local).AddTicks(8716), new DateTime(2002, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCXYZ", "Thành phố Rạch Giá", "guest@gmail.com", "Nguyễn Thị Kim Nguyệt", false, "123123", "0941482144", "Tỉnh Kiên Giang", 3, "Phường Vĩnh Quang" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_AprovedUserId",
                table: "Ad",
                column: "AprovedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_AuthorId",
                table: "Ad",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdGenre_AdId",
                table: "AdGenre",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdGenre_GenreId",
                table: "AdGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AdImage_AdId",
                table: "AdImage",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ParentId",
                table: "Genre",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Slug",
                table: "Genre",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Ad_Favorite_AdId",
                table: "User_Ad_Favorite",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Ad_Favorite_UserId",
                table: "User_Ad_Favorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Genre_Favorite_GenreId",
                table: "User_Genre_Favorite",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Genre_Favorite_UserId",
                table: "User_Genre_Favorite",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdGenre");

            migrationBuilder.DropTable(
                name: "AdImage");

            migrationBuilder.DropTable(
                name: "User_Ad_Favorite");

            migrationBuilder.DropTable(
                name: "User_Genre_Favorite");

            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
