using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AddColumn_OceanImportMbls_OceanImportHbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentRefNo",
                table: "AppOceanImportMbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessReferrerId",
                table: "AppOceanImportMbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CfsLocationId",
                table: "AppOceanImportMbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CyLocationId",
                table: "AppOceanImportMbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Etb",
                table: "AppOceanImportMbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOblReceived",
                table: "AppOceanImportMbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ItDate",
                table: "AppOceanImportMbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItLocation",
                table: "AppOceanImportMbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItNo",
                table: "AppOceanImportMbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LatestContainerEntryDate",
                table: "AppOceanImportMbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OblReceivedDate",
                table: "AppOceanImportMbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmsNo",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessReferrerId",
                table: "AppOceanImportHbls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomsDeclarationNo",
                table: "AppOceanImportHbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomsDeclarationSendDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Demurrage",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupComm",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAn",
                table: "AppOceanImportHbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDo",
                table: "AppOceanImportHbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOblReceived",
                table: "AppOceanImportHbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPor",
                table: "AppOceanImportHbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsfByThirdParty",
                table: "AppOceanImportHbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsfDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsfNo",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ItDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItLocation",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItNo",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineCode",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAccount",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OblReceivedDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RaiseDate",
                table: "AppOceanImportHbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScNo",
                table: "AppOceanImportHbls",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_BusinessReferrerId",
                table: "AppOceanImportMbls",
                column: "BusinessReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_CfsLocationId",
                table: "AppOceanImportMbls",
                column: "CfsLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportMbls_CyLocationId",
                table: "AppOceanImportMbls",
                column: "CyLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOceanImportHbls_BusinessReferrerId",
                table: "AppOceanImportHbls",
                column: "BusinessReferrerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportHbls_AppTradePartners_BusinessReferrerId",
                table: "AppOceanImportHbls",
                column: "BusinessReferrerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_BusinessReferrerId",
                table: "AppOceanImportMbls",
                column: "BusinessReferrerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_CfsLocationId",
                table: "AppOceanImportMbls",
                column: "CfsLocationId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_CyLocationId",
                table: "AppOceanImportMbls",
                column: "CyLocationId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportHbls_AppTradePartners_BusinessReferrerId",
                table: "AppOceanImportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_BusinessReferrerId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_CfsLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportMbls_AppTradePartners_CyLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportMbls_BusinessReferrerId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportMbls_CfsLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportMbls_CyLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropIndex(
                name: "IX_AppOceanImportHbls_BusinessReferrerId",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "AgentRefNo",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "BusinessReferrerId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "CfsLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "CyLocationId",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "Etb",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "IsOblReceived",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "ItDate",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "ItLocation",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "ItNo",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "LatestContainerEntryDate",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "OblReceivedDate",
                table: "AppOceanImportMbls");

            migrationBuilder.DropColumn(
                name: "AmsNo",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "AnDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "BusinessReferrerId",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "CustomsDeclarationNo",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "CustomsDeclarationSendDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "DeliveredDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "Demurrage",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "DoDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ExitDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "GroupComm",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsAn",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsDo",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsOblReceived",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsPor",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsfByThirdParty",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsfDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "IsfNo",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ItDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ItLocation",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ItNo",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "LineCode",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "NameAccount",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "OblReceivedDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "RaiseDate",
                table: "AppOceanImportHbls");

            migrationBuilder.DropColumn(
                name: "ScNo",
                table: "AppOceanImportHbls");
        }
    }
}
