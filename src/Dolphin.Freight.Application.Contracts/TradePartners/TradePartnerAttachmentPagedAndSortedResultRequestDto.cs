using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerAttachmentPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string TradePartnerId { get; set; }
    }
}
