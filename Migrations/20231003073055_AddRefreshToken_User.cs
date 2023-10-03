using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[] { new DateTime(2023, 10, 3, 14, 30, 55, 74, DateTimeKind.Local).AddTicks(8235), "NBSmfJPuNafiHpOQgrWOKfbZrK0uL0qrfnkn1nFrRqLZ77IW", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[] { new DateTime(2023, 10, 3, 14, 30, 55, 79, DateTimeKind.Local).AddTicks(6434), "P0ASGe7h/swkLC9HfYSaJCuv/1X+NsCO7254ok7eC19JYPuZ", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[] { new DateTime(2023, 10, 3, 14, 30, 55, 84, DateTimeKind.Local).AddTicks(6938), "UIwQ2f6T1ASeQ0q07JoVQq6FbPDQnGJO5Ga21xcQcsU45I/9", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 9, 29, 20, 19, 3, 984, DateTimeKind.Local).AddTicks(8681), "123123" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 9, 29, 20, 19, 3, 984, DateTimeKind.Local).AddTicks(8711), "123123" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 9, 29, 20, 19, 3, 984, DateTimeKind.Local).AddTicks(8716), "123123" });
        }
    }
}
