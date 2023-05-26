using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Created_ContactPerson_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppContactPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRep = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailNotification = table.Column<bool>(type: "bit", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ContactTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContactDivision = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContactCellPhone = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ContactFax = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ContactEmailAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ContactRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactGender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ContactMarriage = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ContactSmoking = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ContactDrink = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ContactAge = table.Column<int>(type: "int", nullable: false),
                    ContactBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactHomeAddress = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContactPersons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppContactPersons");
        }
    }
}
