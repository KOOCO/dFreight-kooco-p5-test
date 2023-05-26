using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_PackageUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPackageUnits_AppAwbNoRanges_AwbNoRangeId",
                table: "AppPackageUnits");

            migrationBuilder.RenameColumn(
                name: "AwbNoRangeId",
                table: "AppPackageUnits",
                newName: "AmsNoId");

            migrationBuilder.RenameIndex(
                name: "IX_AppPackageUnits_AwbNoRangeId",
                table: "AppPackageUnits",
                newName: "IX_AppPackageUnits_AmsNoId");

            migrationBuilder.AddColumn<Guid>(
                name: "CareOfId",
                table: "AppOceanExportMbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsedCareOf",
                table: "AppOceanExportMbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportMbls_CareOfId",
                table: "AppOceanExportMbls",
                column: "CareOfId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppTradePartners_CareOfId",
                table: "AppOceanExportMbls",
                column: "CareOfId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPackageUnits_AppSysCodes_AmsNoId",
                table: "AppPackageUnits",
                column: "AmsNoId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppTradePartners_CareOfId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPackageUnits_AppSysCodes_AmsNoId",
                table: "AppPackageUnits");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanExportMbls_CareOfId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "CareOfId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "IsUsedCareOf",
                table: "AppOceanExportMbls");

            migrationBuilder.RenameColumn(
                name: "AmsNoId",
                table: "AppPackageUnits",
                newName: "AwbNoRangeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppPackageUnits_AmsNoId",
                table: "AppPackageUnits",
                newName: "IX_AppPackageUnits_AwbNoRangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPackageUnits_AppAwbNoRanges_AwbNoRangeId",
                table: "AppPackageUnits",
                column: "AwbNoRangeId",
                principalTable: "AppAwbNoRanges",
                principalColumn: "Id");
        }
    }
}
