using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.Settings.Offices;
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
    public class OfficeDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Office, Guid> _officeRepository;
        private readonly IGuidGenerator _guidGenerator;

        public OfficeDataSeedContributor(
            IRepository<Office, Guid> officeRepository,
            IGuidGenerator guidGenerator
        ) {
            _officeRepository = officeRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _officeRepository.GetCountAsync() > 0)
            {
                return;
            }

            await _officeRepository.InsertAsync(
                new Office()
                {
                    OfficeName = "CHI",
                    OfficeCode = "CHI",
                }
            );

            await _officeRepository.InsertAsync(
                new Office()
                {
                    OfficeName = "LAX",
                    OfficeCode = "LAX",
                }
            );

            await _officeRepository.InsertAsync(
                new Office()
                {
                    OfficeName = "NYC",
                    OfficeCode = "NYC",
                }
            );

            await _officeRepository.InsertAsync(
                new Office()
                {
                    OfficeName = "PHX",
                    OfficeCode = "PHX",
                }
            );
        }
    }
}
