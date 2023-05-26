using Dolphin.Freight.TradePartner;
using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.TradePartners
{
    public class ContactPerson : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public bool IsRep { get; set; }
        public bool IsEmailNotification { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactDivision { get; set; }
        public string ContactCellPhone { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmailAddress { get; set; }
        public string ContactRemark { get; set; }
        public GenderType? ContactGender { get; set; }
        public MarriageType? ContactMarriage { get; set; }
        public SmokesType? ContactSmokes { get; set; }
        public DrinkType? ContactDrink { get; set; }
        public int? ContactAge { get; set; }
        public string ContactGarment { get; set; }
        public string ContactHobby { get; set; }
        public string ContactInterest { get; set; }
        public ConstellationType? ContactConstellation { get; set; }
        public DateTime? ContactMemorialDay { get; set; }
        public DateTime? ContactBirthday { get; set; }
        public Guid? ContactCountryId { get; set; }
        public string ContactCityCode { get; set; }
        public string ContactStateCode { get; set; }
        public string ContactPostCode { get; set; }
        public string ContactAddress { get; set; }

        public bool IsDeleted { get; set; }

        public Guid TradePartnerId { get; set; }

        private ContactPerson()
        {

        }

        internal ContactPerson(
            Guid id,
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
        ) : base(id)
        {
            TradePartnerId = tradePartnerId;
            IsRep = isRep;
            IsEmailNotification = isEmailNotification;
            SetContactName(contactName);
            ContactTitle = contactTitle;
            ContactDivision = contactDivision;
            ContactCellPhone = contactCellPhone;
            ContactPhone = contactPhone;
            ContactFax = contactFax;
            ContactEmailAddress = contactEmailAddress;
            ContactRemark = contactRemark;
            ContactGender = contactGender;
            ContactMarriage = contactMarriage;
            ContactSmokes = contactSmokes;
            ContactDrink = contactDrink;
            ContactAge = contactAge;
            ContactGarment = contactGarment;
            ContactHobby = contactHobby;
            ContactInterest = contactInterest;
            ContactConstellation = contactConstellation;
            ContactMemorialDay = contactMemorialDay;
            ContactBirthday = contactBirthday;
            ContactCountryId = contactCountryId;
            ContactCityCode = contactCityCode;
            ContactStateCode = contactStateCode;
            ContactPostCode = contactPostCode;
            ContactAddress = contactAddress;
        }

        internal ContactPerson ChangeContactName([NotNull] string contactName)
        {
            SetContactName(contactName);
            return this;
        }

        private void SetContactName([NotNull] string contactName)
        {
            ContactName = Check.NotNullOrWhiteSpace(
                contactName,
                nameof(contactName),
                maxLength: 128
            );
        }

    }
}
