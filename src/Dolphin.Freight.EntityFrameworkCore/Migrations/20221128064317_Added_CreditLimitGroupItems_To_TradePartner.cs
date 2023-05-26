using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Added_CreditLimitGroupItems_To_TradePartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditLimit",
                table: "AppTradePartners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditTermDays",
                table: "AppTradePartners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditTermType",
                table: "AppTradePartners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "AppTradePartners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CreditTermDays",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CreditTermType",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "AppTradePartners");
        }
    }
}
