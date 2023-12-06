using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_Banner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 6, 18, 47, 17, 293, DateTimeKind.Local).AddTicks(3970), "2hlXDxYZzCD74Fi7mAUpmsNVJp0lmLDeAR0GVXVU7VjGsr/N" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 6, 18, 47, 17, 297, DateTimeKind.Local).AddTicks(1138), "3ETSHJGWul+INRtuga2Ue0VvYSxIBn1MMzbmP9WHcRGcze2g" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 6, 18, 47, 17, 300, DateTimeKind.Local).AddTicks(9912), "oBVWXswA1shVroqad7sUhCyrCORfroSIDyF2/kfBljO8psoO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 13, 18, 55, 2, 300, DateTimeKind.Local).AddTicks(3288), "fZUXCj2fj3PrCxNsPAs7IIKSJ2o1HsqhIx7BrBJkc3Oiuc0w" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 13, 18, 55, 2, 304, DateTimeKind.Local).AddTicks(2373), "0nL2jGwM1Vglzii98kXPtLf2zgvJFfBsJWugCf1Nh7aNz6nr" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 13, 18, 55, 2, 308, DateTimeKind.Local).AddTicks(782), "7w/RGRiFDGBDQg49Ri+yu8ZHEMuawsJtz+D+d85vcCcnOS0a" });
        }
    }
}
