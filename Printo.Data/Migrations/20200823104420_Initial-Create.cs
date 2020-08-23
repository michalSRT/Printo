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
                    UpdatedDate = table.Column<DateTime>(nullable: true)
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
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
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
                    NIP = table.Column<string>(maxLength: 9, nullable: true),
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
                name: "DeliveryAdresses",
                columns: table => new
                {
                    DeliveryAdressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    AppartmentNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAdresses", x => x.DeliveryAdressID);
                    table.ForeignKey(
                        name: "FK_DeliveryAdresses_Users_AddedUserID",
                        column: x => x.AddedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryAdresses_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryAdresses_Users_UpdatedUserID",
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
                    DeliveryAdressID = table.Column<int>(nullable: true),
                    DeliveryTypeID = table.Column<int>(nullable: true),
                    FinishingID = table.Column<int>(nullable: true),
                    FormatID = table.Column<int>(nullable: false),
                    MachineID = table.Column<int>(nullable: true),
                    PaperWeightID = table.Column<int>(nullable: false),
                    PaperTypeID = table.Column<int>(nullable: false),
                    PaymentTypeID = table.Column<int>(nullable: true),
                    PostPressID = table.Column<int>(nullable: true),
                    PrintColorID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductionStageID = table.Column<int>(nullable: true),
                    SheetSizeID = table.Column<int>(nullable: true),
                    VatRateID = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    OrderName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NetPrice = table.Column<string>(nullable: true),
                    IsReprint = table.Column<bool>(nullable: false),
                    ReprintDateAndInfo = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    SheetsNumber = table.Column<string>(nullable: true),
                    SheetsNumberPrinted = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    AddedUserID = table.Column<int>(nullable: true),
                    UpdatedUserID = table.Column<int>(nullable: true)
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
                        name: "FK_Orders_DeliveryAdresses_DeliveryAdressID",
                        column: x => x.DeliveryAdressID,
                        principalTable: "DeliveryAdresses",
                        principalColumn: "DeliveryAdressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryTypes_DeliveryTypeID",
                        column: x => x.DeliveryTypeID,
                        principalTable: "DeliveryTypes",
                        principalColumn: "DeliveryTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Finishings_FinishingID",
                        column: x => x.FinishingID,
                        principalTable: "Finishings",
                        principalColumn: "FinishingID",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PostPresses_PostPressID",
                        column: x => x.PostPressID,
                        principalTable: "PostPresses",
                        principalColumn: "PostPressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PrintColors_PrintColorID",
                        column: x => x.PrintColorID,
                        principalTable: "PrintColors",
                        principalColumn: "PrintColorID",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_SheetSizes_SheetSizeID",
                        column: x => x.SheetSizeID,
                        principalTable: "SheetSizes",
                        principalColumn: "SheetSizeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_VatRates_VatRateID",
                        column: x => x.VatRateID,
                        principalTable: "VatRates",
                        principalColumn: "VatRateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeID", "AddedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(4078), "Administrator systemu", true, "Admin", null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(4381), "Pracownik", true, "Pracownik", null }
                });

            migrationBuilder.InsertData(
                table: "VatRates",
                columns: new[] { "VatRateID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "Rate", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(5862), null, "Standardowa stawka Vat", true, "23%", 23, null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(6152), null, "Stawka Vat przy numerze ISSN", true, "8%", 8, null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(6169), null, "Stawka Vat przy numerze ISBN", true, "5%", 5, null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(6172), null, "Nie dotyczy", true, "nd", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddedDate", "IsActive", "Login", "Name", "Password", "Surname", "UpdatedDate", "UserTypeID" },
                values: new object[] { 1, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(1339), true, "admin", "Admin", "admin", "Admin", null, 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "AddedDate", "AddedUserID", "AppartmentNumber", "City", "CompanyFullName", "Description", "Email", "HouseNumber", "IsActive", "NIP", "Name", "Phone", "PostalCode", "Street", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 171, DateTimeKind.Local).AddTicks(8735), 1, null, "Nowy Sącz", "Joe Doe Co", null, "jd@gmail.com", "218b", true, "123456789", "Joe Doe", "666666666", "33-300", "Lwowska", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 175, DateTimeKind.Local).AddTicks(8778), 1, null, "Nowy Jork", "MikeShinoda Co", null, "mikeshinoda@gmail.com", "52669", true, "123456789", "MikeShinoda", "555777333", "52-300", "Wallstreet", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 175, DateTimeKind.Local).AddTicks(8832), 1, null, "Nowy Sącz", "Vitberg Jacek Sikora", null, "js@gmail.com", "3", true, "123456789", "Vitberg", "666666666", "33-300", "Borelowskiego", null, null }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTypes",
                columns: new[] { "DeliveryTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(1986), 1, "Odbiór osobisty przez klienta", true, "Odbiór", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(2477), 1, "Dostawa do klienta", true, "Dostawa", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(2505), 1, "Wysyłka kurierska", true, "Wysyłka", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(2508), 1, "Wysyłka kurieska z opcją za pobraniem", true, "Wysyłka za pobraniem", null, null }
                });

            migrationBuilder.InsertData(
                table: "Finishings",
                columns: new[] { "FinishingID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4250), 1, "Folia mat jednostronnie i lakier wybiórczo błysk na awersie", true, "1/0 Folia MAT + UV wybiórczo", null, null },
                    { 7, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4247), 1, "Folia soft-touch obustronnie", true, "1/1 Folia SOFT", null, null },
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4243), 1, "Folia mat obustronnie", true, "1/1 Folia MAT", null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4240), 1, "Folia błysk obustronnie", true, "1/1 Folia BŁYSK", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4146), 1, "Folia błysk jednostronnie na awersie", true, "1/0 Folia BŁYSK", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4232), 1, "Folia mat jednostronnie na awersie", true, "1/0 Folia MAT", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(3659), 1, "Brak uszlachetnień druku", true, "Brak", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(4236), 1, "Folia soft-touch jednostronnie na awersie", true, "1/0 Folia SOFT", null, null }
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "FormatID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(6052), 1, "210x297mm", true, "A4", null, null },
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(6055), 1, "148x210mm", true, "A5", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(6048), 1, "297x420mm", true, "A3", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(6045), 1, "420x610mm", true, "A2", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(6020), 1, "440x630mm", true, "A2+", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(5541), 1, "Wymiary w uwagach do druku", true, "Inny", null, null }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "MachineID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(7410), 1, "Nie dotyczy", true, "N/D", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(8011), 1, "Druk offsetowy KBA RAPIDA 75", true, "KBA", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(8053), 1, "Druk offsetowy RYOBI", true, "RYOBI", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(8056), 1, "Druk cyfrowy XEROX D700", true, "XEROX", null, null }
                });

            migrationBuilder.InsertData(
                table: "PaperTypes",
                columns: new[] { "PaperTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(9171), 1, "Szczegóły w uwagach do druku", true, "Inny", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(9638), 1, "Papier powlekany matowy", true, "Kreda mat", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(9662), 1, "Papier powlekany błyszczący", true, "Kreda błysk", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 178, DateTimeKind.Local).AddTicks(9665), 1, "Papier niepowlekany typu offset", true, "Offset", null, null }
                });

            migrationBuilder.InsertData(
                table: "PaperWeights",
                columns: new[] { "PaperWeightID", "AddedDate", "AddedUserID", "Description", "Grammature", "IsActive", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(779), 1, "", "130g", true, null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(1243), 1, "", "170g", true, null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(1266), 1, "", "350g + 170g", true, null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(1269), 1, "", "250g + 130g", true, null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(1272), 1, "Szczegóły w opisie druku", "Inna", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "PaymentTypeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(2842), 1, "Gotówka przy odbiorze", true, "Gotówka", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(2381), 1, "Przelew bankowy termin min. 14 dni", true, "Przelew", null, null }
                });

            migrationBuilder.InsertData(
                table: "PostPresses",
                columns: new[] { "PostPressID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(3959), 1, "Brak obróbki introligatorskiej", true, "Brak", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(4447), 1, "Docięcie do formatu", true, "Docięcie", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(4473), 1, "2 zszywki płaskie", true, "Oprawa zeszytowa", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(4477), 1, "Oprawa miękka klejona", true, "Oprawa klejona", null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(4480), 1, "Składanie do formatu", true, "Falcowanie", null, null },
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(4483), 1, "Szczgóły w opisie do zamówienia", true, "Inna obróbka", null, null }
                });

            migrationBuilder.InsertData(
                table: "PrintColors",
                columns: new[] { "PrintColorID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 7, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(6139), 1, "Szczegóły w uwagach do druku", true, "Inny", null, null },
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(6132), 1, "Pantone jednostronnie", true, "1/0 Pantone", null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(6129), 1, "Okładka: CMYK obustronnie + Środek: czarny obustronnie", true, "4/4 CMYK + 1/1 blacK", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(6126), 1, "Czarny obustronnie", true, "1/1 blacK", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(6123), 1, "Czarny jednostronnie", true, "1/0 blacK", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(6099), 1, "CMYK obustronnie", true, "4/4 CMYK", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(5644), 1, "CMYK jednostronnie", true, "4/0 CMYK", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductionStages",
                columns: new[] { "ProductionStageID", "AddedDate", "AddedUserID", "Color", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 7, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(8448), 1, null, "Zamówienie zrealizowane", true, "KONIEC", null, null },
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(8444), 1, "#000000", "Produkcja zakończona - zamówienie gotowe do wydania", true, "GOTOWE", null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(8441), 1, "#00a8f0", "Obróbka introligatorska i uszlachetnienia", true, "INTRO", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(8438), 1, "#f62323", "Produkcja zatrzymana/anulowana", true, "STOP", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(8434), 1, "#1ae000", "Etap drukowania", true, "START", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(8405), 1, "#fdaa1c", "Naświetlanie CTP", true, "CTP", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 179, DateTimeKind.Local).AddTicks(7506), 1, null, "Nowe zamówienie przyjęte do realizacji", true, "NOWE", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(5742), 1, "Plakat standardowy cięty do formatu", true, "Plakat", null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(5745), 1, "Szycie zeszytowe standrd lub oczkowe", true, "Katalog szyty", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(5738), 1, "Ulotka standardowa cięta do formatu", true, "Ulotka standardowa", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(5711), 1, "Arkusze bez obróbki introligatorskiej", true, "Arkusz plano", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(5048), 1, "Szczegóły w opisie zamówienia", true, "Inny", null, null },
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(5749), 1, "Oprawa miękka klejona", true, "Katalog klejony", null, null }
                });

            migrationBuilder.InsertData(
                table: "SheetSizes",
                columns: new[] { "SheetSizeID", "AddedDate", "AddedUserID", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[,]
                {
                    { 6, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(7924), 1, "Szczegóły w uwagach do druku", true, "Inny", null, null },
                    { 1, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(7316), 1, "630x440mm", true, "A2+", null, null },
                    { 2, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(7888), 1, "610x430mm", true, "A2", null, null },
                    { 3, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(7913), 1, "700x500mm", true, "B2", null, null },
                    { 4, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(7917), 1, "440x315mm", true, "A3+", null, null },
                    { 5, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(7920), 1, "430x305mm", true, "A3", null, null }
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ToDoID", "AddedDate", "AddedUserID", "Date", "Description", "IsActive", "Name", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 1, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(9754), 1, new DateTime(2020, 8, 23, 12, 44, 20, 181, DateTimeKind.Local).AddTicks(9094), "Zamówić 2 ryzy papieru", true, "Przykładowa notatka", null, null });

            migrationBuilder.InsertData(
                table: "DeliveryAdresses",
                columns: new[] { "DeliveryAdressID", "AddedDate", "AddedUserID", "AppartmentNumber", "City", "ClientID", "CompanyName", "ContactName", "HouseNumber", "IsActive", "Phone", "PostalCode", "Street", "UpdatedDate", "UpdatedUserID" },
                values: new object[] { 1, new DateTime(2020, 8, 23, 12, 44, 20, 177, DateTimeKind.Local).AddTicks(9831), 1, "1", "Nowy Sącz", 1, "Joe Doe Co", "Joe Doe", "54", true, "784 138 949", "33-300", "Lwowska", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddedUserID",
                table: "Clients",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdatedUserID",
                table: "Clients",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAdresses_AddedUserID",
                table: "DeliveryAdresses",
                column: "AddedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAdresses_ClientID",
                table: "DeliveryAdresses",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAdresses_UpdatedUserID",
                table: "DeliveryAdresses",
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
                name: "IX_Orders_DeliveryAdressID",
                table: "Orders",
                column: "DeliveryAdressID");

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "DeliveryAdresses");

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
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
