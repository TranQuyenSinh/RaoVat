using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Banner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Display",
                table: "Banners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Banners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 6, 18, 59, 37, 710, DateTimeKind.Local).AddTicks(3900), "+RbBIQb+4eBBct4W54jdB8keWgQjlxl1yBwnBc6VoYBcYvxg" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 6, 18, 59, 37, 714, DateTimeKind.Local).AddTicks(4681), "AKHP5QYi7zwt8IA1vMwWFrPUTlbve4GxBMnkp9EARLU0tq73" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 6, 18, 59, 37, 718, DateTimeKind.Local).AddTicks(1740), "G4W4MryK4+vLDRDVB0u0DVAsg13d7C60c8vu04j0tsf5Gwuv" });

            migrationBuilder.CreateIndex(
                name: "IX_Banners_UserId",
                table: "Banners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_User_UserId",
                table: "Banners",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_User_UserId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_UserId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Banners");

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
    }
}
