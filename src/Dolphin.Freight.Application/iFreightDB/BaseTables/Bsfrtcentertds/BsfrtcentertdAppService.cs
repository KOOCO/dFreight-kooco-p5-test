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

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertds
{

    public class BsfrtcentertdAppService : FreightAppService, IBsfrtcentertdAppService
    {
        private readonly IBsfrtcentertdRepository _bsfrtcentertdRepository;

        private readonly IStringLocalizer<FreightResource> _localizer;

        public BsfrtcentertdAppService(IBsfrtcentertdRepository BsfrtcentertdRepository, IStringLocalizer<FreightResource> localizer)
        {
            _bsfrtcentertdRepository = BsfrtcentertdRepository;
            _localizer = localizer;
        }

        #region 基本 CRUD

        public async Task<Bsfrtcentertd_Dto> GetAsync(Bsfrtcentertd_Keys id)
        {
            var Bsfrtcentertd = await _bsfrtcentertdRepository.GetAsync(x => 
                x.GroupId == id.GroupId && 
                x.Cmp == id.Cmp &&
                x.Stn == id.Stn &&
                x.JobNo == id.JobNo
            );
            return ObjectMapper.Map<Bsfrtcentertd, Bsfrtcentertd_Dto>(Bsfrtcentertd);
        }

        public async Task<PagedResultDto<Bsfrtcentertd_Dto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var queryable = await _bsfrtcentertdRepository.GetQueryableAsync();

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

            List<Bsfrtcentertd_Dto> theDtos = ObjectMapper.Map<List<Bsfrtcentertd>, List<Bsfrtcentertd_Dto>>(queryResult);

            return new PagedResultDto<Bsfrtcentertd_Dto>(totalCount, theDtos);

        }

        public async Task<Bsfrtcentertd_Dto> CreateAsync(Bsfrtcentertd_CreateUpdateDto input)
        {
            // 此處為了通用性應該要去叫用 _BsfrtcentertdManager.CreateAsync()
            // 未來如果此表有其他 API 會去執行到新增的動作，業務邏輯就會不對稱
            // 為了避免這種事情發生官網的範例是建議使用 Manager 的物件來統一業務邏輯

            Bsfrtcentertd Bsfrtcentertd = ObjectMapper.Map<Bsfrtcentertd_CreateUpdateDto, Bsfrtcentertd>(input);

            await _bsfrtcentertdRepository.InsertAsync(Bsfrtcentertd);

            return ObjectMapper.Map<Bsfrtcentertd, Bsfrtcentertd_Dto>(Bsfrtcentertd);

        }

        public async Task UpdateAsync(Bsfrtcentertd_Keys id, Bsfrtcentertd_CreateUpdateDto input)
        {
            var Bsfrtcentertd = await _bsfrtcentertdRepository.GetAsync(x =>
                x.GroupId == id.GroupId &&
                x.Cmp == id.Cmp &&
                x.Stn == id.Stn &&
                x.JobNo == id.JobNo
            );

            // 此處理論上會針對每個欄位可能都有自己的判斷，不過現在還沒去限制，所以就直接覆蓋上去
            Bsfrtcentertd = ObjectMapper.Map<Bsfrtcentertd_CreateUpdateDto, Bsfrtcentertd>(input);

            // 這裡先暫時禁止修改 主索引 的欄位
            Bsfrtcentertd.GroupId = id.GroupId;
            Bsfrtcentertd.Cmp = id.Cmp;
            Bsfrtcentertd.Stn = id.Stn;
            Bsfrtcentertd.JobNo = id.JobNo;

            await _bsfrtcentertdRepository.UpdateAsync(Bsfrtcentertd);
        }

        public async Task DeleteAsync(Bsfrtcentertd_Keys id)
        {
            await _bsfrtcentertdRepository.DeleteAsync(x =>
                x.GroupId == id.GroupId &&
                x.Cmp == id.Cmp &&
                x.Stn == id.Stn &&
                x.JobNo == id.JobNo
            );
        }

        #endregion

    }
}
