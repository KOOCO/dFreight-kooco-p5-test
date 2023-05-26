using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class CreateTradePartnerDefaultFreight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTradePartnerDefaultFreightAP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradePartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    FreightCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreightDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Vol = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    AgentAmount = table.Column<double>(type: "float", nullable: false),
                    ShipModeFCL = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeLCL = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeFAK = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeBULK = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_AppTradePartnerDefaultFreightAP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerDefaultFreightAP_AppBillingCodes_FreightCode",
                        column: x => x.FreightCode,
                        principalTable: "AppBillingCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerDefaultFreightAP_AppTradePartners_TradePartnerId",
                        column: x => x.TradePartnerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTradePartnerDefaultFreightAR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradePartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    FreightCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreightDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Vol = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    AgentAmount = table.Column<double>(type: "float", nullable: false),
                    ShipModeFCL = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeLCL = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeFAK = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeBULK = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_AppTradePartnerDefaultFreightAR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerDefaultFreightAR_AppBillingCodes_FreightCode",
                        column: x => x.FreightCode,
                        principalTable: "AppBillingCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerDefaultFreightAR_AppTradePartners_TradePartnerId",
                        column: x => x.TradePartnerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTradePartnerDefaultFreightDC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradePartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    FreightCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreightDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Vol = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    AgentAmount = table.Column<double>(type: "float", nullable: false),
                    ShipModeFCL = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeLCL = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeFAK = table.Column<bool>(type: "bit", nullable: true),
                    ShipModeBULK = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_AppTradePartnerDefaultFreightDC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerDefaultFreightDC_AppBillingCodes_FreightCode",
                        column: x => x.FreightCode,
                        principalTable: "AppBillingCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerDefaultFreightDC_AppTradePartners_TradePartnerId",
                        column: x => x.TradePartnerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerDefaultFreightAP_FreightCode",
                table: "AppTradePartnerDefaultFreightAP",
                column: "FreightCode");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerDefaultFreightAP_TradePartnerId",
                table: "AppTradePartnerDefaultFreightAP",
                column: "TradePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerDefaultFreightAR_FreightCode",
                table: "AppTradePartnerDefaultFreightAR",
                column: "FreightCode");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerDefaultFreightAR_TradePartnerId",
                table: "AppTradePartnerDefaultFreightAR",
                column: "TradePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerDefaultFreightDC_FreightCode",
                table: "AppTradePartnerDefaultFreightDC",
                column: "FreightCode");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerDefaultFreightDC_TradePartnerId",
                table: "AppTradePartnerDefaultFreightDC",
                column: "TradePartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTradePartnerDefaultFreightAP");

            migrationBuilder.DropTable(
                name: "AppTradePartnerDefaultFreightAR");

            migrationBuilder.DropTable(
                name: "AppTradePartnerDefaultFreightDC");
        }
    }
}
