using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Printo.Data.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VatRates",
                columns: new[] { "VatRateID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "Rate", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Standardowa stawka Vat", true, "23%", 23, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 1);
        }
    }
}
