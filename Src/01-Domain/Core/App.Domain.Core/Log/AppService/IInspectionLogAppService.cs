using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.AppService
{
    public interface IInspectionLogAppService
    {
        Task<InspectionLog> GetLogDetailsAsync(int id);
        Task<List<InspectionLog>> GetAllLogsAsync();
        Task<OperationResult> CreateLogAsync(InspectionLog log);
    }
}
