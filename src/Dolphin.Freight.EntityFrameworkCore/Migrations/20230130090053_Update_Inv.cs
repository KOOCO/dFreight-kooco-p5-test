using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_Inv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInv_AppCurrencies_CurrencyId",
                table: "AppInv");

            migrationBuilder.DropIndex(
                name: "IX_AppInv_CurrencyId",
                table: "AppInv");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "AppInv");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "AppInv",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "AppInv");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "AppInv",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppInv_CurrencyId",
                table: "AppInv",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInv_AppCurrencies_CurrencyId",
                table: "AppInv",
                column: "CurrencyId",
                principalTable: "AppCurrencies",
                principalColumn: "Id");
        }
    }
}
