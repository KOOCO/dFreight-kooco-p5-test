using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AirExportHawbData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAirExportHawbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MawbId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HawbNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingNo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ITNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActualShippedr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Consignee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notify = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverseaAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuingCarrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trucker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubAgentAwb = table.Column<bool>(type: "bit", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoPickup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DVCarriage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DVCustoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WTVAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyingRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyingRateUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingRateUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeWeightKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeWeightCBM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightShprKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightShprLB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightShprAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightCneeKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightShprKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightShprLB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightShprAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightCneeKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightCneeLB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightCneeAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Incoterms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTermStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTermEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AWBCancelled = table.Column<bool>(type: "bit", nullable: false),
                    AWBCancelledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanceledBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForCancel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureAndQuantityOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManifestNatureAndQuantityOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandlingInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppAirExportHawbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAirExportHawbs_AppAirExportMawbs_MawbId",
                        column: x => x.MawbId,
                        principalTable: "AppAirExportMawbs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportHawbs_UserData_OPId",
                        column: x => x.OPId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportHawbs_UserData_SalesId",
                        column: x => x.SalesId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportHawbs_MawbId",
                table: "AppAirExportHawbs",
                column: "MawbId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportHawbs_OPId",
                table: "AppAirExportHawbs",
                column: "OPId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportHawbs_SalesId",
                table: "AppAirExportHawbs",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAirExportHawbs");
        }
    }
}
