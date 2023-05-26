using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UPDATE_ExportBooking_Collum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppVesselSchedules_VesselScheduleId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_VesselScheduleId",
                table: "AppExportBookings");

            migrationBuilder.RenameColumn(
                name: "VesselScheduleId",
                table: "AppExportBookings",
                newName: "ReferenceId");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceType",
                table: "AppExportBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceType",
                table: "AppExportBookings");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "AppExportBookings",
                newName: "VesselScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_VesselScheduleId",
                table: "AppExportBookings",
                column: "VesselScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppVesselSchedules_VesselScheduleId",
                table: "AppExportBookings",
                column: "VesselScheduleId",
                principalTable: "AppVesselSchedules",
                principalColumn: "Id");
        }
    }
}
