using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UpdateContactPersonColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemorialDay",
                table: "AppContactPersons",
                newName: "ContactMemorialDay");

            migrationBuilder.RenameColumn(
                name: "Interest",
                table: "AppContactPersons",
                newName: "ContactInterest");

            migrationBuilder.RenameColumn(
                name: "Hobby",
                table: "AppContactPersons",
                newName: "ContactHobby");

            migrationBuilder.RenameColumn(
                name: "Garment",
                table: "AppContactPersons",
                newName: "ContactGarment");

            migrationBuilder.RenameColumn(
                name: "Constellation",
                table: "AppContactPersons",
                newName: "ContactConstellation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactMemorialDay",
                table: "AppContactPersons",
                newName: "MemorialDay");

            migrationBuilder.RenameColumn(
                name: "ContactInterest",
                table: "AppContactPersons",
                newName: "Interest");

            migrationBuilder.RenameColumn(
                name: "ContactHobby",
                table: "AppContactPersons",
                newName: "Hobby");

            migrationBuilder.RenameColumn(
                name: "ContactGarment",
                table: "AppContactPersons",
                newName: "Garment");

            migrationBuilder.RenameColumn(
                name: "ContactConstellation",
                table: "AppContactPersons",
                newName: "Constellation");
        }
    }
}
