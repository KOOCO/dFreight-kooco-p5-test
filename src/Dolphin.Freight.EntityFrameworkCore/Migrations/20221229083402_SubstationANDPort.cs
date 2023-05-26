using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class SubstationANDPort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_Port_DelId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_Port_FdestId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_Port_PodId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_Port_PorId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Port_DelId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Port_FdestId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Port_PodId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Port_PolId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Port_PorId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Port_TransPort1Id",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_Substation_OfficeId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_Port_AppCountries_CountryId",
                table: "Port");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Substation",
                table: "Substation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Port",
                table: "Port");

            migrationBuilder.RenameTable(
                name: "Substation",
                newName: "AppSubstations");

            migrationBuilder.RenameTable(
                name: "Port",
                newName: "AppPorts");

            migrationBuilder.RenameIndex(
                name: "IX_Port_CountryId",
                table: "AppPorts",
                newName: "IX_AppPorts_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSubstations",
                table: "AppSubstations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPorts",
                table: "AppPorts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_DelId",
                table: "AppOceanExportHbls",
                column: "DelId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_FdestId",
                table: "AppOceanExportHbls",
                column: "FdestId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_PodId",
                table: "AppOceanExportHbls",
                column: "PodId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_PorId",
                table: "AppOceanExportHbls",
                column: "PorId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_DelId",
                table: "AppOceanExportMbls",
                column: "DelId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_FdestId",
                table: "AppOceanExportMbls",
                column: "FdestId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_PodId",
                table: "AppOceanExportMbls",
                column: "PodId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_PolId",
                table: "AppOceanExportMbls",
                column: "PolId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_PorId",
                table: "AppOceanExportMbls",
                column: "PorId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_TransPort1Id",
                table: "AppOceanExportMbls",
                column: "TransPort1Id",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_AppSubstations_OfficeId",
                table: "AppOceanExportMbls",
                column: "OfficeId",
                principalTable: "AppSubstations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPorts_AppCountries_CountryId",
                table: "AppPorts",
                column: "CountryId",
                principalTable: "AppCountries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_DelId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_FdestId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_PodId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportHbls_AppPorts_PorId",
                table: "AppOceanExportHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_DelId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_FdestId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_PodId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_PolId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_PorId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppPorts_TransPort1Id",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOceanExportMbls_AppSubstations_OfficeId",
                table: "AppOceanExportMbls");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPorts_AppCountries_CountryId",
                table: "AppPorts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSubstations",
                table: "AppSubstations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPorts",
                table: "AppPorts");

            migrationBuilder.RenameTable(
                name: "AppSubstations",
                newName: "Substation");

            migrationBuilder.RenameTable(
                name: "AppPorts",
                newName: "Port");

            migrationBuilder.RenameIndex(
                name: "IX_AppPorts_CountryId",
                table: "Port",
                newName: "IX_Port_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Substation",
                table: "Substation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Port",
                table: "Port",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_Port_DelId",
                table: "AppOceanExportHbls",
                column: "DelId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_Port_FdestId",
                table: "AppOceanExportHbls",
                column: "FdestId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_Port_PodId",
                table: "AppOceanExportHbls",
                column: "PodId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportHbls_Port_PorId",
                table: "AppOceanExportHbls",
                column: "PorId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Port_DelId",
                table: "AppOceanExportMbls",
                column: "DelId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Port_FdestId",
                table: "AppOceanExportMbls",
                column: "FdestId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Port_PodId",
                table: "AppOceanExportMbls",
                column: "PodId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Port_PolId",
                table: "AppOceanExportMbls",
                column: "PolId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Port_PorId",
                table: "AppOceanExportMbls",
                column: "PorId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Port_TransPort1Id",
                table: "AppOceanExportMbls",
                column: "TransPort1Id",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOceanExportMbls_Substation_OfficeId",
                table: "AppOceanExportMbls",
                column: "OfficeId",
                principalTable: "Substation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Port_AppCountries_CountryId",
                table: "Port",
                column: "CountryId",
                principalTable: "AppCountries",
                principalColumn: "Id");
        }
    }
}
