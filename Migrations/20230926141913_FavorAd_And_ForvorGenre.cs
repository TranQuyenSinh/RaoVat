using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class FavorAd_And_ForvorGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdCustomer");

            migrationBuilder.DropTable(
                name: "CustomerGenre");

            migrationBuilder.CreateTable(
                name: "CustomerAdsFavor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdsFavor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAdsFavor_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerAdsFavor_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerGenresFavor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGenresFavor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGenresFavor_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerGenresFavor_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 26, 21, 19, 13, 398, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 26, 21, 19, 13, 398, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 26, 21, 19, 13, 398, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdsFavor_AdId",
                table: "CustomerAdsFavor",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdsFavor_CustomerId",
                table: "CustomerAdsFavor",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGenresFavor_CustomerId",
                table: "CustomerGenresFavor",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGenresFavor_GenreId",
                table: "CustomerGenresFavor",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdsFavor");

            migrationBuilder.DropTable(
                name: "CustomerGenresFavor");

            migrationBuilder.CreateTable(
                name: "AdCustomer",
                columns: table => new
                {
                    FavorAdsId = table.Column<int>(type: "int", nullable: false),
                    FavoredCustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCustomer", x => new { x.FavorAdsId, x.FavoredCustomersId });
                    table.ForeignKey(
                        name: "FK_AdCustomer_Ad_FavorAdsId",
                        column: x => x.FavorAdsId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdCustomer_Customer_FavoredCustomersId",
                        column: x => x.FavoredCustomersId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGenre",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    FavorGenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGenre", x => new { x.CustomersId, x.FavorGenresId });
                    table.ForeignKey(
                        name: "FK_CustomerGenre_Customer_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGenre_Genre_FavorGenresId",
                        column: x => x.FavorGenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 26, 18, 52, 17, 970, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.CreateIndex(
                name: "IX_AdCustomer_FavoredCustomersId",
                table: "AdCustomer",
                column: "FavoredCustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGenre_FavorGenresId",
                table: "CustomerGenre",
                column: "FavorGenresId");
        }
    }
}
