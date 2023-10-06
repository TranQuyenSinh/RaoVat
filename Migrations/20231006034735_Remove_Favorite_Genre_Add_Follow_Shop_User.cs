using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Favorite_Genre_Add_Follow_Shop_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Genre_Favorite");

            migrationBuilder.CreateTable(
                name: "User_Shop_Follow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    FollowedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Shop_Follow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Shop_Follow_User_FollowedId",
                        column: x => x.FollowedId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Shop_Follow_User_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_User_Shop_Follow_FollowedId",
                table: "User_Shop_Follow",
                column: "FollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Shop_Follow_FollowerId",
                table: "User_Shop_Follow",
                column: "FollowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Shop_Follow");

            migrationBuilder.CreateTable(
                name: "User_Genre_Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Genre_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Genre_Favorite_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Genre_Favorite_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 3, 14, 30, 55, 74, DateTimeKind.Local).AddTicks(8235), "NBSmfJPuNafiHpOQgrWOKfbZrK0uL0qrfnkn1nFrRqLZ77IW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 3, 14, 30, 55, 79, DateTimeKind.Local).AddTicks(6434), "P0ASGe7h/swkLC9HfYSaJCuv/1X+NsCO7254ok7eC19JYPuZ" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 3, 14, 30, 55, 84, DateTimeKind.Local).AddTicks(6938), "UIwQ2f6T1ASeQ0q07JoVQq6FbPDQnGJO5Ga21xcQcsU45I/9" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Genre_Favorite_GenreId",
                table: "User_Genre_Favorite",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Genre_Favorite_UserId",
                table: "User_Genre_Favorite",
                column: "UserId");
        }
    }
}
