using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Deleted_Item_From_ContactPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAge",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactBirthday",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactDrink",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactGender",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactHomeAddress",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactMarriage",
                table: "AppContactPersons");

            migrationBuilder.DropColumn(
                name: "ContactSmoking",
                table: "AppContactPersons");

            migrationBuilder.AlterColumn<string>(
                name: "ContactRemark",
                table: "AppContactPersons",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactRemark",
                table: "AppContactPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactAge",
                table: "AppContactPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContactBirthday",
                table: "AppContactPersons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ContactDrink",
                table: "AppContactPersons",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactGender",
                table: "AppContactPersons",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactHomeAddress",
                table: "AppContactPersons",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactMarriage",
                table: "AppContactPersons",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactSmoking",
                table: "AppContactPersons",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);
        }
    }
}
