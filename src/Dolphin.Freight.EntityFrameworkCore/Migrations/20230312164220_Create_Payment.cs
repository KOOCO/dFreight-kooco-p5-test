using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Create_Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowPartyOnCheck = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invalid = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U2T = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R2T = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H2T = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPayment_AppSubstations_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "AppSubstations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppPayment_AppTradePartners_PaidTo",
                        column: x => x.PaidTo,
                        principalTable: "AppTradePartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPayment_OfficeId",
                table: "AppPayment",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPayment_PaidTo",
                table: "AppPayment",
                column: "PaidTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPayment");
        }
    }
}
