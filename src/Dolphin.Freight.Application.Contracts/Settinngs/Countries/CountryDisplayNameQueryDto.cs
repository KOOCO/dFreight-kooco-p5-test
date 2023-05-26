using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.Countries
{
    public class CountryDisplayNameQueryDto : PagedAndSortedResultRequestDto
    {
        public Guid? OfficeId { get; set; } = null;
        public bool? HasData { get; set; } = null;
        public Guid? ShipLine { get; set; } = null;
    }
}
