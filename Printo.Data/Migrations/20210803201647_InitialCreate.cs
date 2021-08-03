using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Printo.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true),
                    UserTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CompanyFullName = table.Column<string>(nullable: true),
                    NIP = table.Column<string>(maxLength: 10, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    AppartmentNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTypes",
                columns: table => new
                {
                    DeliveryTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTypes", x => x.DeliveryTypeID);
                    table.ForeignKey(
                        name: "FK_DeliveryTypes_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTypes_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Finishings",
                columns: table => new
                {
                    FinishingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finishings", x => x.FinishingID);
                    table.ForeignKey(
                        name: "FK_Finishings_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Finishings_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    FormatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.FormatID);
                    table.ForeignKey(
                        name: "FK_Formats_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Formats_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineID);
                    table.ForeignKey(
                        name: "FK_Machines_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machines_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaperTypes",
                columns: table => new
                {
                    PaperTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperTypes", x => x.PaperTypeID);
                    table.ForeignKey(
                        name: "FK_PaperTypes_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaperTypes_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaperWeights",
                columns: table => new
                {
                    PaperWeightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grammature = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperWeights", x => x.PaperWeightID);
                    table.ForeignKey(
                        name: "FK_PaperWeights_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaperWeights_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeID);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostPresses",
                columns: table => new
                {
                    PostPressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPresses", x => x.PostPressID);
                    table.ForeignKey(
                        name: "FK_PostPresses_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostPresses_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrintColors",
                columns: table => new
                {
                    PrintColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintColors", x => x.PrintColorID);
                    table.ForeignKey(
                        name: "FK_PrintColors_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrintColors_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionStages",
                columns: table => new
                {
                    ProductionStageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStages", x => x.ProductionStageID);
                    table.ForeignKey(
                        name: "FK_ProductionStages_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionStages_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SheetSizes",
                columns: table => new
                {
                    SheetSizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetSizes", x => x.SheetSizeID);
                    table.ForeignKey(
                        name: "FK_SheetSizes_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SheetSizes_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoID);
                    table.ForeignKey(
                        name: "FK_ToDos_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDos_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VatRates",
                columns: table => new
                {
                    VatRateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatRates", x => x.VatRateID);
                    table.ForeignKey(
                        name: "FK_VatRates_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VatRates_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(nullable: false),
                    DeliveryTypeID = table.Column<int>(nullable: false),
                    FinishingID = table.Column<int>(nullable: false),
                    FormatID = table.Column<int>(nullable: false),
                    MachineID = table.Column<int>(nullable: false),
                    PaperWeightID = table.Column<int>(nullable: false),
                    PaperTypeID = table.Column<int>(nullable: false),
                    PaymentTypeID = table.Column<int>(nullable: false),
                    PostPressID = table.Column<int>(nullable: false),
                    PrintColorID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductionStageID = table.Column<int>(nullable: false),
                    SheetSizeID = table.Column<int>(nullable: false),
                    VatRateID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    OrderName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    NetPrice = table.Column<string>(nullable: true),
                    IsReprint = table.Column<bool>(nullable: false),
                    Quantity = table.Column<string>(nullable: false),
                    SheetsNumber = table.Column<string>(nullable: true),
                    PrintDateTime = table.Column<DateTime>(nullable: true),
                    SheetsNumberPrinted = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    DeliveryDetails = table.Column<string>(nullable: true),
                    PaymentDetails = table.Column<string>(nullable: true),
                    PrintUserID = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryTypes_DeliveryTypeID",
                        column: x => x.DeliveryTypeID,
                        principalTable: "DeliveryTypes",
                        principalColumn: "DeliveryTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Finishings_FinishingID",
                        column: x => x.FinishingID,
                        principalTable: "Finishings",
                        principalColumn: "FinishingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Formats_FormatID",
                        column: x => x.FormatID,
                        principalTable: "Formats",
                        principalColumn: "FormatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Machines_MachineID",
                        column: x => x.MachineID,
                        principalTable: "Machines",
                        principalColumn: "MachineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaperTypes_PaperTypeID",
                        column: x => x.PaperTypeID,
                        principalTable: "PaperTypes",
                        principalColumn: "PaperTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaperWeights_PaperWeightID",
                        column: x => x.PaperWeightID,
                        principalTable: "PaperWeights",
                        principalColumn: "PaperWeightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentTypes_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PostPresses_PostPressID",
                        column: x => x.PostPressID,
                        principalTable: "PostPresses",
                        principalColumn: "PostPressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PrintColors_PrintColorID",
                        column: x => x.PrintColorID,
                        principalTable: "PrintColors",
                        principalColumn: "PrintColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_PrintUserID",
                        column: x => x.PrintUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ProductionStages_ProductionStageID",
                        column: x => x.ProductionStageID,
                        principalTable: "ProductionStages",
                        principalColumn: "ProductionStageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_SheetSizes_SheetSizeID",
                        column: x => x.SheetSizeID,
                        principalTable: "SheetSizes",
                        principalColumn: "SheetSizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_VatRates_VatRateID",
                        column: x => x.VatRateID,
                        principalTable: "VatRates",
                        principalColumn: "VatRateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BackgroundColor = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    AllDay = table.Column<bool>(nullable: false),
                    OrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(7540), null, "Administrator systemu - pełna funkcjonalność i możliwości konfiguracji", true, "Admin", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(7715), null, "Drukarz - dostęp do harmonogramu i częściowej edycji zamówienia", true, "Drukarz", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(7725), null, "Pracownik - dostęp do harmonogramu, tworzenia i edycji zamówienia oraz klientów", true, "Pracownik", null, null }
                });

            migrationBuilder.InsertData(
                table: "VatRates",
                columns: new[] { "VatRateID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "Rate", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(8613), null, "Standardowa stawka Vat", true, "23%", 23, null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(8774), null, "Stawka Vat przy numerze ISSN", true, "8%", 8, null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(8783), null, "Stawka Vat przy numerze ISBN", true, "5%", 5, null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(8786), null, "Nie dotyczy", true, "nd", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddedDate", "AddedUserID", "IsActive", "Login", "Name", "Password", "UpdatedDate", "UpdatedUserID", "UserTypeID" },
                values: new object[] { 1, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(6310), null, true, "admin", "Admin", "21232f297a57a5a743894a0e4a801fc3", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddedDate", "AddedUserID", "IsActive", "Login", "Name", "Password", "UpdatedDate", "UpdatedUserID", "UserTypeID" },
                values: new object[] { 2, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(6694), null, true, "drukarz", "Drukarz", "af6aab224bf93b9d241bfa0773f43df9", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddedDate", "AddedUserID", "IsActive", "Login", "Name", "Password", "UpdatedDate", "UpdatedUserID", "UserTypeID" },
                values: new object[] { 3, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(6708), null, true, "pracownik", "Pracownik", "491910ff69cf9f888d5bed54630ffbaa", null, null, 3 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "AddedDate", "AddedUserID", "AppartmentNumber", "City", "CompanyFullName", "Description", "Email", "HouseNumber", "IsActive", "NIP", "Name", "Phone", "PostalCode", "Street", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 1, new DateTime(2021, 8, 3, 22, 16, 47, 116, DateTimeKind.Local).AddTicks(3718), 1, null, "Nowy Sącz", "Klient testowy firma s.c.", null, "firma@gmail.com", "218b", true, "1234567890", "Klient testowy", "666666666", "33-300", "Lwowska", null, null });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "DeliveryTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(9549), 1, "Odbiór osobisty przez klienta", true, "Odbiór osobisty", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(9841), 1, "Dostawa do klienta", true, "Dostawa", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(9850), 1, "Wysyłka kurierska", true, "Wysyłka", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 119, DateTimeKind.Local).AddTicks(9853), 1, "Wysyłka kurieska z opcją za pobraniem", true, "Wysyłka za pobraniem", null, null }
                });

            migrationBuilder.InsertData(
                table: "Finishings",
                columns: new[] { "FinishingID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(918), 1, "Folia mat jednostronnie i lakier wybiórczo błysk na awersie", true, "1/0 Folia MAT + UV wybiórczo", null, null },
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(915), 1, "Folia soft-touch obustronnie", true, "1/1 Folia SOFT", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(912), 1, "Folia mat obustronnie", true, "1/1 Folia MAT", null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(909), 1, "Folia błysk obustronnie", true, "1/1 Folia BŁYSK", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(906), 1, "Folia soft-touch jednostronnie na awersie", true, "1/0 Folia SOFT", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(903), 1, "Folia mat jednostronnie na awersie", true, "1/0 Folia MAT", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(894), 1, "Folia błysk jednostronnie na awersie", true, "1/0 Folia BŁYSK", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(608), 1, "Brak uszlachetnień druku", true, "Brak", null, null }
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "FormatID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1975), 1, "720x510mm", true, "B2+", null, null },
                    { 8, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1972), 1, "700x500mm", true, "B2", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1966), 1, "148x210mm", true, "A5", null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1963), 1, "210x297mm", true, "A4", null, null },
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1969), 1, "105x148mm", true, "A6", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1956), 1, "420x610mm", true, "A2", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1947), 1, "440x630mm", true, "A2+", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1667), 1, "Wymiary w uwagach do druku", true, "Inny", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(1959), 1, "297x420mm", true, "A3", null, null }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "MachineID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(2746), 1, "Nie dotyczy", true, "N/D", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(3023), 1, "Druk offsetowy KBA RAPIDA 75", true, "KBA", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(3032), 1, "Druk offsetowy RYOBI", true, "RYOBI", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(3035), 1, "Druk cyfrowy", true, "LASER", null, null }
                });

            migrationBuilder.InsertData(
                table: "PaperTypes",
                columns: new[] { "PaperTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(4212), 1, "Karton jednostronnie powlekany z białym spodem", true, "Karton GC1", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(4209), 1, "Papier niepowlekany typu offset", true, "Offset", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(4206), 1, "Papier powlekany błyszczący", true, "Kreda błysk", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(3916), 1, "Szczegóły w uwagach do druku", true, "Inny", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(4197), 1, "Papier powlekany matowy", true, "Kreda mat", null, null }
                });

            migrationBuilder.InsertData(
                table: "PaperWeights",
                columns: new[] { "PaperWeightID", "AddedDate", "AddedUserID", "Description", "Grammature", "IsActive", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(5272), 1, "", "80g", true, null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(4972), 1, "Szczegóły w opisie druku", "Inna", true, null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(5251), 1, "", "130g", true, null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(5260), 1, "", "170g", true, null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(5263), 1, "", "200g", true, null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(5266), 1, "", "250g", true, null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(5269), 1, "", "250g + 130g", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "PaymentTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(6299), 1, "Wysyłka z płatnością za pobraniem", true, "Pobranie", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(6289), 1, "Gotówka przy odbiorze", true, "Gotówka", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(6013), 1, "Przelew bankowy termin min. 14 dni", true, "Przelew", null, null }
                });

            migrationBuilder.InsertData(
                table: "PostPresses",
                columns: new[] { "PostPressID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(7036), 1, "Brak obróbki introligatorskiej", true, "Brak", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(7311), 1, "Docięcie do formatu", true, "Docięcie", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(7320), 1, "2 zszywki płaskie", true, "Oprawa zeszytowa", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(7323), 1, "Oprawa miękka klejona", true, "Oprawa klejona", null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(7326), 1, "Składanie do formatu", true, "Falcowanie", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(7329), 1, "Szczgóły w opisie do zamówienia", true, "Inna obróbka", null, null }
                });

            migrationBuilder.InsertData(
                table: "PrintColors",
                columns: new[] { "PrintColorID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8534), 1, "Szczegóły w uwagach do druku", true, "Inny", null, null },
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8531), 1, "Pantone jednostronnie", true, "1/0 Pantone", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8528), 1, "Okładka: CMYK obustronnie + Środek: czarny obustronnie", true, "4/4 CMYK + 1/1 blacK", null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8524), 1, "Czarny obustronnie", true, "1/1 blacK", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8518), 1, "CMYK obustronnie", true, "4/4 CMYK", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8509), 1, "CMYK jednostronnie", true, "4/0 CMYK", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8230), 1, "Nie dotyczy", true, "N/D", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(8521), 1, "Czarny jednostronnie", true, "1/0 blacK", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductionStages",
                columns: new[] { "ProductionStageID", "AddedDate", "AddedUserID", "Color", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9668), 1, "#fdaa1c", "Naświetlanie CTP", true, "CTP", null, null },
                    { 8, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9692), 1, "#ffffff", "Zamówienie zrealizowane", true, "ARCHIWUM", null, null },
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9689), 1, "#000000", "Produkcja zakończona - zamówienie gotowe do wydania", true, "GOTOWE", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9686), 1, "#7400b8", "Obróbka introligatorska i uszlachetnienia", true, "INTRO", null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9683), 1, "#1ae000", "Zamówienie po wydruku", true, "WYDRUKOWANE", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9680), 1, "#f62323", "Produkcja zatrzymana/anulowana", true, "STOP", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9677), 1, "#00a8f0", "Etap drukowania", true, "DO DRUKU", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 120, DateTimeKind.Local).AddTicks(9389), 1, "#ffffff", "Nowe zamówienie przyjęte do realizacji", true, "NOWE", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(800), 1, "Szycie zeszytowe standard lub oczkowe", true, "Katalog szyty", null, null },
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(806), 1, "Ulotka składana", true, "Ulotka składana", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(803), 1, "Oprawa miękka klejona", true, "Katalog klejony", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(797), 1, "Plakat standardowy cięty do formatu", true, "Plakat", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(793), 1, "Ulotka standardowa cięta do formatu", true, "Ulotka standardowa", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(784), 1, "Arkusze bez obróbki introligatorskiej", true, "Arkusz plano", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(505), 1, "Szczegóły w opisie zamówienia", true, "Inny", null, null },
                    { 8, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(809), 1, "Wizytówki różnego rodzaju", true, "Wizytówka", null, null }
                });

            migrationBuilder.InsertData(
                table: "SheetSizes",
                columns: new[] { "SheetSizeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1892), 1, "Szczegóły w uwagach do druku", true, "Inny", null, null },
                    { 1, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1556), 1, "Nie dotyczy", true, "N/D", null, null },
                    { 2, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1831), 1, "630x440mm", true, "A2+", null, null },
                    { 3, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1839), 1, "610x430mm", true, "A2", null, null },
                    { 4, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1883), 1, "440x315mm", true, "A3+", null, null },
                    { 5, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1886), 1, "700x500mm", true, "B2", null, null },
                    { 6, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(1889), 1, "720x510mm", true, "B2+", null, null }
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ToDoID", "AddedDate", "AddedUserID", "Date", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID", "UserID" },
                values: new object[] { 1, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(2949), 1, new DateTime(2021, 8, 3, 22, 16, 47, 121, DateTimeKind.Local).AddTicks(2544), "Zamówić 2 ryzy offset 190g B1", true, "Przykładowa notatka", null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddedUserID",
                table: "Clients",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdatedUserID",
                table: "Clients",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTypes_AddedUserID",
                table: "DeliveryTypes",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTypes_UpdatedUserID",
                table: "DeliveryTypes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrderID",
                table: "Events",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Finishings_AddedUserID",
                table: "Finishings",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Finishings_UpdatedUserID",
                table: "Finishings",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Formats_AddedUserID",
                table: "Formats",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Formats_UpdatedUserID",
                table: "Formats",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_AddedUserID",
                table: "Machines",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_UpdatedUserID",
                table: "Machines",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddedUserID",
                table: "Orders",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientID",
                table: "Orders",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryTypeID",
                table: "Orders",
                column: "DeliveryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FinishingID",
                table: "Orders",
                column: "FinishingID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FormatID",
                table: "Orders",
                column: "FormatID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MachineID",
                table: "Orders",
                column: "MachineID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaperTypeID",
                table: "Orders",
                column: "PaperTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaperWeightID",
                table: "Orders",
                column: "PaperWeightID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentTypeID",
                table: "Orders",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PostPressID",
                table: "Orders",
                column: "PostPressID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PrintColorID",
                table: "Orders",
                column: "PrintColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PrintUserID",
                table: "Orders",
                column: "PrintUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductionStageID",
                table: "Orders",
                column: "ProductionStageID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SheetSizeID",
                table: "Orders",
                column: "SheetSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedUserID",
                table: "Orders",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VatRateID",
                table: "Orders",
                column: "VatRateID");

            migrationBuilder.CreateIndex(
                name: "IX_PaperTypes_AddedUserID",
                table: "PaperTypes",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaperTypes_UpdatedUserID",
                table: "PaperTypes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaperWeights_AddedUserID",
                table: "PaperWeights",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaperWeights_UpdatedUserID",
                table: "PaperWeights",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_AddedUserID",
                table: "PaymentTypes",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_UpdatedUserID",
                table: "PaymentTypes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostPresses_AddedUserID",
                table: "PostPresses",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostPresses_UpdatedUserID",
                table: "PostPresses",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PrintColors_AddedUserID",
                table: "PrintColors",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PrintColors_UpdatedUserID",
                table: "PrintColors",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStages_AddedUserID",
                table: "ProductionStages",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStages_UpdatedUserID",
                table: "ProductionStages",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AddedUserID",
                table: "Products",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedUserID",
                table: "Products",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SheetSizes_AddedUserID",
                table: "SheetSizes",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SheetSizes_UpdatedUserID",
                table: "SheetSizes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_AddedUserID",
                table: "ToDos",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UpdatedUserID",
                table: "ToDos",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_VatRates_AddedUserID",
                table: "VatRates",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_VatRates_UpdatedUserID",
                table: "VatRates",
                column: "UpdatedUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DeliveryTypes");

            migrationBuilder.DropTable(
                name: "Finishings");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "PaperTypes");

            migrationBuilder.DropTable(
                name: "PaperWeights");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "PostPresses");

            migrationBuilder.DropTable(
                name: "PrintColors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductionStages");

            migrationBuilder.DropTable(
                name: "SheetSizes");

            migrationBuilder.DropTable(
                name: "VatRates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
