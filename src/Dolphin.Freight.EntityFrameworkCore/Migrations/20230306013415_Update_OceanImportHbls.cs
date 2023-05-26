using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_OceanImportHbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "APSurplus",
                table: "AppOceanImportHbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ARSurplus",
                table: "AppOceanImportHbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DCSurplus",
                table: "AppOceanImportHbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PoNo",
                table: "AppOceanImportHbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PolEtd",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PolId",
                table: "AppOceanImportHbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoNote",
                table: "AppOceanImportHbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurplusType",
                table: "AppOceanImportHbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_PolId",
                table: "AppOceanImportHbls",
                column: "PolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportHbls_AppPorts_PolId",
                table: "AppOceanImportHbls",
                column: "PolId",
                principalTable: "AppPorts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportHbls_AppPorts_PolId",
                table: "AppOceanImportHbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportHbls_PolId",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "APSurplus",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ARSurplus",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "DCSurplus",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "PoNo",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "PolEtd",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "PolId",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "SoNote",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "SurplusType",
                table: "AppOceanImportHbls");
        }
    }
}
