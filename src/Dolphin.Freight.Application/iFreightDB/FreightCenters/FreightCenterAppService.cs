using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Dolphin.Freight.ExtensionTools;
using Volo.Abp.Localization;
using Microsoft.AspNetCore.Authorization;
using Dolphin.Freight.Permissions;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Users;
using IdentityServer4.Extensions;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Auditing;
using Microsoft.AspNetCore.Hosting;
using ExcelDataReader;
using Volo.Abp.Uow;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using System.Net;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text;
using NPOI.SS.Formula.Functions;

namespace Dolphin.Freight.iFreightDB.FreightCenters
{

    public class FreightCenterAppService : FreightAppService, IFreightCenterAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IWebHostEnvironment _env;
        private readonly BaseTables.Bsfrtcentertds.IBsfrtcentertdRepository _bsfrtcentertdRepository;
        private readonly BaseTables.Bsfrtcentertms.IBsfrtcentertmRepository _bsfrtcentertmRepository;
        private readonly BaseTables.BsfrtcentertExcelTemps.IBsfrtcentertExcelTempRepository _bsfrtcentertExcelTempRepository;
        private readonly BaseTables.Bscodes.IBscodeRepository _bscodeRepository;
        private readonly BaseTables.Bscss.IBscsRepository _bscsRepository;
        private readonly BaseTables.Bschgcds.IBschgcdRepository _bschgcdRepository;
        private readonly BaseTables.BsfrtcentertPortMappings.IBsfrtcentertPortMappingRepository _bsfrtcentertPortMappingRepository;
        private readonly BaseTables.Bscitys.IBscityRepository _bscityRepository;
        private readonly BaseTables.Gfcompanys.IGfcompanyRepository _gfcompanyRepository;
        private readonly BaseTables.Bscurs.IBscurRepository _bscurRepository;

        public FreightCenterAppService(
            ICurrentUser currentUser,
            IWebHostEnvironment env,
            BaseTables.Bsfrtcentertds.IBsfrtcentertdRepository bsfrtcentertdRepository,
            BaseTables.Bsfrtcentertms.IBsfrtcentertmRepository bsfrtcentertmRepository,
            BaseTables.BsfrtcentertExcelTemps.IBsfrtcentertExcelTempRepository bsfrtcentertExcelTempRepository,
            BaseTables.Bscodes.IBscodeRepository bscodeRepository,
            BaseTables.Bscss.IBscsRepository bscsRepository,
            BaseTables.Bschgcds.IBschgcdRepository bschgcdRepository,
            BaseTables.BsfrtcentertPortMappings.IBsfrtcentertPortMappingRepository bsfrtcentertPortMappingRepository,
            BaseTables.Bscitys.IBscityRepository bscityRepository,
            BaseTables.Gfcompanys.IGfcompanyRepository gfcompanyRepository,
            BaseTables.Bscurs.IBscurRepository bscurRepository
        )
        {
            _currentUser = currentUser;
            _env = env;
            _bsfrtcentertdRepository = bsfrtcentertdRepository;
            _bsfrtcentertmRepository = bsfrtcentertmRepository;
            _bsfrtcentertExcelTempRepository = bsfrtcentertExcelTempRepository;
            _bscodeRepository = bscodeRepository;
            _bscsRepository = bscsRepository;
            _bschgcdRepository = bschgcdRepository;
            _bsfrtcentertPortMappingRepository = bsfrtcentertPortMappingRepository;
            _bscityRepository = bscityRepository;
            _gfcompanyRepository = gfcompanyRepository;
            _bscurRepository = bscurRepository;
        }

        #region 運價合約查詢

        [Authorize(FreightCenterPermissions.ContractCostQuery.Default)]
        public async Task<PagedResultDto<Quot_Dto>> GetQuotContractAsync(Quot_FilterDto input)
        {

            var bscodeQuertable = await _bscodeRepository.GetQueryableAsync();
            var bscsQuertable = await _bscsRepository.GetQueryableAsync();
            var bschgcdQuertable = await _bschgcdRepository.GetQueryableAsync();

            // 用 Linq 建立基礎的結構
            var query = from detail in await _bsfrtcentertdRepository.GetQueryableAsync()
                        join main in await _bsfrtcentertmRepository.GetQueryableAsync() on detail.FJobNo equals main.JobNo
                        select new
                        {
                            detail,
                            main,
                            SalesDepName = (
                                from bscode in bscodeQuertable
                                where bscode.CdType == "SD" && bscode.Cd == detail.SalesDepId && (bscode.GroupId == "DL" && bscode.Cmp == "DS" && bscode.Stn == "TPE")
                                select new { bscode.CdDescp }
                            ).FirstOrDefault().CdDescp ?? detail.SalesDepId ?? $"{detail.SalesDepId}",
                            CarrierName = (
                                from bscs in bscsQuertable
                                where bscs.CustCd == detail.FCarrier && (bscs.GroupId == detail.GroupId && bscs.Cmp == detail.Cmp && bscs.Stn == detail.Stn)
                                select new { cr_name = bscs.AbrNm ?? bscs.LocalNm }
                            ).FirstOrDefault().cr_name ?? $"{detail.FCarrier}",
                            FChargeCdName = (
                                from bschgcd in bschgcdQuertable
                                where bschgcd.ChgCd == detail.FChargeCd && (bschgcd.GroupId == detail.GroupId && bschgcd.Cmp == detail.Cmp && bschgcd.Stn == detail.Stn) // 因為 bschgcd 沒有 Dep， 到時候條件必須自己加上 bschgcd.Dep = XXXX ，不然一定是錯的
                                select new { xxxxx = (L["GetCurrentLanguage"] == "en" ? bschgcd.ChgEnm ?? bschgcd.ChgCnm : bschgcd.ChgCnm ?? bschgcd.ChgEnm) ?? bschgcd.ChgCd }
                            ).FirstOrDefault().xxxxx ?? $"{detail.FChargeCd}",
                        };


            String portLoadingCode = null;
            String portCntyLoadingCode = null;
            String portDestinationCode = null;
            String portCntyDestinationCode = null;

            if (input.FilterPortLoadingCode != null)
            {
                portLoadingCode = input.FilterPortLoadingCode.Split(",")[1];
                portCntyLoadingCode = input.FilterPortLoadingCode.Split(",")[0];
            }

            if (input.FilterPortDestinationCode != null)
            {
                portDestinationCode = input.FilterPortDestinationCode.Split(",")[1];
                portCntyDestinationCode = input.FilterPortDestinationCode.Split(",")[0];
            }

            // 依據篩選條件篩選篩選資料，透過 lambda 自動造出 SQL
            query = query
                .WhereIf(!portLoadingCode.IsNullOrWhiteSpace(), x => x.detail.PorCd.Contains(portLoadingCode))
                .WhereIf(!portCntyLoadingCode.IsNullOrWhiteSpace(), x => x.detail.PorCnty.Contains(portCntyLoadingCode))
                .WhereIf(!portDestinationCode.IsNullOrWhiteSpace(), x => x.detail.DestCd.Contains(portDestinationCode))
                .WhereIf(!portCntyDestinationCode.IsNullOrWhiteSpace(), x => x.detail.DestCnty.Contains(portCntyDestinationCode))
                .WhereIf(!input.FilterCarrier.IsNullOrWhiteSpace(), x => x.detail.FCarrier.Contains(input.FilterCarrier))
                .WhereIf(!input.FilterSVCModeTerm.IsNullOrWhiteSpace(), x => x.detail.SvcModeTerm == input.FilterSVCModeTerm)
                .Where(x => (new string[] { "30", "40", "50" }).Contains(x.main.ConfirmFlag))
                // .WhereIf(true, x => x.detail.Dep == "OE")
                // .WhereIf(true, x => x.main.ExpirationDate > new DateTime(2023, 01, 14))
                .OrderBy(x => x.detail.FJobNo).ThenBy(x => x.detail.Seq)
                .Take(500)
            ;


            // 用 Count(*) 讀取正確的筆數
            // var totalCount = await AsyncExecuter.CountAsync(query.GroupBy(x => x.detail.FreightCenterMainId));

            // 再去做分頁處理
            // query = query.PageBy(input);

            // 真實讀取資料
            var queryResult = await AsyncExecuter.ToListAsync(query);

            var groupResult = queryResult.GroupBy(x => x.detail.FJobNo).ToList();

            var totalCount = groupResult.Count;

            var theDtos = groupResult.Select(x =>
            {
                // var theDto = ObjectMapper.Map<FreightCenterDetail, QuotDto>(x.detail);
                var theDto = new Quot_Dto();

                // theDto.Carrier = x.FirstOrDefault().CarrierName;

                #region 欄位1 海運名稱，匯率
                String f01 = "<span style='text-decoration:underline;'>" + x.FirstOrDefault().CarrierName + "</span><br />";
                f01 += "&nbsp;";

                /*
                // 改為讓 User 自己去站外搜尋
                foreach (var curr in input.FilterCurrency)
                if (!curr.IsNullOrWhiteSpace() && curr != x.FirstOrDefault().detail.FCurrency)
                    f01 += $"<br /><span style=\"font-size: xx-small;\">匯率：{x.FirstOrDefault().detail.FCurrency} ?.?? = {curr} ?.??</span>";
                */

                theDto.CustomField01 = f01;
                #endregion

                #region 欄位2 運費

                String f02 = "<span style='color: #ED7D31;'>運費</span><br />";

                var of02 = x.Where(y => y.detail.FChargeCd != null && y.detail.FChargeCd.Contains("OF")).FirstOrDefault();
                if (of02 != null)
                {
                    String ModalHtml = GetModalHtml("freight" + of02.detail.JobNo.ToString());

                    var minRate = new { rateName = "", CurrencyType = "", value = decimal.MaxValue };
                    if (minRate.value > of02.detail.Rate1.ZeroToMax())
                        minRate = new { rateName = "20'", CurrencyType = of02.detail.FCurrency, value = of02.detail.Rate1.ZeroToMax() };
                    if (minRate.value > of02.detail.Rate2.ZeroToMax())
                        minRate = new { rateName = "40'", CurrencyType = of02.detail.FCurrency, value = of02.detail.Rate2.ZeroToMax() };
                    if (minRate.value > of02.detail.Rate3.ZeroToMax())
                        minRate = new { rateName = "40'HC", CurrencyType = of02.detail.FCurrency, value = of02.detail.Rate3.ZeroToMax() };
                    if (minRate.value > of02.detail.Rate4.ZeroToMax())
                        minRate = new { rateName = "Rate_4", CurrencyType = of02.detail.FCurrency, value = of02.detail.Rate4.ZeroToMax() };
                    if (minRate.value > of02.detail.Rate5.ZeroToMax())
                        minRate = new { rateName = "Rate_5", CurrencyType = of02.detail.FCurrency, value = of02.detail.Rate5.ZeroToMax() };
                    if (minRate.value > of02.detail.Rate6.ZeroToMax())
                        minRate = new { rateName = "Rate_6", CurrencyType = of02.detail.FCurrency, value = of02.detail.Rate6.ZeroToMax() };

                    if (minRate.value == decimal.MaxValue)
                        minRate = new { rateName = "Error", CurrencyType = "", value = 0m };

                    String LinkText = $"{minRate.CurrencyType} {minRate.value:#}({minRate.rateName})";
                    String ModalContent = $"20'：{of02.detail.Rate1}<br />" +
                                          $"40'：{of02.detail.Rate2}<br />" +
                                          $"40'HC：{of02.detail.Rate3}<br />" +
                                          $"Rate_4：{of02.detail.Rate4}<br />" +
                                          $"Rate_5：{of02.detail.Rate5}<br />" +
                                          $"Rate_6：{of02.detail.Rate6}<br />";
                    f02 += "OF " + String.Format(ModalHtml, LinkText, "OF", ModalContent);
                }
                else f02 += "&nbsp;";

                var ole02 = x.Where(y => y.detail.FChargeCd != null && y.detail.FChargeCd.Contains("燃油")).FirstOrDefault();
                if (ole02 != null)
                {
                    String ModalHtml = GetModalHtml("freight" + ole02.detail.JobNo.ToString());
                    var minRate = new { rateName = "", CurrencyType = "", value = decimal.MaxValue };
                    if (minRate.value > ole02.detail.Rate1.ZeroToMax())
                        minRate = new { rateName = "20'", CurrencyType = of02.detail.FCurrency, value = ole02.detail.Rate1.ZeroToMax() };
                    if (minRate.value > ole02.detail.Rate2.ZeroToMax())
                        minRate = new { rateName = "40'", CurrencyType = of02.detail.FCurrency, value = ole02.detail.Rate2.ZeroToMax() };
                    if (minRate.value > ole02.detail.Rate3.ZeroToMax())
                        minRate = new { rateName = "40'HC", CurrencyType = of02.detail.FCurrency, value = ole02.detail.Rate3.ZeroToMax() };
                    if (minRate.value > ole02.detail.Rate4.ZeroToMax())
                        minRate = new { rateName = "Rate_4", CurrencyType = of02.detail.FCurrency, value = ole02.detail.Rate4.ZeroToMax() };
                    if (minRate.value > ole02.detail.Rate5.ZeroToMax())
                        minRate = new { rateName = "Rate_5", CurrencyType = of02.detail.FCurrency, value = ole02.detail.Rate5.ZeroToMax() };
                    if (minRate.value > ole02.detail.Rate6.ZeroToMax())
                        minRate = new { rateName = "Rate_6", CurrencyType = of02.detail.FCurrency, value = ole02.detail.Rate6.ZeroToMax() };

                    if (minRate.value == decimal.MaxValue)
                        minRate = new { rateName = "Error", CurrencyType = "", value = 0m };

                    String LinkText = $"{minRate.CurrencyType} {minRate.value:#}({minRate.rateName})";
                    String ModalContent = $"20'：{ole02.detail.Rate1}<br />" +
                                          $"40'：{ole02.detail.Rate2}<br />" +
                                        $"40'HC：{ole02.detail.Rate3}<br />" +
                                       $"Rate_4：{ole02.detail.Rate4}<br />" +
                                       $"Rate_5：{ole02.detail.Rate5}<br />" +
                                       $"Rate_6：{ole02.detail.Rate6}<br />";
                    f02 += "<br />燃油附加費 " + String.Format(ModalHtml, LinkText, "燃油附加費", ModalContent);
                }
                else f02 += "<br />&nbsp;";

                theDto.CustomField02 = f02; ;
                #endregion

                #region 欄位3 其他費用
                String f03 = "<span style='color: #ED7D31;'>其他費用</span><br />";

                var F03 = x.Where(y => y.detail.Pc != null && y.detail.Pc == "F" && y.detail.FChargeCd != null);
                if (F03.Any())
                {
                    f03 += "Foreign charges ";
                }

                var L03 = x.Where(y => y.detail.Pc != null && y.detail.Pc == "L" && y.detail.FChargeCd != null);
                if (L03.Any())
                {
                    f03 += "<br />Local charges ";
                }

                theDto.CustomField03 = f03;
                #endregion

                #region 欄位4 其他費用 的 費用 (排版整齊用，也可以直接裡面打 Table)

                String f04 = "<br />";

                // var F04 = x.Where(y => y.detail.PrepaidCollect != null && y.detail.PrepaidCollect == "F");
                if (F03.Any())
                {
                    String ModalHtml = GetModalHtml("F" + F03.FirstOrDefault().main.JobNo.ToString());
                    String LinkText = (F03.Sum(y => y.detail.Rate1.GetValueOrDefault(0m)) +
                                       F03.Sum(y => y.detail.Rate2.GetValueOrDefault(0m)) +
                                       F03.Sum(y => y.detail.Rate3.GetValueOrDefault(0m)) +
                                       F03.Sum(y => y.detail.Rate4.GetValueOrDefault(0m)) +
                                       F03.Sum(y => y.detail.Rate5.GetValueOrDefault(0m)) +
                                       F03.Sum(y => y.detail.Rate6.GetValueOrDefault(0m))).ToString();
                    LinkText = L["Details"]; // 這些是所有的其他費用，但是又有分不同的計價方式，我辦不到使用一個數字顯示多重區間的加總
                    String ModalContent = "";
                    foreach (var oneDetail in F03)
                    {
                        if (!String.IsNullOrEmpty(ModalContent)) ModalContent += "<br />";
                        ModalContent += $"{oneDetail.FChargeCdName}({oneDetail.detail.FChargeCd}) ({oneDetail.detail.FCurrency})<br />" +
                              "20'：" + oneDetail.detail.Rate1.ToString() + "<br />" +
                              "40'：" + oneDetail.detail.Rate2.ToString() + "<br />" +
                            "40'HC：" + oneDetail.detail.Rate3.ToString() + "<br />" +
                           "Rate_4：" + oneDetail.detail.Rate4.ToString() + "<br />" +
                           "Rate_5：" + oneDetail.detail.Rate5.ToString() + "<br />" +
                           "Rate_6：" + oneDetail.detail.Rate6.ToString() + "<br />";
                    }
                    f04 += String.Format(ModalHtml, LinkText, "Discharge charges", ModalContent);

                }

                // var L04 = x.Where(y => y.detail.PrepaidCollect != null && y.detail.PrepaidCollect == "F");
                if (L03.Any())
                {
                    String ModalHtml = GetModalHtml("L" + L03.FirstOrDefault().main.JobNo.ToString());
                    String LinkText = "NTD " + (L03.Sum(y => y.detail.Rate1.GetValueOrDefault(0m)) +
                                                L03.Sum(y => y.detail.Rate2.GetValueOrDefault(0m)) +
                                                L03.Sum(y => y.detail.Rate3.GetValueOrDefault(0m)) +
                                                L03.Sum(y => y.detail.Rate4.GetValueOrDefault(0m)) +
                                                L03.Sum(y => y.detail.Rate5.GetValueOrDefault(0m)) +
                                                L03.Sum(y => y.detail.Rate6.GetValueOrDefault(0m))).ToString();
                    LinkText = L["Details"]; // 這些是所有的其他費用，但是又有分不同的計價方式，我辦不到使用一個數字顯示多重區間的加總
                    String ModalContent = "";
                    foreach (var oneDetail in L03)
                    {
                        if (!String.IsNullOrEmpty(ModalContent)) ModalContent += "<br />";
                        ModalContent += $"{oneDetail.FChargeCdName}({oneDetail.detail.FChargeCd}) ({oneDetail.detail.FCurrency})<br />" +
                                 "20'：" + oneDetail.detail.Rate1.ToString() + "<br />" +
                                 "40'：" + oneDetail.detail.Rate2.ToString() + "<br />" +
                               "40'HC：" + oneDetail.detail.Rate3.ToString() + "<br />" +
                              "Rate_4：" + oneDetail.detail.Rate4.ToString() + "<br />" +
                              "Rate_5：" + oneDetail.detail.Rate5.ToString() + "<br />" +
                              "Rate_6：" + oneDetail.detail.Rate6.ToString() + "<br />";
                    }
                    f04 += "<br />" + String.Format(ModalHtml, LinkText, "Loading charges", ModalContent);
                }

                theDto.CustomField04 = f04;
                #endregion

                #region 欄位5 結關日，航程天數
                theDto.CustomField05 = $"<span style='color: #ED7D31;'>結關日</span><br /><span style='color: #ED7D31;'>航程天數</span><br />&nbsp;";
                #endregion

                #region 欄位6 結關日，航程天數 的 星期幾與天數 (排版整齊用，也可以直接裡面打 Table)
                theDto.CustomField06 = $"{x.FirstOrDefault().detail.Closing}<br />{x.FirstOrDefault().detail.FTransit}<br />&nbsp;";
                #endregion

                #region 欄位7 總費用
                string priceModal = GetModalHtml(x.FirstOrDefault().detail.FJobNo.ToString());
                string priceTotal = (x.Sum(y => y.detail.BasicPrice.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.MinChg.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.Rate1.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.Rate2.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.Rate3.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.Rate4.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.Rate5.GetValueOrDefault(0m)) +
                                     x.Sum(y => y.detail.Rate6.GetValueOrDefault(0m))).ToString();

                theDto.CustomField07 = "<span style='color: #ED7D31;'>總費用</span> " + String.Format(priceModal, priceTotal, "Total", priceTotal);
                #endregion

                return theDto;
            }).ToList();

            return new PagedResultDto<Quot_Dto>(totalCount, theDtos);

        }

        #endregion

        #region 運價成本列表
        public async Task<PagedResultDto<SCL_Dto>> GetShippingCostListAsync(PagedAndSortedResultRequestDto input)
        {

            var bscodeQuertable = await _bscodeRepository.GetQueryableAsync();
            var bscsQuertable = await _bscsRepository.GetQueryableAsync();
            var bschgcdQuertable = await _bschgcdRepository.GetQueryableAsync();

            // 用 Linq 建立基礎的結構
            var query = from detail in await _bsfrtcentertdRepository.GetQueryableAsync()
                        join main in await _bsfrtcentertmRepository.GetQueryableAsync() on detail.FJobNo equals main.JobNo
                        select new
                        {
                            detail,
                            main,
                            CarrierName = (
                                from bscs in bscsQuertable
                                where bscs.CustCd == detail.FCarrier && (bscs.GroupId == detail.GroupId && bscs.Cmp == detail.Cmp && bscs.Stn == detail.Stn)
                                select new { cr_name = bscs.AbrNm ?? bscs.LocalNm }
                            ).FirstOrDefault().cr_name ?? $"{detail.FCarrier}",
                            // FChargeCdName = (
                            //     from bschgcd in bschgcdQuertable
                            //     where bschgcd.ChgCd == detail.FChargeCd && (bschgcd.GroupId == detail.GroupId && bschgcd.Cmp == detail.Cmp && bschgcd.Stn == detail.Stn) // 因為 bschgcd 沒有 Dep， 到時候條件必須自己加上 bschgcd.Dep = XXXX ，不然一定是錯的
                            //     select new { xxxxx = (L["GetCurrentLanguage"] == "en" ? bschgcd.ChgEnm ?? bschgcd.ChgCnm : bschgcd.ChgCnm ?? bschgcd.ChgEnm) ?? bschgcd.ChgCd }
                            // ).FirstOrDefault().xxxxx ?? "(Null)",
                        };

            // 依據篩選條件篩選篩選資料，透過 lambda 自動造出 SQL
            query = query
                // .WhereIf(!portLoadingCode.IsNullOrWhiteSpace(), x => x.detail.PorCd.Contains(portLoadingCode))
                .Where(x => x.detail.CreateBy.Contains(_currentUser.UserName))
                // .Where(x => (new string[] { "30", "40", "50" }).Contains(x.main.ConfirmFlag))
                .WhereIf(true, x => x.detail.Dep == "OE")
                // .WhereIf(true, x => x.main.ExpirationDate > new DateTime(2023, 01, 14))
                // .OrderBy(x => x.detail.FJobNo).ThenBy(x => x.detail.Seq)
                ;

            // 用 Count(*) 讀取正確的筆數
            var totalCount = await AsyncExecuter.CountAsync(query);

            // 分頁處裡
            query = query
                // .OrderBy(NormalizeSorting(input.Sorting, "main", nameof(SCL_Dto.SC_NO)))
                .OrderBy(x => x.detail.FJobNo).ThenBy(x => x.detail.Seq)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            ;

            // 真實讀取資料
            var queryResult = await AsyncExecuter.ToListAsync(query);

            String[] knownList = new String[] { "20'", "40'", "40'GP", "40'HQ", "45" };

            var theDtos = queryResult.Select(x =>
            {
                // var theDto = ObjectMapper.Map<FreightCenterDetail, QuotDto>(x.detail);
                SCL_Dto theDto = new();

                theDto.JobNo = x.detail.JobNo;
                theDto.SC_NO = x.main.ContractNo;
                theDto.EffectiveDate = x.main.EffectiveDate;
                theDto.ExpiryDate = x.main.ExpirationDate;
                theDto.Carrier = x.CarrierName;
                theDto.ServiceMode = x.detail.FType == "F" ? "CY (F) 整櫃" : (x.detail.FType == "L" ? "CFS (L) 散貨" : "未知");
                theDto.Origin = x.detail.PolCd;
                theDto.POD = x.detail.PodCd;
                theDto.Destination = x.detail.DestCd;

                // 後續需求的欄位
                theDto.Agent = x.detail.AgentCd;
                theDto.Remark = x.detail.FRmk;
                theDto.TT = x.detail.FTransit;
                theDto.ETC = x.detail.Closing;
                theDto.ETD = x.detail.Etd;
                theDto.ETA = x.detail.Eta;
                theDto.FreeTime = x.detail.FreeTime;

                if (x.detail.ChgUnit == "CTN")
                {
                    if (!x.detail.Rate1.IsNull() && x.detail.ChgUnit1 == "20'") theDto.Ctn_20GP = x.detail.Rate1.ToString();
                    if (!x.detail.Rate2.IsNull() && x.detail.ChgUnit2 == "20'") theDto.Ctn_20GP = x.detail.Rate2.ToString();
                    if (!x.detail.Rate3.IsNull() && x.detail.ChgUnit3 == "20'") theDto.Ctn_20GP = x.detail.Rate3.ToString();
                    if (!x.detail.Rate4.IsNull() && x.detail.ChgUnit4 == "20'") theDto.Ctn_20GP = x.detail.Rate4.ToString();
                    if (!x.detail.Rate5.IsNull() && x.detail.ChgUnit5 == "20'") theDto.Ctn_20GP = x.detail.Rate5.ToString();
                    if (!x.detail.Rate6.IsNull() && x.detail.ChgUnit6 == "20'") theDto.Ctn_20GP = x.detail.Rate6.ToString();

                    if (!x.detail.Rate1.IsNull() && (new[] { "40'", "40'GP" }).Contains(x.detail.ChgUnit1)) theDto.Ctn_40GP = x.detail.Rate1.ToString();
                    if (!x.detail.Rate2.IsNull() && (new[] { "40'", "40'GP" }).Contains(x.detail.ChgUnit2)) theDto.Ctn_40GP = x.detail.Rate2.ToString();
                    if (!x.detail.Rate3.IsNull() && (new[] { "40'", "40'GP" }).Contains(x.detail.ChgUnit3)) theDto.Ctn_40GP = x.detail.Rate3.ToString();
                    if (!x.detail.Rate4.IsNull() && (new[] { "40'", "40'GP" }).Contains(x.detail.ChgUnit4)) theDto.Ctn_40GP = x.detail.Rate4.ToString();
                    if (!x.detail.Rate5.IsNull() && (new[] { "40'", "40'GP" }).Contains(x.detail.ChgUnit5)) theDto.Ctn_40GP = x.detail.Rate5.ToString();
                    if (!x.detail.Rate6.IsNull() && (new[] { "40'", "40'GP" }).Contains(x.detail.ChgUnit6)) theDto.Ctn_40GP = x.detail.Rate6.ToString();

                    if (!x.detail.Rate1.IsNull() && x.detail.ChgUnit1 == "40'HQ") theDto.Ctn_40HQ = x.detail.Rate1.ToString();
                    if (!x.detail.Rate2.IsNull() && x.detail.ChgUnit2 == "40'HQ") theDto.Ctn_40HQ = x.detail.Rate2.ToString();
                    if (!x.detail.Rate3.IsNull() && x.detail.ChgUnit3 == "40'HQ") theDto.Ctn_40HQ = x.detail.Rate3.ToString();
                    if (!x.detail.Rate4.IsNull() && x.detail.ChgUnit4 == "40'HQ") theDto.Ctn_40HQ = x.detail.Rate4.ToString();
                    if (!x.detail.Rate5.IsNull() && x.detail.ChgUnit5 == "40'HQ") theDto.Ctn_40HQ = x.detail.Rate5.ToString();
                    if (!x.detail.Rate6.IsNull() && x.detail.ChgUnit6 == "40'HQ") theDto.Ctn_40HQ = x.detail.Rate6.ToString();

                    if (!x.detail.Rate1.IsNull() && x.detail.ChgUnit1 == "45") theDto.Ctn_45HQ = x.detail.Rate1.ToString();
                    if (!x.detail.Rate2.IsNull() && x.detail.ChgUnit2 == "45") theDto.Ctn_45HQ = x.detail.Rate2.ToString();
                    if (!x.detail.Rate3.IsNull() && x.detail.ChgUnit3 == "45") theDto.Ctn_45HQ = x.detail.Rate3.ToString();
                    if (!x.detail.Rate4.IsNull() && x.detail.ChgUnit4 == "45") theDto.Ctn_45HQ = x.detail.Rate4.ToString();
                    if (!x.detail.Rate5.IsNull() && x.detail.ChgUnit5 == "45") theDto.Ctn_45HQ = x.detail.Rate5.ToString();
                    if (!x.detail.Rate6.IsNull() && x.detail.ChgUnit6 == "45") theDto.Ctn_45HQ = x.detail.Rate6.ToString();

                    if (!x.detail.Rate1.IsNull() && !knownList.Contains(x.detail.ChgUnit1)) theDto.Extension1 += x.detail.ChgUnit1 + ":" + x.detail.Rate1.ToString() + ";";
                    if (!x.detail.Rate2.IsNull() && !knownList.Contains(x.detail.ChgUnit2)) theDto.Extension1 += x.detail.ChgUnit2 + ":" + x.detail.Rate2.ToString() + ";";
                    if (!x.detail.Rate3.IsNull() && !knownList.Contains(x.detail.ChgUnit3)) theDto.Extension1 += x.detail.ChgUnit3 + ":" + x.detail.Rate3.ToString() + ";";
                    if (!x.detail.Rate4.IsNull() && !knownList.Contains(x.detail.ChgUnit4)) theDto.Extension1 += x.detail.ChgUnit4 + ":" + x.detail.Rate4.ToString() + ";";
                    if (!x.detail.Rate5.IsNull() && !knownList.Contains(x.detail.ChgUnit5)) theDto.Extension1 += x.detail.ChgUnit5 + ":" + x.detail.Rate5.ToString() + ";";
                    if (!x.detail.Rate6.IsNull() && !knownList.Contains(x.detail.ChgUnit6)) theDto.Extension1 += x.detail.ChgUnit6 + ":" + x.detail.Rate6.ToString() + ";";


                    // if (x.detail.ChgUnit1 == "CBM") theDto. = x.detail.Rate1.ToString();
                    // if (x.detail.ChgUnit2 == "CBM") theDto. = x.detail.Rate2.ToString();
                    // if (x.detail.ChgUnit3 == "CBM") theDto. = x.detail.Rate3.ToString();
                    // if (x.detail.ChgUnit4 == "CBM") theDto. = x.detail.Rate4.ToString();
                    // if (x.detail.ChgUnit5 == "CBM") theDto. = x.detail.Rate5.ToString();
                    // if (x.detail.ChgUnit6 == "CBM") theDto. = x.detail.Rate6.ToString();

                }

                if (x.detail.FChargeCd == "OF") theDto.OF_Currency = x.detail.FCurrency;

                if (x.detail.FType == "L")
                {
                    if (x.detail.ChgUnit1 == "CBM") theDto.CFS_CBM = x.detail.Rate1.ToString();
                    if (x.detail.ChgUnit2 == "CBM") theDto.CFS_CBM = x.detail.Rate2.ToString();
                    if (x.detail.ChgUnit3 == "CBM") theDto.CFS_CBM = x.detail.Rate3.ToString();
                    if (x.detail.ChgUnit4 == "CBM") theDto.CFS_CBM = x.detail.Rate4.ToString();
                    if (x.detail.ChgUnit5 == "CBM") theDto.CFS_CBM = x.detail.Rate5.ToString();
                    if (x.detail.ChgUnit6 == "CBM") theDto.CFS_CBM = x.detail.Rate6.ToString();

                    theDto.CFS_Currency = x.detail.FCurrency;
                }

                return theDto;
            }).ToList();

            return new PagedResultDto<SCL_Dto>(totalCount, theDtos);
            // return theDtos;

        }

        #endregion

        #region 上傳 船公司報價Excel 然後存入暫存表 BSFRTCENTERT_EXCEL_TEMP

        [HttpPut]
        [DisableAuditing] // 避免 ABP 內建的統計功能產生大量的資料造成資料庫負擔，所以關閉統計功能
        [UnitOfWork]
        public async Task<Models.NotificationMessage> OceanShippingCostUploadAsync(OceanShippingExcelFileUploadDto input)
        {

            DataSet excelDataSet = new DataSet();

            #region 接收 Excel 並轉換寫入至 excelDataSet

            if (input.fileContent == null || input.fileContent.Length == 0)
                return new Models.NotificationMessage(L["TheFileContentIsEmpty"], "錯誤", Models.MessageType.Error);

            using (var stream = new MemoryStream(input.fileContent))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // 設定讀 Excel 的設定
                    ExcelDataSetConfiguration configuration = new()
                    {
                        ConfigureDataTable = (tableReader) => new() { UseHeaderRow = true }
                    };
                    excelDataSet = reader.AsDataSet(configuration);
                }
            }

            // 驗證是否有資料
            bool allTablesEmpty = true;
            foreach (DataTable table in excelDataSet.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    allTablesEmpty = false;
                    break;
                }
            }
            if (allTablesEmpty) return new Models.NotificationMessage(L["ThereIsNoDataInTheFile"], "錯誤", Models.MessageType.Error);

            #endregion

            #region 驗證是否要求的欄位都有存在

            List<string> needColumns = new()
            {
                "GROUP_ID", "CMP", "STN",
                "Effective Date", "Valid Till", "Carrier", "ORIGIN",
                "POD", "DESTINATION", "Model",
                "Currency", "20'GP", "40'GP", "40'HQ",
                // "Agent", "Transit Time", "ETC", "ETD", "ETA", "Free Time", "Remark" // 這邊是運價自己想要的欄位，非必要
            };
            List<string> missingColumns = new();

            foreach (DataTable checkTable in excelDataSet.Tables)
            {
                foreach (string needColumn in needColumns)
                {
                    if (!checkTable.Columns.Contains(needColumn))
                    {
                        missingColumns.Add(checkTable.TableName + "." + needColumn);
                    }
                }
            }

            if (missingColumns.Any())
                return new Models.NotificationMessage(String.Join("<br />", missingColumns.Select(x => $"{x}")), L["TheDataFormatIsIncorrect"], Models.MessageType.Error);

            #endregion

            #region 將 Excel 的資料，整理存入 List<BsfrtcentertExcelTemp> rawDatas

            List<BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp> rawDatas = new();

            foreach (DataTable table in excelDataSet.Tables)
            {
                // table.Rows.RemoveAt(0); // 把第一行拿去當標題了，不用刪除
                // "Agent", "Transit Time", "ETC", "ETD", "ETA", "Free Time", "Remark" // 這邊是運價自己想要的欄位，非必要
                foreach (DataRow dr in table.Rows)
                {
                    BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp row = new();
                    row.GroupId = dr.ToStringFromColumnName("GROUP_ID").ToUpper();
                    row.Cmp = dr.ToStringFromColumnName("CMP").ToUpper();
                    row.Stn = dr.ToStringFromColumnName("STN").ToUpper();
                    row.Agent = dr.ToStringFromColumnName("Agent", true); // Agent
                    bool successEff = DateTime.TryParse(dr["Effective Date"].ToString(), out DateTime EffDate);
                    if (successEff) row.EffectiveDate = EffDate;
                    bool successVal = DateTime.TryParse(dr["Valid Till"].ToString(), out DateTime ValDate);
                    if (successVal) row.ValidTill = ValDate;
                    row.Carrier = dr.ToStringFromColumnName("Carrier"); // table.TableName;
                    row.Origin = dr.ToStringFromColumnName("ORIGIN"); // ORIGIN
                    row.Pod = dr.ToStringFromColumnName("POD"); // POD
                    row.Destination = dr.ToStringFromColumnName("DESTINATION"); // DESTINATION
                    row.Model = dr.ToStringFromColumnName("Model"); // Model
                    row.Currency = dr.ToStringFromColumnName("Currency").ToUpper(); // Currency
                    row.Ic20gp = dr.ToStringFromColumnName("20'GP"); // 20'GP
                    row.Ic40gp = dr.ToStringFromColumnName("40'GP"); // 40'GP
                    row.Ic40hq = dr.ToStringFromColumnName("40'HQ"); // 40'HQ
                    row.TrasitTime = dr.ToStringFromColumnName("Transit Time", true); // Transit Time
                    row.Etc = dr.ToStringFromColumnName("ETC", true); // ETC
                    row.Etd = dr.ToStringFromColumnName("ETD", true); // ETD
                    row.Eta = dr.ToStringFromColumnName("ETA", true); // ETA
                    row.FreeTime = dr.ToStringFromColumnName("Free Time", true); // Free Time
                    row.Remark = dr.ToStringFromColumnName("Remark", true); // Remark

                    row.UploaderId = input.userId; // 因為呼叫的地方不知為何不會帶使用者資料，所以自己傳來
                    row.UploaderTime = DateTime.Now;

                    rawDatas.Add(row);
                }
            }

            #endregion

            #region 驗證代碼相關欄位是都能對應到 IFREIGHTDL 資料庫 (GROUP_ID、CMP、STN、Currency)

            String noMappingMessage = "";

            List<Models.GroupIdCmpStn> groupIdCmpStnDistinctData = rawDatas.Select(x => new { x.GroupId, x.Cmp, x.Stn }).Distinct().Select(x => { return new Models.GroupIdCmpStn(x.GroupId, x.Cmp, x.Stn); }).ToList();
            List<Models.GroupIdCmpStn> noMappingGroupIdCmpStn = new();

            foreach (var check in groupIdCmpStnDistinctData)
            {
                if (!(await _gfcompanyRepository.CheckExistAsync(check.GroupId, check.Cmp, check.Stn)))
                    noMappingGroupIdCmpStn.Add(check);
            }

            if (noMappingGroupIdCmpStn.Any())
                noMappingMessage += L["GroupIdCmpStn"] + " " + L["NotMapped"] + "：<br />" + String.Join("<br />", noMappingGroupIdCmpStn.Select(x => x.ToString() == ", , " ? "[,,]" : $"{x}"));

            List<string> currencyIsDistinctData = rawDatas.Select(x => x.Currency).Distinct().ToList();
            List<string> noMappingCurrency = await _bscurRepository.FindCurNotInAsync(currencyIsDistinctData);

            if (noMappingCurrency.Any())
                noMappingMessage += (noMappingMessage == "" ? "" : "<br /><br />") + L["Currency"] + " " + L["NotMapped"] + "：<br />"
                    + String.Join("<br />", noMappingCurrency.Select(x => (String.IsNullOrEmpty(x) ? "[]" : $"{x}")));

            if (!String.IsNullOrEmpty(noMappingMessage))
                return new Models.NotificationMessage(noMappingMessage, L["CodeNotFoundInTheSystem"], Models.MessageType.Error);

            #endregion

            await _bsfrtcentertExcelTempRepository.InsertManyAsync(rawDatas);

            return new Models.NotificationMessage(L["ImportSuccessful"], msgType: Models.MessageType.Success);

        }

        #endregion

        #region 清除暫存 Excle (清除個人的部分)(真刪除)

        [HttpDelete]
        public async Task<IActionResult> ClearTemporaryExcel()
        {
            // await _bsfrtcentertExcelTempRepository.DeleteAsync(x => x.UploaderId == _currentUser.UserName);
            int affectedRowCount = await _bsfrtcentertExcelTempRepository.DeleteByUploaderIdAsync(_currentUser.UserName);
            return new JsonResult(new { message = String.Format(L["RowsAffected"], affectedRowCount) }, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        }

        #endregion

        #region 讀取暫存的 Excel 表

        public async Task<PagedResultDto<BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp_Dto>> GetOceanExcelTempListAsync(PagedAndSortedResultRequestDto input)
        {
            // 用 Linq 建立基礎的結構
            var query = from main in await _bsfrtcentertExcelTempRepository.GetQueryableAsync()
                        where main.UploaderId == _currentUser.UserName & main.IsDeleted == false
                        select main;

            // 用 Count(*) 讀取正確的筆數
            var totalCount = await AsyncExecuter.CountAsync(query);

            // 再去做分頁處理
            query = query.PageBy(input);

            // 真實讀取資料
            var queryResult = await AsyncExecuter.ToListAsync(query);

            // 轉成 List<BsfrtcentertExcelTemp_Dto>
            var theDtos = queryResult.Select(x =>
            {
                var theDto = ObjectMapper.Map<BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp, BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp_Dto>(x);
                return theDto;
            }).ToList();

            return new PagedResultDto<BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp_Dto>(totalCount, theDtos);

        }
        #endregion

        #region 真的將暫存表存進運價的表 BSFRTCENTERTM、BSFRTCENTERTD

        [DisableAuditing] // 避免 ABP 內建的統計功能產生大量的資料造成資料庫負擔，所以關閉統計功能
        public async Task<Models.NotificationMessage> OceanShippingCostConvertToDatabaseAsync(OceanShippingExcelFileUploadDto input)
        {

            DataSet mappingExcelDataSet = new DataSet();

            #region 接收 Excel 並轉換寫入至 List<CityMapping> cityMappings、List<AgentyMapping> agentMappings

            #region 讀取 Excel 檔案，放入 mappingExcelDataSet

            if (input.fileContent == null || input.fileContent.Length == 0)
                return new Models.NotificationMessage(L["TheFileContentIsEmpty"], L["Error"], Models.MessageType.Error);

            using (var stream = new MemoryStream(input.fileContent))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // 設定讀 Excel 的設定
                    ExcelDataSetConfiguration configuration = new()
                    {
                        ConfigureDataTable = (tableReader) => new() { UseHeaderRow = true }
                    };
                    mappingExcelDataSet = reader.AsDataSet(configuration);
                }
            }

            #endregion

            #region 驗證匯入的 Excel 是否有兩個表以上，有找到對應就直接放，沒找到就順序放入 cityTable 與 agentTable

            DataTable cityTable = null;
            DataTable agentTable = null;

            // 驗證 DataSet 是否包含兩個表
            if (mappingExcelDataSet.Tables.Count >= 2)
            {
                int cityIndex = -1;
                int agentIndex = -1;

                #region 在 mappingExcelDataSet 中尋找名為，[城市對應表] 與 [代理對應表]

                for (int i = 0; i < mappingExcelDataSet.Tables.Count; i++)
                {
                    // 找到名為 城市對應表 的資料表
                    if (mappingExcelDataSet.Tables[i].TableName == "城市對應表")
                    {
                        cityTable = mappingExcelDataSet.Tables[i];
                        cityIndex = i;
                    }
                    // 找到名為 代理對應表 的資料表
                    else if (mappingExcelDataSet.Tables[i].TableName == "代理對應表")
                    {
                        agentTable = mappingExcelDataSet.Tables[i];
                        agentIndex = i;
                    }
                }

                #endregion

                #region 找不到就中文對應，就照順序填入

                if (cityTable == null && agentTable == null) // 兩個都找不到
                {
                    cityTable = mappingExcelDataSet.Tables[0];
                    agentTable = mappingExcelDataSet.Tables[1];
                }
                else if (cityTable != null && agentTable == null) // 只有找到 城市對應表
                {
                    for (int i = 0; i < mappingExcelDataSet.Tables.Count; i++)
                    {
                        if (cityIndex != i)
                        {
                            agentTable = mappingExcelDataSet.Tables[i];
                            break;
                        }
                    }
                }
                else if (cityTable == null && agentTable != null) // 只有找到 代理對應表
                {
                    for (int i = 0; i < mappingExcelDataSet.Tables.Count; i++)
                    {
                        if (agentIndex != i)
                        {
                            cityTable = mappingExcelDataSet.Tables[i];
                            break;
                        }
                    }
                }

                #endregion

            }
            else
            {
                return new Models.NotificationMessage(L["MissingCityOrAgentMappingTable"], L["Error"], Models.MessageType.Error);
            }

            #endregion

            #region 驗證對應表格式是否正確，確保稍後欄位都能對應到

            List<string> cityNeedColumns = new() { "PORT_NAME", "CITY_CD", "CNTY_CD" };
            List<string> agentNeedColumns = new() { "AGENT", "AGENT_CD" };
            List<string> missingColumns = new();

            // 城市對應表檢查欄位
            foreach (string needColumn in cityNeedColumns)
            {
                if (!cityTable.Columns.Contains(needColumn))
                {
                    missingColumns.Add("城市對應表." + needColumn);
                }
            }

            // 代理對應表檢查欄位
            foreach (string needColumn in agentNeedColumns)
            {
                if (!agentTable.Columns.Contains(needColumn))
                {
                    missingColumns.Add("代理對應表." + needColumn);
                }
            }

            if (missingColumns.Any())
                return new Models.NotificationMessage(String.Join("<br />", missingColumns.Select(x => $"{x}")), L["TheDataFormatIsIncorrect"], Models.MessageType.Error);

            #endregion

            #region DataTable 轉換至 List<CityMapping> cityMappings、List<AgentyMapping> agentMappings

            List<CityMapping> cityMappings = new();
            cityMappings = cityTable.AsEnumerable().Select(row => new CityMapping
            {
                PORT_NAME = row.Field<string>("PORT_NAME"),
                CITY_CD = row.Field<string>("CITY_CD"),
                CNTY_CD = row.Field<string>("CNTY_CD")
            }).ToList();

            List<AgentyMapping> agentMappings = new();
            agentMappings = agentTable.AsEnumerable().Select(row => new AgentyMapping
            {
                AGENT = row.Field<string>("AGENT"),
                AGENT_CD = row.Field<string>("AGENT_CD")
            }).ToList();

            #endregion

            #region 驗證 cityMappings 與 agentMappings 有沒有重複輸入的 Key 值

            List<string> duplicatePortName = cityMappings.GroupBy(x => x.PORT_NAME).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            List<string> duplicAteagent = agentMappings.GroupBy(x => x.AGENT).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            String duplicMessage = "";

            if (duplicatePortName.Any())
                duplicMessage += L["Display:TradePartner:THead:City"] + " " + L["AlreadyDuplicated"] + "：<br />"
                    + String.Join("<br />", duplicatePortName.Select(x => String.IsNullOrEmpty(x) ? "[]" : $"{x}"));

            if (duplicAteagent.Any())
                duplicMessage += (duplicMessage == "" ? "" : "<br /><br />") + L["ShippingAgentName"] + " " + L["AlreadyDuplicated"] + "：<br />"
                    + String.Join("<br />", duplicAteagent.Select(x => (String.IsNullOrEmpty(x) ? "[]" : $"{x}")));

            if (!String.IsNullOrEmpty(duplicMessage))
                return new Models.NotificationMessage(duplicMessage, L["TheCityOrAgentInTheMappingTableIsDuplicated"], Models.MessageType.Error);

            #endregion

            #region 驗證代碼相關欄位是都能對應到 IFREIGHTDL 資料庫 (CITY_CD、CNTY_CD、AGENT_CD)

            String noMappingMessage = "";

            List<BaseTables.Bscitys.Bscity> cityDistinctData = cityMappings.Select(x => new { x.CITY_CD, x.CNTY_CD }).Distinct().Select(x => { return new BaseTables.Bscitys.Bscity() { CityCd = x.CITY_CD, CntyCd = x.CNTY_CD }; }).ToList();
            List<BaseTables.Bscitys.Bscity> noMappingGroupIdCmpStn = await _bscityRepository.FindCityCdCntyCdNotInAsync(cityDistinctData);

            if (noMappingGroupIdCmpStn.Any())
                noMappingMessage += L["Display:TradePartner:THead:City"] + " " + L["NotMapped"] + "：<br />" + String.Join("<br />", noMappingGroupIdCmpStn.Select(x => x.GetCityCdCntyCd() == ", " ? "[,]" : $"{x.GetCityCdCntyCd()}"));

            List<string> agentCdDistinctData = agentMappings.Select(x => x.AGENT_CD).Distinct().ToList();
            List<string> noMappingAgent = await _bscsRepository.FindCustCdNotInAsync(agentCdDistinctData);

            if (noMappingAgent.Any())
                noMappingMessage += (noMappingMessage == "" ? "" : "<br /><br />") + L["ShippingAgentName"] + " " + L["NotMapped"] + "：<br />"
                    + String.Join("<br />", noMappingAgent.Select(x => (String.IsNullOrEmpty(x) ? "[]" : $"{x}")));

            if (!String.IsNullOrEmpty(noMappingMessage))
                return new Models.NotificationMessage(noMappingMessage, L["CodeNotFoundInTheSystem"], Models.MessageType.Error);

            #endregion

            #region 對應表添加 空字串直接對應 Null

            cityMappings.Add(new CityMapping() { PORT_NAME = "", CITY_CD = null, CNTY_CD = null });
            agentMappings.Add(new AgentyMapping() { AGENT = null, AGENT_CD = null }); // 代理改為收到空值也會轉成 null，所以不會有 "" 的狀況

            #endregion

            #endregion

            #region 讀取暫存 Excel 資料至 rawExcel

            var query = from t0 in await _bsfrtcentertExcelTempRepository.GetQueryableAsync()
                        where t0.UploaderId == input.userId & t0.IsDeleted == false
                        select t0;

            List<BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp> rawExcel = await AsyncExecuter.ToListAsync(query);

            if (!rawExcel.Any())
                return new Models.NotificationMessage(L["NoDataImported"], L["ImportSuccessful"], msgType: Models.MessageType.Success);

            #endregion

            #region 直接找出 資料有 但 對應表沒有的資料，有找到提前回報於前端並停止任何動作

            List<string> notInMapping = rawExcel.Where(x => !cityMappings.Any(y => x.Origin == y.PORT_NAME || x.Pod == y.PORT_NAME || x.Destination == y.PORT_NAME))
                .SelectMany(x => new string[] { x.Origin != "" ? x.Origin : "[]", x.Pod != "" ? x.Pod : "[]", x.Destination != "" ? x.Destination : "[]" })
                .Distinct().ToList();

            List<string> notInMapping2 = rawExcel.Where(x => !agentMappings.Any(y => x.Agent == y.AGENT) && x.Agent != null)
                .Select(x => x.Agent != "" ? x.Agent : "[]")
                .Distinct().ToList();

            String errMsg = "";
            if (notInMapping.Any())
                errMsg += $"{L["CouldNotFindCorrespondingCity"]}：<br />" + String.Join("<br />", notInMapping.Select(x => $"{x}"));
            if (notInMapping2.Any())
                errMsg += (errMsg != "" ? "<br />" : "") + $"{L["CouldNotFindCorrespondingAgent"]}：<br />" + String.Join("<br />", notInMapping2.Select(x => $"{x}"));

            if (notInMapping.Any() || notInMapping2.Any())
                return new Models.NotificationMessage(errMsg, L["TheFollowingInformationIsNotMatchedByYou"], Models.MessageType.Error);

            #endregion

            // 將原始資料依照船公司與合約日期分組
            var tempExcel_Group = rawExcel.GroupBy(x => new { x.GroupId, x.Cmp, x.Stn, x.Agent, x.Carrier, x.EffectiveDate, x.ValidTill });

            // 到時存多筆用的
            List<BaseTables.Bsfrtcentertms.Bsfrtcentertm> main_array = new();
            List<BaseTables.Bsfrtcentertds.Bsfrtcentertd> detail_array = new();

            List<string> oldJobNo = new();

            foreach (var oneSheet in tempExcel_Group)
            {

                string mainJobNo = await _bsfrtcentertmRepository.GetNextJobNo(oneSheet.Key.Cmp + oneSheet.Key.Stn + DateTime.Now.ToString("yyyyMMdd"));

                // 因為已存入的資料現階段不會真實存進資料庫，而是在SQL交易中，會導致上方取到的永遠都是0001
                while (oldJobNo.Contains(mainJobNo)) mainJobNo = mainJobNo.Increment(); // 此處手動判斷，這次執行有出現過就+1

                oldJobNo.Add(mainJobNo);

                #region 主表資訊

                AgentyMapping mainKeyAgent = agentMappings.Where(x => x.AGENT == oneSheet.Key.Agent).FirstOrDefault() ?? throw new UserFriendlyException(L["Error"]);

                BaseTables.Bsfrtcentertms.Bsfrtcentertm main = new();

                main.GroupId = oneSheet.Key.GroupId;
                main.Cmp = oneSheet.Key.Cmp;
                main.Stn = oneSheet.Key.Stn;
                main.JobNo = mainJobNo;
                // mainJobNo = mainJobNo.Increment(4); // 用過後 +1 下一個單使用就會 +1 // 原本是寫死同一個站 所以舊址讀取一次，但現在這樣就只能每次都讀取
                main.CreateDate = DateTime.Now;
                main.CreateBy = input.userId;
                // main.ModifyDate = DateTime.Now;
                // main.ModifyBy = input.userId;
                main.EffectiveDate = oneSheet.Key.EffectiveDate;
                main.ExpirationDate = oneSheet.Key.ValidTill;
                main.ConfirmFlag = null; // 篩選有篩 30 40 50
                main.ContractNo = (mainKeyAgent.AGENT_CD ?? oneSheet.Key.Carrier) + DateTime.Now.ToString("yyyyMMddHHmm"); // {Agent ?? Carrier}{年4}{月2}{日2}{小時2}{分鐘2}
                BaseTables.Bsfrtcentertms.Bsfrtcentertm confirmOk_main = await _bsfrtcentertmRepository.InsertAsync(main);

                if (confirmOk_main == null)
                    throw new UserFriendlyException(L["主表寫入失敗"]);
                // return "主表寫入失敗";

                #endregion

                foreach (var excelRow in oneSheet)
                {

                    BaseTables.Bsfrtcentertds.Bsfrtcentertd detail = new();

                    #region 必要欄位
                    detail.GroupId = confirmOk_main.GroupId;
                    detail.Cmp = confirmOk_main.Cmp;
                    detail.Stn = confirmOk_main.Stn;
                    detail.JobNo = Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
                    detail.FJobNo = confirmOk_main.JobNo;
                    detail.Dep = "OE";
                    detail.CreateDate = DateTime.Now;
                    detail.CreateBy = input.userId;
                    // detail.ModifyDate = DateTime.Now;
                    // detail.ModifyBy = input.userId;
                    #endregion

                    #region 寫死資料
                    detail.FChargeCd = "OF"; // 費用代碼
                    detail.ChgUnit = "CTN"; // 計費單位 // 避免與其他計費模式混用，燃油費，過路費，之類的
                    detail.MinChg = null; // 計費單價
                    detail.PriceSt = null; // 定價策略
                    detail.BasicPrice = null; // 基本價格
                    #endregion

                    #region Excel資料

                    // 以下的「?? throw new UserFriendlyException(L["Error"])」理論上不可能執行，在上方已有先行驗證沒是否有對應

                    // Agent
                    detail.AgentCd = mainKeyAgent.AGENT_CD;

                    // Carrier // table.TableName;
                    detail.FCarrier = excelRow.Carrier;

                    // ORIGIN // POL_CD 為「起運地/裝貨港代碼」
                    CityMapping POL = cityMappings.Where(x => x.PORT_NAME.Equals(excelRow.Origin)).FirstOrDefault() ?? throw new UserFriendlyException(L["Error"]);
                    detail.PolNm = excelRow.Origin.EmptyToNull();
                    detail.PolCd = POL.CITY_CD;
                    detail.PolCnty = POL.CNTY_CD;

                    // POD // POD_CD 為「卸貨港代碼」
                    CityMapping POD = cityMappings.Where(x => x.PORT_NAME.Equals(excelRow.Pod)).FirstOrDefault() ?? throw new UserFriendlyException(L["Error"]);
                    detail.PodNm = excelRow.Pod.EmptyToNull();
                    detail.PodCd = POD.CITY_CD;
                    detail.PodCnty = POD.CNTY_CD;

                    // DESTINATION // DEST_CD 為「最終目的代碼」
                    CityMapping DEST = cityMappings.Where(x => x.PORT_NAME.Equals(excelRow.Destination)).FirstOrDefault() ?? throw new UserFriendlyException(L["Error"]);
                    detail.DestNm = excelRow.Destination.EmptyToNull();
                    detail.DestCd = DEST.CITY_CD;
                    detail.DestCnty = DEST.CNTY_CD;

                    // Model
                    // CY-CY 目前不確定是不是代表這個
                    detail.FType = "F"; // 計費方式 // 「CY (F) 整櫃」「CFS (L) 散貨」

                    // Currency
                    detail.FCurrency = excelRow.Currency; // 幣別

                    // 20'GP
                    detail.ChgUnit1 = "20'";
                    detail.ChgFlag1 = "@";
                    _ = decimal.TryParse(excelRow.Ic20gp, out decimal ic20);
                    detail.Rate1 = ic20;

                    // 40'GP
                    detail.ChgUnit2 = "40'";
                    detail.ChgFlag2 = "@";
                    _ = decimal.TryParse(excelRow.Ic40gp, out decimal ic40gp);
                    detail.Rate2 = ic40gp;

                    // 40'HQ
                    detail.ChgUnit3 = "40'HQ";
                    detail.ChgFlag3 = "@";
                    _ = decimal.TryParse(excelRow.Ic40gp, out decimal ic40hq);
                    detail.Rate3 = ic40hq;

                    // Transit Time 航程天數
                    detail.FTransit = excelRow.TrasitTime.EmptyToNull();

                    // ETC 截關日
                    detail.Closing = excelRow.Etc.EmptyToNull();

                    // ETD 預計開航時間
                    detail.Etd = excelRow.Etd.EmptyToNull();

                    // ETA 預計到達時間
                    detail.Eta = excelRow.Eta.EmptyToNull();

                    // Free Time 倉儲免租期時間
                    detail.FreeTime = excelRow.FreeTime.EmptyToNull();

                    // Remark
                    detail.FRmk = excelRow.Remark.EmptyToNull();

                    #endregion

                    BaseTables.Bsfrtcentertds.Bsfrtcentertd confirmOk_detail = await _bsfrtcentertdRepository.InsertAsync(detail);

                    if (confirmOk_detail == null) throw new UserFriendlyException("明細儲存錯誤");

                }

            }

            // 刪除暫存的 Excel
            await ClearTemporaryExcel();

            return new Models.NotificationMessage(L["ImportSuccessful"], msgType: Models.MessageType.Success);

        }

        private class CityMapping
        {
            public string PORT_NAME { get; set; }
            public string CITY_CD { get; set; }
            public string CNTY_CD { get; set; }
        }

        private class AgentyMapping
        {
            public string AGENT { get; set; }
            public string AGENT_CD { get; set; }
        }

        #endregion

        #region 回傳 Excel 檔案供使用者下載

        [HttpGet]
        public async Task<IActionResult> GetShippingCostExcelAsync()
        {

            #region 讀取資料放到 'a 物件 queryResult

            var bscodeQuertable = await _bscodeRepository.GetQueryableAsync();
            var bscsQuertable = await _bscsRepository.GetQueryableAsync();
            var bschgcdQuertable = await _bschgcdRepository.GetQueryableAsync();

            // 用 Linq 建立基礎的結構
            var query = from detail in await _bsfrtcentertdRepository.GetQueryableAsync()
                        join main in await _bsfrtcentertmRepository.GetQueryableAsync() on detail.FJobNo equals main.JobNo
                        select new
                        {
                            detail,
                            main,
                            CarrierName = (
                                from bscs in bscsQuertable
                                where bscs.CustCd == detail.FCarrier && (bscs.GroupId == detail.GroupId && bscs.Cmp == detail.Cmp && bscs.Stn == detail.Stn)
                                select new { cr_name = bscs.AbrNm ?? bscs.LocalNm }
                            ).FirstOrDefault().cr_name ?? $"{detail.FCarrier}",
                            // FChargeCdName = (
                            //     from bschgcd in bschgcdQuertable
                            //     where bschgcd.ChgCd == detail.FChargeCd && (bschgcd.GroupId == detail.GroupId && bschgcd.Cmp == detail.Cmp && bschgcd.Stn == detail.Stn) // 因為 bschgcd 沒有 Dep， 到時候條件必須自己加上 bschgcd.Dep = XXXX ，不然一定是錯的
                            //     select new { xxxxx = (L["GetCurrentLanguage"] == "en" ? bschgcd.ChgEnm ?? bschgcd.ChgCnm : bschgcd.ChgCnm ?? bschgcd.ChgEnm) ?? bschgcd.ChgCd }
                            // ).FirstOrDefault().xxxxx ?? "(Null)",
                        };

            // 依據篩選條件篩選篩選資料，透過 lambda 自動造出 SQL
            query = query
                // .WhereIf(!portLoadingCode.IsNullOrWhiteSpace(), x => x.detail.PorCd.Contains(portLoadingCode))
                .Where(x => x.detail.CreateBy.Contains(_currentUser.UserName))
                // .Where(x => (new string[] { "30", "40", "50" }).Contains(x.main.ConfirmFlag))
                .WhereIf(true, x => x.detail.Dep == "OE")
                // .WhereIf(true, x => x.main.ExpirationDate > new DateTime(2023, 01, 14))
                // .OrderBy(x => x.detail.FJobNo).ThenBy(x => x.detail.Seq)
                ;

            // 真實讀取資料
            var queryResult = await AsyncExecuter.ToListAsync(query);

            #endregion

            #region 設定 EXCEL 的欄位

            List<string> excelColumns = new()
            {
                "Agent",
                "Effective Date",
                "Valid Till",
                "Carrier",
                "ORIGIN",
                "POD", "DESTINATION",
                "Model",
                "20'GP",
                "40'GP",
                "40'HQ",
                "Transit Time",
                "ETC",
                "ETD",
                "ETA",
                "Free Time",
                "Remark"
            };

            #endregion

            #region 以 detail.FCarrier 欄位為 key，將 DataTable 加入到 dictionary 中

            var dataTableDict = queryResult
                .GroupBy(x => x.detail.FCarrier)
                .ToDictionary(
                    x => x.Key,
                    x =>
                    {
                        var dataTable = new DataTable();
                        dataTable.TableName = x.Key;

                        foreach (var column in excelColumns)
                            dataTable.Columns.Add(column, typeof(string));

                        foreach (var item in x)
                        {
                            var row = dataTable.NewRow();
                            row["Agent"] = item.detail.AgentCd;
                            row["Effective Date"] = item.main.EffectiveDate;
                            row["Valid Till"] = item.main.ExpirationDate;
                            row["Carrier"] = item.detail.FCarrier;
                            row["ORIGIN"] = item.detail.PolCd;
                            row["POD"] = item.detail.PodCd;
                            row["DESTINATION"] = item.detail.DestCd;
                            row["Model"] = item.detail.FType; // 計費方式 // 「CY (F) 整櫃」「CFS (L) 散貨」
                            row["20'GP"] = item.detail.Rate1; // 這個請在修改，如果未來與其他運價混用，此處錯到爛掉
                            row["40'GP"] = item.detail.Rate2; // 同上
                            row["40'HQ"] = item.detail.Rate3; // 同上
                            row["Transit Time"] = item.detail.FTransit;
                            row["ETC"] = item.detail.Closing;
                            row["ETD"] = item.detail.Etd;
                            row["ETA"] = item.detail.Eta;
                            row["Free Time"] = item.detail.FreeTime;
                            row["Remark"] = item.detail.FRmk;
                            dataTable.Rows.Add(row);
                        }
                        return dataTable;
                    });

            #endregion

            // 將 dictionary 中的 DataTable 加入到同一個 DataSet
            var dataSet = new DataSet();
            foreach (var dataTable in dataTableDict.Values)
            {
                dataSet.Tables.Add(dataTable);
            }

            byte[] byteArray = dataSet.ConvertToExcelByteArray(); // Encoding.ASCII.GetBytes("This is the content of the text file.");

            return new FileContentResult(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "OceanShippingCost.xlsx"
            };
        }

        #endregion

        #region 通用 HTML 樣式

        private String GetModalHtml(String htmlObjectId)
        {
            return "<a href=\"#\" data-bs-toggle=\"modal\" data-bs-target=\"#modal" + htmlObjectId + "\">{0}</a><div class=\"modal fade\" id=\"modal" + htmlObjectId + "\" tabindex=\"-1\" aria-labelledby=\"modalcontent" + htmlObjectId + "\" aria-hidden=\"true\"><div class=\"modal-dialog\"><div class=\"modal-content\"><div class=\"modal-header\"><h1 class=\"modal-title fs-5\" id=\"modalcontent" + htmlObjectId + "\">{1}</h1><button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"modal\" aria-label=\"Close\"></button></div><div class=\"modal-body\"> {2} </div><div class=\"modal-footer\"><button type=\"button\" class=\"btn btn-secondary\" data-bs-dismiss=\"modal\">" + L["Close"] + "</button></div></div></div></div>";
        }

        #endregion

        #region 自訂回傳的格式

        private class DevReturn<T>
        {
            public List<T> value { get; set; }

            public DevReturn(List<T> t)
            {
                value = t;
            }

        }

        #endregion

        #region 轉換排序用字樣

        private static string NormalizeSorting(string sorting, string tableName, string defaultColumn)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"{tableName}.{defaultColumn}";
            }

            #region 自定義欄位轉換

            if (sorting.Contains("sC_NO", StringComparison.OrdinalIgnoreCase))
                return sorting.Replace("sC_NO", "main.ContractNo", StringComparison.OrdinalIgnoreCase);

            #endregion

            return $"{tableName}.{sorting}";
        }

        #endregion

    }
}
