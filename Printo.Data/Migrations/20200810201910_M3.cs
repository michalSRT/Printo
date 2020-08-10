using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Printo.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VatRates",
                columns: new[] { "VatRateID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "Rate", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stawka Vat przy numerze ISSN", true, "8%", 8, null, null });

            migrationBuilder.InsertData(
                table: "VatRates",
                columns: new[] { "VatRateID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "Rate", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stawka Vat przy numerze ISBN", true, "5%", 5, null, null });

            migrationBuilder.InsertData(
                table: "VatRates",
                columns: new[] { "VatRateID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "Rate", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nie dotyczy", true, "nd", 0, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 5);
        }
    }
}
