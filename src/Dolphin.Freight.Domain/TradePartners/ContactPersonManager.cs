using Dolphin.Freight.TradePartner;
using JetBrains.Annotations;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Dolphin.Freight.TradePartners
{
    public class ContactPersonManager : DomainService
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        private readonly ITradePartnerRepository _tradePartnerRepository;


        public ContactPersonManager(
            IContactPersonRepository contactPersonRepository,
            ITradePartnerRepository tradePartnerRepository
            )
        {
            _contactPersonRepository = contactPersonRepository;
            _tradePartnerRepository = tradePartnerRepository;
        }

        public async Task<ContactPerson> CreateContactPersonAsync(
            Guid tradePartnerId,
            bool isRep,
            bool isEmailNotification,
            [NotNull] string contactName,
            [CanBeNull] string contactTitle,
            [CanBeNull] string contactDivision,
            [CanBeNull] string contactCellPhone,
            [CanBeNull] string contactPhone,
            [CanBeNull] string contactFax,
            [CanBeNull] string contactEmailAddress,
               [CanBeNull] string contactRemark,
            [CanBeNull] GenderType? contactGender,
            [CanBeNull] MarriageType? contactMarriage,
            [CanBeNull] SmokesType? contactSmokes,
            [CanBeNull] DrinkType? contactDrink,
            [CanBeNull] int? contactAge,
            [CanBeNull] string contactGarment,
            [CanBeNull] string contactHobby,
            [CanBeNull] string contactInterest,
            [CanBeNull] ConstellationType? contactConstellation,
            [CanBeNull] DateTime? contactMemorialDay,
            [CanBeNull] DateTime? contactBirthday,
            [CanBeNull] Guid? contactCountryId,
            [CanBeNull] string contactCityCode,
            [CanBeNull] string contactStateCode,
            [CanBeNull] string contactPostCode,
            [CanBeNull] string contactAddress
            )
        {
            Check.NotNullOrWhiteSpace(contactName, nameof(contactName));
            var existingTradePartner = await _tradePartnerRepository.FindAsync(tradePartnerId);
            if (null == existingTradePartner) 
            {
                throw new BusinessException(FreightDomainErrorCodes.TradePartnerDoesNotExist);
            }
            var existingContactName = await _contactPersonRepository.FindByContactNameAsync(contactName, tradePartnerId);
            if (null != existingContactName)
            {
                throw new BusinessException(FreightDomainErrorCodes.ContactPersonNameAlreadyExists)
                    .WithData("ContactName", contactName);
            }
            return new ContactPerson(
                GuidGenerator.Create(),
                tradePartnerId,
                isRep,
                isEmailNotification,
                contactName,
                contactTitle,
                contactDivision,
                contactCellPhone,
                contactPhone,
                contactFax,
                contactEmailAddress,
                      contactRemark,
                contactGender,
                contactMarriage,
                contactSmokes,
                contactDrink,
                contactAge,
                contactGarment,
                contactHobby,
                contactInterest,
                contactConstellation,
                contactMemorialDay,
                contactBirthday,
                contactCountryId,
                contactCityCode,
                contactStateCode,
                contactPostCode,
                contactAddress
            ); 
        }

        public async Task ChangeContactNameAsync(
            [NotNull] ContactPerson contactPerson,
            [NotNull] string newContactPersonContactName
            )
        {
            Check.NotNull(contactPerson, nameof(contactPerson));
            Check.NotNullOrWhiteSpace(newContactPersonContactName, nameof(newContactPersonContactName));
            var existingContactPerson = await _contactPersonRepository.FindByContactNameAsync(newContactPersonContactName, contactPerson.TradePartnerId);
            if (null != existingContactPerson && existingContactPerson.Id != contactPerson.Id)
            {
                throw new BusinessException(FreightDomainErrorCodes.ContactPersonNameAlreadyExists)
                    .WithData("ContactName", newContactPersonContactName);
            }
            contactPerson.ChangeContactName(newContactPersonContactName);
        }


    }
}
