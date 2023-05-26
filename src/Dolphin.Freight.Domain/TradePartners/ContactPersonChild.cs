using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.TradePartners
{
    public class ContactPersonChild : Entity<Guid>
    {
        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public ContactPerson ContactPerson { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Remark { get; set; }
    }
}
