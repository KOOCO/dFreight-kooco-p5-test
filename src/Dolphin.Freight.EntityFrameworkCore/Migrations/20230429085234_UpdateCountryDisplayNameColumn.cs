using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UpdateCountryDisplayNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipLine",
                table: "AppCountryDisplayName");

            migrationBuilder.AddColumn<Guid>(
                name: "AirportId",
                table: "AppCountryDisplayName",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCountryDisplayName_AirportId",
                table: "AppCountryDisplayName",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCountryDisplayName_AppAirports_AirportId",
                table: "AppCountryDisplayName",
                column: "AirportId",
                principalTable: "AppAirports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCountryDisplayName_AppAirports_AirportId",
                table: "AppCountryDisplayName");

            migrationBuilder.DropIndex(
                name: "IX_AppCountryDisplayName_AirportId",
                table: "AppCountryDisplayName");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "AppCountryDisplayName");

            migrationBuilder.AddColumn<string>(
                name: "ShipLine",
                table: "AppCountryDisplayName",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
