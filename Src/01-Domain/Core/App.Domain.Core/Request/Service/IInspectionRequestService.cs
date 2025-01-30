using App.Domain.Core.OpResult;
using App.Domain.Core.Request.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.Service
{
    public interface IInspectionRequestService
    {
        Task<InspectionRequest> GetRequestByIdAsync(int id);
        Task<List<InspectionRequest>> GetAllRequestsAsync();
        Task<OperationResult> AddRequestAsync(InspectionRequest request);
        Task<OperationResult> UpdateRequestAsync(InspectionRequest request);
        Task<OperationResult> DeleteRequestAsync(int id);
    }
}
