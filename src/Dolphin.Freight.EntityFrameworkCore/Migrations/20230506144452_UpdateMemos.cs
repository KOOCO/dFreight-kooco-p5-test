using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UpdateMemos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTradeParties_AppTradePartners_TargetTradePartnerId",
                table: "AppTradeParties");

            migrationBuilder.DropIndex(
                name: "IX_AppTradeParties_TargetTradePartnerId",
                table: "AppTradeParties");

            migrationBuilder.RenameColumn(
                name: "Ftype",
                table: "AppMemos",
                newName: "FType");

            migrationBuilder.RenameColumn(
                name: "Fid",
                table: "AppMemos",
                newName: "SourceId");

            migrationBuilder.AddColumn<bool>(
                name: "Highlight",
                table: "AppMemos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Highlight",
                table: "AppMemos");

            migrationBuilder.RenameColumn(
                name: "FType",
                table: "AppMemos",
                newName: "Ftype");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "AppMemos",
                newName: "Fid");

            migrationBuilder.CreateIndex(
                name: "IX_AppTradeParties_TargetTradePartnerId",
                table: "AppTradeParties",
                column: "TargetTradePartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTradeParties_AppTradePartners_TargetTradePartnerId",
                table: "AppTradeParties",
                column: "TargetTradePartnerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");
        }
    }
}
