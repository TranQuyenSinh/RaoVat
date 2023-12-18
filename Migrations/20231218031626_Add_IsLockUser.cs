using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsLockUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsLocked", "Password" },
                values: new object[] { new DateTime(2023, 12, 18, 10, 16, 26, 81, DateTimeKind.Local).AddTicks(4545), false, "mv4eC1xgisry1iLZNJqLwIlkqYknN+RsO1XZjrNC2BHM3/7I" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsLocked", "Password" },
                values: new object[] { new DateTime(2023, 12, 18, 10, 16, 26, 85, DateTimeKind.Local).AddTicks(8695), false, "8mOPX1mvtiKWc6/d3A75Q71ew90GXCAnAxi28dDkFqdlyT2N" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsLocked", "Password" },
                values: new object[] { new DateTime(2023, 12, 18, 10, 16, 26, 90, DateTimeKind.Local).AddTicks(3872), false, "IZa2tlc7Tp0nVFhuyp/kYbT23L6oKnX8XaV/AJItQ0ldwzUY" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "User");

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
    }
}
