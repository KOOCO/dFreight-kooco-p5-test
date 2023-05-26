using Dolphin.Freight.TradePartner;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerManager : DomainService
    {
        private readonly ITradePartnerRepository _tradePartnerRepository;

        public TradePartnerManager(ITradePartnerRepository tradePartnerRepository)
        { 
            _tradePartnerRepository = tradePartnerRepository;
        }

        public async Task<TradePartner> CreateAsync(
            Guid accountGroupId,
            Guid creditLimitGroupId,
            [NotNull] TPType tpTyp,
            [NotNull] string tpName,
            [NotNull] string tpNamePrint,

            BussinessStatusType bussinessStatusType,
            PaymentType paymentType,
            CreditTermType creditTermType,
            ImporterCodeType importerCodeType,
            int creditTermDays,
            int creditLimit,


            bool isActive = false,
            bool trackPayment = true,
            bool clm = false,
            bool billToAgentCode = false,

            [CanBeNull] string tpNameLocal = null,
            [CanBeNull] string tpLocalAddress = null,
            [CanBeNull] string cityCode = null,
            [CanBeNull] string stateCode = null,
            [CanBeNull] string postCode = null,
            [CanBeNull] string countryCode = null,
            [CanBeNull] string telephone = null,
            [CanBeNull] string fax = null,
            [CanBeNull] string website = null,
            [CanBeNull] string tpPrintAddress = null,
            [CanBeNull] string remark = null,
            [CanBeNull] string tpAliasName = null,
            [CanBeNull] string ceo = null,
            [CanBeNull] string corpNo = null,
            [CanBeNull] string iataCode = null,
            [CanBeNull] string iataPrefix = null,
            [CanBeNull] string scacCode = null,
            [CanBeNull] string firmsCode = null,
            [CanBeNull] string cbsaCode = null,
            [CanBeNull] string dutyPaymentType = null,
            [CanBeNull] string openHours = null,
            [CanBeNull] string csCode = null,
            [CanBeNull] string salesOfficeCode = null,
            [CanBeNull] string salesCode = null,
            [CanBeNull] string salesCodeOe = null,
            [CanBeNull] string salesCodeOi = null,
            [CanBeNull] string salesCodeAe = null,
            [CanBeNull] string salesCodeAi = null,
            [CanBeNull] string salesCodeCuOe = null,
            [CanBeNull] string salesCodeCuAe = null,
            [CanBeNull] string salesCodeCuOi = null,
            [CanBeNull] string salesCodeCuAi = null,
            [CanBeNull] string accountAddress = null,
            [CanBeNull] string taxId = null,
            //[CanBeNull] string billToAgentCode = null,
            [CanBeNull] string accountName = null,
            [CanBeNull] string bankName = null,
            [CanBeNull] string accountNo = null,
            [CanBeNull] string accountCurrencyCode = null,
            [CanBeNull] string bankName2 = null,
            [CanBeNull] string accountNo2 = null,
            [CanBeNull] string accountCurrencyCode2 = null,
            [CanBeNull] string bankName3 = null,
            [CanBeNull] string accountNo3 = null,
            [CanBeNull] string accountCurrencyCode3 = null,
            [CanBeNull] string isfSubmissionName = null,
            [CanBeNull] string importerNo = null,
            [CanBeNull] string popUpTips = null
            ) 
        {
            Check.NotNullOrWhiteSpace(tpName, nameof(tpName));
            var existingTP = await _tradePartnerRepository.FindByTpNameAsync(tpName);
            if (null != existingTP)
            {
                throw new BusinessException(FreightDomainErrorCodes.TradePartnerNameAlreadyExists)
                        .WithData("TradePartnerName", tpName);
            }

            return new TradePartner(
                GuidGenerator.Create(),
                accountGroupId,
                creditLimitGroupId,
                tpTyp,
                tpName,
                tpNamePrint,

                bussinessStatusType,
                paymentType,
                creditTermType,
                importerCodeType,
                creditTermDays,
                creditLimit,

                isActive,
                trackPayment,
                clm,
                billToAgentCode,

                tpNameLocal,
                tpLocalAddress,
                cityCode,
                stateCode,
                postCode,
                countryCode,
                telephone,
                fax,
                website,
                tpPrintAddress,
                remark,
                tpAliasName,
                ceo,
                corpNo,
                iataCode,
                iataPrefix,
                scacCode,
                firmsCode,
                cbsaCode,
                dutyPaymentType,
                openHours,
                csCode,
                salesOfficeCode,
                salesCode,
                salesCodeOe,
                salesCodeOi,
                salesCodeAe,
                salesCodeAi,
                salesCodeCuOe,
                salesCodeCuAe,
                salesCodeCuOi,
                salesCodeCuAi,
                accountAddress,
                taxId,
                //billToAgentCode,
                accountName,
                bankName,
                accountNo,
                accountCurrencyCode,
                bankName2,
                accountNo2,
                accountCurrencyCode2,
                bankName3,
                accountNo3,
                accountCurrencyCode3,
                isfSubmissionName,
                importerNo,
                popUpTips
            );
        }

        public async Task ChangeTPNameAsync(
            [NotNull] TradePartner tradePartner,
            [NotNull] string newTPName)
        {
            Check.NotNull(tradePartner, nameof(tradePartner));
            Check.NotNullOrWhiteSpace(newTPName, nameof(newTPName));
            var existingTP = await _tradePartnerRepository.FindByTpNameAsync(newTPName);
            if (null != existingTP && existingTP.Id != tradePartner.Id)
            {
                throw new BusinessException(FreightDomainErrorCodes.TradePartnerNameAlreadyExists)
                        .WithData("TradePartnerName", newTPName);
            }
            tradePartner.ChangeTPName(newTPName);
        }


    }
}
