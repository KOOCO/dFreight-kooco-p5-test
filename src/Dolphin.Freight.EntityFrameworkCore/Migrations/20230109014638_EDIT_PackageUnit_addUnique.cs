using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class EDIT_PackageUnit_addUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppPackageUnits_PackageCode",
                table: "AppPackageUnits",
                column: "PackageCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppPackageUnits_PackageCode",
                table: "AppPackageUnits");
        }
    }
}
