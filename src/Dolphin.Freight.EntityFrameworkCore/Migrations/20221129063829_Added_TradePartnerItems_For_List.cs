using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Added_TradePartnerItems_For_List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppAccountGroups");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppAccountGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppAccountGroups");

            migrationBuilder.AddColumn<string>(
                name: "AccountAddress",
                table: "AppTradePartners",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "AppTradePartners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmsCode",
                table: "AppTradePartners",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IataCode",
                table: "AppTradePartners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScacCode",
                table: "AppTradePartners",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TPNameLocal",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TPPrintAddress",
                table: "AppTradePartners",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "AppTradePartners",
                type: "nvarchar(72)",
                maxLength: 72,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrackPayment",
                table: "AppTradePartners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "AccountGroupName",
                table: "AppAccountGroups",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(384)",
                oldMaxLength: 384,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountAddress",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "FirmsCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "IataCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "ScacCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "TPNameLocal",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "TPPrintAddress",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "TrackPayment",
                table: "AppTradePartners");

            migrationBuilder.AlterColumn<string>(
                name: "AccountGroupName",
                table: "AppAccountGroups",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(384)",
                oldMaxLength: 384);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppAccountGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppAccountGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppAccountGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
