using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_CustomerPayment_Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomerPayment_AppTradePartners_ReceivablesSources",
                table: "AppCustomerPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPayment_AppTradePartners_PaidTo",
                table: "AppPayment");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaidTo",
                table: "AppPayment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmountTwd",
                table: "AppInvoices",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "AppInvoices",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceAmount",
                table: "AppInvoices",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceAmount",
                table: "AppInvoices",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceivablesSources",
                table: "AppCustomerPayment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomerPayment_AppTradePartners_ReceivablesSources",
                table: "AppCustomerPayment",
                column: "ReceivablesSources",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPayment_AppTradePartners_PaidTo",
                table: "AppPayment",
                column: "PaidTo",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomerPayment_AppTradePartners_ReceivablesSources",
                table: "AppCustomerPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPayment_AppTradePartners_PaidTo",
                table: "AppPayment");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaidTo",
                table: "AppPayment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmountTwd",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceAmount",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceAmount",
                table: "AppInvoices",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceivablesSources",
                table: "AppCustomerPayment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomerPayment_AppTradePartners_ReceivablesSources",
                table: "AppCustomerPayment",
                column: "ReceivablesSources",
                principalTable: "AppTradePartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPayment_AppTradePartners_PaidTo",
                table: "AppPayment",
                column: "PaidTo",
                principalTable: "AppTradePartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
