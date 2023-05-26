using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Add_OceanExport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ShowName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppAwbNoRanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EndNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAwbNoRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAwbNoRanges_AppTradePartners_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppContainerDimensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerLength = table.Column<double>(type: "float", nullable: false),
                    ContainerWidth = table.Column<double>(type: "float", nullable: false),
                    ContainerHeight = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContainerDimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCurrencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlphabetCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMemos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    ForignType = table.Column<int>(type: "int", nullable: false),
                    ForignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMemos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSysCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodeValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShowName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSysCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Substation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubstationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbreviationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCountries_AppCurrencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "AppCurrencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppContainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ContainerSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SealNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PackageNum = table.Column<int>(type: "int", nullable: false),
                    PackageWeight = table.Column<double>(type: "float", nullable: false),
                    PackageMeasure = table.Column<double>(type: "float", nullable: false),
                    SealNo2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PicupNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDanger = table.Column<bool>(type: "bit", nullable: false),
                    StorageStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StorageEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureUnit = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    VentilationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    GateInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CutOffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadedOnVesselDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCarrierRelease = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomsClearance = table.Column<bool>(type: "bit", nullable: false),
                    UvDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastFreeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YardLocation = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    ApptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GateOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreeDetentionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimateDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmptyReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailableForPickup = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppContainers_AppSysCodes_VentilationId",
                        column: x => x.VentilationId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppContainerSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SizeDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContainerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Teu = table.Column<double>(type: "float", nullable: false),
                    IsUseed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContainerSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppContainerSizes_AppSysCodes_ContainerGroupId",
                        column: x => x.ContainerGroupId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppPackageUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AwbNoRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EManifestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPackageUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPackageUnits_AppAwbNoRanges_AwbNoRangeId",
                        column: x => x.AwbNoRangeId,
                        principalTable: "AppAwbNoRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppPackageUnits_AppSysCodes_EManifestId",
                        column: x => x.EManifestId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDiv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPort = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Port_AppCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AppCountries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppCargoManifests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PackageNum = table.Column<int>(type: "int", nullable: false),
                    PackageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HtsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcs = table.Column<int>(type: "int", nullable: false),
                    NetWeight = table.Column<double>(type: "float", nullable: false),
                    GrossWeight = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCargoManifests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCargoManifests_AppPackageUnits_PackageUnitId",
                        column: x => x.PackageUnitId,
                        principalTable: "AppPackageUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppWarehouseReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    DimensionUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pcs = table.Column<int>(type: "int", nullable: false),
                    PackageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Measure = table.Column<double>(type: "float", nullable: false),
                    LoadPlanRemarks = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWarehouseReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppWarehouseReceipts_AppPackageUnits_PackageUnitId",
                        column: x => x.PackageUnitId,
                        principalTable: "AppPackageUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppWarehouseReceipts_AppSysCodes_DimensionUnitId",
                        column: x => x.DimensionUnitId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppOceanExportMbls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    FilingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ItnNo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    AmsNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    MblCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlAcctCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblOverseaAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblNotifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ForwardingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoLoaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblOperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarrierContractNo = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDirect = table.Column<bool>(type: "bit", nullable: false),
                    CustomerRefNo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MblCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblBillToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblSalesTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookingMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voyage = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PorEtd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolEtd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PodEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DelEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FdestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FdestEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmptyPickupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PreCarriageVesselNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrepreCarriageVoyage = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    FreightTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayMblContainerSizeQtyInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OblTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VgmCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RailCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblReferralById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsBookingAgent = table.Column<bool>(type: "bit", nullable: false),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    MblReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OnBoardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubBlNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ServiceContactNo = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    ForwardRefNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    TransPort1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Trans1Eta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EctNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PrnNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsEcommerce = table.Column<bool>(type: "bit", nullable: false),
                    ColorRemarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomesticInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageWeightId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalAmountType = table.Column<bool>(type: "bit", nullable: false),
                    TotalPackage = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<double>(type: "float", nullable: false),
                    TotalMeasure = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOceanExportMbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_BlTypeId",
                        column: x => x.BlTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_ColorRemarkId",
                        column: x => x.ColorRemarkId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_FreightTermId",
                        column: x => x.FreightTermId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_MblSalesTypeId",
                        column: x => x.MblSalesTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_OblTypeId",
                        column: x => x.OblTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_PackageCategoryId",
                        column: x => x.PackageCategoryId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_PackageMeasureId",
                        column: x => x.PackageMeasureId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_PackageWeightId",
                        column: x => x.PackageWeightId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_PreCarriageVesselNameId",
                        column: x => x.PreCarriageVesselNameId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_ShipModeId",
                        column: x => x.ShipModeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_SvcTermFromId",
                        column: x => x.SvcTermFromId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppSysCodes_SvcTermToId",
                        column: x => x.SvcTermToId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_BlAcctCarrierId",
                        column: x => x.BlAcctCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_CoLoaderId",
                        column: x => x.CoLoaderId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_DeliveryToId",
                        column: x => x.DeliveryToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_EmptyPickupId",
                        column: x => x.EmptyPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_ForwardingAgentId",
                        column: x => x.ForwardingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblBillToId",
                        column: x => x.MblBillToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblCarrierId",
                        column: x => x.MblCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblConsigneeId",
                        column: x => x.MblConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblCustomerId",
                        column: x => x.MblCustomerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblNotifyId",
                        column: x => x.MblNotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblOverseaAgentId",
                        column: x => x.MblOverseaAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_MblReferralById",
                        column: x => x.MblReferralById,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_AppTradePartners_ShippingAgentId",
                        column: x => x.ShippingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Port_DelId",
                        column: x => x.DelId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Port_FdestId",
                        column: x => x.FdestId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Port_PodId",
                        column: x => x.PodId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Port_PolId",
                        column: x => x.PolId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Port_PorId",
                        column: x => x.PorId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Port_TransPort1Id",
                        column: x => x.TransPort1Id,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_Substation_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Substation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_UserData_CancelById",
                        column: x => x.CancelById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_UserData_MblOperatorId",
                        column: x => x.MblOperatorId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_UserData_MblSaleId",
                        column: x => x.MblSaleId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportMbls_UserData_ReleaseById",
                        column: x => x.ReleaseById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppOceanExportHbls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MblId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HblNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SoNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CustomerRefNo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    B2bNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    QuotationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HblShipperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblBillToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblNotifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomsBrokerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TruckerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ForwardingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblOperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsSubAgentBl = table.Column<bool>(type: "bit", nullable: false),
                    ReceivingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PorEtd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PodEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DelEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FdestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FdestEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FbaFcId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmptyPickupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CargoPickupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreightTermForBuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreightTermForSalerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayHblContainerSizeQtyInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExpress = table.Column<bool>(type: "bit", nullable: false),
                    CargoTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblSalesTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblWhCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EarlyReturnDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LcNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LcIssueBank = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    LcIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnBoardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsStackable = table.Column<bool>(type: "bit", nullable: false),
                    IsHold = table.Column<bool>(type: "bit", nullable: false),
                    HoldReason = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    HolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    HblReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblReferralById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WoNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ShipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncotermsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NraNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsEcommerce = table.Column<bool>(type: "bit", nullable: false),
                    CyCfsLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRailwayCode = table.Column<bool>(type: "bit", nullable: false),
                    RailwayCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoorDeliveryETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoorDeliveryATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomClearance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomDeclaration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardColorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ColorRemarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomesticInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOceanExportHbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppOceanExportMbls_MblId",
                        column: x => x.MblId,
                        principalTable: "AppOceanExportMbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_CardColorId",
                        column: x => x.CardColorId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_ColorRemarkId",
                        column: x => x.ColorRemarkId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_FreightTermForBuyerId",
                        column: x => x.FreightTermForBuyerId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_FreightTermForSalerId",
                        column: x => x.FreightTermForSalerId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_IncotermsId",
                        column: x => x.IncotermsId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_MblSalesTypeId",
                        column: x => x.MblSalesTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_RailwayCodeId",
                        column: x => x.RailwayCodeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_ShipModeId",
                        column: x => x.ShipModeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_ShipTypeId",
                        column: x => x.ShipTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_SvcTermFromId",
                        column: x => x.SvcTermFromId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppSysCodes_SvcTermToId",
                        column: x => x.SvcTermToId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_CargoPickupId",
                        column: x => x.CargoPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_CustomsBrokerId",
                        column: x => x.CustomsBrokerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_CyCfsLocationId",
                        column: x => x.CyCfsLocationId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_DeliveryToId",
                        column: x => x.DeliveryToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_EmptyPickupId",
                        column: x => x.EmptyPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_FbaFcId",
                        column: x => x.FbaFcId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_ForwardingAgentId",
                        column: x => x.ForwardingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_HblBillToId",
                        column: x => x.HblBillToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_HblConsigneeId",
                        column: x => x.HblConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_HblCustomerId",
                        column: x => x.HblCustomerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_HblNotifyId",
                        column: x => x.HblNotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_HblShipperId",
                        column: x => x.HblShipperId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_MblReferralById",
                        column: x => x.MblReferralById,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_ReceivingAgentId",
                        column: x => x.ReceivingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_AppTradePartners_TruckerId",
                        column: x => x.TruckerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_Port_DelId",
                        column: x => x.DelId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_Port_FdestId",
                        column: x => x.FdestId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_Port_PodId",
                        column: x => x.PodId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_Port_PorId",
                        column: x => x.PorId,
                        principalTable: "Port",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_UserData_CancelById",
                        column: x => x.CancelById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_UserData_HblOperatorId",
                        column: x => x.HblOperatorId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_UserData_HblSaleId",
                        column: x => x.HblSaleId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_UserData_HolderId",
                        column: x => x.HolderId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanExportHbls_UserData_ReleaseById",
                        column: x => x.ReleaseById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAwbNoRanges_CompanyId",
                table: "AppAwbNoRanges",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCargoManifests_PackageUnitId",
                table: "AppCargoManifests",
                column: "PackageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppContainers_VentilationId",
                table: "AppContainers",
                column: "VentilationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppContainerSizes_ContainerGroupId",
                table: "AppContainerSizes",
                column: "ContainerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCountries_CurrencyId",
                table: "AppCountries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_AgentId",
                table: "AppOceanExportHbls",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_CancelById",
                table: "AppOceanExportHbls",
                column: "CancelById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_CardColorId",
                table: "AppOceanExportHbls",
                column: "CardColorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_CargoPickupId",
                table: "AppOceanExportHbls",
                column: "CargoPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_CargoTypeId",
                table: "AppOceanExportHbls",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_ColorRemarkId",
                table: "AppOceanExportHbls",
                column: "ColorRemarkId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_CustomsBrokerId",
                table: "AppOceanExportHbls",
                column: "CustomsBrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_CyCfsLocationId",
                table: "AppOceanExportHbls",
                column: "CyCfsLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_DelId",
                table: "AppOceanExportHbls",
                column: "DelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_DeliveryToId",
                table: "AppOceanExportHbls",
                column: "DeliveryToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_EmptyPickupId",
                table: "AppOceanExportHbls",
                column: "EmptyPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_FbaFcId",
                table: "AppOceanExportHbls",
                column: "FbaFcId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_FdestId",
                table: "AppOceanExportHbls",
                column: "FdestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_ForwardingAgentId",
                table: "AppOceanExportHbls",
                column: "ForwardingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_FreightTermForBuyerId",
                table: "AppOceanExportHbls",
                column: "FreightTermForBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_FreightTermForSalerId",
                table: "AppOceanExportHbls",
                column: "FreightTermForSalerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblBillToId",
                table: "AppOceanExportHbls",
                column: "HblBillToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblConsigneeId",
                table: "AppOceanExportHbls",
                column: "HblConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblCustomerId",
                table: "AppOceanExportHbls",
                column: "HblCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblNotifyId",
                table: "AppOceanExportHbls",
                column: "HblNotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblOperatorId",
                table: "AppOceanExportHbls",
                column: "HblOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblSaleId",
                table: "AppOceanExportHbls",
                column: "HblSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HblShipperId",
                table: "AppOceanExportHbls",
                column: "HblShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_HolderId",
                table: "AppOceanExportHbls",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_IncotermsId",
                table: "AppOceanExportHbls",
                column: "IncotermsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_MblId",
                table: "AppOceanExportHbls",
                column: "MblId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_MblReferralById",
                table: "AppOceanExportHbls",
                column: "MblReferralById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_MblSalesTypeId",
                table: "AppOceanExportHbls",
                column: "MblSalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_PodId",
                table: "AppOceanExportHbls",
                column: "PodId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_PorId",
                table: "AppOceanExportHbls",
                column: "PorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_RailwayCodeId",
                table: "AppOceanExportHbls",
                column: "RailwayCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_ReceivingAgentId",
                table: "AppOceanExportHbls",
                column: "ReceivingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_ReleaseById",
                table: "AppOceanExportHbls",
                column: "ReleaseById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_ShipModeId",
                table: "AppOceanExportHbls",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_ShipTypeId",
                table: "AppOceanExportHbls",
                column: "ShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_SvcTermFromId",
                table: "AppOceanExportHbls",
                column: "SvcTermFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_SvcTermToId",
                table: "AppOceanExportHbls",
                column: "SvcTermToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_TruckerId",
                table: "AppOceanExportHbls",
                column: "TruckerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_BlAcctCarrierId",
                table: "AppOceanExportMbls",
                column: "BlAcctCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_BlTypeId",
                table: "AppOceanExportMbls",
                column: "BlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_CancelById",
                table: "AppOceanExportMbls",
                column: "CancelById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_CargoTypeId",
                table: "AppOceanExportMbls",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_CoLoaderId",
                table: "AppOceanExportMbls",
                column: "CoLoaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_ColorRemarkId",
                table: "AppOceanExportMbls",
                column: "ColorRemarkId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_DelId",
                table: "AppOceanExportMbls",
                column: "DelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_DeliveryToId",
                table: "AppOceanExportMbls",
                column: "DeliveryToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_EmptyPickupId",
                table: "AppOceanExportMbls",
                column: "EmptyPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_FdestId",
                table: "AppOceanExportMbls",
                column: "FdestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_ForwardingAgentId",
                table: "AppOceanExportMbls",
                column: "ForwardingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_FreightTermId",
                table: "AppOceanExportMbls",
                column: "FreightTermId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblBillToId",
                table: "AppOceanExportMbls",
                column: "MblBillToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblCarrierId",
                table: "AppOceanExportMbls",
                column: "MblCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblConsigneeId",
                table: "AppOceanExportMbls",
                column: "MblConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblCustomerId",
                table: "AppOceanExportMbls",
                column: "MblCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblNotifyId",
                table: "AppOceanExportMbls",
                column: "MblNotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblOperatorId",
                table: "AppOceanExportMbls",
                column: "MblOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblOverseaAgentId",
                table: "AppOceanExportMbls",
                column: "MblOverseaAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblReferralById",
                table: "AppOceanExportMbls",
                column: "MblReferralById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblSaleId",
                table: "AppOceanExportMbls",
                column: "MblSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_MblSalesTypeId",
                table: "AppOceanExportMbls",
                column: "MblSalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_OblTypeId",
                table: "AppOceanExportMbls",
                column: "OblTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_OfficeId",
                table: "AppOceanExportMbls",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PackageCategoryId",
                table: "AppOceanExportMbls",
                column: "PackageCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PackageMeasureId",
                table: "AppOceanExportMbls",
                column: "PackageMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PackageWeightId",
                table: "AppOceanExportMbls",
                column: "PackageWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PodId",
                table: "AppOceanExportMbls",
                column: "PodId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PolId",
                table: "AppOceanExportMbls",
                column: "PolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PorId",
                table: "AppOceanExportMbls",
                column: "PorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_PreCarriageVesselNameId",
                table: "AppOceanExportMbls",
                column: "PreCarriageVesselNameId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_ReleaseById",
                table: "AppOceanExportMbls",
                column: "ReleaseById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_ShipModeId",
                table: "AppOceanExportMbls",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_ShippingAgentId",
                table: "AppOceanExportMbls",
                column: "ShippingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_SvcTermFromId",
                table: "AppOceanExportMbls",
                column: "SvcTermFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_SvcTermToId",
                table: "AppOceanExportMbls",
                column: "SvcTermToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_TransPort1Id",
                table: "AppOceanExportMbls",
                column: "TransPort1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppPackageUnits_AwbNoRangeId",
                table: "AppPackageUnits",
                column: "AwbNoRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPackageUnits_EManifestId",
                table: "AppPackageUnits",
                column: "EManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWarehouseReceipts_DimensionUnitId",
                table: "AppWarehouseReceipts",
                column: "DimensionUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWarehouseReceipts_PackageUnitId",
                table: "AppWarehouseReceipts",
                column: "PackageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Port_CountryId",
                table: "Port",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAttachments");

            migrationBuilder.DropTable(
                name: "AppCargoManifests");

            migrationBuilder.DropTable(
                name: "AppContainerDimensions");

            migrationBuilder.DropTable(
                name: "AppContainers");

            migrationBuilder.DropTable(
                name: "AppContainerSizes");

            migrationBuilder.DropTable(
                name: "AppMemos");

            migrationBuilder.DropTable(
                name: "AppOceanExportHbls");

            migrationBuilder.DropTable(
                name: "AppWarehouseReceipts");

            migrationBuilder.DropTable(
                name: "AppOceanExportMbls");

            migrationBuilder.DropTable(
                name: "AppPackageUnits");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Substation");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "AppAwbNoRanges");

            migrationBuilder.DropTable(
                name: "AppSysCodes");

            migrationBuilder.DropTable(
                name: "AppCountries");

            migrationBuilder.DropTable(
                name: "AppCurrencies");
        }
    }
}
