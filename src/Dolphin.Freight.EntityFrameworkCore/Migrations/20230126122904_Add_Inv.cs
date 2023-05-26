using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Add_Inv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GlCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    BalanceAmount = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    PaymentAmountTwd = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    InvoiceDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInv_AppCurrencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "AppCurrencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInv_AppGlCodes_GlCodeId",
                        column: x => x.GlCodeId,
                        principalTable: "AppGlCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInv_AppTradePartners_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInv_CurrencyId",
                table: "AppInv",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInv_CustomerId",
                table: "AppInv",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInv_GlCodeId",
                table: "AppInv",
                column: "GlCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInv");
        }
    }
}
