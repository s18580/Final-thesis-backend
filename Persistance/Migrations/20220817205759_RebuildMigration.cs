using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class RebuildMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BindingTypes",
                columns: table => new
                {
                    IdBindingType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BindingTypes", x => x.IdBindingType);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTypes",
                columns: table => new
                {
                    IdDeliveryType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTypes", x => x.IdDeliveryType);
                });

            migrationBuilder.CreateTable(
                name: "FileStatuses",
                columns: table => new
                {
                    IdFileStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStatuses", x => x.IdFileStatus);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    IdFileType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.IdFileType);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemTypes",
                columns: table => new
                {
                    IdOrderItemType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemTypes", x => x.IdOrderItemType);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ChipColor = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    IdPriceList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.IdPriceList);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "ServiceNames",
                columns: table => new
                {
                    IdServiceName = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DefaultPrice = table.Column<double>(type: "float", nullable: true),
                    MinimumPrice = table.Column<double>(type: "float", nullable: true),
                    MinimumCirculation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceNames", x => x.IdServiceName);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    IdSupplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.IdSupplier);
                });

            migrationBuilder.CreateTable(
                name: "SupplyItemTypes",
                columns: table => new
                {
                    IdSupplyItemType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyItemTypes", x => x.IdSupplyItemType);
                });

            migrationBuilder.CreateTable(
                name: "Worksites",
                columns: table => new
                {
                    IdWorksite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worksites", x => x.IdWorksite);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IdWorker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    EmailAddres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IdWorksite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IdWorker);
                    table.ForeignKey(
                        name: "FK_Workers_Worksites_IdWorksite",
                        column: x => x.IdWorksite,
                        principalTable: "Worksites",
                        principalColumn: "IdWorksite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CompanyEmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdWorker = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                    table.ForeignKey(
                        name: "FK_Customers_Workers_IdWorker",
                        column: x => x.IdWorker,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleAssignments",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdWorker = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAssignments", x => new { x.IdWorker, x.IdRole });
                    table.ForeignKey(
                        name: "FK_RoleAssignments_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleAssignments_Workers_IdWorker",
                        column: x => x.IdWorker,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdSupplier = table.Column<int>(type: "int", nullable: true),
                    IdCustomer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Suppliers_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "IdSupplier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    IdRepresentative = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdSupplier = table.Column<int>(type: "int", nullable: true),
                    IdCustomer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.IdRepresentative);
                    table.ForeignKey(
                        name: "FK_Representatives_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Representatives_Suppliers_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "IdSupplier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderSubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsAuction = table.Column<bool>(type: "bit", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfferValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdRepresentative = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "OrderStatuses",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Representatives_IdRepresentative",
                        column: x => x.IdRepresentative,
                        principalTable: "Representatives",
                        principalColumn: "IdRepresentative",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    IdWorker = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    OrderLeader = table.Column<bool>(type: "bit", nullable: false),
                    HoursWorked = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => new { x.IdWorker, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Assignments_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Workers_IdWorker",
                        column: x => x.IdWorker,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    IdOrderItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    Circulation = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsideFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoverFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSelectedValuation = table.Column<int>(type: "int", nullable: true),
                    IdDeliveryType = table.Column<int>(type: "int", nullable: false),
                    IdBindingType = table.Column<int>(type: "int", nullable: true),
                    IdOrderItemType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.IdOrderItem);
                    table.ForeignKey(
                        name: "FK_OrderItems_BindingTypes_IdBindingType",
                        column: x => x.IdBindingType,
                        principalTable: "BindingTypes",
                        principalColumn: "IdBindingType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_DeliveryTypes_IdDeliveryType",
                        column: x => x.IdDeliveryType,
                        principalTable: "DeliveryTypes",
                        principalColumn: "IdDeliveryType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderItemTypes_IdOrderItemType",
                        column: x => x.IdOrderItemType,
                        principalTable: "OrderItemTypes",
                        principalColumn: "IdOrderItemType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    IdSupply = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    SupplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReceived = table.Column<bool>(type: "bit", nullable: false),
                    IdSupplyItemType = table.Column<int>(type: "int", nullable: false),
                    IdRepresentative = table.Column<int>(type: "int", nullable: false),
                    IdOrderItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.IdSupply);
                    table.ForeignKey(
                        name: "FK_Supplies_OrderItems_IdOrderItem",
                        column: x => x.IdOrderItem,
                        principalTable: "OrderItems",
                        principalColumn: "IdOrderItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplies_Representatives_IdRepresentative",
                        column: x => x.IdRepresentative,
                        principalTable: "Representatives",
                        principalColumn: "IdRepresentative",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplies_SupplyItemTypes_IdSupplyItemType",
                        column: x => x.IdSupplyItemType,
                        principalTable: "SupplyItemTypes",
                        principalColumn: "IdSupplyItemType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valuations",
                columns: table => new
                {
                    IdValuation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferValidityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GraphicDesignPrice = table.Column<double>(type: "float", nullable: false),
                    SamplePrintoutsPrice = table.Column<double>(type: "float", nullable: false),
                    PrintingOnReverse = table.Column<bool>(type: "bit", nullable: false),
                    UnitPriceNet = table.Column<double>(type: "float", nullable: false),
                    Circulation = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    InsideFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoverFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsideSheetFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoverSheetFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrintingPlateNuber = table.Column<int>(type: "int", nullable: false),
                    PrintPrice = table.Column<double>(type: "float", nullable: false),
                    IdAuthor = table.Column<int>(type: "int", nullable: false),
                    IdOrderItem = table.Column<int>(type: "int", nullable: false),
                    IdBindingType = table.Column<int>(type: "int", nullable: true),
                    OrderItemIdOrderItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuations", x => x.IdValuation);
                    table.ForeignKey(
                        name: "FK_Valuations_BindingTypes_IdBindingType",
                        column: x => x.IdBindingType,
                        principalTable: "BindingTypes",
                        principalColumn: "IdBindingType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Valuations_OrderItems_OrderItemIdOrderItem",
                        column: x => x.OrderItemIdOrderItem,
                        principalTable: "OrderItems",
                        principalColumn: "IdOrderItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Valuations_Workers_IdAuthor",
                        column: x => x.IdAuthor,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveriesAddresses",
                columns: table => new
                {
                    IdDeliveriesAddresses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: true),
                    IdSupply = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveriesAddresses", x => x.IdDeliveriesAddresses);
                    table.ForeignKey(
                        name: "FK_DeliveriesAddresses_Addresses_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveriesAddresses_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveriesAddresses_Supplies_IdSupply",
                        column: x => x.IdSupply,
                        principalTable: "Supplies",
                        principalColumn: "IdSupply",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    IdColor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdValuation = table.Column<int>(type: "int", nullable: true),
                    IdOrderItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.IdColor);
                    table.ForeignKey(
                        name: "FK_Colors_OrderItems_IdOrderItem",
                        column: x => x.IdOrderItem,
                        principalTable: "OrderItems",
                        principalColumn: "IdOrderItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colors_Valuations_IdValuation",
                        column: x => x.IdValuation,
                        principalTable: "Valuations",
                        principalColumn: "IdValuation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    IdFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFileType = table.Column<int>(type: "int", nullable: false),
                    IdFileStatus = table.Column<int>(type: "int", nullable: true),
                    IdValuation = table.Column<int>(type: "int", nullable: true),
                    IdOrderItem = table.Column<int>(type: "int", nullable: true),
                    IdOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.IdFile);
                    table.ForeignKey(
                        name: "FK_Files_FileStatuses_IdFileStatus",
                        column: x => x.IdFileStatus,
                        principalTable: "FileStatuses",
                        principalColumn: "IdFileStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_FileTypes_IdFileType",
                        column: x => x.IdFileType,
                        principalTable: "FileTypes",
                        principalColumn: "IdFileType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_OrderItems_IdOrderItem",
                        column: x => x.IdOrderItem,
                        principalTable: "OrderItems",
                        principalColumn: "IdOrderItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Valuations_IdValuation",
                        column: x => x.IdValuation,
                        principalTable: "Valuations",
                        principalColumn: "IdValuation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    IdPaper = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Kind = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SheetFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FiberDirection = table.Column<int>(type: "int", nullable: false),
                    Opacity = table.Column<int>(type: "int", nullable: false),
                    PricePerKilogram = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IdValuation = table.Column<int>(type: "int", nullable: true),
                    IdOrderItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.IdPaper);
                    table.ForeignKey(
                        name: "FK_Papers_OrderItems_IdOrderItem",
                        column: x => x.IdOrderItem,
                        principalTable: "OrderItems",
                        principalColumn: "IdOrderItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Papers_Valuations_IdValuation",
                        column: x => x.IdValuation,
                        principalTable: "Valuations",
                        principalColumn: "IdValuation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IdOrderItem = table.Column<int>(type: "int", nullable: true),
                    IdValuation = table.Column<int>(type: "int", nullable: true),
                    IdServiceName = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdService);
                    table.ForeignKey(
                        name: "FK_Services_OrderItems_IdOrderItem",
                        column: x => x.IdOrderItem,
                        principalTable: "OrderItems",
                        principalColumn: "IdOrderItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_ServiceNames_IdServiceName",
                        column: x => x.IdServiceName,
                        principalTable: "ServiceNames",
                        principalColumn: "IdServiceName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Valuations_IdValuation",
                        column: x => x.IdValuation,
                        principalTable: "Valuations",
                        principalColumn: "IdValuation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValuationPriceLists",
                columns: table => new
                {
                    IdValuation = table.Column<int>(type: "int", nullable: false),
                    IdPriceList = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationPriceLists", x => new { x.IdValuation, x.IdPriceList });
                    table.ForeignKey(
                        name: "FK_ValuationPriceLists_PriceLists_IdPriceList",
                        column: x => x.IdPriceList,
                        principalTable: "PriceLists",
                        principalColumn: "IdPriceList",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValuationPriceLists_Valuations_IdPriceList",
                        column: x => x.IdPriceList,
                        principalTable: "Valuations",
                        principalColumn: "IdValuation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IdCustomer",
                table: "Addresses",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IdSupplier",
                table: "Addresses",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_IdOrder",
                table: "Assignments",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_IdOrderItem",
                table: "Colors",
                column: "IdOrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_IdValuation",
                table: "Colors",
                column: "IdValuation");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdWorker",
                table: "Customers",
                column: "IdWorker");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveriesAddresses_IdAddress",
                table: "DeliveriesAddresses",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveriesAddresses_IdOrder",
                table: "DeliveriesAddresses",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveriesAddresses_IdSupply",
                table: "DeliveriesAddresses",
                column: "IdSupply");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IdFileStatus",
                table: "Files",
                column: "IdFileStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IdFileType",
                table: "Files",
                column: "IdFileType");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IdOrder",
                table: "Files",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IdOrderItem",
                table: "Files",
                column: "IdOrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IdValuation",
                table: "Files",
                column: "IdValuation");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdBindingType",
                table: "OrderItems",
                column: "IdBindingType");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdDeliveryType",
                table: "OrderItems",
                column: "IdDeliveryType");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdOrder",
                table: "OrderItems",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdOrderItemType",
                table: "OrderItems",
                column: "IdOrderItemType");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdRepresentative",
                table: "Orders",
                column: "IdRepresentative");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdStatus",
                table: "Orders",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_IdOrderItem",
                table: "Papers",
                column: "IdOrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_IdValuation",
                table: "Papers",
                column: "IdValuation");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_IdCustomer",
                table: "Representatives",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_IdSupplier",
                table: "Representatives",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_IdRole",
                table: "RoleAssignments",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Services_IdOrderItem",
                table: "Services",
                column: "IdOrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_Services_IdServiceName",
                table: "Services",
                column: "IdServiceName");

            migrationBuilder.CreateIndex(
                name: "IX_Services_IdValuation",
                table: "Services",
                column: "IdValuation");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_IdOrderItem",
                table: "Supplies",
                column: "IdOrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_IdRepresentative",
                table: "Supplies",
                column: "IdRepresentative");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_IdSupplyItemType",
                table: "Supplies",
                column: "IdSupplyItemType");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationPriceLists_IdPriceList",
                table: "ValuationPriceLists",
                column: "IdPriceList");

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_IdAuthor",
                table: "Valuations",
                column: "IdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_IdBindingType",
                table: "Valuations",
                column: "IdBindingType");

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_OrderItemIdOrderItem",
                table: "Valuations",
                column: "OrderItemIdOrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdWorksite",
                table: "Workers",
                column: "IdWorksite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "DeliveriesAddresses");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "RoleAssignments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ValuationPriceLists");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "FileStatuses");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ServiceNames");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Valuations");

            migrationBuilder.DropTable(
                name: "SupplyItemTypes");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "BindingTypes");

            migrationBuilder.DropTable(
                name: "DeliveryTypes");

            migrationBuilder.DropTable(
                name: "OrderItemTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Worksites");
        }
    }
}
