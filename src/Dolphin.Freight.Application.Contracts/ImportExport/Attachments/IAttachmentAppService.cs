
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.ImportExport.Attachments
{
    public interface IAttachmentAppService :
        ICrudAppService<
        AttachmentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateAttachmentDto>
    {
        Task<List<AttachmentDto>> QueryListAsync(QueryAttachmentDto query);
}
}