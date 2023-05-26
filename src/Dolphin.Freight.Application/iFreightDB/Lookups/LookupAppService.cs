using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.Lookups
{
    public class LookupAppService : FreightAppService, IApplicationService
    {

        private readonly BaseTables.Bscitys.IBscityRepository _bscityRepository;
        private readonly BaseTables.Bscss.IBscsRepository _bscsRepository;
        private readonly BaseTables.Bscurs.IBscurRepository _bscurRepository;
        private readonly BaseTables.Bscodes.IBscodeRepository _bscodeRepository;

        public LookupAppService(
            BaseTables.Bscitys.IBscityRepository bscityRepository,
            BaseTables.Bscss.IBscsRepository bscsRepository,
            BaseTables.Bscurs.IBscurRepository bscurRepository,
            BaseTables.Bscodes.IBscodeRepository bscodeRepository
        )
        {
            _bscityRepository = bscityRepository;
            _bscsRepository = bscsRepository;
            _bscurRepository = bscurRepository;
            _bscodeRepository = bscodeRepository;
        }

        #region 港口(城市)資料

        public async Task<List<Select2Format>> GetSelect2PortLookupAsync(string FilterText)
        {

            if (FilterText.IsNullOrWhiteSpace()) // 未輸入字串則不顯示任何資料，節省資源
                return new List<Select2Format>();


            var query = from bscity in await _bscityRepository.GetQueryableAsync()
                        where bscity.GroupId.Equals("DL") && bscity.Cmp.Equals("DS") && bscity.Stn.Equals("TPE") // 此處到時候要修改為使用者的
                        select bscity;

            string[] filterArray = FilterText.Trim().Split(" ");

            foreach (string filter in filterArray)
            {
                query = query.Where(x => x.CityNm.Contains(filter) ||
                                         x.CityCd.Contains(filter) ||
                                         x.CntyCd.Contains(filter))
                ;
            }

            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Select2Format> keyValuePairs = new();
            foreach (var oneRow in queryResult)
            {
                keyValuePairs.Add(new Select2Format()
                {
                    id = $"{oneRow.CntyCd},{oneRow.CityCd}",
                    text = $"{oneRow.CityNm}",
                    image = null,
                    display_text = $"{oneRow.CityNm} ({oneRow.CntyCd},{oneRow.CityCd})"
                });
            }

            await Task.Delay(1);

            return keyValuePairs;

        }
        public async Task<ListResultDto<Select2Format>> GetPortLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2PortLookupAsync(FilterText));
        }

        #endregion

        #region 航空、船公司(客戶建檔篩 CUST_TYPE = H、V)

        public async Task<List<Select2Format>> GetSelect2SeaAirCompanyLookupAsync(string FilterText)
        {

            if (FilterText.IsNullOrWhiteSpace())
                return new List<Select2Format>();

            var query = from bscs in await _bscsRepository.GetQueryableAsync()
                        where bscs.GroupId.Equals("DL") && bscs.Cmp.Equals("DS") && bscs.Stn.Equals("TPE") // 此處到時候要修改為使用者的
                        && String.IsNullOrEmpty(bscs.VoidBy) // 作廢不顯示
                        && (bscs.CustType.Contains("H") || bscs.CustType.Contains("V")) // H 航空公司，V 船公司
                        select new
                        {
                            bscs.LocalNm,
                            bscs.EngNm,
                            bscs.AbrNm,
                            bscs.CityCd,
                            bscs.CntyCd,
                            bscs.CustCd,
                            bscs.HeaderCd,
                            bscs.GlobalCd
                        };

            string[] filterArray = FilterText.Trim().Split(" ");

            foreach (string filter in filterArray)
            {
                query = query.Where(x => x.LocalNm.Contains(filter) ||
                                         x.EngNm.Contains(filter) ||
                                         x.AbrNm.Contains(filter) ||
                                         x.CityCd.Contains(filter) ||
                                         x.CntyCd.Contains(filter) ||
                                         x.CustCd.Contains(filter) ||
                                         x.HeaderCd.Contains(filter) ||
                                         x.GlobalCd.Contains(filter))
                ;
            }

            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Select2Format> keyValuePairs = new();
            foreach (var oneRow in queryResult)
            {
                string showName = L["GetCurrentLanguage"] == "en" ? $"{oneRow.AbrNm} ({oneRow.EngNm ?? oneRow.LocalNm})" : $"{oneRow.AbrNm} ({oneRow.LocalNm ?? oneRow.EngNm})";

                keyValuePairs.Add(new Select2Format() { 
                    id = oneRow.CustCd,
                    text = showName,
                    image = null,
                    display_text = showName
                });
            }

            await Task.Delay(1);

            return keyValuePairs;
        }
        public async Task<ListResultDto<Select2Format>> GetSeaAirCompanyLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2SeaAirCompanyLookupAsync(FilterText));
        }

        #endregion

        #region 貿易條件

        public async Task<List<Select2Format>> GetSelect2SVCModeTermLookupAsync(string FilterText)
        {
            List<Select2Format> keyValuePairs = new()
            {
                new Select2Format() { id = "FOB", text = "(FOB) Free on board", display_text = "(FOB) Free on board" }
            };
            for (int i = 1; i <= 10; i++)
            {
                keyValuePairs.Add(new Select2Format()
                {
                    id = i.ToString(),
                    text = $"貿易條件{i}",
                    display_text = $"貿易條件{i} ({i})"
                });
            }
            await Task.Delay(1);

            keyValuePairs = keyValuePairs.WhereIf(!FilterText.IsNullOrWhiteSpace(), x => x.text.Contains(FilterText) || x.id.Contains(FilterText)).ToList();

            return keyValuePairs;
        }
        public async Task<ListResultDto<Select2Format>> GetSVCModeTermLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2SeaAirCompanyLookupAsync(FilterText));
        }

        #endregion

        #region 幣別 BSCUR

        public async Task<List<Select2Format>> GetSelect2CurrencyLookupAsync(string FilterText)
        {

            var query = from bscur in await _bscurRepository.GetQueryableAsync()
                        where bscur.GroupId.Equals("DL") && bscur.Cmp.Equals("DS") && bscur.Stn.Equals("TPE") // 此處到時候要修改為使用者的
                        select new
                        {
                            bscur.Cur,
                            bscur.CurDescp
                        };

            if (!String.IsNullOrEmpty(FilterText))
                query = query.Where(x => x.Cur.Contains(FilterText) || x.CurDescp.Contains(FilterText));

            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Select2Format> keyValuePairs = new();

            foreach (var oneRow in queryResult)
            {
                keyValuePairs.Add(new Select2Format()
                {
                    id = $"{oneRow.Cur}",
                    text = $"{oneRow.CurDescp}",
                    display_text = $"{oneRow.CurDescp} ({oneRow.Cur})"
                });
            }

            await Task.Delay(1);

            return keyValuePairs;
        }
        public async Task<ListResultDto<Select2Format>> GetCurrencyLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2CurrencyLookupAsync(FilterText));
        }

        #endregion

        #region 通用 BSCODE (BSCODE 使用 CdType 參數篩選)

        public async Task<List<Select2Format>> GetSelect2BscodeLookupAsync(string CdType, string FilterText)
        {

            var query = from bscode in await _bscodeRepository.GetQueryableAsync()
                        where bscode.GroupId.Equals("DL") && bscode.Cmp.Equals("*") && bscode.Stn.Equals("*") // 可能還是要跟著使用者來改條件
                        && bscode.CdType.Equals(CdType)
                        select new
                        {
                            bscode.Cd,
                            bscode.CdDescp
                        };

            if (!String.IsNullOrEmpty(FilterText))
                query = query.Where(x => x.Cd.Contains(FilterText) || x.CdDescp.Contains(FilterText));

            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Select2Format> keyValuePairs = new();

            foreach (var oneRow in queryResult)
            {
                keyValuePairs.Add(new Select2Format()
                {
                    id = $"{oneRow.Cd}",
                    text = $"{oneRow.CdDescp}",
                    display_text = $"{oneRow.CdDescp} ({oneRow.Cd})"
                });
            }

            await Task.Delay(1);

            return keyValuePairs;
        }
        public async Task<ListResultDto<Select2Format>> GetBscodeLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2CurrencyLookupAsync(FilterText));
        }

        #endregion

        #region 公司 CMP (BSCODE 篩 CP)

        public async Task<List<Select2Format>> GetSelect2CmpLookupAsync(string FilterText)
        {

            var query = from bscode in await _bscodeRepository.GetQueryableAsync()
                        where bscode.GroupId.Equals("DL") && bscode.Cmp.Equals("*") && bscode.Stn.Equals("*") // 可能還是要跟著使用者來改條件
                        && bscode.CdType.Equals("CP")
                        select new
                        {
                            bscode.Cd,
                            bscode.CdDescp
                        };

            if (!String.IsNullOrEmpty(FilterText))
                query = query.Where(x => x.Cd.Contains(FilterText) || x.CdDescp.Contains(FilterText));

            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Select2Format> keyValuePairs = new();

            foreach (var oneRow in queryResult)
            {
                keyValuePairs.Add(new Select2Format()
                {
                    id = $"{oneRow.Cd}",
                    text = $"{oneRow.CdDescp}",
                    display_text = $"{oneRow.CdDescp} ({oneRow.Cd})"
                });
            }

            await Task.Delay(1);

            return keyValuePairs;
        }
        public async Task<ListResultDto<Select2Format>> GetCmpLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2CurrencyLookupAsync(FilterText));
        }

        #endregion

        #region 站別 STN (BSCODE 篩 ST)

        public async Task<List<Select2Format>> GetSelect2StnLookupAsync(string FilterText)
        {

            var query = from bscode in await _bscodeRepository.GetQueryableAsync()
                        where bscode.GroupId.Equals("DL") && bscode.Cmp.Equals("*") && bscode.Stn.Equals("*") // 可能還是要跟著使用者來改條件
                        && bscode.CdType.Equals("ST")
                        select new
                        {
                            bscode.Cd,
                            bscode.CdDescp
                        };

            if (!String.IsNullOrEmpty(FilterText))
                query = query.Where(x => x.Cd.Contains(FilterText) || x.CdDescp.Contains(FilterText));

            var queryResult = await AsyncExecuter.ToListAsync(query);

            List<Select2Format> keyValuePairs = new();

            foreach (var oneRow in queryResult)
            {
                keyValuePairs.Add(new Select2Format()
                {
                    id = $"{oneRow.Cd}",
                    text = $"{oneRow.CdDescp}",
                    display_text = $"{oneRow.CdDescp} ({oneRow.Cd})"
                });
            }

            await Task.Delay(1);

            return keyValuePairs;
        }
        public async Task<ListResultDto<Select2Format>> GetStnLookupAsync(string FilterText)
        {
            return new ListResultDto<Select2Format>(await GetSelect2CurrencyLookupAsync(FilterText));
        }

        #endregion

        #region 回傳模型 (Select2 用)

        public class Select2Format
        {
#pragma warning disable IDE1006 // 為符合 Select2 的顯示格式，忽略命名樣式的訊息
            public string id { get; set; }
            public string text { get; set; }
            public string image { get; set; }
            public string display_text { get; set; }
#pragma warning restore IDE1006 // 命名樣式
        }

        #endregion

    }
}
