using App.Domain.Core.Log.AppService;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.Log.Service;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppService.InspectionLogAppSer
{
    public class InspectionLogAppService : IInspectionLogAppService
    {
        private readonly IInspectionLogService _logService;

        public InspectionLogAppService(IInspectionLogService logService)
        {
            _logService = logService;
        }
        public async Task<InspectionLog> GetLogDetailsAsync(int id)
        {
            return await _logService.GetLogByIdAsync(id);
        }

        public async Task<List<InspectionLog>> GetAllLogsAsync()
        {
            return await _logService.GetAllLogsAsync();
        }

        public async Task<OperationResult> CreateLogAsync(InspectionLog log)
        {
            return await _logService.AddLogAsync(log);
        }
    }
}
