using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Constellation",
                table: "AppContactPersons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactAge",
                table: "AppContactPersons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContactBirthday",
                table: "AppContactPersons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactCityCode",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactCountryId",
                table: "AppContactPersons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactDrink",
                table: "AppContactPersons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactGender",
                table: "AppContactPersons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactMarriage",
                table: "AppContactPersons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPostCode",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactSmokes",
                table: "AppContactPersons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactStateCode",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Garment",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hobby",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interest",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MemorialDay",
                table: "AppContactPersons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppContactPersonChilds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContactPersonChilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppContactPersonChilds_AppContactPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AppContactPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTradePartnerMemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradePartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Highlight = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTradePartnerMemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTradePartnerMemo_AppTradePartners_TradePartnerId",
                        column: x => x.TradePartnerId,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppContactPersonChilds_PersonId",
                table: "AppContactPersonChilds",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradePartnerMemo_TradePartnerId",
                table: "AppTradePartnerMemo",
                column: "TradePartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppContactPersonChilds");

            migrationBuilder.DropTable(
                name: "AppTradePartnerMemo");

            migrationBuilder.DropColumn(
                name: "Constellation",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactAge",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactBirthday",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactCityCode",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactCountryId",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactDrink",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactGender",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactMarriage",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactPostCode",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactSmokes",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactStateCode",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "Garment",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "Hobby",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "MemorialDay",
                table: "AppContactPersons");
        }
    }
}
