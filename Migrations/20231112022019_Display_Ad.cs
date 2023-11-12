using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Display_Ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Display",
                table: "Ad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 12, 9, 20, 18, 973, DateTimeKind.Local).AddTicks(7677), "8pdeBGbDfkR+1Cl0vb0KFIUkCBQM1hTrkYNPiXAarJDnB4fG" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 12, 9, 20, 18, 977, DateTimeKind.Local).AddTicks(4806), "GMQ8CiRbnSN+6o7t5l8jqssKGfrTv/CLPilMEnbjhqCoJ7DD" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 12, 9, 20, 18, 981, DateTimeKind.Local).AddTicks(5420), "y0KR+bWoxA415hC6HowIvTMfelW4FhSn4U1VMP6j/INTBngR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Display",
                table: "Ad");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 23, 17, 45, 59, 489, DateTimeKind.Local).AddTicks(2391), "SAsBA+VWn6ugXQTEo4q9fNJgyohrMtUaYn5I3lj7dtiMlCvN" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 23, 17, 45, 59, 493, DateTimeKind.Local).AddTicks(6229), "xU1KfgXlMVrEPMSNqG5Ozq4RB+NcRoDCZ/C04N54NIW55qUr" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 23, 17, 45, 59, 498, DateTimeKind.Local).AddTicks(2868), "xlpuOHJ01/WOfEN8y+e26Ic2a7YRmctv46X0hscxNQ8qi/k3" });
        }
    }
}
