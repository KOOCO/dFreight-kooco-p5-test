using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.Settings.Countries;
using Dolphin.Freight.Settings.Currencies;
using Dolphin.Freight.Settings.Substations;
using Dolphin.Freight.Settings.SysCodes;
using Dolphin.Freight.TradePartner;
using Dolphin.Freight.TradePartners;
using Dolphin.Freight.TradePartners.Credits;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Dolphin.Freight.Data
{
    public class FreightDataSeedContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<AccountGroup, Guid> _accountGroupRepository;
        //private readonly IRepository<CreditLimitGroup, Guid> _creditLimitGroupRepository;
        private readonly ICreditLimitGroupRepository _creditLimitGroupRepository;
        private readonly CreditLimitGroupManager _creditLimitGroupManager;
        private readonly ITradePartnerRepository _tradePartnerRepository;
        private readonly TradePartnerManager _tradePartnerManager;
        private readonly IRepository<ContactPerson, Guid> _contactPersonRepository;
        private readonly IRepository<Currency, Guid> _currencyRepository;
        private readonly IRepository<Country, Guid> _countryRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<SysCode, Guid> _syscodeRepository;
        private readonly IRepository<Airport, Guid> _airportRepository;
        private readonly IRepository<Substation, Guid> _substationRepository;

        public FreightDataSeedContributor(
            //IRepository<CreditLimitGroup, Guid> creditLimitGroupRepository
            ICreditLimitGroupRepository creditLimitGroupRepository,
            CreditLimitGroupManager creditLimitGroupManager,
            ITradePartnerRepository tradePartnerRepository,
            TradePartnerManager tradePartnerManager,
            IRepository<AccountGroup, Guid> accountGroupRepository,
            IRepository<ContactPerson, Guid> contactPersonRepository,
            IRepository<Currency, Guid> currencyRepository,
            IRepository<Country, Guid> countryRepository,
            IGuidGenerator guidGenerator,
            IRepository<SysCode, Guid> syscodeRepository,
            IRepository<Airport, Guid> airportRepository,
            IRepository<Substation, Guid> substationRepository
            )
        {
            _accountGroupRepository = accountGroupRepository;
            _creditLimitGroupRepository = creditLimitGroupRepository;
            _creditLimitGroupManager = creditLimitGroupManager;
            _tradePartnerRepository = tradePartnerRepository;
            _tradePartnerManager = tradePartnerManager;
            _contactPersonRepository = contactPersonRepository;
            _currencyRepository = currencyRepository;
            _countryRepository = countryRepository;
            _guidGenerator = guidGenerator;
            _syscodeRepository = syscodeRepository;
            _airportRepository = airportRepository;
            _substationRepository = substationRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // Add Currency & Country initial testing data
            await CreateCurrencyCountryAsync();
            // Add AccountGroup initial testing data
            await CreateAccountGroupAsync();
            // Add CreditLimitGroup initial testing data
            await CreateCreditLimitGroupAsync();
            // Add Airport initital testing data
            await CreateAirportAsync();
            // Add Substation initial testing data
            await CreateSubstationAsync();

            await CreateSysCodeAsync();

        }

        // avoid insert the same data in every run

        private async Task CreateSysCodeAsync()
        {
            if (await _syscodeRepository.GetCountAsync() > 0)
            {
                return;
            }

            #region PaymentLevel_1
            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "PaymentLevel_1",
                    CodeValue = "1",
                    ShowName = "Level1",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "PaymentLevel_1",
                    CodeValue = "2",
                    ShowName = "Level2",
                    IsDeleted = false
                },
                autoSave: true
            );
            #endregion

            #region PaymentLevel_2
            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "PaymentLevel_2",
                    CodeValue = "1",
                    ShowName = "第一級",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "PaymentLevel_2",
                    CodeValue = "2",
                    ShowName = "第二級",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "PaymentLevel_2",
                    CodeValue = "3",
                    ShowName = "第一級/第二級",
                    IsDeleted = false
                },
                autoSave: true
            );
            #endregion

            #region Category
            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "0",
                    ShowName = "",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "1",
                    ShowName = "ACH",
                    IsDeleted = false
                },
                autoSave: true
            );


            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "2",
                    ShowName = "Bill Pay",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "3",
                    ShowName = "Cargospint",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "4",
                    ShowName = "GoFreight Pay",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "5",
                    ShowName = "Melio",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "6",
                    ShowName = "Paycargo",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "7",
                    ShowName = "Zelle",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "8",
                    ShowName = "信用卡",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "9",
                    ShowName = "匯款",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "10",
                    ShowName = "支票",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _syscodeRepository.InsertAsync(
                new SysCode
                {
                    CodeType = "Category",
                    CodeValue = "11",
                    ShowName = "現金",
                    IsDeleted = false
                },
                autoSave: true
            );
            #endregion
        }

        private async Task CreateCurrencyCountryAsync()
        {
            if (await _currencyRepository.GetCountAsync() > 0)
            {
                return;
            }

            var usd = await _currencyRepository.InsertAsync(
                new Currency(_guidGenerator.Create(), "USD", "US")
            );

            var twd = await _currencyRepository.InsertAsync(
                new Currency(_guidGenerator.Create(), "TWD", "TW")
            );

            //await _countryRepository.InsertAsync(
            //    new Country
            //    {
            //        CountryName = "United States of America",
            //        CurrencyId = usd.Id,
            //        IsDeleted = false
            //    },
            //    autoSave: true
            //);

            var tw = await _countryRepository.FindAsync(row => row.CountryCode.Equals("TW"));

            // Add TradePartner initial testing data
            if (await _tradePartnerRepository.GetCountAsync() <= 0)
            {
                await _tradePartnerRepository.InsertAsync(
                    await _tradePartnerManager.CreateAsync(
                        Guid.Empty,
                        Guid.Empty,
                        TPType.AirCarrier,
                        "testTP1",
                        "testTP1",

                        BussinessStatusType.Business,
                        PaymentType.Cod,
                        CreditTermType.DaysAfterETA,
                        ImporterCodeType.CbpAssignedNumber,
                        3,
                        200,

                        true,
                        false,
                        false,
                        false,

                        "台積電",
                        "新竹科學園區力行六路8號",
                        "HSC",
                        "HSC",
                        "123",
                        tw.Id.ToString(),
                        "03-5636968",
                        "03-5636968",
                        "www.tsmcmoi.com",
                        "新竹科學園區力行六路8號",
                        "這是一個提醒測試",
                        null,
                        "張忠謀",
                        null,
                        "695",
                        null,
                        null,
                        "204",
                        null,
                        null,
                        "8-17",
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,

                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,

                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        "{\"DoorToDoor\":false,\"BadCustomer\":false,\"ImportOnly\":false,\"ExportOnly\":false,\"CoLoader\":false,\"CustomClear\":false,\"Warehouse\":false,\"ISFCharges\":false,\"FreeHandCargo\":false,\"Nomination\":false,\"SeeMemoRemark\":false}"
                    ),
                    autoSave: true
                );
            }
        }

        private async Task CreateAccountGroupAsync()
        {
            if (await _accountGroupRepository.GetCountAsync() <= 0)
            {
                var acc1 = new AccountGroup
                {
                    AccountGroupName = "testA1"
                };

                var acc2 = new AccountGroup
                {
                    AccountGroupName = "testA2"
                };

                await _accountGroupRepository.InsertManyAsync(
                   new[] { acc1, acc2 }
                );
            }
        }

        private async Task CreateCreditLimitGroupAsync()
        {
            if (await _creditLimitGroupRepository.CountAsync() > 0)
            {
                return;
            }

            if (await _creditLimitGroupRepository.GetCountAsync() <= 0)
            {
                await _creditLimitGroupRepository.InsertAsync(
                    await _creditLimitGroupManager.CreateAsync(
                        "testCLG1",
                        PaymentType.Cod,
                        CreditTermType.Days,
                        1,
                        100
                    )
                );

                await _creditLimitGroupRepository.InsertAsync(
                    await _creditLimitGroupManager.CreateAsync(
                        "testCLG2",
                        PaymentType.Koinfo,
                        CreditTermType.DaysAfterETD,
                        10,
                        200
                    )
                );
            }
        }

        private async Task CreateAirportAsync()
        {
            if (await _airportRepository.GetCountAsync() > 0)
            {
                return;
            }

            await _airportRepository.InsertAsync(
                new Airport
                {
                    AirportName = "ANAA",
                    AirportIataCode = "AAA",
                    IsDeleted = false
                },
                autoSave: true
            );
            await _airportRepository.InsertAsync(
                new Airport
                {
                    AirportName = "ARRABURY",
                    AirportIataCode = "AAB",
                    IsDeleted = false
                },
                autoSave: true
            );

            await _airportRepository.InsertAsync(
                new Airport
                {
                    AirportName = "TAIWAN TAOYUAN INT'L",
                    AirportIataCode = "TPE",
                    IsDeleted = false
                },
                autoSave: true
            );

        }

        private async Task CreateSubstationAsync()
        {
            if (await _substationRepository.GetCountAsync() <= 0)
            {
                await _substationRepository.InsertAsync(
                    new Substation
                    {
                        SubstationName = "Sub1",
                        AbbreviationName = "Abb1",
                        Currency = null,
                        IsDeleted = false
                    },
                    autoSave: true
                );
            }
        }
    }
}
