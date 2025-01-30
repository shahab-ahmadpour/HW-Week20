using App.Domain.Core.Log.Data;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.Log.Service;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service.InspectionLogSer
{
    public class InspectionLogService : IInspectionLogService
    {
        private readonly IInspectionLogRepository _logRepository;

        public InspectionLogService(IInspectionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<InspectionLog> GetLogByIdAsync(int id)
        {
            return await _logRepository.GetByIdAsync(id);
        }

        public async Task<List<InspectionLog>> GetAllLogsAsync()
        {
            return await _logRepository.GetAllAsync();
        }

        public async Task<OperationResult> AddLogAsync(InspectionLog log)
        {
            return await _logRepository.AddAsync(log);
        }
    }
}
