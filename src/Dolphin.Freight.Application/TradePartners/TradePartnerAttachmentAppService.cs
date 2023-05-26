using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerAttachmentAppService :
        CrudAppService<
            TradePartnerAttachment, // entity
            TradePartnerAttachmentDto, // show
            Guid, // primary key
            TradePartnerAttachmentPagedAndSortedResultRequestDto, // paging or sorting
            CreateUpdateTradePartnerAttachmentDto>, 
        ITradePartnerAttachmentAppService
    {
        
        //private readonly IdentityUserAppService _identityUserAppService;
        private readonly IIdentityUserRepository _identityUserRepository;
        public new ILogger<TradePartnerAttachmentAppService> Logger { get; set; }
        private readonly string _folder;

        public TradePartnerAttachmentAppService(
            IWebHostEnvironment env,
            IRepository<TradePartnerAttachment, Guid> repository,
            //IdentityUserAppService identityUserAppService,
            IIdentityUserRepository identityUserRepository
            ) : base(repository)
        {
            //_identityUserAppService = identityUserAppService;
            _identityUserRepository = identityUserRepository;
            Logger = NullLogger<TradePartnerAttachmentAppService>.Instance;
            // 上傳目錄設為: wwwroot\mediaUpload\tradepartner\doc
            _folder = $@"{env.WebRootPath}\mediaUpload\tradepartner\doc";
        }

        public override async Task<PagedResultDto<TradePartnerAttachmentDto>> GetListAsync(TradePartnerAttachmentPagedAndSortedResultRequestDto input)
        {
            Logger.LogDebug("input.sorting:" + input.Sorting);
            // 取得目前系統內所有的User
            Dictionary<Guid, string> userDictionary = new Dictionary<Guid, string>();
            var userList = await _identityUserRepository.GetListAsync();
            if (userList != null && userList.Count > 0) 
            {
                foreach (var user in userList)
                {
                    userDictionary.Add(user.Id, user.UserName);
                }
            }
            var queryable = await Repository.GetQueryableAsync();
            var query = from tradePartnerAttachment in queryable
                        where tradePartnerAttachment.TPId.ToString() == input.TradePartnerId.ToString()
                        //orderby tradePartnerAttachment.CreationTime descending
                        select tradePartnerAttachment;

            if (input.Sorting.IsNullOrEmpty())
            {
                Logger.LogDebug("sorting is null");
                // paging
                query = (IOrderedQueryable<TradePartnerAttachment>)query
                    .OrderByDescending(tradePartnerAttachment => tradePartnerAttachment.CreationTime)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount);
            }
            else {
                // paging
                query = (IOrderedQueryable<TradePartnerAttachment>)query
                    .OrderBy(input.Sorting)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount);
            }
            

            var queryResult = await AsyncExecuter.ToListAsync(query);
            List<TradePartnerAttachmentDto> tradePartnerAttachmentDtos = new List<TradePartnerAttachmentDto>();
            if (queryResult != null && queryResult.Count > 0)
            {
                foreach (var q in queryResult)
                {
                    var tradePartnerAttachmentDto = ObjectMapper.Map<TradePartnerAttachment, TradePartnerAttachmentDto>(q);
                    if (q.CreatorId != null)
                    {
                        tradePartnerAttachmentDto.UserName = userDictionary[q.CreatorId.Value];
                    }
                    else 
                    {
                        tradePartnerAttachmentDto.UserName = null;
                    }
                    tradePartnerAttachmentDtos.Add(tradePartnerAttachmentDto);
                }
            }

            var totalCount = query.Count();

            return new PagedResultDto<TradePartnerAttachmentDto>(
                totalCount,
                tradePartnerAttachmentDtos
            );
        }

        public Task<IRemoteStreamContent> Download(string attachmentName)
        {
            var fs = new FileStream(_folder + attachmentName, FileMode.OpenOrCreate);
            return Task.FromResult(
                (IRemoteStreamContent)new RemoteStreamContent(fs, attachmentName, "application/octet-stream")
            );
        }

    }
}
