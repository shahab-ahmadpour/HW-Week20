using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.Service
{
    public interface IInspectionLogService
    {
        Task<InspectionLog> GetLogByIdAsync(int id);
        Task<List<InspectionLog>> GetAllLogsAsync();
        Task<OperationResult> AddLogAsync(InspectionLog log);
    }
}
