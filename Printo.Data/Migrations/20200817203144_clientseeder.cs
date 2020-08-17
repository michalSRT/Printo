using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Printo.Data.Migrations
{
    public partial class clientseeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 32, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "AddedDate", "AddedUserID", "AppartmentNumber", "City", "CompanyFullName", "CompanyName", "Description", "Email", "FirstName", "HouseNumber", "IsActive", "LastName", "NIP", "Phone", "PostalCode", "Street", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 8, 17, 22, 31, 43, 34, DateTimeKind.Local).AddTicks(8720), 1, null, "Nowy Jork", "MikeShinoda Co", "MikeShinoda", null, "mikeshinoda@gmail.com", "Mike", "52669", true, "Shinoda", "123456789", "555777333", "52-300", "Wallstreet", null, null },
                    { 3, new DateTime(2020, 8, 17, 22, 31, 43, 34, DateTimeKind.Local).AddTicks(8767), 1, null, "Nowy Sącz", "Vitberg Jacek Sikora", "Vitberg", null, "js@gmail.com", "Jacek", "3", true, "Sikora", "123456789", "666666666", "33-300", "Borelowskiego", null, null }
                });

            migrationBuilder.UpdateData(
                table: "DeliveryAdresses",
                keyColumn: "DeliveryAdressID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 37, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 38, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 39, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "PaymentTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "PaymentTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 40, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 41, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ToDoID",
                keyValue: 1,
                columns: new[] { "AddedDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(2616), new DateTime(2020, 8, 17, 22, 31, 43, 42, DateTimeKind.Local).AddTicks(1703) });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 36, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 37, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 36, DateTimeKind.Local).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 37, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 37, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 37, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 17, 22, 31, 43, 37, DateTimeKind.Local).AddTicks(3582));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 187, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "DeliveryAdresses",
                keyColumn: "DeliveryAdressID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 195, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 195, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 195, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 195, DateTimeKind.Local).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "DeliveryTypes",
                keyColumn: "DeliveryTypeID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 195, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Finishings",
                keyColumn: "FinishingID",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 196, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Formats",
                keyColumn: "FormatID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "MachineID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "PaperTypes",
                keyColumn: "PaperTypeID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 197, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "PaperWeights",
                keyColumn: "PaperWeightID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(3312));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "PaymentTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "PaymentTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 198, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "PostPresses",
                keyColumn: "PostPressID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "PrintColors",
                keyColumn: "PrintColorID",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 199, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "ProductionStages",
                keyColumn: "ProductionStageID",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 200, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "SheetSizes",
                keyColumn: "SheetSizeID",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "ToDoID",
                keyValue: 1,
                columns: new[] { "AddedDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(6340), new DateTime(2020, 8, 12, 19, 2, 55, 201, DateTimeKind.Local).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 193, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 193, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 192, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 193, DateTimeKind.Local).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 194, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 194, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "VatRates",
                keyColumn: "VatRateID",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2020, 8, 12, 19, 2, 55, 194, DateTimeKind.Local).AddTicks(1238));
        }
    }
}
