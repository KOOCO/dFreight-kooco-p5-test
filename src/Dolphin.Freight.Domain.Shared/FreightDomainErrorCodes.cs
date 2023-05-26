namespace Dolphin.Freight;

public static class FreightDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public const string CreditLimitGroupNameAlreadyExists = "Freight:CreditLimitGroupNameAlreadyExists";
    public const string TradePartnerNameAlreadyExists = "Freight:TradePartnerNameAlreadyExists";
    public const string TradePartnerDoesNotExist = "Freight:TradePartnerDoesNotExist";
    public const string ContactPersonNameAlreadyExists = "Freight:ContactPersonNameAlreadyExists";
    public const string CustomerPaymentAlreadyExists = "Freight:CustomerPaymentAlreadyExists";
    public const string PaymentAlreadyExists = "Freight:PaymentAlreadyExists";
}
