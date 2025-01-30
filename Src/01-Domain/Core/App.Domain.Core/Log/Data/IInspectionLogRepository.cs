using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.Data
{
    public interface IInspectionLogRepository
    {
        Task<InspectionLog> GetByIdAsync(int id);
        Task<List<InspectionLog>> GetAllAsync();
        Task<OperationResult> AddAsync(InspectionLog log);
    }
}
