using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Created_OceanImportMbls_OceanImportHbls_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppOceanImportMbls",
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
                    MblCarrierContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlAcctCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlAcctCarrierContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingAgentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblOverseaAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblOverseaAgentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblNotifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblNotifyContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForwardingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ForwardingAgentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoLoaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoLoaderContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsedCareOf = table.Column<bool>(type: "bit", nullable: false),
                    CareOfId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CareOfContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblOperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarrierContractNo = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDirect = table.Column<bool>(type: "bit", nullable: false),
                    CustomerRefNo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MblCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblCustomerContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblBillToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblBillToContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblConsigneeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblSalesTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookingMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voyage = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PorEtd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolEtd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PodEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DelEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FdestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FdestEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmptyPickupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmptyPickupContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryToContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreCarriageVesselNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrepreCarriageVoyage = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    FreightTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayMblContainerSizeQtyInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OblTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PortCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VgmCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RailCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MblReferralById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblReferralByContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBookingAgent = table.Column<bool>(type: "bit", nullable: false),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    MblReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleaseById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OnBoardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubBlNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ServiceContactNo = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    ForwardRefNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    TransPort1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Trans1Eta = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_AppOceanImportMbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppPorts_DelId",
                        column: x => x.DelId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppPorts_FdestId",
                        column: x => x.FdestId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppPorts_PodId",
                        column: x => x.PodId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppPorts_PolId",
                        column: x => x.PolId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppPorts_PorId",
                        column: x => x.PorId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppPorts_TransPort1Id",
                        column: x => x.TransPort1Id,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSubstations_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "AppSubstations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_BlTypeId",
                        column: x => x.BlTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_ColorRemarkId",
                        column: x => x.ColorRemarkId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_FreightTermId",
                        column: x => x.FreightTermId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_MblSalesTypeId",
                        column: x => x.MblSalesTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_OblTypeId",
                        column: x => x.OblTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_PackageCategoryId",
                        column: x => x.PackageCategoryId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_PackageMeasureId",
                        column: x => x.PackageMeasureId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_PackageWeightId",
                        column: x => x.PackageWeightId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_PreCarriageVesselNameId",
                        column: x => x.PreCarriageVesselNameId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_ShipModeId",
                        column: x => x.ShipModeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_SvcTermFromId",
                        column: x => x.SvcTermFromId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppSysCodes_SvcTermToId",
                        column: x => x.SvcTermToId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_BlAcctCarrierId",
                        column: x => x.BlAcctCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_CareOfId",
                        column: x => x.CareOfId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_CoLoaderId",
                        column: x => x.CoLoaderId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_DeliveryToId",
                        column: x => x.DeliveryToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_EmptyPickupId",
                        column: x => x.EmptyPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_ForwardingAgentId",
                        column: x => x.ForwardingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblBillToId",
                        column: x => x.MblBillToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblCarrierId",
                        column: x => x.MblCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblConsigneeId",
                        column: x => x.MblConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblCustomerId",
                        column: x => x.MblCustomerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblNotifyId",
                        column: x => x.MblNotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblOverseaAgentId",
                        column: x => x.MblOverseaAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_MblReferralById",
                        column: x => x.MblReferralById,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_AppTradePartners_ShippingAgentId",
                        column: x => x.ShippingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_UserData_CancelById",
                        column: x => x.CancelById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_UserData_MblOperatorId",
                        column: x => x.MblOperatorId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_UserData_MblSaleId",
                        column: x => x.MblSaleId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportMbls_UserData_ReleaseById",
                        column: x => x.ReleaseById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppOceanImportHbls",
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
                    PorEtd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PodEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DelEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FdestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FdestEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FbaFcId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmptyPickupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    HblWhCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EarlyReturnDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LcNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LcIssueBank = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    LcIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnBoardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsStackable = table.Column<bool>(type: "bit", nullable: false),
                    IsHold = table.Column<bool>(type: "bit", nullable: false),
                    HoldReason = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    HolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    HblReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleaseById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    DoorDeliveryETA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoorDeliveryATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomClearance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomDeclaration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CardColorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ColorRemarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomesticInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_AppOceanImportHbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppOceanImportMbls_MblId",
                        column: x => x.MblId,
                        principalTable: "AppOceanImportMbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppPorts_DelId",
                        column: x => x.DelId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppPorts_FdestId",
                        column: x => x.FdestId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppPorts_PodId",
                        column: x => x.PodId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppPorts_PorId",
                        column: x => x.PorId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_CardColorId",
                        column: x => x.CardColorId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_ColorRemarkId",
                        column: x => x.ColorRemarkId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_FreightTermForBuyerId",
                        column: x => x.FreightTermForBuyerId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_FreightTermForSalerId",
                        column: x => x.FreightTermForSalerId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_IncotermsId",
                        column: x => x.IncotermsId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_MblSalesTypeId",
                        column: x => x.MblSalesTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_RailwayCodeId",
                        column: x => x.RailwayCodeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_ShipModeId",
                        column: x => x.ShipModeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_ShipTypeId",
                        column: x => x.ShipTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_SvcTermFromId",
                        column: x => x.SvcTermFromId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppSysCodes_SvcTermToId",
                        column: x => x.SvcTermToId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_CargoPickupId",
                        column: x => x.CargoPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_CustomsBrokerId",
                        column: x => x.CustomsBrokerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_CyCfsLocationId",
                        column: x => x.CyCfsLocationId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_DeliveryToId",
                        column: x => x.DeliveryToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_EmptyPickupId",
                        column: x => x.EmptyPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_FbaFcId",
                        column: x => x.FbaFcId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_ForwardingAgentId",
                        column: x => x.ForwardingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_HblBillToId",
                        column: x => x.HblBillToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_HblConsigneeId",
                        column: x => x.HblConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_HblCustomerId",
                        column: x => x.HblCustomerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_HblNotifyId",
                        column: x => x.HblNotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_HblShipperId",
                        column: x => x.HblShipperId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_MblReferralById",
                        column: x => x.MblReferralById,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_ReceivingAgentId",
                        column: x => x.ReceivingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_AppTradePartners_TruckerId",
                        column: x => x.TruckerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_UserData_CancelById",
                        column: x => x.CancelById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_UserData_HblOperatorId",
                        column: x => x.HblOperatorId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_UserData_HblSaleId",
                        column: x => x.HblSaleId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_UserData_HolderId",
                        column: x => x.HolderId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOceanImportHbls_UserData_ReleaseById",
                        column: x => x.ReleaseById,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_AgentId",
                table: "AppOceanImportHbls",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_CancelById",
                table: "AppOceanImportHbls",
                column: "CancelById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_CardColorId",
                table: "AppOceanImportHbls",
                column: "CardColorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_CargoPickupId",
                table: "AppOceanImportHbls",
                column: "CargoPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_CargoTypeId",
                table: "AppOceanImportHbls",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_ColorRemarkId",
                table: "AppOceanImportHbls",
                column: "ColorRemarkId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_CustomsBrokerId",
                table: "AppOceanImportHbls",
                column: "CustomsBrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_CyCfsLocationId",
                table: "AppOceanImportHbls",
                column: "CyCfsLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_DelId",
                table: "AppOceanImportHbls",
                column: "DelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_DeliveryToId",
                table: "AppOceanImportHbls",
                column: "DeliveryToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_EmptyPickupId",
                table: "AppOceanImportHbls",
                column: "EmptyPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_FbaFcId",
                table: "AppOceanImportHbls",
                column: "FbaFcId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_FdestId",
                table: "AppOceanImportHbls",
                column: "FdestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_ForwardingAgentId",
                table: "AppOceanImportHbls",
                column: "ForwardingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_FreightTermForBuyerId",
                table: "AppOceanImportHbls",
                column: "FreightTermForBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_FreightTermForSalerId",
                table: "AppOceanImportHbls",
                column: "FreightTermForSalerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblBillToId",
                table: "AppOceanImportHbls",
                column: "HblBillToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblConsigneeId",
                table: "AppOceanImportHbls",
                column: "HblConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblCustomerId",
                table: "AppOceanImportHbls",
                column: "HblCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblNotifyId",
                table: "AppOceanImportHbls",
                column: "HblNotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblOperatorId",
                table: "AppOceanImportHbls",
                column: "HblOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblSaleId",
                table: "AppOceanImportHbls",
                column: "HblSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HblShipperId",
                table: "AppOceanImportHbls",
                column: "HblShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_HolderId",
                table: "AppOceanImportHbls",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_IncotermsId",
                table: "AppOceanImportHbls",
                column: "IncotermsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_MblId",
                table: "AppOceanImportHbls",
                column: "MblId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_MblReferralById",
                table: "AppOceanImportHbls",
                column: "MblReferralById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_MblSalesTypeId",
                table: "AppOceanImportHbls",
                column: "MblSalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_PodId",
                table: "AppOceanImportHbls",
                column: "PodId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_PorId",
                table: "AppOceanImportHbls",
                column: "PorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_RailwayCodeId",
                table: "AppOceanImportHbls",
                column: "RailwayCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_ReceivingAgentId",
                table: "AppOceanImportHbls",
                column: "ReceivingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_ReleaseById",
                table: "AppOceanImportHbls",
                column: "ReleaseById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_ShipModeId",
                table: "AppOceanImportHbls",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_ShipTypeId",
                table: "AppOceanImportHbls",
                column: "ShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_SvcTermFromId",
                table: "AppOceanImportHbls",
                column: "SvcTermFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_SvcTermToId",
                table: "AppOceanImportHbls",
                column: "SvcTermToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_TruckerId",
                table: "AppOceanImportHbls",
                column: "TruckerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_BlAcctCarrierId",
                table: "AppOceanImportMbls",
                column: "BlAcctCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_BlTypeId",
                table: "AppOceanImportMbls",
                column: "BlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_CancelById",
                table: "AppOceanImportMbls",
                column: "CancelById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_CareOfId",
                table: "AppOceanImportMbls",
                column: "CareOfId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_CargoTypeId",
                table: "AppOceanImportMbls",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_CoLoaderId",
                table: "AppOceanImportMbls",
                column: "CoLoaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_ColorRemarkId",
                table: "AppOceanImportMbls",
                column: "ColorRemarkId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_DelId",
                table: "AppOceanImportMbls",
                column: "DelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_DeliveryToId",
                table: "AppOceanImportMbls",
                column: "DeliveryToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_EmptyPickupId",
                table: "AppOceanImportMbls",
                column: "EmptyPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_FdestId",
                table: "AppOceanImportMbls",
                column: "FdestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_ForwardingAgentId",
                table: "AppOceanImportMbls",
                column: "ForwardingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_FreightTermId",
                table: "AppOceanImportMbls",
                column: "FreightTermId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblBillToId",
                table: "AppOceanImportMbls",
                column: "MblBillToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblCarrierId",
                table: "AppOceanImportMbls",
                column: "MblCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblConsigneeId",
                table: "AppOceanImportMbls",
                column: "MblConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblCustomerId",
                table: "AppOceanImportMbls",
                column: "MblCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblNotifyId",
                table: "AppOceanImportMbls",
                column: "MblNotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblOperatorId",
                table: "AppOceanImportMbls",
                column: "MblOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblOverseaAgentId",
                table: "AppOceanImportMbls",
                column: "MblOverseaAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblReferralById",
                table: "AppOceanImportMbls",
                column: "MblReferralById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblSaleId",
                table: "AppOceanImportMbls",
                column: "MblSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblSalesTypeId",
                table: "AppOceanImportMbls",
                column: "MblSalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_OblTypeId",
                table: "AppOceanImportMbls",
                column: "OblTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_OfficeId",
                table: "AppOceanImportMbls",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PackageCategoryId",
                table: "AppOceanImportMbls",
                column: "PackageCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PackageMeasureId",
                table: "AppOceanImportMbls",
                column: "PackageMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PackageWeightId",
                table: "AppOceanImportMbls",
                column: "PackageWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PodId",
                table: "AppOceanImportMbls",
                column: "PodId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PolId",
                table: "AppOceanImportMbls",
                column: "PolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PorId",
                table: "AppOceanImportMbls",
                column: "PorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_PreCarriageVesselNameId",
                table: "AppOceanImportMbls",
                column: "PreCarriageVesselNameId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_ReleaseById",
                table: "AppOceanImportMbls",
                column: "ReleaseById");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_ShipModeId",
                table: "AppOceanImportMbls",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_ShippingAgentId",
                table: "AppOceanImportMbls",
                column: "ShippingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_SvcTermFromId",
                table: "AppOceanImportMbls",
                column: "SvcTermFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_SvcTermToId",
                table: "AppOceanImportMbls",
                column: "SvcTermToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_TransPort1Id",
                table: "AppOceanImportMbls",
                column: "TransPort1Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOceanImportHbls");

            migrationBuilder.DropTable(
                name: "AppOceanImportMbls");
        }
    }
}
