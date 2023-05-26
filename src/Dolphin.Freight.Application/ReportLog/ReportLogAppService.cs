using Dolphin.Freight.Accounting.Inv;
using Dolphin.Freight.Accounting.Payment;
using Dolphin.Freight.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace Dolphin.Freight.ReportLog
{
    public class ReportLogAppService :
        CrudAppService<
            ReportLog,
            ReportLogDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateReportLogDto>,
        IReportLogAppService
    {
        private readonly IReportLogRepository _ReportLogRepository;

        public ReportLogAppService(IRepository<ReportLog, Guid> repository, IReportLogRepository ReportLogRepository)
        : base(repository)
        {
            _ReportLogRepository = ReportLogRepository;
        }

        public async Task<PagedResultDto<MawbReportDto>> GetMawbReport()
        {
            var report = await _ReportLogRepository.GetMawbReport();

            return new PagedResultDto<MawbReportDto>(report.Count, ObjectMapper.Map<List<MawbReport>, List<MawbReportDto>>(report));
        }

        [UnitOfWork]
        public async Task UpdateReportLog(ReportLogDto reportLog)
        {
            IQueryable<ReportLog> queryable = await _ReportLogRepository.GetQueryableAsync();

            var query = from rlog in queryable
                        where rlog.ReportId == reportLog.ReportId && rlog.ReportName == reportLog.ReportName
                        select rlog;

            var reportModel = new ReportLog();
            reportModel.ReportId = reportLog.ReportId;
            reportModel.ReportName = reportLog.ReportName;
            reportModel.ReportData = reportLog.ReportData;
            reportModel.LastUpdateTime = reportLog.LastUpdateTime;

            if (query.Count() > 0)
            {
                #region Update

                _ReportLogRepository.UpdateByReportIdAsync(reportModel);   
                
                #endregion
            }
            else 
            {
                #region Insert

                _ReportLogRepository.InsertByReportIdAsync(reportModel);
                
                #endregion
            }
        }

        [UnitOfWork]
        public async Task<ReportLogDto> QueryReportLog(ReportLogDto reportLog)
        {
            var query = await _ReportLogRepository.FindByReportIdAsync(reportLog.ReportId, reportLog.ReportName);

            return ObjectMapper.Map<ReportLog, ReportLogDto>(query);
        }
    }
}