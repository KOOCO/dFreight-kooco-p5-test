using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UPDATE_Hbl_DateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "APSurplus",
                table: "AppOceanExportHbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ARSurplus",
                table: "AppOceanExportHbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DCSurplus",
                table: "AppOceanExportHbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PolEtd",
                table: "AppOceanExportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PolId",
                table: "AppOceanExportHbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanExportHbls_PolId",
                table: "AppOceanExportHbls",
                column: "PolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_PolId",
                table: "AppOceanExportHbls",
                column: "PolId",
                principalTable: "AppPorts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_PolId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanExportHbls_PolId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropColumn(
                name: "APSurplus",
                table: "AppOceanExportHbls");

            migrationBuilder.DropColumn(
                name: "ARSurplus",
                table: "AppOceanExportHbls");

            migrationBuilder.DropColumn(
                name: "DCSurplus",
                table: "AppOceanExportHbls");

            migrationBuilder.DropColumn(
                name: "PolEtd",
                table: "AppOceanExportHbls");

            migrationBuilder.DropColumn(
                name: "PolId",
                table: "AppOceanExportHbls");
        }
    }
}
