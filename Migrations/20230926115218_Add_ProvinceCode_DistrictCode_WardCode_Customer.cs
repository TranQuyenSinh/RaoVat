using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_ProvinceCode_DistrictCode_WardCode_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictCode",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceCode",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WardCode",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DistrictCode", "ProvinceCode", "WardCode" },
                values: new object[] { new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2180), 82, 10, 2683 });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DistrictCode", "ProvinceCode", "WardCode" },
                values: new object[] { new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2207), 883, 89, 30280 });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DistrictCode", "ProvinceCode", "WardCode" },
                values: new object[] { new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2211), 1, 1, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Customer");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 25, 16, 50, 42, 98, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 25, 16, 50, 42, 98, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 25, 16, 50, 42, 98, DateTimeKind.Local).AddTicks(5031));
        }
    }
}
