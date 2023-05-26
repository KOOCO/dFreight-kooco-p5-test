using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dolphin.Freight.Migrations
{
    public partial class UPDATE_ExportBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Voyage",
                table: "AppVesselSchedules",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CargoArrivalDate",
                table: "AppOceanExportHbls",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "BillToId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingRemark",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CancelById",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CargoArrivalDate",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CargoPickupId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CargoRemark",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CargoTypeId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierBkgNo",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarrierId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoLoaderId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsigneeId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContainerPickupNo",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContainerQtyInputText",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerRefNo",
                table: "AppExportBookings",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelEta",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DelId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryToId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DocCutOffTime",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocNo",
                table: "AppExportBookings",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EarlyReturnDatetime",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EctNo",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmptyPickupId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FbaId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FdestEta",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FdestId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForwardingAgentId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HblAgentId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HblNo",
                table: "AppExportBookings",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HblReleaseDate",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HoldReason",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HolderId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IncotermsId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "AppExportBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHold",
                table: "AppExportBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReleased",
                table: "AppExportBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStackable",
                table: "AppExportBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ItnNo",
                table: "AppExportBookings",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MblSaleId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotifyId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PodEta",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PodId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PolEtd",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PolId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PorEtd",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PorId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PortCutOffTime",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrnNo",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RailCutOffTime",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReferralById",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReleaseById",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalespersonId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipModeId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipperId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingAgentId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingRemark",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoNo",
                table: "AppExportBookings",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SoNoDate",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "SvcTermFromId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SvcTermToId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Trans1Eta",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "TransPort1Id",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TruckerId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VesselName",
                table: "AppExportBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VesselScheduleId",
                table: "AppExportBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VgmCutOffTime",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voyage",
                table: "AppExportBookings",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WhCutOffTime",
                table: "AppExportBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_BillToId",
                table: "AppExportBookings",
                column: "BillToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_CancelById",
                table: "AppExportBookings",
                column: "CancelById");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_CargoPickupId",
                table: "AppExportBookings",
                column: "CargoPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_CargoTypeId",
                table: "AppExportBookings",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_CarrierId",
                table: "AppExportBookings",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_CoLoaderId",
                table: "AppExportBookings",
                column: "CoLoaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ConsigneeId",
                table: "AppExportBookings",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_CustomerId",
                table: "AppExportBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_DelId",
                table: "AppExportBookings",
                column: "DelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_DeliveryToId",
                table: "AppExportBookings",
                column: "DeliveryToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_EmptyPickupId",
                table: "AppExportBookings",
                column: "EmptyPickupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_FbaId",
                table: "AppExportBookings",
                column: "FbaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_FdestId",
                table: "AppExportBookings",
                column: "FdestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ForwardingAgentId",
                table: "AppExportBookings",
                column: "ForwardingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_HblAgentId",
                table: "AppExportBookings",
                column: "HblAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_HolderId",
                table: "AppExportBookings",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_IncotermsId",
                table: "AppExportBookings",
                column: "IncotermsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_MblSaleId",
                table: "AppExportBookings",
                column: "MblSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_NotifyId",
                table: "AppExportBookings",
                column: "NotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_OfficeId",
                table: "AppExportBookings",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_PodId",
                table: "AppExportBookings",
                column: "PodId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_PolId",
                table: "AppExportBookings",
                column: "PolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_PorId",
                table: "AppExportBookings",
                column: "PorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ReferralById",
                table: "AppExportBookings",
                column: "ReferralById");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ReleaseById",
                table: "AppExportBookings",
                column: "ReleaseById");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ShipModeId",
                table: "AppExportBookings",
                column: "ShipModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ShipperId",
                table: "AppExportBookings",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_ShippingAgentId",
                table: "AppExportBookings",
                column: "ShippingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_SvcTermFromId",
                table: "AppExportBookings",
                column: "SvcTermFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_SvcTermToId",
                table: "AppExportBookings",
                column: "SvcTermToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_TransPort1Id",
                table: "AppExportBookings",
                column: "TransPort1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_TruckerId",
                table: "AppExportBookings",
                column: "TruckerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExportBookings_VesselScheduleId",
                table: "AppExportBookings",
                column: "VesselScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppPorts_DelId",
                table: "AppExportBookings",
                column: "DelId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppPorts_FdestId",
                table: "AppExportBookings",
                column: "FdestId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppPorts_PodId",
                table: "AppExportBookings",
                column: "PodId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppPorts_PolId",
                table: "AppExportBookings",
                column: "PolId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppPorts_PorId",
                table: "AppExportBookings",
                column: "PorId",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppPorts_TransPort1Id",
                table: "AppExportBookings",
                column: "TransPort1Id",
                principalTable: "AppPorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSubstations_OfficeId",
                table: "AppExportBookings",
                column: "OfficeId",
                principalTable: "AppSubstations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_CargoTypeId",
                table: "AppExportBookings",
                column: "CargoTypeId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_IncotermsId",
                table: "AppExportBookings",
                column: "IncotermsId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_ShipModeId",
                table: "AppExportBookings",
                column: "ShipModeId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_SvcTermFromId",
                table: "AppExportBookings",
                column: "SvcTermFromId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_SvcTermToId",
                table: "AppExportBookings",
                column: "SvcTermToId",
                principalTable: "AppSysCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_BillToId",
                table: "AppExportBookings",
                column: "BillToId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CargoPickupId",
                table: "AppExportBookings",
                column: "CargoPickupId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CarrierId",
                table: "AppExportBookings",
                column: "CarrierId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CoLoaderId",
                table: "AppExportBookings",
                column: "CoLoaderId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ConsigneeId",
                table: "AppExportBookings",
                column: "ConsigneeId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CustomerId",
                table: "AppExportBookings",
                column: "CustomerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_DeliveryToId",
                table: "AppExportBookings",
                column: "DeliveryToId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_EmptyPickupId",
                table: "AppExportBookings",
                column: "EmptyPickupId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_FbaId",
                table: "AppExportBookings",
                column: "FbaId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ForwardingAgentId",
                table: "AppExportBookings",
                column: "ForwardingAgentId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_HblAgentId",
                table: "AppExportBookings",
                column: "HblAgentId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_NotifyId",
                table: "AppExportBookings",
                column: "NotifyId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ReferralById",
                table: "AppExportBookings",
                column: "ReferralById",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ShipperId",
                table: "AppExportBookings",
                column: "ShipperId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ShippingAgentId",
                table: "AppExportBookings",
                column: "ShippingAgentId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_TruckerId",
                table: "AppExportBookings",
                column: "TruckerId",
                principalTable: "AppTradePartners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_AppVesselSchedules_VesselScheduleId",
                table: "AppExportBookings",
                column: "VesselScheduleId",
                principalTable: "AppVesselSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_UserData_CancelById",
                table: "AppExportBookings",
                column: "CancelById",
                principalTable: "UserData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_UserData_HolderId",
                table: "AppExportBookings",
                column: "HolderId",
                principalTable: "UserData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_UserData_MblSaleId",
                table: "AppExportBookings",
                column: "MblSaleId",
                principalTable: "UserData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExportBookings_UserData_ReleaseById",
                table: "AppExportBookings",
                column: "ReleaseById",
                principalTable: "UserData",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppPorts_DelId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppPorts_FdestId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppPorts_PodId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppPorts_PolId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppPorts_PorId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppPorts_TransPort1Id",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSubstations_OfficeId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_CargoTypeId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_IncotermsId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_ShipModeId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_SvcTermFromId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppSysCodes_SvcTermToId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_BillToId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CargoPickupId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CarrierId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CoLoaderId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ConsigneeId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_CustomerId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_DeliveryToId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_EmptyPickupId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_FbaId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ForwardingAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_HblAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_NotifyId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ReferralById",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ShipperId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_ShippingAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppTradePartners_TruckerId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_AppVesselSchedules_VesselScheduleId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_UserData_CancelById",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_UserData_HolderId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_UserData_MblSaleId",
                table: "AppExportBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_AppExportBookings_UserData_ReleaseById",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_BillToId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_CancelById",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_CargoPickupId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_CargoTypeId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_CarrierId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_CoLoaderId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ConsigneeId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_CustomerId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_DelId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_DeliveryToId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_EmptyPickupId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_FbaId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_FdestId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ForwardingAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_HblAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_HolderId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_IncotermsId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_MblSaleId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_NotifyId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_OfficeId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_PodId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_PolId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_PorId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ReferralById",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ReleaseById",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ShipModeId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ShipperId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_ShippingAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_SvcTermFromId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_SvcTermToId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_TransPort1Id",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_TruckerId",
                table: "AppExportBookings");

            migrationBuilder.DropIndex(
                name: "IX_AppExportBookings_VesselScheduleId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "BillToId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "BookingRemark",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CancelById",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CargoArrivalDate",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CargoPickupId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CargoRemark",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CargoTypeId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CarrierBkgNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CoLoaderId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ConsigneeId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ContainerPickupNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ContainerQtyInputText",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "CustomerRefNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "DelEta",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "DelId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "DeliveryToId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "DocCutOffTime",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "DocNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "EarlyReturnDatetime",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "EctNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "EmptyPickupId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "FbaId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "FdestEta",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "FdestId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ForwardingAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "HblAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "HblNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "HblReleaseDate",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "HoldReason",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "HolderId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "IncotermsId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "IsHold",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "IsReleased",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "IsStackable",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ItnNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "MblSaleId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "NotifyId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PodEta",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PodId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PolEtd",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PolId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PorEtd",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PorId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PortCutOffTime",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "PrnNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "RailCutOffTime",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ReferralById",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ReleaseById",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "SalespersonId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ShipModeId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ShipperId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ShippingAgentId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "ShippingRemark",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "SoNo",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "SoNoDate",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "SvcTermFromId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "SvcTermToId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "Trans1Eta",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "TransPort1Id",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "TruckerId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "VesselName",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "VesselScheduleId",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "VgmCutOffTime",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "Voyage",
                table: "AppExportBookings");

            migrationBuilder.DropColumn(
                name: "WhCutOffTime",
                table: "AppExportBookings");

            migrationBuilder.AlterColumn<string>(
                name: "Voyage",
                table: "AppVesselSchedules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CargoArrivalDate",
                table: "AppOceanExportHbls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
