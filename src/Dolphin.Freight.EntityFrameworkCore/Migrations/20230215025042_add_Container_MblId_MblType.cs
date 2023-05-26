using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class add_Container_MblId_MblType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForignId",
                table: "AppMemos",
                newName: "Fid");

            migrationBuilder.AddColumn<Guid>(
                name: "MblId",
                table: "AppContainers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MblType",
                table: "AppContainers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MblId",
                table: "AppContainers");

            migrationBuilder.DropColumn(
                name: "MblType",
                table: "AppContainers");

            migrationBuilder.RenameColumn(
                name: "Fid",
                table: "AppMemos",
                newName: "ForignId");
        }
    }
}
