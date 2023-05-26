using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using Dolphin.Freight.Localization;
using Microsoft.Extensions.Localization;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertms
{

    public class BsfrtcentertmAppService : FreightAppService, IBsfrtcentertmAppService
    {
        private readonly IBsfrtcentertmRepository _bsfrtcentertmRepository;

        public BsfrtcentertmAppService(IBsfrtcentertmRepository BsfrtcentertmRepository)
        {
            _bsfrtcentertmRepository = BsfrtcentertmRepository;
        }

        public async Task<Bsfrtcentertm_Dto> GetAsync(Bsfrtcentertm_Keys id)
        {
            var Bsfrtcentertm = await _bsfrtcentertmRepository.GetAsync(x => 
                x.GroupId == id.GroupId && 
                x.Cmp == id.Cmp &&
                x.Stn == id.Stn &&
                x.JobNo == id.JobNo
            );
            return ObjectMapper.Map<Bsfrtcentertm, Bsfrtcentertm_Dto>(Bsfrtcentertm);
        }

        public async Task<PagedResultDto<Bsfrtcentertm_Dto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var queryable = await _bsfrtcentertmRepository.GetQueryableAsync();

            // 用 Linq 建立基礎的結構
            var query = from main in queryable select main;

            // 依據篩選條件篩選篩選資料，透過 lambda 自動造出 SQL
            query = query
                // .WhereIf(!input.FilterJobNo.IsNullOrWhiteSpace(), x => x.JobNo.Contains(input.FilterJobNo))
                .OrderBy(input.Sorting ?? "jobNo desc");

            // 用 Count(*) 讀取正確的筆數
            var totalCount = await AsyncExecuter.CountAsync(query);

            // 再去做分頁處理
            query = query.PageBy(input);

            // 真實讀取資料
            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Bsfrtcentertm_Dto> theDtos = ObjectMapper.Map<List<Bsfrtcentertm>, List<Bsfrtcentertm_Dto>>(queryResult);

            return new PagedResultDto<Bsfrtcentertm_Dto>(totalCount, theDtos);

        }

        public async Task<Bsfrtcentertm_Dto> CreateAsync(Bsfrtcentertm_CreateUpdateDto input)
        {
            // 此處為了通用性應該要去叫用 _BsfrtcentertmManager.CreateAsync()
            // 未來如果此表有其他 API 會去執行到新增的動作，業務邏輯就會不對稱
            // 為了避免這種事情發生官網的範例是建議使用 Manager 的物件來統一業務邏輯

            Bsfrtcentertm Bsfrtcentertm = ObjectMapper.Map<Bsfrtcentertm_CreateUpdateDto, Bsfrtcentertm>(input);

            await _bsfrtcentertmRepository.InsertAsync(Bsfrtcentertm);

            return ObjectMapper.Map<Bsfrtcentertm, Bsfrtcentertm_Dto>(Bsfrtcentertm);

        }

        public async Task UpdateAsync(Bsfrtcentertm_Keys id, Bsfrtcentertm_CreateUpdateDto input)
        {
            var Bsfrtcentertm = await _bsfrtcentertmRepository.GetAsync(x =>
                x.GroupId == id.GroupId &&
                x.Cmp == id.Cmp &&
                x.Stn == id.Stn &&
                x.JobNo == id.JobNo
            );

            // 此處理論上會針對每個欄位可能都有自己的判斷，不過現在還沒去限制，所以就直接覆蓋上去
            Bsfrtcentertm = ObjectMapper.Map<Bsfrtcentertm_CreateUpdateDto, Bsfrtcentertm>(input);

            // 這裡先暫時禁止修改 主索引 的欄位
            Bsfrtcentertm.GroupId = id.GroupId;
            Bsfrtcentertm.Cmp = id.Cmp;
            Bsfrtcentertm.Stn = id.Stn;
            Bsfrtcentertm.JobNo = id.JobNo;

            await _bsfrtcentertmRepository.UpdateAsync(Bsfrtcentertm);
        }

        public async Task DeleteAsync(Bsfrtcentertm_Keys id)
        {
            await _bsfrtcentertmRepository.DeleteAsync(x =>
                x.GroupId == id.GroupId &&
                x.Cmp == id.Cmp &&
                x.Stn == id.Stn &&
                x.JobNo == id.JobNo
            );
        }

    }
}
