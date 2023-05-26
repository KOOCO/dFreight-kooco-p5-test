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

namespace Dolphin.Freight.iFreightDB.BaseTables.Stemps
{

    public class StempAppService : FreightAppService, IStempAppService
    {
        private readonly IStempRepository _stempRepository;

        public StempAppService(IStempRepository stempRepository)
        {
            _stempRepository = stempRepository;
        }

        public async Task<Stemp_Dto> GetAsync(Stemp_Keys id)
        {
            var stemp = await _stempRepository.GetAsync(x => x.GroupId == id.GroupId && x.EmpId == id.EmpId);
            return ObjectMapper.Map<Stemp, Stemp_Dto>(stemp);
        }

        public async Task<PagedResultDto<Stemp_Dto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var queryable = await _stempRepository.GetQueryableAsync();

            // 用 Linq 建立基礎的結構
            var query = from main in queryable select main;

            // 依據篩選條件篩選篩選資料，透過 lambda 自動造出 SQL
            query = query
                // .WhereIf(!input.FilterJobNo.IsNullOrWhiteSpace(), x => x.JobNo.Contains(input.FilterJobNo))
                .OrderBy(input.Sorting ?? "empid desc");

            // 用 Count(*) 讀取正確的筆數
            var totalCount = await AsyncExecuter.CountAsync(query);

            // 再去做分頁處理
            query = query.PageBy(input);

            // 真實讀取資料
            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Stemp_Dto> theDtos = ObjectMapper.Map<List<Stemp>, List<Stemp_Dto>>(queryResult);

            return new PagedResultDto<Stemp_Dto>(totalCount, theDtos);

        }

        public async Task<Stemp_Dto> CreateAsync(Stemp_CreateUpdateDto input)
        {
            // 此處為了通用性應該要去叫用 _stempManager.CreateAsync()
            // 未來如果此表有其他 API 會去執行到新增的動作，業務邏輯就會不對稱
            // 為了避免這種事情發生官網的範例是建議使用 Manager 的物件來統一業務邏輯

            #region 慢慢丟的寫法
            /*
            stemp.GroupId = input.GroupId;
            stemp.EmpId = input.EmpId;
            stemp.EmpCnm = input.EmpCnm;
            stemp.EmpEnm = input.EmpEnm;
            stemp.EmpPass = input.EmpPass;
            stemp.EmpTel = input.EmpTel;
            stemp.EmpFax = input.EmpFax;
            stemp.EmpCell = input.EmpCell;
            stemp.EmpMail = input.EmpMail;
            stemp.EmpMsn = input.EmpMsn;
            stemp.EmpSkype = input.EmpSkype;
            stemp.EmpQq = input.EmpQq;
            stemp.EmpTitle = input.EmpTitle;
            stemp.SalesFlag = input.SalesFlag;
            stemp.OwnLeader = input.OwnLeader;
            stemp.Dep = input.Dep;
            stemp.Cmp = input.Cmp;
            stemp.Stn = input.Stn;
            stemp.CmpChoice = input.CmpChoice;
            stemp.StnChoice = input.StnChoice;
            stemp.DepChoice = input.DepChoice;
            stemp.CreateBy = input.CreateBy;
            stemp.CreateDate = input.CreateDate;
            stemp.ModifyBy = input.ModifyBy;
            stemp.ModifyDate = input.ModifyDate;
            stemp.InternalFlag = input.InternalFlag;
            stemp.EvidentPass = input.EvidentPass;
            stemp.Favorites = input.Favorites;
            stemp.SelfFlag = input.SelfFlag;
            stemp.IesId = input.IesId;
            stemp.SalesDepId = input.SalesDepId;
            stemp.EmpIsshare = input.EmpIsshare;
            stemp.IsOnline = input.IsOnline;
            stemp.LastAccessTime = input.LastAccessTime;
            stemp.LastAccessIp = input.LastAccessIp;
            stemp.FStatus = input.FStatus;
            stemp.CustType = input.CustType;
            stemp.SalesdepChoice = input.SalesdepChoice;
            stemp.MailUser = input.MailUser;
            stemp.MailPsw = input.MailPsw;
            stemp.LastmodifyPsw = input.LastmodifyPsw;
            stemp.OceanLine = input.OceanLine;
            stemp.OceanLineNm = input.OceanLineNm;
            stemp.CmpLogin = input.CmpLogin;
            stemp.StnLogin = input.StnLogin;
            stemp.CmpCust = input.CmpCust;
            stemp.StnCust = input.StnCust;
            stemp.EntryDate = input.EntryDate;
            stemp.LeaveDate = input.LeaveDate;
            stemp.GuiDep = input.GuiDep;
            stemp.SalesCs = input.SalesCs;
            stemp.CmpRole = input.CmpRole;
            stemp.HomeRole = input.HomeRole;
            stemp.VpnFromDate = input.VpnFromDate;
            stemp.VpnToDate = input.VpnToDate;
            stemp.ApproveCustType = input.ApproveCustType;
            stemp.ApproveAgntType = input.ApproveAgntType;
            stemp.EmpPassSha512 = input.EmpPassSha512;
            stemp.IfVersion = input.IfVersion;
            */
            #endregion

            Stemp stemp = ObjectMapper.Map<Stemp_CreateUpdateDto, Stemp>(input);

            await _stempRepository.InsertAsync(stemp);

            return ObjectMapper.Map<Stemp, Stemp_Dto>(stemp);

        }

        public async Task UpdateAsync(Stemp_Keys id, Stemp_CreateUpdateDto input)
        {
            var stemp = await _stempRepository.GetAsync(x => x.GroupId == id.GroupId && x.EmpId == id.EmpId);

            // 此處理論上會針對每個欄位可能都有自己的判斷，不過現在還沒去限制，所以就直接覆蓋上去
            stemp = ObjectMapper.Map<Stemp_CreateUpdateDto, Stemp>(input);

            // 這裡先暫時禁止修改 主索引 的欄位
            stemp.GroupId = id.GroupId;
            stemp.EmpId = id.EmpId;

            await _stempRepository.UpdateAsync(stemp);
        }

        public async Task DeleteAsync(Stemp_Keys id)
        {
            await _stempRepository.DeleteAsync(x => x.GroupId == id.GroupId && x.EmpId == id.EmpId);
        }

    }
}
