using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UpdateTradeParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TargetTradePartnerId",
                table: "AppTradeParties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppTradeParties_TargetTradePartnerId",
                table: "AppTradeParties",
                column: "TargetTradePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradeParties_TradePartnerId",
                table: "AppTradeParties",
                column: "TradePartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTradeParties_AppTradePartners_TargetTradePartnerId",
                table: "AppTradeParties",
                column: "TargetTradePartnerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTradeParties_AppTradePartners_TradePartnerId",
                table: "AppTradeParties",
                column: "TradePartnerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTradeParties_AppTradePartners_TargetTradePartnerId",
                table: "AppTradeParties");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTradeParties_AppTradePartners_TradePartnerId",
                table: "AppTradeParties");

            migrationBuilder.DropIndex(
                name: "IX_AppTradeParties_TargetTradePartnerId",
                table: "AppTradeParties");

            migrationBuilder.DropIndex(
                name: "IX_AppTradeParties_TradePartnerId",
                table: "AppTradeParties");

            migrationBuilder.DropColumn(
                name: "TargetTradePartnerId",
                table: "AppTradeParties");
        }
    }
}
