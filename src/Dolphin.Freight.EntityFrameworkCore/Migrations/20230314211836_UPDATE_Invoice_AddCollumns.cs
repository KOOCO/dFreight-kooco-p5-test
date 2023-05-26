using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UPDATE_Invoice_AddCollumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilingNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HblNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblNo",
                table: "AppInvoices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilingNo",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "HblNo",
                table: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "MblNo",
                table: "AppInvoices");
        }
    }
}
