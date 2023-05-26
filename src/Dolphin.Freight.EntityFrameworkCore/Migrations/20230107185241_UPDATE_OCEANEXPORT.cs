using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UPDATE_OCEANEXPORT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppOceanExportMbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppOceanExportHbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomerRefNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "AppInvoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAmountConfirmed",
                table: "AppInvoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Memorandum",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OutstandingAmount",
                table: "AppInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PaidAmount",
                table: "AppInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PoNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfitShare",
                table: "AppInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipToId",
                table: "AppInvoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_ShipToId",
                table: "AppInvoices",
                column: "ShipToId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInvoices_AppTradePartners_ShipToId",
                table: "AppInvoices",
                column: "ShipToId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInvoices_AppTradePartners_ShipToId",
                table: "AppInvoices");

            migrationBuilder.DropIndex(
                name: "IX_AppInvoices_ShipToId",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppOceanExportHbls");

            migrationBuilder.DropColumn(
                name: "CustomerRefNo",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "IsAmountConfirmed",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "Memorandum",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "OutstandingAmount",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "PoNo",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "ProfitShare",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "ShipToId",
                table: "AppInvoices");
        }
    }
}
