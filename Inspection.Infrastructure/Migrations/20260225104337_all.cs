using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounting");

            migrationBuilder.EnsureSchema(
                name: "Inspection");

            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.EnsureSchema(
                name: "Sec");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "DMS");

            migrationBuilder.EnsureSchema(
                name: "HRManagement");

            migrationBuilder.EnsureSchema(
                name: "Syst");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Stt");

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "Accounting",
                columns: table => new
                {
                    AccountTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountTypeName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AccountTypeNameEnglish = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentAccountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetAccountingEvent",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AssetEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SourceModule = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsReversible = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAccountingEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetCategory",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DefaultUsefulLifeMonths = table.Column<long>(type: "bigint", nullable: false),
                    DefaultDepreciationMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEquipment",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentIdNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalibrationStatus = table.Column<int>(type: "int", nullable: false),
                    CalibrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageConditionTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalOperationTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageConditionRelativeHumidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalOperationRelativeHumidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostUnit",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ParentCostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sub_Currency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsBaseCurrency = table.Column<bool>(type: "bit", nullable: false),
                    IsOfficialCurrency = table.Column<bool>(type: "bit", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBranch",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultAccountGroup",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAccountGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCategory",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentInspection",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsOperational = table.Column<bool>(type: "bit", nullable: false),
                    InspectedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false, defaultValue: 4),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentInspection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYear",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYear", x => x.Id);
                    table.CheckConstraint("CK_FiscalYear_StartDate_EndDate", "[StartDate] < [EndDate]");
                });

            migrationBuilder.CreateTable(
                name: "InspectionMethod",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsMethodNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    series = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionReport",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReportUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCodeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionStandard",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Authority = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionStandard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionType",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectorCategory",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localization",
                schema: "Syst",
                columns: table => new
                {
                    LocaleCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Translate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tooltip = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    System = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localization", x => new { x.LocaleCode, x.Caption });
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceReport",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceSchedule",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationType",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerm",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DaysDue = table.Column<int>(type: "int", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DaysDiscount = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                schema: "Syst",
                columns: table => new
                {
                    Program_ID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    WebRoute = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Program_ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Itemtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Itemcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Itemprice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubcontractorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubcontractor = table.Column<bool>(type: "bit", nullable: true),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#808080"),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCategory",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant_Code",
                schema: "Syst",
                columns: table => new
                {
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tenant_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocaleCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant_codes", x => x.Tenant_ID);
                });

            migrationBuilder.CreateTable(
                name: "TestTableMaster",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTableMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supervisor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsBaseUnit = table.Column<bool>(type: "bit", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Approval",
                schema: "Syst",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Screen_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TableMasterName = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    Keys = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Values = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ScreenName = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descrp = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RepFileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true, comment: "0 Initialized 1 New 2 Approved 3 Rejected 4 Returned 5 Hold 6 Delegate 7 Completed 8 Sent"),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: true),
                    User_CodeId_SentTo = table.Column<long>(type: "bigint", nullable: true),
                    Rejected_Reasons = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Hold_Reasons = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Returned_Reasons = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Delegate_Reasons = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReturnedUser_CodeId = table.Column<long>(type: "bigint", nullable: true),
                    User_CodeId_Delegated = table.Column<long>(type: "bigint", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Confirm_No = table.Column<int>(type: "int", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Approvals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Notification",
                schema: "Syst",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: true),
                    Screen_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Values = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NotificationSubject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Descrp = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Unread = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Push_Error = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email_Error = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Notifications_1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AssetAccountingEventAccount",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetAccountingEventId = table.Column<long>(type: "bigint", nullable: false),
                    DebitAccountRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreditAccountRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AmountSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAccountingEventAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAccountingEventAccount_AssetAccountingEvent_AssetAccountingEventId",
                        column: x => x.AssetAccountingEventId,
                        principalSchema: "Accounting",
                        principalTable: "AssetAccountingEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Inventory",
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentAccessory",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentAccessory_CompanyEquipment_CompanyEquipmentId",
                        column: x => x.CompanyEquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "CompanyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCalibrationHistory",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalibrationBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCalibrationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentCalibrationHistory_CompanyEquipment_CompanyEquipmentId",
                        column: x => x.CompanyEquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "CompanyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMaintenanceAndRepairRecord",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    MaintenanceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescriptionOfWorkDone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenanceAndRepairRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceAndRepairRecord_CompanyEquipment_CompanyEquipmentId",
                        column: x => x.CompanyEquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "CompanyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPreventiveMaintenance",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dte = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPreventiveMaintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPreventiveMaintenance_CompanyEquipment_CompanyEquipmentId",
                        column: x => x.CompanyEquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "CompanyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentSoftware",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentSoftware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentSoftware_CompanyEquipment_CompanyEquipmentId",
                        column: x => x.CompanyEquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "CompanyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccreditationBody",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsInternationallyRecognized = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccreditationBody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccreditationBody_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.CheckConstraint("CK_City_Code_MustContainLetter", "Code LIKE '%[A-Za-z]%'");
                    table.CheckConstraint("CK_City_Name_MustContainLetter", "Name LIKE '%[A-Za-z]%'");
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangeRateHeader",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseCurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangeRateHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRateHeader_BaseCurrency_Currency",
                        column: x => x.BaseCurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangRate",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyExchangRate_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostCenter",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCenter_CostCenter_ParentCostCenterId",
                        column: x => x.ParentCostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCenter_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTitle_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentType",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentType_EquipmentCategory_EquipmentCategoryId",
                        column: x => x.EquipmentCategoryId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountingPeriod",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LockDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingPeriod", x => x.Id);
                    table.CheckConstraint("CK_AccountingPeriod_DateRange", "[EndDate] >= [StartDate]");
                    table.CheckConstraint("CK_AccountingPeriod_LockDate", "[LockDate] >= [StartDate] AND [LockDate] <= [EndDate]");
                    table.ForeignKey(
                        name: "FK_AccountingPeriod_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultAccountType",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VATOUTPUT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAccountType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultAccountType_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "Syst",
                        principalTable: "Program",
                        principalColumn: "Program_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "Syst",
                columns: table => new
                {
                    Menu_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Menu_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Program_ID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Parent_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DontUseInReport = table.Column<bool>(type: "bit", nullable: true),
                    Is_DashBoard = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Is_Report = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    WebRoute = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Menu_ID);
                    table.ForeignKey(
                        name: "FK_Menu_Program",
                        column: x => x.Program_ID,
                        principalSchema: "Syst",
                        principalTable: "Program",
                        principalColumn: "Program_ID");
                });

            migrationBuilder.CreateTable(
                name: "ModuleSetting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    SettingKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ValueType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleSetting_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "Syst",
                        principalTable: "Program",
                        principalColumn: "Program_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroup",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTermsId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultAccountGroupId = table.Column<long>(type: "bigint", nullable: true),
                    TaxCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroup_DefaultAccountGroup_DefaultAccountGroupId",
                        column: x => x.DefaultAccountGroupId,
                        principalSchema: "Accounting",
                        principalTable: "DefaultAccountGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerGroup_PaymentTerm_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalSchema: "Accounting",
                        principalTable: "PaymentTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerGroup_TaxCategory_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierGroup",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultAccountGroupId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentTermsId = table.Column<long>(type: "bigint", nullable: true),
                    TaxCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierGroup_DefaultAccountGroup_DefaultAccountGroupId",
                        column: x => x.DefaultAccountGroupId,
                        principalSchema: "Accounting",
                        principalTable: "DefaultAccountGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierGroup_PaymentTerm_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalSchema: "Accounting",
                        principalTable: "PaymentTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierGroup_TaxCategory_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Code",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    System_Owner = table.Column<bool>(type: "bit", nullable: false),
                    System_Administrator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Codes_Tenant_codes",
                        column: x => x.Tenant_ID,
                        principalSchema: "Syst",
                        principalTable: "Tenant_Code",
                        principalColumn: "Tenant_ID");
                });

            migrationBuilder.CreateTable(
                name: "User_Group",
                schema: "Sec",
                columns: table => new
                {
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_group_ID = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    User_group_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_groups", x => new { x.Tenant_ID, x.User_group_ID });
                    table.ForeignKey(
                        name: "FK_User_groups_Tenant_codes",
                        column: x => x.Tenant_ID,
                        principalSchema: "Syst",
                        principalTable: "Tenant_Code",
                        principalColumn: "Tenant_ID");
                });

            migrationBuilder.CreateTable(
                name: "TestTableDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestTableMasterId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTableDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestTableDetail_TestTableMaster_TestTableMasterId",
                        column: x => x.TestTableMasterId,
                        principalSchema: "Inspection",
                        principalTable: "TestTableMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureConversion",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUoMId = table.Column<long>(type: "bigint", nullable: false),
                    ToUoMId = table.Column<long>(type: "bigint", nullable: false),
                    ConversionFactor = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureConversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UoMConversion_FromUoM",
                        column: x => x.FromUoMId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UoMConversion_ToUoM",
                        column: x => x.ToUoMId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccreditationBodyLine",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccreditationBodyId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionStandardId = table.Column<long>(type: "bigint", nullable: false),
                    RiskLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccreditationBodyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccreditationBodyLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccreditationBodyLine_AccreditationBody_AccreditationBodyId",
                        column: x => x.AccreditationBodyId,
                        principalSchema: "Inspection",
                        principalTable: "AccreditationBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccreditationBodyLine_AccreditationBody_AccreditationBodyId1",
                        column: x => x.AccreditationBodyId1,
                        principalSchema: "Inspection",
                        principalTable: "AccreditationBody",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccreditationBodyLine_InspectionStandard_InspectionStandardId",
                        column: x => x.InspectionStandardId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionStandard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccreditationBodyLine_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IndustrySector = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalRegistrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxIdNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CommercialRegisterNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsHolding = table.Column<bool>(type: "bit", nullable: false),
                    IsSubsidiary = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Sec",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangeRateLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyExchangHeaderId = table.Column<long>(type: "bigint", nullable: false),
                    TargetCurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangeRateLine", x => x.Id);
                    table.CheckConstraint("CK_CurrencyExchangeRateLine_Rate_Positive", "[Rate] > 0");
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRateHeader_TargetCurrencyId_Currency",
                        column: x => x.TargetCurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRateLines_Header_CurrencyExchangeRates",
                        column: x => x.CurrencyExchangHeaderId,
                        principalSchema: "Accounting",
                        principalTable: "CurrencyExchangeRateHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailTable",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyExchangRateId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailTable_CurrencyExchangRate_CurrencyExchangRateId",
                        column: x => x.CurrencyExchangRateId,
                        principalSchema: "Sec",
                        principalTable: "CurrencyExchangRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailTable_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccount",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentAccountId = table.Column<long>(type: "bigint", maxLength: 50, nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<long>(type: "bigint", nullable: false),
                    AccountTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    IsCostCenterRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsCostUnitRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDisable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsControlAccount = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsReconciliationAccount = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsCashAccount = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsBankAccount = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccount", x => x.Id);
                    table.CheckConstraint("CK_ChartOfAccount_CostCenter_Required", "([IsCostCenterRequired] = 0) OR ([CostCenterId] IS NOT NULL)");
                    table.CheckConstraint("CK_ChartOfAccount_CostUnit_Required", "([IsCostUnitRequired] = 0) OR ([CostUnitId] IS NOT NULL)");
                    table.CheckConstraint("CK_ChartOfAccount_Level", "[Level] >= 1");
                    table.CheckConstraint("CK_ChartOfAccount_Parent_When_Not_Main", "([IsMain] = 1 AND [ParentAccountId] IS NULL) OR ([IsMain] = 0 AND [ParentAccountId] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_AccountType_AccountTypeCode",
                        column: x => x.AccountTypeCode,
                        principalSchema: "Accounting",
                        principalTable: "AccountType",
                        principalColumn: "AccountTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_ChartOfAccount_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobRequest",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    JobTitleId = table.Column<long>(type: "bigint", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    NeededPositions = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequest_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobRequest_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "HR",
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentsMoreInformationTemplate",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentsMoreInformationTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentsMoreInformationTemplate_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionChecklistMoreInformationTemplate",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionChecklistMoreInformationTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionChecklistMoreInformationTemplate_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionStandardApplicabilityRule",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: true),
                    MinValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    MaxValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    Disable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionStandardId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionStandardApplicabilityRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionStandardApplicabilityRule_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionStandardApplicabilityRule_InspectionStandard_InspectionStandardId",
                        column: x => x.InspectionStandardId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionStandard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionStandardApplicabilityRule_InspectionStandard_StandardId",
                        column: x => x.StandardId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionStandard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionStandardApplicabilityRule_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuLocalization",
                schema: "Syst",
                columns: table => new
                {
                    Menu_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocaleCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tooltip = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLocalization_1", x => new { x.Menu_ID, x.LocaleCode });
                    table.ForeignKey(
                        name: "FK_MenuLocalization_Menu",
                        column: x => x.Menu_ID,
                        principalSchema: "Syst",
                        principalTable: "Menu",
                        principalColumn: "Menu_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screen_Code",
                schema: "Syst",
                columns: table => new
                {
                    Screen_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Screen_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Menu_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TrType_No = table.Column<int>(type: "int", nullable: true),
                    DuplicateTrTypeNo = table.Column<bool>(type: "bit", nullable: true),
                    Program_ID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TabelMasterName = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: false),
                    NotWorkWithSmallClients = table.Column<bool>(type: "bit", nullable: false),
                    HasApproval = table.Column<bool>(type: "bit", nullable: false),
                    FieldNameCondition = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HasIndex = table.Column<bool>(type: "bit", nullable: false),
                    HasOpen = table.Column<bool>(type: "bit", nullable: false),
                    HasAdd = table.Column<bool>(type: "bit", nullable: false),
                    HasUpdate = table.Column<bool>(type: "bit", nullable: false),
                    HasDelete = table.Column<bool>(type: "bit", nullable: false),
                    HasPrice = table.Column<bool>(type: "bit", nullable: false),
                    HasPost = table.Column<bool>(type: "bit", nullable: false),
                    HasPrint = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    Documntation = table.Column<bool>(type: "bit", nullable: false),
                    DevelopingBackEnd = table.Column<bool>(type: "bit", nullable: false),
                    DevelopingFrontEnd = table.Column<bool>(type: "bit", nullable: false),
                    Tested = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen_codes", x => x.Screen_ID);
                    table.ForeignKey(
                        name: "FK_Screen_Code_Menu_Menu_ID",
                        column: x => x.Menu_ID,
                        principalSchema: "Syst",
                        principalTable: "Menu",
                        principalColumn: "Menu_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDiscountPercent = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 0m),
                    CanApproveQuotation = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: true),
                    SalesRole = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPerson_User_Code_User_CodeId",
                        column: x => x.User_CodeId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Screen_permission",
                schema: "Sec",
                columns: table => new
                {
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_group_ID = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    Screen_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CanAdd = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanPrice = table.Column<bool>(type: "bit", nullable: false),
                    CanPost = table.Column<bool>(type: "bit", nullable: false),
                    CanPrint = table.Column<bool>(type: "bit", nullable: false),
                    CanAttachment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen_permissions", x => new { x.Tenant_ID, x.User_group_ID, x.Screen_ID });
                    table.ForeignKey(
                        name: "FK_Screen_permissions_User_groups",
                        columns: x => new { x.Tenant_ID, x.User_group_ID },
                        principalSchema: "Sec",
                        principalTable: "User_Group",
                        principalColumns: new[] { "Tenant_ID", "User_group_ID" });
                });

            migrationBuilder.CreateTable(
                name: "User_Code_dGroup",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Code_dGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Code_dGroup_User_Code",
                        column: x => x.User_CodeId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Code_dGroup_User_Group",
                        columns: x => new { x.Tenant_ID, x.Id },
                        principalSchema: "Sec",
                        principalTable: "User_Group",
                        principalColumns: new[] { "Tenant_ID", "User_group_ID" });
                });

            migrationBuilder.CreateTable(
                name: "TestTableSubDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestTableDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTableSubDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestTableSubDetail_TestTableDetail_TestTableDetailId",
                        column: x => x.TestTableDetailId,
                        principalSchema: "Inspection",
                        principalTable: "TestTableDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsSalesBranch = table.Column<bool>(type: "bit", nullable: false),
                    IsWarehouseBranch = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Sec",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Sec",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branch_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    IsCompanyAccount = table.Column<bool>(type: "bit", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Accounting",
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccount_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccount_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultAccountAssignment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultAccountGroupID = table.Column<long>(type: "bigint", nullable: false),
                    DefaultAccountTypeID = table.Column<long>(type: "bigint", nullable: false),
                    AccountID = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyID = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAccountAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultAccountAssignment_ChartOfAccount_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultAccountAssignment_DefaultAccountGroup_DefaultAccountGroupID",
                        column: x => x.DefaultAccountGroupID,
                        principalSchema: "Accounting",
                        principalTable: "DefaultAccountGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultAccountAssignment_DefaultAccountType_DefaultAccountTypeID",
                        column: x => x.DefaultAccountTypeID,
                        principalSchema: "Accounting",
                        principalTable: "DefaultAccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxType",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsRecoverable = table.Column<bool>(type: "bit", nullable: false),
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false),
                    taxCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccounttId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxType_ChartOfAccount_ChartOfAccounttId",
                        column: x => x.ChartOfAccounttId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxType_TaxCategory_taxCategoryId",
                        column: x => x.taxCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantCV",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRequestId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CVUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsInterviewed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AcceptedOffer = table.Column<bool>(type: "bit", nullable: true),
                    WillJoin = table.Column<bool>(type: "bit", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantCV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantCV_JobRequest_JobRequestId",
                        column: x => x.JobRequestId,
                        principalSchema: "HR",
                        principalTable: "JobRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobAdvertisement",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRequestId = table.Column<long>(type: "bigint", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdvertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAdvertisement_JobRequest_JobRequestId",
                        column: x => x.JobRequestId,
                        principalSchema: "HR",
                        principalTable: "JobRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentsMoreInformationTemplateDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentsMoreInformationTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentsMoreInformationTemplateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentsMoreInformationTemplateDetail_EquipmentsMoreInformationTemplate_EquipmentsMoreInformationTemplateId",
                        column: x => x.EquipmentsMoreInformationTemplateId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentsMoreInformationTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionChecklistMoreInformaionTemplateDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionChecklistMoreInformationTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionChecklistMoreInformaionTemplateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionChecklistMoreInformaionTemplateDetail_InspectionChecklistMoreInformationTemplate_InspectionChecklistMoreInformatio~",
                        column: x => x.InspectionChecklistMoreInformationTemplateId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionChecklistMoreInformationTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approval",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    WorkFlowTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen_Code_dApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approval_Screen_Code_ScreenId",
                        column: x => x.ScreenId,
                        principalSchema: "Syst",
                        principalTable: "Screen_Code",
                        principalColumn: "Screen_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Folder",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentFolderId = table.Column<long>(type: "bigint", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FolderType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ScreenId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkedEntityId = table.Column<long>(type: "bigint", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InheritPermissions = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Folder"),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#FFA500"),
                    SortOrder = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folder_Folder_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalSchema: "DMS",
                        principalTable: "Folder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folder_Screen_Code_ScreenId",
                        column: x => x.ScreenId,
                        principalSchema: "Syst",
                        principalTable: "Screen_Code",
                        principalColumn: "Screen_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                schema: "Stt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodePattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaddingLength = table.Column<int>(type: "int", nullable: false),
                    ResetPolicy = table.Column<int>(type: "int", nullable: false),
                    ScreenCode_Id = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Screen_Code_ScreenCode_Id",
                        column: x => x.ScreenCode_Id,
                        principalSchema: "Syst",
                        principalTable: "Screen_Code",
                        principalColumn: "Screen_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cash",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    CashOnHandAccountId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cash_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cash_ChartOfAccount_CashOnHandAccountId",
                        column: x => x.CashOnHandAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cash_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<long>(type: "bigint", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobTitleId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_ApplicantCV_CVId",
                        column: x => x.CVId,
                        principalSchema: "HR",
                        principalTable: "ApplicantCV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "HR",
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterviewEvaluation",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantCVId = table.Column<long>(type: "bigint", nullable: false),
                    TechnicalEvaluation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    BehavioralEvaluation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    InterviewerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewEvaluation_ApplicantCV_ApplicantCVId",
                        column: x => x.ApplicantCVId,
                        principalSchema: "HR",
                        principalTable: "ApplicantCV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferNegotiation",
                schema: "HRManagement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposedSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ApplicantCVId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferNegotiation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOfferNegotiation_ApplicantCV_ApplicantCVId",
                        column: x => x.ApplicantCVId,
                        principalSchema: "HR",
                        principalTable: "ApplicantCV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approval_d",
                schema: "Sec",
                columns: table => new
                {
                    IDScrAproval = table.Column<long>(type: "bigint", nullable: false),
                    RecordID = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Approval_title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: false),
                    HasCondition = table.Column<bool>(type: "bit", nullable: false),
                    From_Val = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    To_Val = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Deactivate = table.Column<bool>(type: "bit", nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen_Code_dApproval_List", x => new { x.IDScrAproval, x.RecordID });
                    table.ForeignKey(
                        name: "FK_Approval_d_User_Code_User_CodeId",
                        column: x => x.User_CodeId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Screen_Code_dApproval_List_Screen_Code_dApproval",
                        column: x => x.IDScrAproval,
                        principalSchema: "Sec",
                        principalTable: "Approval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approval_Delegation",
                schema: "Sec",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDScrAproval = table.Column<long>(type: "bigint", nullable: false),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: false),
                    User_CodeId_Delegated = table.Column<long>(type: "bigint", nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approval_Delegation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Approval_Delegation_Approval",
                        column: x => x.IDScrAproval,
                        principalSchema: "Sec",
                        principalTable: "Approval",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FolderPermission",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CanView = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanDownload = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanUpload = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanShare = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanManage = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FolderId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderPermission_Folder_FolderId",
                        column: x => x.FolderId,
                        principalSchema: "DMS",
                        principalTable: "Folder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistTemplate",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StandardId = table.Column<long>(type: "bigint", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    ChecklistTemplateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RunningNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistTemplate_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Sec",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistTemplate_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistTemplate_InspectionStandard_StandardId",
                        column: x => x.StandardId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionStandard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistTemplate_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerType = table.Column<int>(type: "int", maxLength: 20, nullable: false, defaultValue: 2),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaxRegistrationNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommercialRegistryNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentTermId = table.Column<long>(type: "bigint", nullable: true),
                    TaxCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Disable = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Sec",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalSchema: "Accounting",
                        principalTable: "CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_PaymentTerm_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalSchema: "Accounting",
                        principalTable: "PaymentTerm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_TaxCategory_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "TaxCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FixedAsset",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AssetCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "date", nullable: false),
                    CapitalizationDate = table.Column<DateTime>(type: "date", nullable: true),
                    AcquisitionCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResidualValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsefulLifeMonths = table.Column<int>(type: "int", nullable: false),
                    DepreciationMethod = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAsset", x => x.Id);
                    table.CheckConstraint("CK_FixedAsset_CapitalizationDate_Valid", "[CapitalizationDate] IS NULL OR [CapitalizationDate] >= [AcquisitionDate]");
                    table.CheckConstraint("CK_FixedAsset_Cost_Greater_Than_Residual", "[AcquisitionCost] >= [ResidualValue]");
                    table.CheckConstraint("CK_FixedAsset_UsefulLife_Positive", "[UsefulLifeMonths] > 0");
                    table.ForeignKey(
                        name: "FK_FixedAsset_AssetCategory",
                        column: x => x.AssetCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "AssetCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixedAsset_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroup",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParentGroupId = table.Column<long>(type: "bigint", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsSerialTracking = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsBatchTracking = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsExpiryTracking = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InventoryAccountId = table.Column<long>(type: "bigint", nullable: true),
                    CogsAccountId = table.Column<long>(type: "bigint", nullable: true),
                    AdjustmentAccountId = table.Column<long>(type: "bigint", nullable: true),
                    RevenueAccountId = table.Column<long>(type: "bigint", nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemGroup_ChartOfAccount_AdjustmentAccountId",
                        column: x => x.AdjustmentAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGroup_ChartOfAccount_CogsAccountId",
                        column: x => x.CogsAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGroup_ChartOfAccount_InventoryAccountId",
                        column: x => x.InventoryAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGroup_ChartOfAccount_RevenueAccountId",
                        column: x => x.RevenueAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGroup_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Sec",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGroup_ItemGroup_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalSchema: "Inventory",
                        principalTable: "ItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGroup_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeriesDetails",
                schema: "Stt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentNumber = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesDetails_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SupplierTypeEnum = table.Column<int>(type: "int", maxLength: 20, nullable: false, defaultValue: 1),
                    NationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaxRegistration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommercialRegistry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentTermsId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentTermId = table.Column<long>(type: "bigint", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dsiable = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    TaxCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    SupplierGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Sec",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_PaymentTerm_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalSchema: "Accounting",
                        principalTable: "PaymentTerm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Supplier_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                        column: x => x.SupplierGroupId,
                        principalSchema: "Accounting",
                        principalTable: "SupplierGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_TaxCategory_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "TaxCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inspector",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: false),
                    InspectorCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    QualificationNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspector_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspector_InspectorCategory_InspectorCategoryId",
                        column: x => x.InspectorCategoryId,
                        principalSchema: "Inspection",
                        principalTable: "InspectorCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspector_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspector_User_Code_User_CodeId",
                        column: x => x.User_CodeId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSessionAttendance",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    TrainingProgramId = table.Column<long>(type: "bigint", nullable: false),
                    Attended = table.Column<bool>(type: "bit", nullable: false),
                    SignedByEmployee = table.Column<bool>(type: "bit", nullable: false),
                    SignedBySupervisor = table.Column<bool>(type: "bit", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSessionAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSessionAttendance_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingSessionAttendance_TrainingProgram_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalSchema: "HR",
                        principalTable: "TrainingProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    AllowNegativeStock = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResponsibleEmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouse_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Sec",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouse_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Sec",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouse_Employee_ResponsibleEmployeeId",
                        column: x => x.ResponsibleEmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistTemplateLine",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ItemText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChecklistTemplateId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistTemplateLine", x => x.Id);
                    table.CheckConstraint("CK_ChecklistTemplateLine_DisplayOrder", "[DisplayOrder] > 0");
                    table.ForeignKey(
                        name: "FK_ChecklistTemplateLine_ChecklistTemplate_ChecklistTemplateId",
                        column: x => x.ChecklistTemplateId,
                        principalSchema: "Inspection",
                        principalTable: "ChecklistTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChecklistTemplateLine_ChecklistTemplate_ChecklistTemplateId1",
                        column: x => x.ChecklistTemplateId1,
                        principalSchema: "Inspection",
                        principalTable: "ChecklistTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerContact",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContact_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerContact_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HR",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLocation",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    District = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AdditionalNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GPSLatitude = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GPSLongitude = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerLocation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProject",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", maxLength: 150, nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    District = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AdditionalNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GPSLatitude = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GPSLongitude = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProject_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.CheckConstraint("CK_Operation_PlannedDates", "([PlannedStartDate] IS NULL AND [PlannedEndDate] IS NULL) OR ([PlannedStartDate] IS NOT NULL AND [PlannedEndDate] IS NOT NULL AND [PlannedEndDate] >= [PlannedStartDate])");
                    table.ForeignKey(
                        name: "FK_Operation_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Sec",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_OperationType_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalSchema: "Inspection",
                        principalTable: "OperationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetDepreciationSchedule",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    PeriodYear = table.Column<int>(type: "int", nullable: false),
                    PeriodMonth = table.Column<int>(type: "int", nullable: false),
                    DepreciationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDepreciationSchedule", x => x.Id);
                    table.CheckConstraint("CK_AssetDepreciation_DepreciationAmount", "[DepreciationAmount] >= 0");
                    table.CheckConstraint("CK_AssetDepreciation_PeriodMonth", "[PeriodMonth] >= 1 AND [PeriodMonth] <= 12");
                    table.ForeignKey(
                        name: "FK_AssetDepreciationSchedule_FixedAsset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Accounting",
                        principalTable: "FixedAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetTransaction",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedAssetId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionType = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetTransaction_FixedAsset_FixedAssetId",
                        column: x => x.FixedAssetId,
                        principalSchema: "Accounting",
                        principalTable: "FixedAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierContact",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierContact_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Accounting",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectorCompetency",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    InspectorId = table.Column<long>(type: "bigint", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorCompetency", x => x.Id);
                    table.CheckConstraint("CK_InspectorCompetency_ExpiryDate", "[ExpiryDate] IS NULL OR [ExpiryDate] >= [IssueDate]");
                    table.ForeignKey(
                        name: "FK_InspectorCompetency_Inspector_InspectorId",
                        column: x => x.InspectorId,
                        principalSchema: "Inspection",
                        principalTable: "Inspector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectorCompetency_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ItemGroupId = table.Column<long>(type: "bigint", nullable: false),
                    ItemType = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    IsStocked = table.Column<bool>(type: "bit", nullable: false),
                    IsSerialTracked = table.Column<bool>(type: "bit", nullable: false),
                    IsBatchTracked = table.Column<bool>(type: "bit", nullable: false),
                    IsExpiryTracked = table.Column<bool>(type: "bit", nullable: false),
                    DefaultWarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    MinStockLevel = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    MaxStockLevel = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    LeadTime = table.Column<long>(type: "bigint", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    ModelId = table.Column<long>(type: "bigint", nullable: true),
                    ColorId = table.Column<long>(type: "bigint", nullable: true),
                    SizeId = table.Column<long>(type: "bigint", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.CheckConstraint("CK_Item_Inventory_Rules", "([ItemType] <> 'Inventory') OR ([IsStocked] = 1 AND [UnitOfMeasureId] IS NOT NULL)");
                    table.CheckConstraint("CK_Item_Service_No_Stock", "([ItemType] <> 'Service') OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0 AND [IsExpiryTracked] = 0)");
                    table.ForeignKey(
                        name: "FK_Item_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Inventory",
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Color_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "Inventory",
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalSchema: "Inventory",
                        principalTable: "ItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Model_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "Inventory",
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Size_SizeId",
                        column: x => x.SizeId,
                        principalSchema: "Inventory",
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Warehouse_DefaultWarehouseId",
                        column: x => x.DefaultWarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseLocation",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentLocationId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Capacity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_WarehouseLocation_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerProjectId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerLocationId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperationStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PowerRating = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Voltage = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Pressure = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: false),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_CustomerLocation_CustomerLocationId",
                        column: x => x.CustomerLocationId,
                        principalSchema: "Inspection",
                        principalTable: "CustomerLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_CustomerProject_CustomerProjectId",
                        column: x => x.CustomerProjectId,
                        principalSchema: "Inspection",
                        principalTable: "CustomerProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionRequest",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    RequestNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    ContactPersonId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerProjectId = table.Column<long>(type: "bigint", nullable: true),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: true),
                    RequestedInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusCancelledDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionRequest_CustomerContact_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalSchema: "Accounting",
                        principalTable: "CustomerContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionRequest_CustomerLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Inspection",
                        principalTable: "CustomerLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionRequest_CustomerProject_CustomerProjectId",
                        column: x => x.CustomerProjectId,
                        principalSchema: "Inspection",
                        principalTable: "CustomerProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionRequest_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionRequest_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionRequest_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceipt",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    PurshseOrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Accounting",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectorAccreditation",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectorId = table.Column<long>(type: "bigint", nullable: false),
                    InspectorCompetencyId = table.Column<long>(type: "bigint", nullable: false),
                    AccreditationBodyId = table.Column<long>(type: "bigint", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorAccreditation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorAccreditation_AccreditationBody_AccreditationBodyId",
                        column: x => x.AccreditationBodyId,
                        principalSchema: "Inspection",
                        principalTable: "AccreditationBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorAccreditation_InspectorCompetency_InspectorCompetencyId",
                        column: x => x.InspectorCompetencyId,
                        principalSchema: "Inspection",
                        principalTable: "InspectorCompetency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorAccreditation_Inspector_InspectorId",
                        column: x => x.InspectorId,
                        principalSchema: "Inspection",
                        principalTable: "Inspector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectorCompetencyLine",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectorCompetencyId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: true),
                    MaxLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CertificationNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificationExpiry = table.Column<DateTime>(type: "date", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectorCompetencyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorCompetencyLine", x => x.Id);
                    table.CheckConstraint("CK_InspectorCompetencyLine_CertificationExpiry", "[CertificationExpiry] IS NULL OR [CertificationExpiry] >= [In_Date]");
                    table.ForeignKey(
                        name: "FK_InspectorCompetencyLine_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectorCompetencyLine_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectorCompetencyLine_InspectorCompetency_InspectorCompetencyId",
                        column: x => x.InspectorCompetencyId,
                        principalSchema: "Inspection",
                        principalTable: "InspectorCompetency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorCompetencyLine_InspectorCompetency_InspectorCompetencyId1",
                        column: x => x.InspectorCompetencyId1,
                        principalSchema: "Inspection",
                        principalTable: "InspectorCompetency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemVariant",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: true),
                    SizeId = table.Column<long>(type: "bigint", nullable: true),
                    ModelId = table.Column<long>(type: "bigint", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVariant", x => x.Id);
                    table.CheckConstraint("CK_ItemVariant_AtLeastOneAttribute", "[ColorId] IS NOT NULL OR [SizeId] IS NOT NULL OR [ModelId] IS NOT NULL");
                    table.CheckConstraint("CK_ItemVariant_UnitPrice_Positive", "[UnitPrice] IS NULL OR [UnitPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_ItemVariant_Color_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "Inventory",
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Item_ItemId1",
                        column: x => x.ItemId1,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemVariant_Model_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "Inventory",
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Size_SizeId",
                        column: x => x.SizeId,
                        principalSchema: "Inventory",
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentsMoreInformation",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentsMoreInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentsMoreInformation_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentsMoreInformation_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionRequestLines",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionRequestId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    IsSubcontractor = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionRequestLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionRequestLines_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionRequestLines_InspectionRequest_InspectionRequestId",
                        column: x => x.InspectionRequestId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionRequestLines_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionRequestSubcontractorDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceItemId = table.Column<long>(type: "bigint", nullable: false),
                    SubcontractorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubcontractor = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionRequestId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionRequestSubcontractorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionRequestSubcontractorDetail_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionRequestSubcontractorDetail_InspectionRequest_InspectionRequestId",
                        column: x => x.InspectionRequestId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionRequestSubcontractorDetail_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalSchema: "Inspection",
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesQuotation",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionRequestId = table.Column<long>(type: "bigint", nullable: true),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalespersonId = table.Column<long>(type: "bigint", nullable: true),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusCancelled = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DocumentStatusDeclined = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesQuotation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesQuotation_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesQuotation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesQuotation_InspectionRequest_InspectionRequestId",
                        column: x => x.InspectionRequestId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesQuotation_SalesPerson_SalespersonId",
                        column: x => x.SalespersonId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesQuotation_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesQuotation_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiptLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsReceiptId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemVariantId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    UomId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptLine_GoodsReceipt_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalSchema: "Inventory",
                        principalTable: "GoodsReceipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptLine_ItemVariant_ItemVariantId",
                        column: x => x.ItemVariantId,
                        principalSchema: "Inventory",
                        principalTable: "ItemVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptLine_UnitOfMeasure_UomId",
                        column: x => x.UomId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryBalance",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    ItemVariantId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    BaseUoMId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[Quantity] - [ReservedQuantity]", stored: true),
                    AverageCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryBalance", x => x.Id);
                    table.CheckConstraint("CK_InvBalance_ItemOrVariant", "(ItemId IS NOT NULL OR ItemVariantId IS NOT NULL)");
                    table.CheckConstraint("CK_InvBalance_Quantity", "Quantity >= 0");
                    table.CheckConstraint("CK_InvBalance_ReservedQuantity", "ReservedQuantity >= 0");
                    table.ForeignKey(
                        name: "FK_InventoryBalance_ItemVariant_ItemVariantId",
                        column: x => x.ItemVariantId,
                        principalSchema: "Inventory",
                        principalTable: "ItemVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryBalance_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryBalance_UnitOfMeasure_BaseUoMId",
                        column: x => x.BaseUoMId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryBalance_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryBalance_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCostLayer",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemVariantId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    QuantityIn = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    QuantityOut = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false, defaultValue: 0m),
                    RemainingQty = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    SourceTransactionId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCostLayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryCostLayer_ItemVariant_ItemVariantId",
                        column: x => x.ItemVariantId,
                        principalSchema: "Inventory",
                        principalTable: "ItemVariant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryCostLayer_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryCostLayer_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLedger",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemVariantId = table.Column<long>(type: "bigint", nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityIn = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    QuantityOut = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    BalanceAfter = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SourceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: true),
                    CostingMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArabicDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLedger", x => x.Id);
                    table.CheckConstraint("CK_InventoryLedger_QuantityIn_QuantityOut", "(QuantityIn > 0 AND QuantityOut = 0) \r\n              OR \r\n              (QuantityIn = 0 AND QuantityOut > 0)");
                    table.ForeignKey(
                        name: "FK_InventoryLedger_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLedger_ItemVariant_ItemVariantId",
                        column: x => x.ItemVariantId,
                        principalSchema: "Inventory",
                        principalTable: "ItemVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLedger_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLedger_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLedger_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLedger_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOpeningBalance",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemVariantId = table.Column<long>(type: "bigint", nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    OpeningQuantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    OpeningUnitCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TotalOpeningCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOpeningBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_ItemVariant_ItemVariantId",
                        column: x => x.ItemVariantId,
                        principalSchema: "Inventory",
                        principalTable: "ItemVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalance_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentsMoreInformationDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentsMoreInformationId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentsMoreInformationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentsMoreInformationDetail_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentsMoreInformationDetail_EquipmentsMoreInformation_EquipmentsMoreInformationId",
                        column: x => x.EquipmentsMoreInformationId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentsMoreInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    SalesQuotationId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentTermId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalespersonId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusCancelledReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrder_PaymentTerm_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalSchema: "Accounting",
                        principalTable: "PaymentTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrder_SalesPerson_SalespersonId",
                        column: x => x.SalespersonId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SalesOrder_SalesQuotation_SalesQuotationId",
                        column: x => x.SalesQuotationId,
                        principalSchema: "Sales",
                        principalTable: "SalesQuotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrder_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesQuotationLines",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesQuotationId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesQuotationLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLines_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLines_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLines_SalesQuotation_SalesQuotationId",
                        column: x => x.SalesQuotationId,
                        principalSchema: "Sales",
                        principalTable: "SalesQuotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOrder",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobOrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    InspectionRequestId = table.Column<long>(type: "bigint", nullable: true),
                    QuotationId = table.Column<long>(type: "bigint", nullable: true),
                    SalesOrderId = table.Column<long>(type: "bigint", nullable: true),
                    JobOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteContactName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SiteContactMobile = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SiteContactEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusCancelledDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrder_InspectionRequest_InspectionRequestId",
                        column: x => x.InspectionRequestId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrder_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Sales",
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrder_SalesQuotation_QuotationId",
                        column: x => x.QuotationId,
                        principalSchema: "Sales",
                        principalTable: "SalesQuotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrder_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    ItemVariantId = table.Column<long>(type: "bigint", nullable: true),
                    UOMId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_ItemVariant_ItemVariantId",
                        column: x => x.ItemVariantId,
                        principalSchema: "Inventory",
                        principalTable: "ItemVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Sales",
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_UnitOfMeasure_UOMId",
                        column: x => x.UOMId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionChecklist",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobOrderId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: true),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerProjectId = table.Column<long>(type: "bigint", nullable: true),
                    InspectorId = table.Column<long>(type: "bigint", nullable: true),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: true),
                    PreviousInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSheetNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StickerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemarksAndRecommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    RefferenceStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionChecklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Sec",
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_CustomerLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Inspection",
                        principalTable: "CustomerLocation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_CustomerProject_CustomerProjectId",
                        column: x => x.CustomerProjectId,
                        principalSchema: "Inspection",
                        principalTable: "CustomerProject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_Inspector_InspectorId",
                        column: x => x.InspectorId,
                        principalSchema: "Inspection",
                        principalTable: "Inspector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionChecklist_JobOrder_JobOrderId",
                        column: x => x.JobOrderId,
                        principalSchema: "Inspection",
                        principalTable: "JobOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOrderLine",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: false),
                    InspectorId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduledFromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedQuantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CompletedQuantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOrderLine_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrderLine_Inspector_InspectorId",
                        column: x => x.InspectorId,
                        principalSchema: "Inspection",
                        principalTable: "Inspector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrderLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrderLine_JobOrder_JobOrderId",
                        column: x => x.JobOrderId,
                        principalSchema: "Inspection",
                        principalTable: "JobOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionCertificate",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectionChecklistId = table.Column<long>(type: "bigint", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionCertificate_InspectionChecklist_InspectionChecklistId",
                        column: x => x.InspectionChecklistId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionChecklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionChecklistMoreInformation",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionChecklistId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionChecklistMoreInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionChecklistMoreInformation_EquipmentType_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalSchema: "Inspection",
                        principalTable: "EquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionChecklistMoreInformation_InspectionChecklist_InspectionChecklistId",
                        column: x => x.InspectionChecklistId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionChecklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checklist",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    InspectorId = table.Column<long>(type: "bigint", nullable: false),
                    ChecklistTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    StandardId = table.Column<long>(type: "bigint", nullable: false),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    JoborderId = table.Column<long>(type: "bigint", nullable: false),
                    JobOrderLineId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DocStatus = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ChecklistNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checklist_ChecklistTemplate_ChecklistTemplateId",
                        column: x => x.ChecklistTemplateId,
                        principalSchema: "Inspection",
                        principalTable: "ChecklistTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklist_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Inspection",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklist_InspectionStandard_StandardId",
                        column: x => x.StandardId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionStandard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklist_InspectionType_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklist_Inspector_InspectorId",
                        column: x => x.InspectorId,
                        principalSchema: "Inspection",
                        principalTable: "Inspector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklist_JobOrderLine_JobOrderLineId",
                        column: x => x.JobOrderLineId,
                        principalSchema: "Inspection",
                        principalTable: "JobOrderLine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checklist_JobOrder_JoborderId",
                        column: x => x.JoborderId,
                        principalSchema: "Inspection",
                        principalTable: "JobOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionChecklistMoreInformationDetail",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionChecklistMoreInformationId = table.Column<long>(type: "bigint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionChecklistMoreInformationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionChecklistMoreInformationDetail_InspectionChecklistMoreInformation_InspectionChecklistMoreInformationId",
                        column: x => x.InspectionChecklistMoreInformationId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionChecklistMoreInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CerficateNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ChekclistId = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    IssuedByEmployeeId = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    CertificateType = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Checklist_ChekclistId",
                        column: x => x.ChekclistId,
                        principalSchema: "Inspection",
                        principalTable: "Checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certificate_Employee_IssuedByEmployeeId",
                        column: x => x.IssuedByEmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certificate_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistLine",
                schema: "Inspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistId = table.Column<long>(type: "bigint", nullable: false),
                    MeasuredValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistLine_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalSchema: "Inspection",
                        principalTable: "Checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriod_CompanyId_FiscalYearId",
                schema: "Accounting",
                table: "AccountingPeriod",
                columns: new[] { "CompanyId", "FiscalYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriod_FiscalYearId",
                schema: "Accounting",
                table: "AccountingPeriod",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriod_Tenant_ID_CompanyId_Code_FiscalYearId",
                schema: "Accounting",
                table: "AccountingPeriod",
                columns: new[] { "Tenant_ID", "CompanyId", "Code", "FiscalYearId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationBody_CountryId",
                schema: "Inspection",
                table: "AccreditationBody",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationBody_Tenant_ID_CompanyId_Code",
                schema: "Inspection",
                table: "AccreditationBody",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationBodyLine_AccreditationBodyId_InspectionTypeId_InspectionStandardId",
                schema: "Inspection",
                table: "AccreditationBodyLine",
                columns: new[] { "AccreditationBodyId", "InspectionTypeId", "InspectionStandardId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationBodyLine_AccreditationBodyId1",
                schema: "Inspection",
                table: "AccreditationBodyLine",
                column: "AccreditationBodyId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationBodyLine_InspectionStandardId",
                schema: "Inspection",
                table: "AccreditationBodyLine",
                column: "InspectionStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationBodyLine_InspectionTypeId",
                schema: "Inspection",
                table: "AccreditationBodyLine",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantCV_JobRequestId",
                schema: "HR",
                table: "ApplicantCV",
                column: "JobRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_ScreenId",
                schema: "Sec",
                table: "Approval",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_d_User_CodeId",
                schema: "Sec",
                table: "Approval_d",
                column: "User_CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_Delegation_IDScrAproval",
                schema: "Sec",
                table: "Approval_Delegation",
                column: "IDScrAproval");

            migrationBuilder.CreateIndex(
                name: "UQ_AssetAccountingEvent_Tenant_Code",
                schema: "Accounting",
                table: "AssetAccountingEvent",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccountingEventAccount_AssetAccountingEventId",
                schema: "Accounting",
                table: "AssetAccountingEventAccount",
                column: "AssetAccountingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccountingEventAccount_Tenant_ID_AssetAccountingEventId_DebitAccountRole_CreditAccountRole",
                schema: "Accounting",
                table: "AssetAccountingEventAccount",
                columns: new[] { "Tenant_ID", "AssetAccountingEventId", "DebitAccountRole", "CreditAccountRole" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_Tenant_ID_Code",
                schema: "Accounting",
                table: "AssetCategory",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciation_AssetId",
                schema: "Accounting",
                table: "AssetDepreciationSchedule",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciation_IsPosted",
                schema: "Accounting",
                table: "AssetDepreciationSchedule",
                column: "IsPosted");

            migrationBuilder.CreateIndex(
                name: "UQ_AssetDepreciationSchedule_Code_Tenant",
                schema: "Accounting",
                table: "AssetDepreciationSchedule",
                columns: new[] { "AssetId", "Tenant_ID", "PeriodYear", "PeriodMonth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransaction_FixedAssetId",
                schema: "Accounting",
                table: "AssetTransaction",
                column: "FixedAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransaction_TransactionDate",
                schema: "Accounting",
                table: "AssetTransaction",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Tenant_ID_Code",
                schema: "Accounting",
                table: "Bank",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankId",
                schema: "Accounting",
                table: "BankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_ChartOfAccountId",
                schema: "Accounting",
                table: "BankAccount",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_CurrencyId",
                schema: "Accounting",
                table: "BankAccount",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CityId",
                schema: "Accounting",
                table: "Branch",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CountryId",
                schema: "Accounting",
                table: "Branch",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UQ_Branch_Company_Tenant_Code",
                schema: "Accounting",
                table: "Branch",
                columns: new[] { "CompanyId", "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Brand_Code_Tenant",
                schema: "Inventory",
                table: "Brand",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cash_BranchId",
                schema: "Accounting",
                table: "Cash",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_CashOnHandAccountId",
                schema: "Accounting",
                table: "Cash",
                column: "CashOnHandAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_CurrencyId",
                schema: "Accounting",
                table: "Cash",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_Tenant_ID_Code",
                schema: "Accounting",
                table: "Cash",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_ChekclistId",
                schema: "Inspection",
                table: "Certificate",
                column: "ChekclistId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_IssuedByEmployeeId",
                schema: "Inspection",
                table: "Certificate",
                column: "IssuedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_SeriesId",
                schema: "Inspection",
                table: "Certificate",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_Tenant_ID_CompanyId_CerficateNumber",
                schema: "Inspection",
                table: "Certificate",
                columns: new[] { "Tenant_ID", "CompanyId", "CerficateNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_AccountTypeCode",
                schema: "Accounting",
                table: "ChartOfAccount",
                column: "AccountTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_CostCenterId",
                schema: "Accounting",
                table: "ChartOfAccount",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_CostUnitId",
                schema: "Accounting",
                table: "ChartOfAccount",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_CurrencyId",
                schema: "Accounting",
                table: "ChartOfAccount",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_ParentAccountId",
                schema: "Accounting",
                table: "ChartOfAccount",
                column: "ParentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_Tenant_ID_AccountCode",
                schema: "Accounting",
                table: "ChartOfAccount",
                columns: new[] { "Tenant_ID", "AccountCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_ChecklistTemplateId",
                schema: "Inspection",
                table: "Checklist",
                column: "ChecklistTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_EquipmentId",
                schema: "Inspection",
                table: "Checklist",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_InspectionTypeId",
                schema: "Inspection",
                table: "Checklist",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_InspectorId",
                schema: "Inspection",
                table: "Checklist",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_JoborderId",
                schema: "Inspection",
                table: "Checklist",
                column: "JoborderId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_JobOrderLineId",
                schema: "Inspection",
                table: "Checklist",
                column: "JobOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_StandardId",
                schema: "Inspection",
                table: "Checklist",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistLine_ChecklistId",
                schema: "Inspection",
                table: "ChecklistLine",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTemplate_CompanyId",
                schema: "Inspection",
                table: "ChecklistTemplate",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTemplate_SeriesId",
                schema: "Inspection",
                table: "ChecklistTemplate",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTemplate_StandardId",
                schema: "Inspection",
                table: "ChecklistTemplate",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "UX_ChecklistTemplate_Active",
                schema: "Inspection",
                table: "ChecklistTemplate",
                columns: new[] { "EquipmentTypeId", "StandardId", "Version" },
                unique: true,
                filter: "[Disabled] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTemplateLine_ChecklistTemplateId1",
                schema: "Inspection",
                table: "ChecklistTemplateLine",
                column: "ChecklistTemplateId1");

            migrationBuilder.CreateIndex(
                name: "UX_ChecklistTemplateLine_Template_DisplayOrder",
                schema: "Inspection",
                table: "ChecklistTemplateLine",
                columns: new[] { "ChecklistTemplateId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                schema: "Sec",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_Tenant_ID_Code",
                schema: "Sec",
                table: "City",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_Tenant_ID_Code",
                schema: "Inventory",
                table: "Color",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CityId",
                schema: "Sec",
                table: "Company",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                schema: "Sec",
                table: "Company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CurrencyId",
                schema: "Sec",
                table: "Company",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Tenant_ID_Code",
                schema: "Sec",
                table: "Company",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCenter_DepartmentId",
                schema: "Accounting",
                table: "CostCenter",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenter_ParentCostCenterId",
                schema: "Accounting",
                table: "CostCenter",
                column: "ParentCostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenter_Tenant_ID_Code",
                schema: "Accounting",
                table: "CostCenter",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostUnit_Tenant_ID_Code",
                schema: "Accounting",
                table: "CostUnit",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Tenant_ID_Code",
                schema: "Sec",
                table: "Country",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Tenant_ID_Code",
                schema: "Sec",
                table: "Currency",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangeRateHeader_BaseCurrencyId",
                schema: "Accounting",
                table: "CurrencyExchangeRateHeader",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "UX_CurrencyExchangeRate_Tenant_BaseCurrency_EffectiveDate",
                schema: "Accounting",
                table: "CurrencyExchangeRateHeader",
                columns: new[] { "Tenant_ID", "BaseCurrencyId", "EffectiveDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangeRateLine_TargetCurrencyId",
                schema: "Accounting",
                table: "CurrencyExchangeRateLine",
                column: "TargetCurrencyId");

            migrationBuilder.CreateIndex(
                name: "UX_CurrencyExchangeRateLine_Header_TargetCurrency",
                schema: "Accounting",
                table: "CurrencyExchangeRateLine",
                columns: new[] { "CurrencyExchangHeaderId", "TargetCurrencyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangRate_CurrencyId",
                schema: "Sec",
                table: "CurrencyExchangRate",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangRate_Tenant_ID_CurrencyId_EffectiveDate",
                schema: "Sec",
                table: "CurrencyExchangRate",
                columns: new[] { "Tenant_ID", "CurrencyId", "EffectiveDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityId",
                schema: "Accounting",
                table: "Customer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Code_Tenant_ID",
                schema: "Accounting",
                table: "Customer",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CountryId",
                schema: "Accounting",
                table: "Customer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CurrencyId",
                schema: "Accounting",
                table: "Customer",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerGroupId",
                schema: "Accounting",
                table: "Customer",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentTermId",
                schema: "Accounting",
                table: "Customer",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SeriesId",
                schema: "Accounting",
                table: "Customer",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TaxCategoryId",
                schema: "Accounting",
                table: "Customer",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContact_CustomerId",
                schema: "Accounting",
                table: "CustomerContact",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContact_DepartmentId",
                schema: "Accounting",
                table: "CustomerContact",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroup_DefaultAccountGroupId",
                schema: "Accounting",
                table: "CustomerGroup",
                column: "DefaultAccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroup_PaymentTermsId",
                schema: "Accounting",
                table: "CustomerGroup",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroup_TaxCategoryId",
                schema: "Accounting",
                table: "CustomerGroup",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroup_Tenant_ID_GroupCode",
                schema: "Accounting",
                table: "CustomerGroup",
                columns: new[] { "Tenant_ID", "GroupCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLocation_CustomerId",
                schema: "Inspection",
                table: "CustomerLocation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProject_CustomerId",
                schema: "Inspection",
                table: "CustomerProject",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountAssignment_AccountID",
                schema: "Accounting",
                table: "DefaultAccountAssignment",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountAssignment_DefaultAccountGroupID",
                schema: "Accounting",
                table: "DefaultAccountAssignment",
                column: "DefaultAccountGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountAssignment_DefaultAccountTypeID",
                schema: "Accounting",
                table: "DefaultAccountAssignment",
                column: "DefaultAccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountAssignment_Tenant_ID_DefaultAccountGroupID_DefaultAccountTypeID_CurrencyID",
                schema: "Accounting",
                table: "DefaultAccountAssignment",
                columns: new[] { "Tenant_ID", "DefaultAccountGroupID", "DefaultAccountTypeID", "CurrencyID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountGroup_Tenant_ID_GroupCode",
                schema: "Accounting",
                table: "DefaultAccountGroup",
                columns: new[] { "Tenant_ID", "GroupCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountType_Code",
                schema: "Accounting",
                table: "DefaultAccountType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAccountType_ProgramId",
                schema: "Accounting",
                table: "DefaultAccountType",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailTable_CurrencyExchangRateId_CurrencyId",
                schema: "Sec",
                table: "DetailTable",
                columns: new[] { "CurrencyExchangRateId", "CurrencyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailTable_CurrencyId",
                schema: "Sec",
                table: "DetailTable",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CVId",
                schema: "HR",
                table: "Employee",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "HR",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTitleId",
                schema: "HR",
                table: "Employee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CustomerId",
                schema: "Inspection",
                table: "Equipment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CustomerLocationId",
                schema: "Inspection",
                table: "Equipment",
                column: "CustomerLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CustomerProjectId",
                schema: "Inspection",
                table: "Equipment",
                column: "CustomerProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeId",
                schema: "Inspection",
                table: "Equipment",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_SeriesId",
                schema: "Inspection",
                table: "Equipment",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "UX_Equipment_Tenant_Company_EquipmentNo",
                schema: "Inspection",
                table: "Equipment",
                columns: new[] { "Tenant_ID", "CompanyId", "EquipmentNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAccessory_CompanyEquipmentId",
                schema: "Inspection",
                table: "EquipmentAccessory",
                column: "CompanyEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCalibrationHistory_CompanyEquipmentId",
                schema: "Inspection",
                table: "EquipmentCalibrationHistory",
                column: "CompanyEquipmentId");

            migrationBuilder.CreateIndex(
                name: "UX_EquipmentCategory_Name_Tenant",
                schema: "Inspection",
                table: "EquipmentCategory",
                columns: new[] { "Name", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceAndRepairRecord_CompanyEquipmentId",
                schema: "Inspection",
                table: "EquipmentMaintenanceAndRepairRecord",
                column: "CompanyEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPreventiveMaintenance_CompanyEquipmentId",
                schema: "Inspection",
                table: "EquipmentPreventiveMaintenance",
                column: "CompanyEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsMoreInformation_EquipmentId",
                schema: "Inspection",
                table: "EquipmentsMoreInformation",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsMoreInformation_EquipmentTypeId",
                schema: "Inspection",
                table: "EquipmentsMoreInformation",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsMoreInformationDetail_EquipmentId",
                schema: "Inspection",
                table: "EquipmentsMoreInformationDetail",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsMoreInformationDetail_EquipmentsMoreInformationId",
                schema: "Inspection",
                table: "EquipmentsMoreInformationDetail",
                column: "EquipmentsMoreInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsMoreInformationTemplate_EquipmentTypeId",
                schema: "Inspection",
                table: "EquipmentsMoreInformationTemplate",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsMoreInformationTemplateDetail_EquipmentsMoreInformationTemplateId",
                schema: "Inspection",
                table: "EquipmentsMoreInformationTemplateDetail",
                column: "EquipmentsMoreInformationTemplateId");

            migrationBuilder.CreateIndex(
                name: "UX_EquipmentMoreInformationTemplateDetail_KeyName_Tenant",
                schema: "Inspection",
                table: "EquipmentsMoreInformationTemplateDetail",
                columns: new[] { "KeyName", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSoftware_CompanyEquipmentId",
                schema: "Inspection",
                table: "EquipmentSoftware",
                column: "CompanyEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentType_EquipmentCategoryId",
                schema: "Inspection",
                table: "EquipmentType",
                column: "EquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentType_Name",
                schema: "Inspection",
                table: "EquipmentType",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "UX_EquipmentType_Code_Tenant",
                schema: "Inspection",
                table: "EquipmentType",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYear_Tenant_ID_Code",
                schema: "Accounting",
                table: "FiscalYear",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_AssetCategoryId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_SeriesId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "UQ_FixedAsset_AssetCode",
                schema: "Accounting",
                table: "FixedAsset",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folder_ParentFolderId",
                schema: "DMS",
                table: "Folder",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_ScreenId",
                schema: "DMS",
                table: "Folder",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_Tenant_ID_CompanyId_Path",
                schema: "DMS",
                table: "Folder",
                columns: new[] { "Tenant_ID", "CompanyId", "Path" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FolderPermission_FolderId",
                schema: "DMS",
                table: "FolderPermission",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderPermission_Tenant_ID_CompanyId_FolderId",
                schema: "DMS",
                table: "FolderPermission",
                columns: new[] { "Tenant_ID", "CompanyId", "FolderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_BranchId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_Company_Tenant",
                schema: "Inventory",
                table: "GoodsReceipt",
                columns: new[] { "CompanyId", "Tenant_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_OperationId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_SupplierId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_WarehouseId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_ItemId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_UomId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_WarehouseLocationId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "UQ_GoodsReceiptLine_NoDuplicate",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                columns: new[] { "GoodsReceiptId", "ItemId", "ItemVariantId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL AND [WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionCertificate_InspectionChecklistId",
                schema: "Inspection",
                table: "InspectionCertificate",
                column: "InspectionChecklistId");

            migrationBuilder.CreateIndex(
                name: "UX_InspectionCertificate_CertificateNumber_Tenant",
                schema: "Inspection",
                table: "InspectionCertificate",
                columns: new[] { "CertificateNumber", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_CompanyId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_CustomerId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_CustomerProjectId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "CustomerProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_EquipmentId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_EquipmentTypeId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_InspectionMethodId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_InspectionTypeId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_InspectorId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_JobOrderId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklist_LocationId",
                schema: "Inspection",
                table: "InspectionChecklist",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "UX_InspectionChecklist_ChecklistNumber_Tenant",
                schema: "Inspection",
                table: "InspectionChecklist",
                columns: new[] { "ChecklistNumber", "Tenant_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklistMoreInformaionTemplateDetail_InspectionChecklistMoreInformationTemplateId",
                schema: "Inspection",
                table: "InspectionChecklistMoreInformaionTemplateDetail",
                column: "InspectionChecklistMoreInformationTemplateId");

            migrationBuilder.CreateIndex(
                name: "UX_InspectionChecklistMoreInformaionTemplateDetail_KeyName_Tenant",
                schema: "Inspection",
                table: "InspectionChecklistMoreInformaionTemplateDetail",
                columns: new[] { "KeyName", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklistMoreInformation_EquipmentTypeId",
                schema: "Inspection",
                table: "InspectionChecklistMoreInformation",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklistMoreInformation_InspectionChecklistId",
                schema: "Inspection",
                table: "InspectionChecklistMoreInformation",
                column: "InspectionChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionChecklistMoreInformationDetail_InspectionChecklistMoreInformationId",
                schema: "Inspection",
                table: "InspectionChecklistMoreInformationDetail",
                column: "InspectionChecklistMoreInformationId");

            migrationBuilder.CreateIndex(
                name: "UX_EquipmentType_EquipmentTypeId_Tenant",
                schema: "Inspection",
                table: "InspectionChecklistMoreInformationTemplate",
                columns: new[] { "EquipmentTypeId", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_InspectionMethod_InsMethodNo_Tenant",
                schema: "Inspection",
                table: "InspectionMethod",
                columns: new[] { "InsMethodNo", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequest_ContactPersonId",
                schema: "Inspection",
                table: "InspectionRequest",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequest_CustomerId",
                schema: "Inspection",
                table: "InspectionRequest",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequest_CustomerProjectId",
                schema: "Inspection",
                table: "InspectionRequest",
                column: "CustomerProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequest_InspectionTypeId",
                schema: "Inspection",
                table: "InspectionRequest",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequest_LocationId",
                schema: "Inspection",
                table: "InspectionRequest",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequest_SeriesId",
                schema: "Inspection",
                table: "InspectionRequest",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "UX_InspectionRequest_RequestNumber_Tenant",
                schema: "Inspection",
                table: "InspectionRequest",
                columns: new[] { "RequestNumber", "Tenant_ID" },
                unique: true,
                filter: "[Tenant_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequestLines_InspectionMethodId",
                schema: "Inspection",
                table: "InspectionRequestLines",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequestLines_InspectionRequestId",
                schema: "Inspection",
                table: "InspectionRequestLines",
                column: "InspectionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequestLines_ItemId",
                schema: "Inspection",
                table: "InspectionRequestLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequestSubcontractorDetail_InspectionMethodId",
                schema: "Inspection",
                table: "InspectionRequestSubcontractorDetail",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequestSubcontractorDetail_InspectionRequestId",
                schema: "Inspection",
                table: "InspectionRequestSubcontractorDetail",
                column: "InspectionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequestSubcontractorDetail_ServiceItemId",
                schema: "Inspection",
                table: "InspectionRequestSubcontractorDetail",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionStandard_Code",
                schema: "Inspection",
                table: "InspectionStandard",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Item_Company_Code_Tenant",
                schema: "Inspection",
                table: "InspectionStandard",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionStandardApplicabilityRule_EquipmentTypeId",
                schema: "Inspection",
                table: "InspectionStandardApplicabilityRule",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionStandardApplicabilityRule_InspectionStandardId",
                schema: "Inspection",
                table: "InspectionStandardApplicabilityRule",
                column: "InspectionStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionStandardApplicabilityRule_InspectionTypeId",
                schema: "Inspection",
                table: "InspectionStandardApplicabilityRule",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionStandardApplicabilityRule_StandardId",
                schema: "Inspection",
                table: "InspectionStandardApplicabilityRule",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionType_Tenant_ID_Code",
                schema: "Inspection",
                table: "InspectionType",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspector_EmployeeId",
                schema: "Inspection",
                table: "Inspector",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspector_InspectorCategoryId",
                schema: "Inspection",
                table: "Inspector",
                column: "InspectorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspector_SeriesId",
                schema: "Inspection",
                table: "Inspector",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspector_Tenant_ID_CompanyId_Code",
                schema: "Inspection",
                table: "Inspector",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspector_User_CodeId",
                schema: "Inspection",
                table: "Inspector",
                column: "User_CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorAccreditation_AccreditationBodyId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "AccreditationBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorAccreditation_InspectorCompetencyId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "InspectorCompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorAccreditation_InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCategory_Tenant_ID_Code",
                schema: "Inspection",
                table: "InspectorCategory",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCompetency_InspectorId",
                schema: "Inspection",
                table: "InspectorCompetency",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCompetency_SeriesId",
                schema: "Inspection",
                table: "InspectorCompetency",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCompetencyLine_InspectionMethodId",
                schema: "Inspection",
                table: "InspectorCompetencyLine",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCompetencyLine_InspectionTypeId",
                schema: "Inspection",
                table: "InspectorCompetencyLine",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCompetencyLine_InspectorCompetencyId_InspectionMethodId_InspectionTypeId",
                schema: "Inspection",
                table: "InspectorCompetencyLine",
                columns: new[] { "InspectorCompetencyId", "InspectionMethodId", "InspectionTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_InspectorCompetencyLine_InspectorCompetencyId1",
                schema: "Inspection",
                table: "InspectorCompetencyLine",
                column: "InspectorCompetencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewEvaluation_ApplicantCVId",
                schema: "HR",
                table: "InterviewEvaluation",
                column: "ApplicantCVId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_BaseUoMId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "BaseUoMId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_ItemId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_Tenant_ID_ItemId_WarehouseId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance",
                columns: new[] { "Tenant_ID", "ItemId", "WarehouseId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemId] IS NOT NULL AND [ItemVariantId] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_Tenant_ID_ItemVariantId_WarehouseId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance",
                columns: new[] { "Tenant_ID", "ItemVariantId", "WarehouseId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_WarehouseId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayer_ItemId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayer_ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayer_WarehouseId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryCostLayer_Item",
                schema: "Inventory",
                table: "InventoryCostLayer",
                columns: new[] { "Tenant_ID", "ItemId", "WarehouseId" },
                unique: true,
                filter: "[ItemVariantId] IS NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryCostLayer_Variant",
                schema: "Inventory",
                table: "InventoryCostLayer",
                columns: new[] { "CompanyId", "ItemVariantId", "WarehouseId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_BranchId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_ItemId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_WarehouseId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_BranchId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_FiscalYearId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_WarehouseId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                columns: new[] { "CompanyId", "FiscalYearId", "WarehouseId", "ItemId", "ItemVariantId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL AND [WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BrandId",
                schema: "Inventory",
                table: "Item",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ColorId",
                schema: "Inventory",
                table: "Item",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Company_ItemGroup",
                schema: "Inventory",
                table: "Item",
                columns: new[] { "CompanyId", "ItemGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_Company_Name",
                schema: "Inventory",
                table: "Item",
                columns: new[] { "CompanyId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_DefaultWarehouseId",
                schema: "Inventory",
                table: "Item",
                column: "DefaultWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemGroupId",
                schema: "Inventory",
                table: "Item",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ModelId",
                schema: "Inventory",
                table: "Item",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SeriesId",
                schema: "Inventory",
                table: "Item",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SizeId",
                schema: "Inventory",
                table: "Item",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UnitOfMeasureId",
                schema: "Inventory",
                table: "Item",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "UQ_Item_Company_Code_Tenant",
                schema: "Inventory",
                table: "Item",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_AdjustmentAccountId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "AdjustmentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_CogsAccountId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "CogsAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_CompanyId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_InventoryAccountId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "InventoryAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_ParentGroupId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_RevenueAccountId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "RevenueAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_SeriesId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_Tenant_ID_CompanyId_Code",
                schema: "Inventory",
                table: "ItemGroup",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_ColorId",
                schema: "Inventory",
                table: "ItemVariant",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_ItemId1",
                schema: "Inventory",
                table: "ItemVariant",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_ModelId",
                schema: "Inventory",
                table: "ItemVariant",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_SizeId",
                schema: "Inventory",
                table: "ItemVariant",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariant_BarCode",
                schema: "Inventory",
                table: "ItemVariant",
                column: "BarCode",
                unique: true,
                filter: "[BarCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariant_Item_Code",
                schema: "Inventory",
                table: "ItemVariant",
                columns: new[] { "ItemId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariant_Item_Combination",
                schema: "Inventory",
                table: "ItemVariant",
                columns: new[] { "ItemId", "ColorId", "SizeId", "ModelId" },
                unique: true,
                filter: "[ColorId] IS NOT NULL AND [SizeId] IS NOT NULL AND [ModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisement_JobRequestId",
                schema: "HR",
                table: "JobAdvertisement",
                column: "JobRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferNegotiation_ApplicantCVId",
                schema: "HRManagement",
                table: "JobOfferNegotiation",
                column: "ApplicantCVId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOrder_CustomerId",
                schema: "Inspection",
                table: "JobOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrder_InspectionRequestId",
                schema: "Inspection",
                table: "JobOrder",
                column: "InspectionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrder_QuotationId",
                schema: "Inspection",
                table: "JobOrder",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrder_SalesOrderId",
                schema: "Inspection",
                table: "JobOrder",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrder_SeriesId",
                schema: "Inspection",
                table: "JobOrder",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "UX_JobOrder_JobOrderNumber",
                schema: "Inspection",
                table: "JobOrder",
                column: "JobOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderLine_InspectionMethodId",
                schema: "Inspection",
                table: "JobOrderLine",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderLine_InspectorId",
                schema: "Inspection",
                table: "JobOrderLine",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderLine_ItemId",
                schema: "Inspection",
                table: "JobOrderLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderLine_JobOrderId",
                schema: "Inspection",
                table: "JobOrderLine",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequest_DepartmentId",
                schema: "HR",
                table: "JobRequest",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequest_JobTitleId",
                schema: "HR",
                table: "JobRequest",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitle_DepartmentId",
                schema: "HR",
                table: "JobTitle",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Program_ID",
                schema: "Syst",
                table: "Menu",
                column: "Program_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                schema: "Inventory",
                table: "Model",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "UQ_Model_Code_Tenant",
                schema: "Inventory",
                table: "Model",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSetting_ProgramId",
                table: "ModuleSetting",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "UQ_ModuleSetting_Company_Module_Key",
                table: "ModuleSetting",
                columns: new[] { "Tenant_ID", "CompanyId", "ProgramId", "SettingKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operation_CompanyId",
                schema: "Sec",
                table: "Operation",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_CostCenterId",
                schema: "Sec",
                table: "Operation",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_CostUnitId",
                schema: "Sec",
                table: "Operation",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_CustomerId",
                schema: "Sec",
                table: "Operation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OperationTypeId",
                schema: "Sec",
                table: "Operation",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_Tenant_ID_CompanyId_Code",
                schema: "Sec",
                table: "Operation",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operation_Tenant_ID_CompanyId_Name",
                schema: "Sec",
                table: "Operation",
                columns: new[] { "Tenant_ID", "CompanyId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerm_Tenant_ID_Code",
                schema: "Accounting",
                table: "PaymentTerm",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_BranchId",
                schema: "Sales",
                table: "SalesOrder",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CurrencyId",
                schema: "Sales",
                table: "SalesOrder",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerId",
                schema: "Sales",
                table: "SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_DocumentStatus",
                schema: "Sales",
                table: "SalesOrder",
                column: "DocumentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_OrderDate",
                schema: "Sales",
                table: "SalesOrder",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_PaymentTermId",
                schema: "Sales",
                table: "SalesOrder",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_SalespersonId",
                schema: "Sales",
                table: "SalesOrder",
                column: "SalespersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_SalesQuotationId",
                schema: "Sales",
                table: "SalesOrder",
                column: "SalesQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_SeriesId",
                schema: "Sales",
                table: "SalesOrder",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_TaxTypeId",
                schema: "Sales",
                table: "SalesOrder",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "UX_SalesOrder_OrderNumber_Tenant",
                schema: "Sales",
                table: "SalesOrder",
                columns: new[] { "OrderNumber", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_ItemId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_SalesOrderId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_UOMId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "UOMId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_WarehouseId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_User_CodeId",
                schema: "Sales",
                table: "SalesPerson",
                column: "User_CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_CurrencyId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_CustomerId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_InspectionRequestId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "InspectionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_SalespersonId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "SalespersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_SeriesId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_TaxTypeId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "UX_SalesQuotation_QuotationNumber_Tenant",
                schema: "Sales",
                table: "SalesQuotation",
                columns: new[] { "QuotationNumber", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLines_InspectionMethodId",
                schema: "Sales",
                table: "SalesQuotationLines",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLines_ItemId",
                schema: "Sales",
                table: "SalesQuotationLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLines_SalesQuotationId",
                schema: "Sales",
                table: "SalesQuotationLines",
                column: "SalesQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Screen_Code_Menu_ID",
                schema: "Syst",
                table: "Screen_Code",
                column: "Menu_ID",
                unique: true,
                filter: "[Menu_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ScreenCode_Id",
                schema: "Stt",
                table: "Series",
                column: "ScreenCode_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Series_Tenant_ID_ScreenCode_Id",
                schema: "Stt",
                table: "Series",
                columns: new[] { "Tenant_ID", "ScreenCode_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDetails_SeriesId",
                schema: "Stt",
                table: "SeriesDetails",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDetails_Tenant_ID_SeriesId",
                schema: "Stt",
                table: "SeriesDetails",
                columns: new[] { "Tenant_ID", "SeriesId" });

            migrationBuilder.CreateIndex(
                name: "UX_ServiceItem_Itemcode_Tenant",
                schema: "Inspection",
                table: "ServiceItem",
                columns: new[] { "Itemcode", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Size_Tenant_ID_Code",
                schema: "Inventory",
                table: "Size",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CityId",
                schema: "Accounting",
                table: "Supplier",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CountryId",
                schema: "Accounting",
                table: "Supplier",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CurrencyId",
                schema: "Accounting",
                table: "Supplier",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_PaymentTermId",
                schema: "Accounting",
                table: "Supplier",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SeriesId",
                schema: "Accounting",
                table: "Supplier",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupplierGroupId",
                schema: "Accounting",
                table: "Supplier",
                column: "SupplierGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_TaxCategoryId",
                schema: "Accounting",
                table: "Supplier",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Tenant_ID_Code",
                schema: "Accounting",
                table: "Supplier",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContact_SupplierId",
                schema: "Accounting",
                table: "SupplierContact",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroup_DefaultAccountGroupId",
                schema: "Accounting",
                table: "SupplierGroup",
                column: "DefaultAccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroup_PaymentTermsId",
                schema: "Accounting",
                table: "SupplierGroup",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroup_TaxCategoryId",
                schema: "Accounting",
                table: "SupplierGroup",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroup_Tenant_ID_Code",
                schema: "Accounting",
                table: "SupplierGroup",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Tenant_ID_CompanyId_Name",
                schema: "DMS",
                table: "Tag",
                columns: new[] { "Tenant_ID", "CompanyId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxCategory_Tenant_ID_Code",
                schema: "Accounting",
                table: "TaxCategory",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType",
                column: "ChartOfAccounttId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_taxCategoryId",
                schema: "Accounting",
                table: "TaxType",
                column: "taxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_Tenant_ID_Code",
                schema: "Accounting",
                table: "TaxType",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestTableDetail_TestTableMasterId",
                schema: "Inspection",
                table: "TestTableDetail",
                column: "TestTableMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TestTableSubDetail_TestTableDetailId",
                schema: "Inspection",
                table: "TestTableSubDetail",
                column: "TestTableDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionAttendance_EmployeeId",
                schema: "HR",
                table: "TrainingSessionAttendance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionAttendance_TrainingProgramId",
                schema: "HR",
                table: "TrainingSessionAttendance",
                column: "TrainingProgramId");

            migrationBuilder.CreateIndex(
                name: "UQ_UnitOfMeasure_Code_Tenant",
                schema: "Inventory",
                table: "UnitOfMeasure",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConversion_ToUoMId",
                schema: "Inventory",
                table: "UnitOfMeasureConversion",
                column: "ToUoMId");

            migrationBuilder.CreateIndex(
                name: "UQ_UoMConversion_From_To",
                schema: "Inventory",
                table: "UnitOfMeasureConversion",
                columns: new[] { "FromUoMId", "ToUoMId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_Tenant_ID_User_ID",
                schema: "Sec",
                table: "User_Code",
                columns: new[] { "Tenant_ID", "User_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup_Tenant_ID_Id",
                schema: "Sec",
                table: "User_Code_dGroup",
                columns: new[] { "Tenant_ID", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup_User_CodeId",
                schema: "Sec",
                table: "User_Code_dGroup",
                column: "User_CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_BranchId",
                schema: "Inventory",
                table: "Warehouse",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CityId",
                schema: "Inventory",
                table: "Warehouse",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CountryId",
                schema: "Inventory",
                table: "Warehouse",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_ResponsibleEmployeeId",
                schema: "Inventory",
                table: "Warehouse",
                column: "ResponsibleEmployeeId");

            migrationBuilder.CreateIndex(
                name: "UQ_Warehouse_Code_Tenant_Company",
                schema: "Inventory",
                table: "Warehouse",
                columns: new[] { "Code", "Tenant_ID", "CompanyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_ParentLocationId",
                schema: "Inventory",
                table: "WarehouseLocation",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "UQ_WarehouseLocation_Code",
                schema: "Inventory",
                table: "WarehouseLocation",
                columns: new[] { "WarehouseId", "Tenant_ID", "Code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingPeriod",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "AccreditationBodyLine",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Approval_d",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "Approval_Delegation",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "Area",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "AssetAccountingEventAccount",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "AssetDepreciationSchedule",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "AssetTransaction",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "BankAccount",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Cash",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Certificate",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "ChecklistLine",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "ChecklistTemplateLine",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "CurrencyExchangeRateLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CustomerBranch",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "DefaultAccountAssignment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "DetailTable",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "EquipmentAccessory",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentCalibrationHistory",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentInspection",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentMaintenanceAndRepairRecord",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentPreventiveMaintenance",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentsMoreInformationDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentsMoreInformationTemplateDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentSoftware",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "FolderPermission",
                schema: "DMS");

            migrationBuilder.DropTable(
                name: "GoodsReceiptLine",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InspectionCertificate",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionChecklistMoreInformaionTemplateDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionChecklistMoreInformationDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionReport",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionRequestLines",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionRequestSubcontractorDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionStandardApplicabilityRule",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectorAccreditation",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectorCompetencyLine",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InterviewEvaluation",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "InventoryBalance",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryCostLayer",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryLedger",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryOpeningBalance",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "JobAdvertisement",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "JobOfferNegotiation",
                schema: "HRManagement");

            migrationBuilder.DropTable(
                name: "Localization",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "MaintenanceReport",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "MaintenanceSchedule",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "MenuLocalization",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "ModuleSetting");

            migrationBuilder.DropTable(
                name: "SalesOrderLine",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesQuotationLines",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Screen_permission",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "SeriesDetails",
                schema: "Stt");

            migrationBuilder.DropTable(
                name: "ServiceType",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "SupplierContact",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "DMS");

            migrationBuilder.DropTable(
                name: "TestTableSubDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "TrainingSessionAttendance",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureConversion",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "User_Approval",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "User_Code_dGroup",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "User_Notification",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "Approval",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "AssetAccountingEvent",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "FixedAsset",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Bank",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Checklist",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "CurrencyExchangeRateHeader",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "DefaultAccountType",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CurrencyExchangRate",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "EquipmentsMoreInformation",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "EquipmentsMoreInformationTemplate",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "CompanyEquipment",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Folder",
                schema: "DMS");

            migrationBuilder.DropTable(
                name: "GoodsReceipt",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InspectionChecklistMoreInformationTemplate",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionChecklistMoreInformation",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "ServiceItem",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "AccreditationBody",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectorCompetency",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "FiscalYear",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "WarehouseLocation",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "ItemVariant",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "TestTableDetail",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "TrainingProgram",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "User_Group",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "AssetCategory",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "ChecklistTemplate",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "JobOrderLine",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Operation",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "InspectionChecklist",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "TestTableMaster",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionStandard",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "OperationType",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "SupplierGroup",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionMethod",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Inspector",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "JobOrder",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "ItemGroup",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Model",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Size",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "EquipmentType",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectorCategory",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "SalesOrder",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EquipmentCategory",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "SalesQuotation",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ApplicantCV",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "InspectionRequest",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "SalesPerson",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "TaxType",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "JobRequest",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "CustomerContact",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CustomerLocation",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "CustomerProject",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "InspectionType",
                schema: "Inspection");

            migrationBuilder.DropTable(
                name: "User_Code",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "ChartOfAccount",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "JobTitle",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Tenant_Code",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "AccountType",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CostCenter",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CostUnit",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "CustomerGroup",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Series",
                schema: "Stt");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "DefaultAccountGroup",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PaymentTerm",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "TaxCategory",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Screen_Code",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "Syst");

            migrationBuilder.DropTable(
                name: "Program",
                schema: "Syst");
        }
    }
}
