using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_CustomerPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ReceivablesSources",
                table: "AppCustomerPayment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomerPayment_ReceivablesSources",
                table: "AppCustomerPayment",
                column: "ReceivablesSources");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomerPayment_AppTradePartners_ReceivablesSources",
                table: "AppCustomerPayment",
                column: "ReceivablesSources",
                principalTable: "AppTradePartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomerPayment_AppTradePartners_ReceivablesSources",
                table: "AppCustomerPayment");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomerPayment_ReceivablesSources",
                table: "AppCustomerPayment");

            migrationBuilder.AlterColumn<string>(
                name: "ReceivablesSources",
                table: "AppCustomerPayment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
