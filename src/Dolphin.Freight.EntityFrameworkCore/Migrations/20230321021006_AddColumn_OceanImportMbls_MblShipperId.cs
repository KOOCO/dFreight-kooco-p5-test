using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AddColumn_OceanImportMbls_MblShipperId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MblShipperId",
                table: "AppOceanImportMbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_MblShipperId",
                table: "AppOceanImportMbls",
                column: "MblShipperId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_MblShipperId",
                table: "AppOceanImportMbls",
                column: "MblShipperId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_MblShipperId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportMbls_MblShipperId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "MblShipperId",
                table: "AppOceanImportMbls");
        }
    }
}
