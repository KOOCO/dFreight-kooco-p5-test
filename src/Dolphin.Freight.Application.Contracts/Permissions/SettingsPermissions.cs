namespace Dolphin.Freight.Permissions;

/// <summary>
/// 權限管理設定-設置
/// </summary>
public static class SettingsPermissions
{
    public const string GroupName = "Settings";

    /// <summary>
    /// IT號碼管理
    /// </summary>
    public static class ItNoRanges
    {
        public const string Default = GroupName + ".ItNoRanges";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class PortsManagement
    {
        public const string Default = GroupName + ".PortsManagement";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// AWB號碼管理
    /// </summary>
    public static class AwbNoRanges
    {
        public const string Default = GroupName + ".AwbNoRanges";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 包裝管理
    /// </summary>
    public static class PackageUnits
    {
        public const string Default = GroupName + ".PackageUnits";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 集裝箱管理
    /// </summary>
    public static class ContainerSizes
    {
        public const string Default = GroupName + ".ContainerSizes";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    /// <summary>
    /// 空運出口其他費用
    /// </summary>
    public static class AirOtherCharge
    {
        public const string Default = GroupName + ".AirOtherCharge";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

	/// <summary>
    /// <summary>
    /// 貨幣表
    /// </summary>
    public static class CurrencySetting
    {
        public const string Default = GroupName + ".CurrencySetting";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    /// 顯示設定
    /// </summary>
    public static class DisplaySetting
    {
        public const string Default = GroupName + ".DisplaySetting";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 國家管理
    /// </summary>
    public static class CountryDisplayName
    {
        public const string Default = GroupName + ".CountryDisplayName";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Users
    {
        public const string Default = GroupName + ".Users";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

}
