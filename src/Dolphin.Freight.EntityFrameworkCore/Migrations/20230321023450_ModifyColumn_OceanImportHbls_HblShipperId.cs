using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class ModifyColumn_OceanImportHbls_HblShipperId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportHbls_AppSysCodes_MblSalesTypeId",
                table: "AppOceanImportHbls");

            migrationBuilder.RenameColumn(
                name: "MblSalesTypeId",
                table: "AppOceanImportHbls",
                newName: "HblSalesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppOceanImportHbls_MblSalesTypeId",
                table: "AppOceanImportHbls",
                newName: "IX_AppOceanImportHbls_HblSalesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportHbls_AppSysCodes_HblSalesTypeId",
                table: "AppOceanImportHbls",
                column: "HblSalesTypeId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanImportHbls_AppSysCodes_HblSalesTypeId",
                table: "AppOceanImportHbls");

            migrationBuilder.RenameColumn(
                name: "HblSalesTypeId",
                table: "AppOceanImportHbls",
                newName: "MblSalesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppOceanImportHbls_HblSalesTypeId",
                table: "AppOceanImportHbls",
                newName: "IX_AppOceanImportHbls_MblSalesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanImportHbls_AppSysCodes_MblSalesTypeId",
                table: "AppOceanImportHbls",
                column: "MblSalesTypeId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");
        }
    }
}
