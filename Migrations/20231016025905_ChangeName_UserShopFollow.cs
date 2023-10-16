using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeName_UserShopFollow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_Follow_User_FollowedId",
                table: "User_Shop_Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_Follow_User_FollowerId",
                table: "User_Shop_Follow");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "User_Shop_Follow",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FollowedId",
                table: "User_Shop_Follow",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Shop_Follow_FollowerId",
                table: "User_Shop_Follow",
                newName: "IX_User_Shop_Follow_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Shop_Follow_FollowedId",
                table: "User_Shop_Follow",
                newName: "IX_User_Shop_Follow_ShopId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 16, 9, 59, 5, 278, DateTimeKind.Local).AddTicks(1570), "TxyUkDC+mIYvLYG2uApOPT3HbEj2oPn/tQMdEOJokF/BpzvJ" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 16, 9, 59, 5, 281, DateTimeKind.Local).AddTicks(8838), "I2i2mwglJP1bWa9nU1ya2w2iYHH/oILTrTThQCTr5Huodsom" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 16, 9, 59, 5, 285, DateTimeKind.Local).AddTicks(9088), "ZKI8QPAUfoiS0E4LOP33LHtsZvNPUrOxXH953uwo/4V6mYJ+" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_Follow_User_ShopId",
                table: "User_Shop_Follow",
                column: "ShopId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_Follow_User_UserId",
                table: "User_Shop_Follow",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_Follow_User_ShopId",
                table: "User_Shop_Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_Follow_User_UserId",
                table: "User_Shop_Follow");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User_Shop_Follow",
                newName: "FollowerId");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "User_Shop_Follow",
                newName: "FollowedId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Shop_Follow_UserId",
                table: "User_Shop_Follow",
                newName: "IX_User_Shop_Follow_FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Shop_Follow_ShopId",
                table: "User_Shop_Follow",
                newName: "IX_User_Shop_Follow_FollowedId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 6, 10, 47, 34, 998, DateTimeKind.Local).AddTicks(9793), "eohmUr1uzyGV4x267uMHzH5wA9mr/Ri52W5bV/m+lxt16cH/" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 6, 10, 47, 35, 2, DateTimeKind.Local).AddTicks(7581), "Y6qxjbad6/843IsLAIZrSN7OR3PBC7fiZvuoWNIKWxEsWBfk" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 6, 10, 47, 35, 6, DateTimeKind.Local).AddTicks(6791), "3gqzwyn+OvL+xdxnhzzRGZ5foYJ2JC1X+M7T1VyH1AeyuAPN" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_Follow_User_FollowedId",
                table: "User_Shop_Follow",
                column: "FollowedId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_Follow_User_FollowerId",
                table: "User_Shop_Follow",
                column: "FollowerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
