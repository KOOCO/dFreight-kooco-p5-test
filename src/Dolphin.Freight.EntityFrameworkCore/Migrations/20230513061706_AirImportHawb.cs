using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AirImportHawb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAirImportHawbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MawbId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HawbNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Hsn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreightLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trucker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastFreeDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StorageStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Freight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeightLB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeableWeightLB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeWeightKG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeWeightCBM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassOfEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ITIssuedLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrtRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoReleasedto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoorDelivered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Incoterms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTermStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTermTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppAirImportHawbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAirImportHawbs_AppTradePartners_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportHawbs_AppTradePartners_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportHawbs_UserData_OPId",
                        column: x => x.OPId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAirImportHawbs_UserData_SalesId",
                        column: x => x.SalesId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportHawbs_ConsigneeId",
                table: "AppAirImportHawbs",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportHawbs_OPId",
                table: "AppAirImportHawbs",
                column: "OPId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportHawbs_SalesId",
                table: "AppAirImportHawbs",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAirImportHawbs_ShipperId",
                table: "AppAirImportHawbs",
                column: "ShipperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAirImportHawbs");
        }
    }
}
