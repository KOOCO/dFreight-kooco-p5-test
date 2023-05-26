using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Add_VesselSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppExportBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AppExportBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppVesselSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ItnNo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    MblCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlAcctCarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblOverseaAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MblNotifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ForwardingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoLoaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voyage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmptyPickupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolEtd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PorEtd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PodEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DelEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FdestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FdestEta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreightTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SvcTermToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OblTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VgmCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RailCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnBoardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubBlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForwardRefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransPort1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Trans1Eta = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_AppVesselSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppPorts_DelId",
                        column: x => x.DelId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppPorts_FdestId",
                        column: x => x.FdestId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppPorts_PodId",
                        column: x => x.PodId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppPorts_PolId",
                        column: x => x.PolId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppPorts_PorId",
                        column: x => x.PorId,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppPorts_TransPort1Id",
                        column: x => x.TransPort1Id,
                        principalTable: "AppPorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSubstations_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "AppSubstations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSysCodes_BlTypeId",
                        column: x => x.BlTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSysCodes_FreightTermId",
                        column: x => x.FreightTermId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSysCodes_OblTypeId",
                        column: x => x.OblTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSysCodes_ShipModeId",
                        column: x => x.ShipModeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSysCodes_SvcTermFromId",
                        column: x => x.SvcTermFromId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppSysCodes_SvcTermToId",
                        column: x => x.SvcTermToId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_BlAcctCarrierId",
                        column: x => x.BlAcctCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_CoLoaderId",
                        column: x => x.CoLoaderId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_DeliveryToId",
                        column: x => x.DeliveryToId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_EmptyPickupId",
                        column: x => x.EmptyPickupId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_ForwardingAgentId",
                        column: x => x.ForwardingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_MblCarrierId",
                        column: x => x.MblCarrierId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_MblNotifyId",
                        column: x => x.MblNotifyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_MblOverseaAgentId",
                        column: x => x.MblOverseaAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppVesselSchedules_AppTradePartners_ShippingAgentId",
                        column: x => x.ShippingAgentId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_BlAcctCarrierId",
                table: "AppVesselSchedules",
                column: "BlAcctCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_BlTypeId",
                table: "AppVesselSchedules",
                column: "BlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_CoLoaderId",
                table: "AppVesselSchedules",
                column: "CoLoaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_DelId",
                table: "AppVesselSchedules",
                column: "DelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_DeliveryToId",
                table: "AppVesselSchedules",
                column: "DeliveryToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_EmptyPickupId",
                table: "AppVesselSchedules",
                column: "EmptyPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_FdestId",
                table: "AppVesselSchedules",
                column: "FdestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_ForwardingAgentId",
                table: "AppVesselSchedules",
                column: "ForwardingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_FreightTermId",
                table: "AppVesselSchedules",
                column: "FreightTermId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_MblCarrierId",
                table: "AppVesselSchedules",
                column: "MblCarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_MblNotifyId",
                table: "AppVesselSchedules",
                column: "MblNotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_MblOverseaAgentId",
                table: "AppVesselSchedules",
                column: "MblOverseaAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_OblTypeId",
                table: "AppVesselSchedules",
                column: "OblTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_OfficeId",
                table: "AppVesselSchedules",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_PodId",
                table: "AppVesselSchedules",
                column: "PodId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_PolId",
                table: "AppVesselSchedules",
                column: "PolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_PorId",
                table: "AppVesselSchedules",
                column: "PorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_ShipModeId",
                table: "AppVesselSchedules",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_ShippingAgentId",
                table: "AppVesselSchedules",
                column: "ShippingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_SvcTermFromId",
                table: "AppVesselSchedules",
                column: "SvcTermFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_SvcTermToId",
                table: "AppVesselSchedules",
                column: "SvcTermToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVesselSchedules_TransPort1Id",
                table: "AppVesselSchedules",
                column: "TransPort1Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppExportBookings");

            migrationBuilder.DropTable(
                name: "AppVesselSchedules");
        }
    }
}
