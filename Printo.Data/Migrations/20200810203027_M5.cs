using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Printo.Data.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 30, 26, 507, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeID", "AddedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2020, 8, 10, 22, 30, 26, 507, DateTimeKind.Local).AddTicks(4567), "Pracownik", true, "Pracownik", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddedDate", "IsActive", "Login", "Name", "Password", "Surname", "UpdatedDate", "UserTypeID" },
                values: new object[] { 1, new DateTime(2020, 8, 10, 22, 30, 26, 503, DateTimeKind.Local).AddTicks(6315), true, "admin", "Admin", "admin", "Admin", null, 1 });

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 30, 26, 507, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 30, 26, 507, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 30, 26, 507, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 30, 26, 507, DateTimeKind.Local).AddTicks(7641));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 10, 22, 25, 48, 447, DateTimeKind.Local).AddTicks(6047));

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
    }
}
