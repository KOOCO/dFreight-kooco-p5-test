using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Created_AirExportMawb_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAirExportMawbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MawbCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IssuingCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AwbType = table.Column<int>(type: "int", nullable: false),
                    MawbNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwbDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItnNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ShipperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwbAcctCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoLoaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MawbOperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDirectMaster = table.Column<bool>(type: "bit", nullable: false),
                    DepatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RouteTrans1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RouteTrans1ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTrans1DepatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTrans1FlightNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RouteTrans1CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RouteTrans2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RouteTrans2ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTrans2DepatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTrans2FlightNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RouteTrans2CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RouteTrans3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RouteTrans3ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTrans3DepatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteTrans3FlightNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RouteTrans3CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DVCarriage = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    DVCustomer = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CarrierSpotNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    WtVal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingInfo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ShipperLoad = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Sci = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Package = table.Column<double>(type: "float", nullable: false),
                    MawbPackageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuyingRate = table.Column<double>(type: "float", nullable: false),
                    BuyingRateUnitType = table.Column<int>(type: "int", nullable: false),
                    SellingRate = table.Column<double>(type: "float", nullable: false),
                    SellingRateUnitType = table.Column<int>(type: "int", nullable: false),
                    VolumeWeightKg = table.Column<double>(type: "float", nullable: false),
                    VolumeWeightCbm = table.Column<double>(type: "float", nullable: false),
                    GrossWeightKg = table.Column<double>(type: "float", nullable: false),
                    GrossWeightLb = table.Column<double>(type: "float", nullable: false),
                    GrossWeightAmount = table.Column<double>(type: "float", nullable: false),
                    AwbGrossWeightKg = table.Column<double>(type: "float", nullable: false),
                    AwbGrossWeightLb = table.Column<double>(type: "float", nullable: false),
                    AwbGrossWeightAmount = table.Column<double>(type: "float", nullable: false),
                    ChargeableWeightKg = table.Column<double>(type: "float", nullable: false),
                    ChargeableWeightLb = table.Column<double>(type: "float", nullable: false),
                    ChargeableWeightAmount = table.Column<double>(type: "float", nullable: false),
                    AwbChargeableWeightKg = table.Column<double>(type: "float", nullable: false),
                    AwbChargeableWeightLb = table.Column<double>(type: "float", nullable: false),
                    AwbChargeableWeightAmount = table.Column<double>(type: "float", nullable: false),
                    IncotermsType = table.Column<int>(type: "int", nullable: false),
                    ServiceTermTypeFrom = table.Column<int>(type: "int", nullable: false),
                    ServiceTermTypeTo = table.Column<int>(type: "int", nullable: false),
                    IsAwbCancelled = table.Column<bool>(type: "bit", nullable: false),
                    AwbCancelledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AwbCancelledOpId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonForCancel = table.Column<int>(type: "int", nullable: false),
                    BusinessReferredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsECom = table.Column<bool>(type: "bit", nullable: false),
                    DisplayUnit = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AppAirExportMawbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppAirports_DepatureId",
                        column: x => x.DepatureId,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppAirports_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppAirports_RouteTrans1Id",
                        column: x => x.RouteTrans1Id,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppAirports_RouteTrans2Id",
                        column: x => x.RouteTrans2Id,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppAirports_RouteTrans3Id",
                        column: x => x.RouteTrans3Id,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppPackageUnits_PackageId",
                        column: x => x.PackageId,
                        principalTable: "AppPackageUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppSubstations_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "AppSubstations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_AwbAcctCarrierId",
                        column: x => x.AwbAcctCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_BusinessReferredId",
                        column: x => x.BusinessReferredId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_CoLoaderId",
                        column: x => x.CoLoaderId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_IssuingCarrierId",
                        column: x => x.IssuingCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_MawbCarrierId",
                        column: x => x.MawbCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_NotifyId",
                        column: x => x.NotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_RouteTrans1CarrierId",
                        column: x => x.RouteTrans1CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_RouteTrans2CarrierId",
                        column: x => x.RouteTrans2CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_RouteTrans3CarrierId",
                        column: x => x.RouteTrans3CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_AppTradePartners_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_UserData_AwbCancelledOpId",
                        column: x => x.AwbCancelledOpId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirExportMawbs_UserData_MawbOperatorId",
                        column: x => x.MawbOperatorId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_AwbAcctCarrierId",
                table: "AppAirExportMawbs",
                column: "AwbAcctCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_AwbCancelledOpId",
                table: "AppAirExportMawbs",
                column: "AwbCancelledOpId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_BusinessReferredId",
                table: "AppAirExportMawbs",
                column: "BusinessReferredId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_CoLoaderId",
                table: "AppAirExportMawbs",
                column: "CoLoaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_ConsigneeId",
                table: "AppAirExportMawbs",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_DeliveryId",
                table: "AppAirExportMawbs",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_DepatureId",
                table: "AppAirExportMawbs",
                column: "DepatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_DestinationId",
                table: "AppAirExportMawbs",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_IssuingCarrierId",
                table: "AppAirExportMawbs",
                column: "IssuingCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_MawbCarrierId",
                table: "AppAirExportMawbs",
                column: "MawbCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_MawbOperatorId",
                table: "AppAirExportMawbs",
                column: "MawbOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_NotifyId",
                table: "AppAirExportMawbs",
                column: "NotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_OfficeId",
                table: "AppAirExportMawbs",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_PackageId",
                table: "AppAirExportMawbs",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_RouteTrans1CarrierId",
                table: "AppAirExportMawbs",
                column: "RouteTrans1CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_RouteTrans1Id",
                table: "AppAirExportMawbs",
                column: "RouteTrans1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_RouteTrans2CarrierId",
                table: "AppAirExportMawbs",
                column: "RouteTrans2CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_RouteTrans2Id",
                table: "AppAirExportMawbs",
                column: "RouteTrans2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_RouteTrans3CarrierId",
                table: "AppAirExportMawbs",
                column: "RouteTrans3CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_RouteTrans3Id",
                table: "AppAirExportMawbs",
                column: "RouteTrans3Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirExportMawbs_ShipperId",
                table: "AppAirExportMawbs",
                column: "ShipperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAirExportMawbs");
        }
    }
}
