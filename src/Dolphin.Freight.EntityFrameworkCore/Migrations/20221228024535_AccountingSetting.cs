using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AccountingSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCurrencyTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ccy1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ccy2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateInternal = table.Column<double>(type: "float", nullable: false),
                    RateInterna2 = table.Column<double>(type: "float", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
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
                    table.PrimaryKey("PK_AppCurrencyTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCurrencyTables_AppSysCodes_Ccy1Id",
                        column: x => x.Ccy1Id,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppCurrencyTables_AppSysCodes_Ccy2Id",
                        column: x => x.Ccy2Id,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppGlCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GlTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingGlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeposit = table.Column<bool>(type: "bit", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false),
                    IsRevaluation = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_AppGlCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGlCodes_AppSysCodes_GlGroupId",
                        column: x => x.GlGroupId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppGlCodes_AppSysCodes_GlTypeId",
                        column: x => x.GlTypeId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppBillingCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    BillingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsAR = table.Column<bool>(type: "bit", nullable: false),
                    IsAP = table.Column<bool>(type: "bit", nullable: false),
                    IsDC = table.Column<bool>(type: "bit", nullable: false),
                    IsGA = table.Column<bool>(type: "bit", nullable: false),
                    IsOceanImportMbl = table.Column<bool>(type: "bit", nullable: false),
                    IsOceanImportHbl = table.Column<bool>(type: "bit", nullable: false),
                    IsOceanExportMbl = table.Column<bool>(type: "bit", nullable: false),
                    IsOceanExportHbl = table.Column<bool>(type: "bit", nullable: false),
                    IsAirImportMbl = table.Column<bool>(type: "bit", nullable: false),
                    IsAirImportHbl = table.Column<bool>(type: "bit", nullable: false),
                    IsAirExportMbl = table.Column<bool>(type: "bit", nullable: false),
                    IsAirExportHbl = table.Column<bool>(type: "bit", nullable: false),
                    IsTkm = table.Column<bool>(type: "bit", nullable: false),
                    IsMsm = table.Column<bool>(type: "bit", nullable: false),
                    IsWhs = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_AppBillingCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBillingCodes_AppGlCodes_CostId",
                        column: x => x.CostId,
                        principalTable: "AppGlCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppBillingCodes_AppGlCodes_CreditId",
                        column: x => x.CreditId,
                        principalTable: "AppGlCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppBillingCodes_AppGlCodes_DeitId",
                        column: x => x.DeitId,
                        principalTable: "AppGlCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppBillingCodes_AppGlCodes_RevenueId",
                        column: x => x.RevenueId,
                        principalTable: "AppGlCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBillingCodes_CostId",
                table: "AppBillingCodes",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBillingCodes_CreditId",
                table: "AppBillingCodes",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBillingCodes_DeitId",
                table: "AppBillingCodes",
                column: "DeitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBillingCodes_RevenueId",
                table: "AppBillingCodes",
                column: "RevenueId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurrencyTables_Ccy1Id",
                table: "AppCurrencyTables",
                column: "Ccy1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurrencyTables_Ccy2Id",
                table: "AppCurrencyTables",
                column: "Ccy2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppGlCodes_GlGroupId",
                table: "AppGlCodes",
                column: "GlGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppGlCodes_GlTypeId",
                table: "AppGlCodes",
                column: "GlTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBillingCodes");

            migrationBuilder.DropTable(
                name: "AppCurrencyTables");

            migrationBuilder.DropTable(
                name: "AppGlCodes");
        }
    }
}
