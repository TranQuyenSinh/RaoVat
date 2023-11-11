using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class RejectReason_Ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Ad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 13, 18, 55, 2, 300, DateTimeKind.Local).AddTicks(3288), "fZUXCj2fj3PrCxNsPAs7IIKSJ2o1HsqhIx7BrBJkc3Oiuc0w" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 13, 18, 55, 2, 304, DateTimeKind.Local).AddTicks(2373), "0nL2jGwM1Vglzii98kXPtLf2zgvJFfBsJWugCf1Nh7aNz6nr" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 13, 18, 55, 2, 308, DateTimeKind.Local).AddTicks(782), "7w/RGRiFDGBDQg49Ri+yu8ZHEMuawsJtz+D+d85vcCcnOS0a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Ad");

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
    }
}
