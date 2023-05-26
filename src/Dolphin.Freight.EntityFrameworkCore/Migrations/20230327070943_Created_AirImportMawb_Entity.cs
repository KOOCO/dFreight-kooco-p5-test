using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Created_AirImportMawb_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAirImportMawbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MawbNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwbType = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OverseaAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AwbAcctCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoLoaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDirectMaster = table.Column<bool>(type: "bit", nullable: false),
                    ShipperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BillToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    FPOEDepature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FPOETrans1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FPOETrans2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FPOETrans3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FPOEDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreightLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Package = table.Column<double>(type: "float", nullable: false),
                    MawbPackageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MawbPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GrossWeightKg = table.Column<double>(type: "float", nullable: false),
                    GrossWeightLb = table.Column<double>(type: "float", nullable: false),
                    ChargeableWeightKg = table.Column<double>(type: "float", nullable: false),
                    ChargeableWeightLb = table.Column<double>(type: "float", nullable: false),
                    VolumeWeightKg = table.Column<double>(type: "float", nullable: false),
                    VolumeWeightCbm = table.Column<double>(type: "float", nullable: false),
                    FreightType = table.Column<int>(type: "int", nullable: false),
                    IncotermsType = table.Column<int>(type: "int", nullable: false),
                    ServiceTermTypeFrom = table.Column<int>(type: "int", nullable: false),
                    ServiceTermTypeTo = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AppAirImportMawbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppAirports_DepatureId",
                        column: x => x.DepatureId,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppAirports_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppAirports_RouteTrans1Id",
                        column: x => x.RouteTrans1Id,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppAirports_RouteTrans2Id",
                        column: x => x.RouteTrans2Id,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppAirports_RouteTrans3Id",
                        column: x => x.RouteTrans3Id,
                        principalTable: "AppAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppPackageUnits_MawbPackageId",
                        column: x => x.MawbPackageId,
                        principalTable: "AppPackageUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppSubstations_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "AppSubstations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_AwbAcctCarrierId",
                        column: x => x.AwbAcctCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_BillToId",
                        column: x => x.BillToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_BusinessReferredId",
                        column: x => x.BusinessReferredId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_CoLoaderId",
                        column: x => x.CoLoaderId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_FreightLocationId",
                        column: x => x.FreightLocationId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_NotifyId",
                        column: x => x.NotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_OverseaAgentId",
                        column: x => x.OverseaAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_RouteTrans1CarrierId",
                        column: x => x.RouteTrans1CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_RouteTrans2CarrierId",
                        column: x => x.RouteTrans2CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_RouteTrans3CarrierId",
                        column: x => x.RouteTrans3CarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_AppTradePartners_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_UserData_OPId",
                        column: x => x.OPId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportMawbs_UserData_SalesId",
                        column: x => x.SalesId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_AwbAcctCarrierId",
                table: "AppAirImportMawbs",
                column: "AwbAcctCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_BillToId",
                table: "AppAirImportMawbs",
                column: "BillToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_BusinessReferredId",
                table: "AppAirImportMawbs",
                column: "BusinessReferredId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_CarrierId",
                table: "AppAirImportMawbs",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_CoLoaderId",
                table: "AppAirImportMawbs",
                column: "CoLoaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_ConsigneeId",
                table: "AppAirImportMawbs",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_CustomerId",
                table: "AppAirImportMawbs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_DepatureId",
                table: "AppAirImportMawbs",
                column: "DepatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_DestinationId",
                table: "AppAirImportMawbs",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_FreightLocationId",
                table: "AppAirImportMawbs",
                column: "FreightLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_MawbPackageId",
                table: "AppAirImportMawbs",
                column: "MawbPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_NotifyId",
                table: "AppAirImportMawbs",
                column: "NotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_OfficeId",
                table: "AppAirImportMawbs",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_OPId",
                table: "AppAirImportMawbs",
                column: "OPId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_OverseaAgentId",
                table: "AppAirImportMawbs",
                column: "OverseaAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_RouteTrans1CarrierId",
                table: "AppAirImportMawbs",
                column: "RouteTrans1CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_RouteTrans1Id",
                table: "AppAirImportMawbs",
                column: "RouteTrans1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_RouteTrans2CarrierId",
                table: "AppAirImportMawbs",
                column: "RouteTrans2CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_RouteTrans2Id",
                table: "AppAirImportMawbs",
                column: "RouteTrans2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_RouteTrans3CarrierId",
                table: "AppAirImportMawbs",
                column: "RouteTrans3CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_RouteTrans3Id",
                table: "AppAirImportMawbs",
                column: "RouteTrans3Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_SalesId",
                table: "AppAirImportMawbs",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportMawbs_ShipperId",
                table: "AppAirImportMawbs",
                column: "ShipperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAirImportMawbs");
        }
    }
}
