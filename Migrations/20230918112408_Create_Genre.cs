using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Create_Genre : Migration
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

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Icon", "Image", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, "ABC", "genreicon.png", "genreimage.png", null, "Đồ điện tử" },
                    { 5, "ABC", "genreicon.png", "genreimage.png", null, "Đồ gia dụng" },
                    { 2, "ABC", "genreicon.png", "genreimage.png", 1, "Điện thoại" },
                    { 3, "ABC", "genreicon.png", "genreimage.png", 1, "Máy tính bảng" },
                    { 4, "ABC", "genreicon.png", "genreimage.png", 1, "Laptop" },
                    { 6, "ABC", "genreicon.png", "genreimage.png", 5, "Giường, chăn ga" },
                    { 7, "ABC", "genreicon.png", "genreimage.png", 5, "Dụng cụ bếp" },
                    { 8, "ABC", "genreicon.png", "genreimage.png", 5, "Đèn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ParentId",
                table: "Genre",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
