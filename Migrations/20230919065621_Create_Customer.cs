using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Create_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Avatar", "DateOfBirth", "Description", "Email", "FullName", "Gender", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "5M2, Mỹ Long, Long Xuyên, An Giang", "customerAvatar.jpg", new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC", "tqsinh_21th@student.agu.edu.vn", "Trần Quyền Sinh", true, "123123", "0818283714" },
                    { 2, "60C, Mỹ Bình, Long Xuyên, An Giang", "customerAvatar.jpg", new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ", "hmnguyen_21th@student.agu.edu.vn", "Hồ Minh Nguyên", true, "123123", "0913615294" },
                    { 3, "30/12A, Mỹ Phước, Long Xuyên, An Giang", "customerAvatar.jpg", new DateTime(2002, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCXYZ", "ntknguyet_21th@student.agu.edu.vn", "Nguyễn Thị Kim Nguyệt", false, "123123", "0941482144" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
