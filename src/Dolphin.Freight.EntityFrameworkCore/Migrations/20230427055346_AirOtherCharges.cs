using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class AirOtherCharges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAirOtherCharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    showOnMAWB = table.Column<bool>(type: "bit", nullable: false),
                    showOnHAWB = table.Column<bool>(type: "bit", nullable: false),
                    chargeItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chargeItemSubitem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chargeRate = table.Column<int>(type: "int", nullable: false),
                    chargeRateUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppAirOtherCharges", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAirOtherCharges");
        }
    }
}
