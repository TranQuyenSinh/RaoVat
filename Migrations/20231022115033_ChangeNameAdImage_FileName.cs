using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameAdImage_FileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AdImage",
                newName: "FileName");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "AdImage",
                newName: "Image");

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
        }
    }
}
