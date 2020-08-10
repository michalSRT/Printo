using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Printo.Data.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeID", "AddedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2020, 8, 10, 22, 25, 48, 447, DateTimeKind.Local).AddTicks(6047), "Administrator systemu", true, "Admin", null });

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 25, 48, 451, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 25, 48, 451, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 25, 48, 451, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 25, 48, 451, DateTimeKind.Local).AddTicks(2620));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
