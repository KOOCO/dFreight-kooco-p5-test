using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class Update_Memos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForignType",
                table: "AppMemos",
                newName: "Ftype");

            migrationBuilder.AddColumn<string>(
                name: "BlAcctCarrierContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CareOfContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoLoaderContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryToContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmptyPickupContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForwardingAgentContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblBillToContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblCarrierContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblConsigneeContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblCustomerContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblNotifyContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblOverseaAgentContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MblReferralByContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAgentContent",
                table: "AppOceanExportMbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMemo",
                table: "AppAttachments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlAcctCarrierContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "CareOfContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "CoLoaderContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "DeliveryToContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "EmptyPickupContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "ForwardingAgentContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblBillToContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblCarrierContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblConsigneeContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblCustomerContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblNotifyContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblOverseaAgentContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "MblReferralByContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "ShippingAgentContent",
                table: "AppOceanExportMbls");

            migrationBuilder.DropColumn(
                name: "IsMemo",
                table: "AppAttachments");

            migrationBuilder.RenameColumn(
                name: "Ftype",
                table: "AppMemos",
                newName: "ForignType");
        }
    }
}
