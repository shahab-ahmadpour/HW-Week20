using App.Domain.Core.OpResult;
using App.Domain.Core.Request.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.Data
{
    public interface IInspectionRequestRepository
    {
        Task<InspectionRequest> GetByIdAsync(int id);
        Task<List<InspectionRequest>> GetAllAsync();
        Task<OperationResult> AddAsync(InspectionRequest request);
        Task<OperationResult> UpdateAsync(InspectionRequest request);
        Task<OperationResult> DeleteAsync(int id);
    }
}
