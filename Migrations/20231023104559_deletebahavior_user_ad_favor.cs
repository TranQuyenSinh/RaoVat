using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class deletebahavior_user_ad_favor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Ad_Favorite_Ad_AdId",
                table: "User_Ad_Favorite");

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

            migrationBuilder.AddForeignKey(
                name: "FK_User_Ad_Favorite_Ad_AdId",
                table: "User_Ad_Favorite",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Ad_Favorite_Ad_AdId",
                table: "User_Ad_Favorite");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 22, 18, 50, 33, 547, DateTimeKind.Local).AddTicks(7265), "fEHE5Pf8jTS33tI8O8CTuVOxU/qBX2G9UqQYUTpv/FnzGbBc" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 22, 18, 50, 33, 551, DateTimeKind.Local).AddTicks(6775), "wGPt51zlNtKGgNAMOy3s6jzM5+iPVRCZ+cBy0KpAgR+V2R05" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 22, 18, 50, 33, 555, DateTimeKind.Local).AddTicks(3657), "RscuPQrDt7rYYYLf3SdCu3Y1bWzGwGCCPTzdkmA1qFTIx0dj" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Ad_Favorite_Ad_AdId",
                table: "User_Ad_Favorite",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id");
        }
    }
}
