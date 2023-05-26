using Dolphin.Freight.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dolphin.Freight.Permissions;

public class FreightPermissionDefinitionProvider : PermissionDefinitionProvider
{
    /// <summary>
    /// 權限設定
    /// </summary>
    /// <param name="context"></param>
    public override void Define(IPermissionDefinitionContext context)
    {
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FreightPermissions.MyPermission1, L("Permission:MyPermission1"));

        #region 設置
        var settingsGroup = context.AddGroup(SettingsPermissions.GroupName, L("Permission:Settings"));
        //IT號碼管理
        var itNoRangesPermission = settingsGroup.AddPermission(SettingsPermissions.ItNoRanges.Default, L("Permission:ItNoRanges"));
        itNoRangesPermission.AddChild(SettingsPermissions.ItNoRanges.Create, L("Create"));
        itNoRangesPermission.AddChild(SettingsPermissions.ItNoRanges.Edit, L("Edit"));
        itNoRangesPermission.AddChild(SettingsPermissions.ItNoRanges.Delete, L("Delete"));
        //AWB號碼管理
        var awbNoRangesPermission = settingsGroup.AddPermission(SettingsPermissions.AwbNoRanges.Default, L("Permission:AwbNoRanges"));
        awbNoRangesPermission.AddChild(SettingsPermissions.AwbNoRanges.Create, L("Create"));
        awbNoRangesPermission.AddChild(SettingsPermissions.AwbNoRanges.Edit, L("Edit"));
        awbNoRangesPermission.AddChild(SettingsPermissions.AwbNoRanges.Delete, L("Delete"));
        //包裝管理
        var PackageUnitsPermission = settingsGroup.AddPermission(SettingsPermissions.PackageUnits.Default, L("Permission:PackageUnits"));
        PackageUnitsPermission.AddChild(SettingsPermissions.PackageUnits.Create, L("Create"));
        PackageUnitsPermission.AddChild(SettingsPermissions.PackageUnits.Edit, L("Edit"));
        PackageUnitsPermission.AddChild(SettingsPermissions.PackageUnits.Delete, L("Delete"));
        //集裝箱管理
        var ContainerSizesPermission = settingsGroup.AddPermission(SettingsPermissions.ContainerSizes.Default, L("Permission:ContainerSizes"));
        ContainerSizesPermission.AddChild(SettingsPermissions.ContainerSizes.Create, L("Create"));
        ContainerSizesPermission.AddChild(SettingsPermissions.ContainerSizes.Edit, L("Edit"));
        ContainerSizesPermission.AddChild(SettingsPermissions.ContainerSizes.Delete, L("Delete"));
        //空運出口其他費用
        var airOtherChargePermission = settingsGroup.AddPermission(SettingsPermissions.AirOtherCharge.Default, L("Permission:AirOtherCharge"));
        airOtherChargePermission.AddChild(SettingsPermissions.AirOtherCharge.Create, L("Create"));
        airOtherChargePermission.AddChild(SettingsPermissions.AirOtherCharge.Edit, L("Edit"));
        airOtherChargePermission.AddChild(SettingsPermissions.AirOtherCharge.Delete, L("Delete"));

        //港口管理
        var portsManagement = settingsGroup.AddPermission(SettingsPermissions.PortsManagement.Default, L("Permission:PortsManagement"));
        portsManagement.AddChild(SettingsPermissions.PortsManagement.Create, L("Create"));
        portsManagement.AddChild(SettingsPermissions.PortsManagement.Edit, L("Edit"));
        portsManagement.AddChild(SettingsPermissions.PortsManagement.Delete, L("Delete"));        

		//貨幣表
        var currencySettingPermission = settingsGroup.AddPermission(SettingsPermissions.CurrencySetting.Default, L("Permission:CurrencySetting"));
        currencySettingPermission.AddChild(SettingsPermissions.CurrencySetting.Create, L("Create"));
        currencySettingPermission.AddChild(SettingsPermissions.CurrencySetting.Edit, L("Edit"));
        currencySettingPermission.AddChild(SettingsPermissions.CurrencySetting.Delete, L("Delete"));

		//顯示設定
        var DisplaySettingPermission = settingsGroup.AddPermission(SettingsPermissions.DisplaySetting.Default, L("Permission:DisplaySetting"));
        DisplaySettingPermission.AddChild(SettingsPermissions.DisplaySetting.Create, L("Create"));
        DisplaySettingPermission.AddChild(SettingsPermissions.DisplaySetting.Edit, L("Edit"));
        DisplaySettingPermission.AddChild(SettingsPermissions.DisplaySetting.Delete, L("Delete"));		

        //國家管理
        var countryDisplayNamePermission = settingsGroup.AddPermission(SettingsPermissions.CountryDisplayName.Default, L("Permission:CountryDisplayName"));
        countryDisplayNamePermission.AddChild(SettingsPermissions.CountryDisplayName.Create, L("Create"));
        countryDisplayNamePermission.AddChild(SettingsPermissions.CountryDisplayName.Edit, L("Edit"));
        countryDisplayNamePermission.AddChild(SettingsPermissions.CountryDisplayName.Delete, L("Delete"));
        //User Management
        var userPermission = settingsGroup.AddPermission(SettingsPermissions.Users.Default, L("Permission:User"));
        userPermission.AddChild(SettingsPermissions.Users.Create, L("Create"));
        userPermission.AddChild(SettingsPermissions.Users.Edit, L("Edit"));
        userPermission.AddChild(SettingsPermissions.Users.Delete, L("Delete"));
        #endregion

        #region OceanExport
        var OceanExportGroup = context.AddGroup(OceanExportPermissions.GroupName, L("Permission:OceanExport"));
        //BillingCodes
        var oceanExportPermission = OceanExportGroup.AddPermission(OceanExportPermissions.OceanExportMbls.Default, L("Permission:OceanExportMbls"));
        oceanExportPermission.AddChild(OceanExportPermissions.OceanExportMbls.Create, L("Create"));
        oceanExportPermission.AddChild(OceanExportPermissions.OceanExportMbls.Edit, L("Edit"));
        oceanExportPermission.AddChild(OceanExportPermissions.OceanExportMbls.Delete, L("Delete"));
        var vesselScheduleaPermission = OceanExportGroup.AddPermission(OceanExportPermissions.VesselSchedules.Default, L("Permission:VesselSchedules"));
        vesselScheduleaPermission.AddChild(OceanExportPermissions.VesselSchedules.Create, L("Create"));
        vesselScheduleaPermission.AddChild(OceanExportPermissions.VesselSchedules.Edit, L("Edit"));
        vesselScheduleaPermission.AddChild(OceanExportPermissions.VesselSchedules.Delete, L("Delete"));
        var exportBookingPermission = OceanExportGroup.AddPermission(OceanExportPermissions.ExportBookings.Default, L("Permission:ExportBookings"));
        exportBookingPermission.AddChild(OceanExportPermissions.ExportBookings.Create, L("Create"));
        exportBookingPermission.AddChild(OceanExportPermissions.ExportBookings.Edit, L("Edit"));
        exportBookingPermission.AddChild(OceanExportPermissions.ExportBookings.Delete, L("Delete"));
        #endregion
        #region AccountingSetting
        var AccountingSettingGroup = context.AddGroup(AccountingSettingPermissions.GroupName, L("Permission:AccountingSetting"));


        #endregion

        #region OceanImport
        var OceanImportGroup = context.AddGroup(OceanImportPermissions.GroupName, L("Permission:OceanImport"));
        var oceanImportPermission = OceanImportGroup.AddPermission(OceanImportPermissions.OceanImportMbls.Default, L("Permission:OceanImportMbls"));
        oceanImportPermission.AddChild(OceanImportPermissions.OceanImportMbls.Create, L("Create"));
        oceanImportPermission.AddChild(OceanImportPermissions.OceanImportMbls.Edit, L("Edit"));
        oceanImportPermission.AddChild(OceanImportPermissions.OceanImportMbls.Delete, L("Delete"));
        #endregion

        #region Report
        var ReportGroup = context.AddGroup(ReportsPermissions.GroupName, L("Permission:Reports"));
        var reportPermission = ReportGroup.AddPermission(ReportsPermissions.VolumeProfitReport.Default, L("Permission:Reports"));
        reportPermission.AddChild(ReportsPermissions.VolumeProfitReport.Create, L("Create"));
        reportPermission.AddChild(ReportsPermissions.VolumeProfitReport.Edit, L("Edit"));
        reportPermission.AddChild(ReportsPermissions.VolumeProfitReport.Delete, L("Delete"));
        #endregion

        #region 運價中心
        var freightCenterImportGroup = context.AddGroup(FreightCenterPermissions.GroupName, L("Permission:FreightCenter"));

        // 運價成本查詢
        var freightCenterPermissions = freightCenterImportGroup.AddPermission(FreightCenterPermissions.ContractCostQuery.Default, L("Permission:FreightCenterContractCostQuery"));
        freightCenterPermissions.AddChild(FreightCenterPermissions.ContractCostQuery.Create, L("Create"));
        freightCenterPermissions.AddChild(FreightCenterPermissions.ContractCostQuery.Edit, L("Edit"));
        freightCenterPermissions.AddChild(FreightCenterPermissions.ContractCostQuery.Delete, L("Delete"));

        // 運價成本列表
        #endregion

        #region 會計
        var accountingGroup = context.AddGroup(AccountingPermissions.GroupName, L("Permission:Accounting"));

        //收入支出
        var InvoicePermissions = accountingGroup.AddPermission(AccountingPermissions.Invoice.Default, L("Permission:Invoice"));
        InvoicePermissions.AddChild(AccountingPermissions.Invoice.GARCreate, L("GARCreate"));
        InvoicePermissions.AddChild(AccountingPermissions.Invoice.GAPCreate, L("GAPCreate"));
        InvoicePermissions.AddChild(AccountingPermissions.Invoice.Edit, L("Edit"));
        InvoicePermissions.AddChild(AccountingPermissions.Invoice.Delete, L("Delete"));
        InvoicePermissions.AddChild(AccountingPermissions.Invoice.GAList, L("GAList"));

        //收付款-收款
        var accountingCustomerPaymentPermissions = accountingGroup.AddPermission(AccountingPermissions.CustomerPayment.Default, L("Permission:CustomerPayment"));
        accountingCustomerPaymentPermissions.AddChild(AccountingPermissions.CustomerPayment.Create, L("Create"));
        accountingCustomerPaymentPermissions.AddChild(AccountingPermissions.CustomerPayment.Edit, L("Edit"));
        accountingCustomerPaymentPermissions.AddChild(AccountingPermissions.CustomerPayment.Delete, L("Delete"));

        //收付款-收款清單
        var accountingCustomerPermissions = accountingGroup.AddPermission(AccountingPermissions.Customer.Default, L("Permission:Customer"));
        accountingCustomerPermissions.AddChild(AccountingPermissions.Customer.Create, L("Create"));
        accountingCustomerPermissions.AddChild(AccountingPermissions.Customer.Edit, L("Edit"));
        accountingCustomerPermissions.AddChild(AccountingPermissions.Customer.Delete, L("Delete"));

        //收付款-付款
        var accountingPaymentPermissions = accountingGroup.AddPermission(AccountingPermissions.Payment.Default, L("Permission:Payment"));
        accountingPaymentPermissions.AddChild(AccountingPermissions.Payment.Create, L("Create"));
        accountingPaymentPermissions.AddChild(AccountingPermissions.Payment.Edit, L("Edit"));
        accountingPaymentPermissions.AddChild(AccountingPermissions.Payment.Delete, L("Delete"));

        //收付款-付款清單
        var accountingPaymentMadeListPermissions = accountingGroup.AddPermission(AccountingPermissions.PaymentMadeList.Default, L("Permission:PaymentMadeList"));
        accountingPaymentMadeListPermissions.AddChild(AccountingPermissions.PaymentMadeList.Create, L("Create"));
        accountingPaymentMadeListPermissions.AddChild(AccountingPermissions.PaymentMadeList.Edit, L("Edit"));
        accountingPaymentMadeListPermissions.AddChild(AccountingPermissions.PaymentMadeList.Delete, L("Delete"));
        #endregion
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FreightResource>(name);
    }
}
