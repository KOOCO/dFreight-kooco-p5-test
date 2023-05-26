using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UPDATE_INVOICE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MblId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HblId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttentionTo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastNo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SystemNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CcyRateSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncotermsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AppInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppSysCodes_CcyRateSourceId",
                        column: x => x.CcyRateSourceId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppSysCodes_IncotermsId",
                        column: x => x.IncotermsId,
                        principalTable: "AppSysCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppTradePartners_InvoiceCompanyId",
                        column: x => x.InvoiceCompanyId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_CcyRateSourceId",
                table: "AppInvoices",
                column: "CcyRateSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_IncotermsId",
                table: "AppInvoices",
                column: "IncotermsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_InvoiceCompanyId",
                table: "AppInvoices",
                column: "InvoiceCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInvoices");
        }
    }
}
