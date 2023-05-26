
using Dolphin.Freight.Settings.Countries;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Dolphin.Freight.Data
{
    public class CountryDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Country, Guid> _countryRepository;
        private readonly IRepository<CountryDisplayName, Guid> _countryDisplayNameRepository;
        private readonly IGuidGenerator _guidGenerator;

        public CountryDataSeedContributor(
            IRepository<Country, Guid> countryRepository,
            IRepository<CountryDisplayName, Guid> countryDisplayNameRepository,
            IGuidGenerator guidGenerator
        )
        {
            _countryRepository = countryRepository;
            _countryDisplayNameRepository = countryDisplayNameRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            //if (await _countryDisplayNameRepository.GetCountAsync() == 0)
            //{
            //    await _countryDisplayNameRepository.InsertAsync(
            //        new CountryDisplayName()
            //        {
            //            DisplayName = "ABC",
            //            CountryId = Guid.Parse("61D935F5-F999-2E2D-477F-3A0ADD45AC22"),
            //            OfficeId = Guid.Parse("C92D4915-6434-B0FE-5F82-3A0ADBC0B793"),
            //        }
            //    );
            //    await _countryDisplayNameRepository.InsertAsync(
            //        new CountryDisplayName()
            //        {
            //            DisplayName = "123",
            //            CountryId = Guid.Parse("61D935F5-F999-2E2D-477F-3A0ADD45AC22"),
            //            OfficeId = Guid.Parse("0614ED7D-3A88-15F1-237B-3A0ADBC0B77B"),
            //            AirportId = Guid.Parse("F0DFBDF3-9A8B-EBB0-17DC-3A0ADA6A3460"),
            //        }
            //    );
            //    return;
            //}
            if (await _countryRepository.GetCountAsync() > 0)
            {
                return;
            }

            await _countryRepository.InsertAsync(
                new Country()
                {
                    CountryName = "ZIMBABWE",
                    CountryCode = "ZW",
                }
            );
            await _countryRepository.InsertAsync(
                new Country()
                {
                    CountryName = "ZAMBIA",
                    CountryCode = "ZM",
                }
            );
            await _countryRepository.InsertAsync(
                new Country()
                {
                    CountryName = "SOUTH AFRICA",
                    CountryCode = "ZA",
                }
            );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MAYOTTE",
                                CountryCode = "YT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "YEMEN",
                                CountryCode = "YE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "INSTALLATIONS IN INTERNATIONAL WATERS",
                                CountryCode = "XZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAMOA",
                                CountryCode = "WS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "WALLIS AND FUTUNA",
                                CountryCode = "WF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "VANUATU",
                                CountryCode = "VU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "VIETNAM",
                                CountryCode = "VN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "VIRGIN ISLANDS",
                                CountryCode = "VI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "VIRGIN ISLANDS",
                                CountryCode = "VG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "VENEZUELA",
                                CountryCode = "VE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT VINCENT AND THE GRENADINES",
                                CountryCode = "VC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "HOLY SEE (VATICAN CITY STATE)",
                                CountryCode = "VA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UZBEKISTAN",
                                CountryCode = "UZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "URUGUAY",
                                CountryCode = "UY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UNITED STATES",
                                CountryCode = "US",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UNITED STATES MINOR OUTLYING ISLANDS",
                                CountryCode = "UM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UGANDA",
                                CountryCode = "UG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UKRAINE",
                                CountryCode = "UA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TANZANIA",
                                CountryCode = "TZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TAIWAN",
                                CountryCode = "TW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TUVALU",
                                CountryCode = "TV",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TRINIDAD AND TOBAGO",
                                CountryCode = "TT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TURKEY",
                                CountryCode = "TR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TONGA",
                                CountryCode = "TO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TUNISIA",
                                CountryCode = "TN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TURKMENISTAN",
                                CountryCode = "TM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TIMOR-LESTE",
                                CountryCode = "TL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TOKELAU",
                                CountryCode = "TK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TAJIKISTAN",
                                CountryCode = "TJ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "THAILAND",
                                CountryCode = "TH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TOGO",
                                CountryCode = "TG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FRENCH SOUTHERN TERRITORIES",
                                CountryCode = "TF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CHAD",
                                CountryCode = "TD",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "TURKS AND CAICOS ISLANDS",
                                CountryCode = "TC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SWAZILAND",
                                CountryCode = "SZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SYRIAN ARAB REPUBLIC",
                                CountryCode = "SY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SINT MAARTEN (DUTCH PART)",
                                CountryCode = "SX",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "EL SALVADOR",
                                CountryCode = "SV",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAO TOME AND PRINCIPE",
                                CountryCode = "ST",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SOUTH SUDAN",
                                CountryCode = "SS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SURINAME",
                                CountryCode = "SR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SOMALIA",
                                CountryCode = "SO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SENEGAL",
                                CountryCode = "SN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAN MARINO",
                                CountryCode = "SM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SIERRA LEONE",
                                CountryCode = "SL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SLOVAKIA",
                                CountryCode = "SK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SVALBARD AND JAN MAYEN",
                                CountryCode = "SJ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SLOVENIA",
                                CountryCode = "SI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT HELENA",
                                CountryCode = "SH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SINGAPORE",
                                CountryCode = "SG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SWEDEN",
                                CountryCode = "SE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SUDAN",
                                CountryCode = "SD",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SEYCHELLES",
                                CountryCode = "SC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SOLOMON ISLANDS",
                                CountryCode = "SB",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAUDI ARABIA",
                                CountryCode = "SA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "RWANDA",
                                CountryCode = "RW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "RUSSIAN FEDERATION",
                                CountryCode = "RU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SERBIA",
                                CountryCode = "RS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ROMANIA",
                                CountryCode = "RO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "RÉUNION",
                                CountryCode = "RE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "QATAR",
                                CountryCode = "QA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PARAGUAY",
                                CountryCode = "PY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PALAU",
                                CountryCode = "PW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PORTUGAL",
                                CountryCode = "PT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PALESTINE",
                                CountryCode = "PS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PUERTO RICO",
                                CountryCode = "PR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PITCAIRN",
                                CountryCode = "PN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT PIERRE AND MIQUELON",
                                CountryCode = "PM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "POLAND",
                                CountryCode = "PL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PAKISTAN",
                                CountryCode = "PK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PHILIPPINES",
                                CountryCode = "PH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PAPUA NEW GUINEA",
                                CountryCode = "PG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FRENCH POLYNESIA",
                                CountryCode = "PF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PERU",
                                CountryCode = "PE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "PANAMA",
                                CountryCode = "PA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "OMAN",
                                CountryCode = "OM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NEW ZEALAND",
                                CountryCode = "NZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NIUE",
                                CountryCode = "NU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NAURU",
                                CountryCode = "NR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NEPAL",
                                CountryCode = "NP",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NORWAY",
                                CountryCode = "NO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NETHERLANDS",
                                CountryCode = "NL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NICARAGUA",
                                CountryCode = "NI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NIGERIA",
                                CountryCode = "NG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NORFOLK ISLAND",
                                CountryCode = "NF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NIGER",
                                CountryCode = "NE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NEW CALEDONIA",
                                CountryCode = "NC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NAMIBIA",
                                CountryCode = "NA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MOZAMBIQUE",
                                CountryCode = "MZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MALAYSIA",
                                CountryCode = "MY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MEXICO",
                                CountryCode = "MX",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MALAWI",
                                CountryCode = "MW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MALDIVES",
                                CountryCode = "MV",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MAURITIUS",
                                CountryCode = "MU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MALTA",
                                CountryCode = "MT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MONTSERRAT",
                                CountryCode = "MS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MAURITANIA",
                                CountryCode = "MR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MARTINIQUE",
                                CountryCode = "MQ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "NORTHERN MARIANA ISLANDS",
                                CountryCode = "MP",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MACAO",
                                CountryCode = "MO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MONGOLIA",
                                CountryCode = "MN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MYANMAR",
                                CountryCode = "MM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MALI",
                                CountryCode = "ML",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MACEDONIA",
                                CountryCode = "MK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MARSHALL ISLANDS",
                                CountryCode = "MH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MADAGASCAR",
                                CountryCode = "MG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT MARTIN (FRENCH PART)",
                                CountryCode = "MF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MONTENEGRO",
                                CountryCode = "ME",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MOLDOVA",
                                CountryCode = "MD",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MONACO",
                                CountryCode = "MC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MOROCCO",
                                CountryCode = "MA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LIBYA",
                                CountryCode = "LY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LATVIA",
                                CountryCode = "LV",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LUXEMBOURG",
                                CountryCode = "LU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LITHUANIA",
                                CountryCode = "LT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LESOTHO",
                                CountryCode = "LS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LIBERIA",
                                CountryCode = "LR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SRI LANKA",
                                CountryCode = "LK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LIECHTENSTEIN",
                                CountryCode = "LI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT LUCIA",
                                CountryCode = "LC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LEBANON",
                                CountryCode = "LB",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "LAO PEOPLE'S DEMOCRATIC REPUBLIC",
                                CountryCode = "LA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KAZAKHSTAN",
                                CountryCode = "KZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CAYMAN ISLANDS",
                                CountryCode = "KY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KUWAIT",
                                CountryCode = "KW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KOREA",
                                CountryCode = "KR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KOREA",
                                CountryCode = "KP",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT KITTS AND NEVIS",
                                CountryCode = "KN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "COMOROS",
                                CountryCode = "KM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KIRIBATI",
                                CountryCode = "KI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CAMBODIA",
                                CountryCode = "KH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KYRGYZSTAN",
                                CountryCode = "KG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "KENYA",
                                CountryCode = "KE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "JAPAN",
                                CountryCode = "JP",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "JORDAN",
                                CountryCode = "JO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "JAMAICA",
                                CountryCode = "JM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "JERSEY",
                                CountryCode = "JE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ITALY",
                                CountryCode = "IT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ICELAND",
                                CountryCode = "IS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "IRAN",
                                CountryCode = "IR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "IRAQ",
                                CountryCode = "IQ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BRITISH INDIAN OCEAN TERRITORY",
                                CountryCode = "IO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "INDIA",
                                CountryCode = "IN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ISLE OF MAN",
                                CountryCode = "IM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ISRAEL",
                                CountryCode = "IL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "IRELAND",
                                CountryCode = "IE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "INDONESIA",
                                CountryCode = "ID",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "HUNGARY",
                                CountryCode = "HU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "HAITI",
                                CountryCode = "HT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CROATIA",
                                CountryCode = "HR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "HONDURAS",
                                CountryCode = "HN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "HEARD ISLAND AND MCDONALD ISLANDS",
                                CountryCode = "HM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "HONG KONG ",
                                CountryCode = "HK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUYANA",
                                CountryCode = "GY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUINEA-BISSAU",
                                CountryCode = "GW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUAM",
                                CountryCode = "GU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUATEMALA",
                                CountryCode = "GT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS",
                                CountryCode = "GS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GREECE",
                                CountryCode = "GR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "EQUATORIAL GUINEA",
                                CountryCode = "GQ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUADELOUPE",
                                CountryCode = "GP",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUINEA",
                                CountryCode = "GN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GAMBIA",
                                CountryCode = "GM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GREENLAND",
                                CountryCode = "GL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GIBRALTAR",
                                CountryCode = "GI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GHANA",
                                CountryCode = "GH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GUERNSEY",
                                CountryCode = "GG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FRENCH GUIANA",
                                CountryCode = "GF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GEORGIA",
                                CountryCode = "GE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GRENADA",
                                CountryCode = "GD",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UNITED KINGDOM",
                                CountryCode = "GB",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GABON",
                                CountryCode = "GA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FRANCE",
                                CountryCode = "FR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FAROE ISLANDS",
                                CountryCode = "FO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "MICRONESIA",
                                CountryCode = "FM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FALKLAND ISLANDS (MALVINAS)",
                                CountryCode = "FK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FIJI",
                                CountryCode = "FJ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "FINLAND",
                                CountryCode = "FI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ETHIOPIA",
                                CountryCode = "ET",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SPAIN",
                                CountryCode = "ES",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ERITREA",
                                CountryCode = "ER",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "WESTERN SAHARA",
                                CountryCode = "EH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "EGYPT",
                                CountryCode = "EG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ESTONIA",
                                CountryCode = "EE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ECUADOR",
                                CountryCode = "EC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ALGERIA",
                                CountryCode = "DZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "DOMINICAN REPUBLIC",
                                CountryCode = "DO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "DOMINICA",
                                CountryCode = "DM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "DENMARK",
                                CountryCode = "DK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "DJIBOUTI",
                                CountryCode = "DJ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "GERMANY",
                                CountryCode = "DE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CZECH REPUBLIC",
                                CountryCode = "CZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CYPRUS",
                                CountryCode = "CY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CHRISTMAS ISLAND",
                                CountryCode = "CX",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CURAÇAO",
                                CountryCode = "CW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CAPE VERDE",
                                CountryCode = "CV",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CUBA",
                                CountryCode = "CU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "COSTA RICA",
                                CountryCode = "CR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "COLOMBIA",
                                CountryCode = "CO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CHINA",
                                CountryCode = "CN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CAMEROON",
                                CountryCode = "CM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CHILE",
                                CountryCode = "CL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "COOK ISLANDS",
                                CountryCode = "CK",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CÔTE D'IVOIRE",
                                CountryCode = "CI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SWITZERLAND",
                                CountryCode = "CH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CONGO",
                                CountryCode = "CG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CENTRAL AFRICAN REPUBLIC",
                                CountryCode = "CF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CONGO",
                                CountryCode = "CD",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "COCOS (KEELING) ISLANDS",
                                CountryCode = "CC",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "CANADA",
                                CountryCode = "CA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BELIZE",
                                CountryCode = "BZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BELARUS",
                                CountryCode = "BY",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BOTSWANA",
                                CountryCode = "BW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BHUTAN",
                                CountryCode = "BT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BAHAMAS",
                                CountryCode = "BS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BRAZIL",
                                CountryCode = "BR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BONAIRE",
                                CountryCode = "BQ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BOLIVIA",
                                CountryCode = "BO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BRUNEI DARUSSALAM",
                                CountryCode = "BN",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BERMUDA",
                                CountryCode = "BM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "SAINT BARTHÉLEMY",
                                CountryCode = "BL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BENIN",
                                CountryCode = "BJ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BURUNDI",
                                CountryCode = "BI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BAHRAIN",
                                CountryCode = "BH",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BULGARIA",
                                CountryCode = "BG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BURKINA FASO",
                                CountryCode = "BF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BELGIUM",
                                CountryCode = "BE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BANGLADESH",
                                CountryCode = "BD",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BARBADOS",
                                CountryCode = "BB",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "BOSNIA AND HERZEGOVINA",
                                CountryCode = "BA",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "AZERBAIJAN",
                                CountryCode = "AZ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ÅLAND ISLANDS",
                                CountryCode = "AX",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ARUBA",
                                CountryCode = "AW",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "AUSTRALIA",
                                CountryCode = "AU",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "AUSTRIA",
                                CountryCode = "AT",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "AMERICAN SAMOA",
                                CountryCode = "AS",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ARGENTINA",
                                CountryCode = "AR",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ANTARCTICA",
                                CountryCode = "AQ",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ANGOLA",
                                CountryCode = "AO",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ARMENIA",
                                CountryCode = "AM",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ALBANIA",
                                CountryCode = "AL",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ANGUILLA",
                                CountryCode = "AI",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ANTIGUA AND BARBUDA",
                                CountryCode = "AG",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "AFGHANISTAN",
                                CountryCode = "AF",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "UNITED ARAB EMIRATES",
                                CountryCode = "AE",
                            }
                        );
            await _countryRepository.InsertAsync(
                            new Country()
                            {
                                CountryName = "ANDORRA",
                                CountryCode = "AD",
                            }
                        );
        }
    }
}