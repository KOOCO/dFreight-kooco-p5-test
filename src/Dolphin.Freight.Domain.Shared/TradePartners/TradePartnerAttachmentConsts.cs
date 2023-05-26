namespace Dolphin.Freight.TradePartners
{
    public static class TradePartnerAttachmentConsts
    {
        public const string DefaultSorting = "CreationTime desc";

        public const int MinNameLength = 2;
        public const int MaxNameLength = 128;

        // 1KB = 1024 Byte, 1MB = 1024KB
        public const int MaxAttachmentFileSize = 10 * 1024 * 1024; // 10MB

    }
}
