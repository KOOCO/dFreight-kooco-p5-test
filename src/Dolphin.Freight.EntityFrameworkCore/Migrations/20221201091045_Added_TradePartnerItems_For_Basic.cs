using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Added_TradePartnerItems_For_Basic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScacCode",
                table: "AppTradePartners",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountCurrencyCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountCurrencyCode2",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountCurrencyCode3",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "AppTradePartners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNo2",
                table: "AppTradePartners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNo3",
                table: "AppTradePartners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName2",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName3",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillToAgentCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BussinessStatusType",
                table: "AppTradePartners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CbsaCode",
                table: "AppTradePartners",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ceo",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Clm",
                table: "AppTradePartners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CorpNo",
                table: "AppTradePartners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CsCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DutyPaymentType",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "AppTradePartners",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IataPrefix",
                table: "AppTradePartners",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImporterCodeType",
                table: "AppTradePartners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImporterNo",
                table: "AppTradePartners",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AppTradePartners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsfSubmissionName",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenHours",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PopUpTips",
                table: "AppTradePartners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "AppTradePartners",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeAe",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeAi",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeCuAe",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeCuAi",
                table: "AppTradePartners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeCuOe",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeCuOi",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeOe",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesCodeOi",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOfficeCode",
                table: "AppTradePartners",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TPLocalAddress",
                table: "AppTradePartners",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TPNamePrint",
                table: "AppTradePartners",
                type: "nvarchar(384)",
                maxLength: 384,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "AppTradePartners",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AppTradePartners",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountCurrencyCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "AccountCurrencyCode2",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "AccountCurrencyCode3",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "AccountNo2",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "AccountNo3",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "BankName2",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "BankName3",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "BillToAgentCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "BussinessStatusType",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CbsaCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "Ceo",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "Clm",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CorpNo",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "CsCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "DutyPaymentType",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "IataPrefix",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "ImporterCodeType",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "ImporterNo",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "IsfSubmissionName",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "OpenHours",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "PopUpTips",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeAe",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeAi",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeCuAe",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeCuAi",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeCuOe",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeCuOi",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeOe",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesCodeOi",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "SalesOfficeCode",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "TPLocalAddress",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "TPNamePrint",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "AppTradePartners");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AppTradePartners");

            migrationBuilder.AlterColumn<string>(
                name: "ScacCode",
                table: "AppTradePartners",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
