using AutoMapper.Internal;
using Dolphin.Freight.EntityFrameworkCore;
using Dolphin.Freight.ImportExport.AirImports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace Dolphin.Freight.ReportLog
{
    public class ReportLogRepository : EfCoreRepository<FreightDbContext, ReportLog, Guid>, IReportLogRepository
    {
        IDbContextProvider<FreightDbContext> _dbContextProvider;
        public ReportLogRepository(IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<ReportLog> FindByReportIdAsync(Guid ReportId, string ReportName)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.FirstOrDefaultAsync(x => x.ReportId == ReportId && x.ReportName == ReportName);
        }

        public void InsertByReportIdAsync(ReportLog reportLog)
        {
            var _dbContext = _dbContextProvider.GetDbContext();

            _dbContext.ReportLog.Add(reportLog);
            _dbContext.SaveChanges();
        }

        public void UpdateByReportIdAsync(ReportLog reportLog)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            var rlog = _dbContext.ReportLog.FirstOrDefault(x => x.ReportId == Guid.Parse(reportLog.ReportId.ToString()) && x.ReportName == reportLog.ReportName);
            if (rlog != null)
            {
                rlog.ReportId = reportLog.ReportId;
                rlog.ReportName = reportLog.ReportName;
                rlog.ReportData = reportLog.ReportData;
                rlog.LastUpdateTime = reportLog.LastUpdateTime;

                _dbContext.ReportLog.Update(rlog);
                _dbContext.SaveChanges();
            }            
        }

        public async Task<List<MawbReport>> GetMawbReport()
        {
            var _dbContext = await _dbContextProvider.GetDbContextAsync();

            // Get Air Import Mawb
            var report = _dbContext.AirImportMawbs
                                   .Select(ai => new MawbReport()
                                   {
                                       ReportType = "Air Import",
                                       OverseaAgent = "",
                                       OverseaAgentId = ai.OverseaAgentId,
                                       ConsigneeId = ai.ConsigneeId,
                                       OfficeId = ai.OfficeId
                                   })
                                   .Union(_dbContext.AirExportHawbs
                                                   .Select(ae => new MawbReport()
                                                   {
                                                       ReportType = "Air Export",
                                                       OverseaAgent = ae.OverseaAgent,
                                                       ConsigneeId = ae.ConsigneeId,
                                                       OverseaAgentId = Guid.Empty,
                                                       OfficeId = Guid.Empty    
                                                   })
                                   )
                                   .Union(_dbContext.OceanImportMbls
                                                   .Select(oi => new MawbReport() 
                                                   { 
                                                       ReportType = "Ocean Import",
                                                       OverseaAgent = "",
                                                       OverseaAgentId = oi.MblOverseaAgentId,
                                                       ConsigneeId = oi.MblConsigneeId,
                                                       OfficeId = oi.OfficeId
                                                   })
                                   )
                                   .Union(_dbContext.OceanExportMbls
                                                   .Select(oe => new MawbReport()
                                                   {
                                                       ReportType = "Ocean Export",
                                                       OverseaAgent = "",
                                                       OverseaAgentId = oe.MblOverseaAgentId,
                                                       ConsigneeId= oe.MblConsigneeId,
                                                       OfficeId = oe.OfficeId
                                                   }))
                                  .ToList();

            return report;
        }
    }
}
