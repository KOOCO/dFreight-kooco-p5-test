using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Add_ExportBooking_Collum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PolEtd",
                table: "AppVesselSchedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PodEta",
                table: "AppVesselSchedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PolEtd",
                table: "AppOceanExportMbls",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PodEta",
                table: "AppOceanExportMbls",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "FreightTermForBuyerId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FreightTermForSalerId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_FreightTermForBuyerId",
                table: "AppExportBookings",
                column: "FreightTermForBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_FreightTermForSalerId",
                table: "AppExportBookings",
                column: "FreightTermForSalerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_FreightTermForBuyerId",
                table: "AppExportBookings",
                column: "FreightTermForBuyerId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_FreightTermForSalerId",
                table: "AppExportBookings",
                column: "FreightTermForSalerId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_FreightTermForBuyerId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_FreightTermForSalerId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_FreightTermForBuyerId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_FreightTermForSalerId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "FreightTermForBuyerId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "FreightTermForSalerId",
                table: "AppExportBookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PolEtd",
                table: "AppVesselSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PodEta",
                table: "AppVesselSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PolEtd",
                table: "AppOceanExportMbls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PodEta",
                table: "AppOceanExportMbls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
