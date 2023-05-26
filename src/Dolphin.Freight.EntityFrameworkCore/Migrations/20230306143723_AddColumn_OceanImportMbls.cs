using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AddColumn_OceanImportMbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReturnLocationId",
                table: "AppOceanImportMbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_ReturnLocationId",
                table: "AppOceanImportMbls",
                column: "ReturnLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_ReturnLocationId",
                table: "AppOceanImportMbls",
                column: "ReturnLocationId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_ReturnLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportMbls_ReturnLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "ReturnLocationId",
                table: "AppOceanImportMbls");
        }
    }
}
