using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_Invoice_cols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceAmount",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CsCode",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "AppInvoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GlCodeId",
                table: "AppInvoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceAmount",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceDescription",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "AppInvoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmountTwd",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCode",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_CustomerId",
                table: "AppInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_GlCodeId",
                table: "AppInvoices",
                column: "GlCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInvoices_AppGlCodes_GlCodeId",
                table: "AppInvoices",
                column: "GlCodeId",
                principalTable: "AppGlCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInvoices_AppTradePartners_CustomerId",
                table: "AppInvoices",
                column: "CustomerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInvoices_AppGlCodes_GlCodeId",
                table: "AppInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppInvoices_AppTradePartners_CustomerId",
                table: "AppInvoices");

            migrationBuilder.DropIndex(
                name: "IX_AppInvoices_CustomerId",
                table: "AppInvoices");

            migrationBuilder.DropIndex(
                name: "IX_AppInvoices_GlCodeId",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "BalanceAmount",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "BlNo",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "CsCode",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "DocNo",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "GlCodeId",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "InvoiceAmount",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "InvoiceDescription",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "PaymentAmountTwd",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "SalesCode",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppInvoices");
        }
    }
}
