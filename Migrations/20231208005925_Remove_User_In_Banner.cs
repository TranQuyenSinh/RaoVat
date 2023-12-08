using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Remove_User_In_Banner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_User_UserId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_UserId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Banners");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 8, 7, 59, 24, 998, DateTimeKind.Local).AddTicks(4406), "1982S7uHLboH1444t5ZySnone28Ssodqb+BizlKmbgakwotB" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 8, 7, 59, 25, 2, DateTimeKind.Local).AddTicks(7355), "PCkOPe0D+Zfm/C5Hr6g551kNaAgpbkMinUmqZrasrA0Tic5t" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 12, 8, 7, 59, 25, 6, DateTimeKind.Local).AddTicks(4545), "a/sHeuIbgr8p25jRx7pY40jUpfbQRWYynIaqkYWT5ElaVAR6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
