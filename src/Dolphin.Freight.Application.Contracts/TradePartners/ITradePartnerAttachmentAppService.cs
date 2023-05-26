using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Dolphin.Freight.TradePartners
{
    public interface ITradePartnerAttachmentAppService :
        ICrudAppService< // Define CRUD methods
            TradePartnerAttachmentDto, // show TradePartnerAttachment
            Guid, // primary key
            TradePartnerAttachmentPagedAndSortedResultRequestDto, // show TradePartnerAttachment
            CreateUpdateTradePartnerAttachmentDto>,
        IApplicationService
    {
        //Task<PagedResultDto<TradePartnerAttachmentDto>> GetListByTpidAsync(TradePartnerAttachmentPagedAndSortedResultRequestDto input);
        Task<IRemoteStreamContent> Download(string attachmentName);
    }
}
