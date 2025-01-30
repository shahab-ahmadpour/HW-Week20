using App.Domain.Core.OpResult;
using App.Domain.Core.Request.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.AppService
{
    public interface IInspectionRequestAppService
    {
        Task<InspectionRequest> GetRequestDetailsAsync(int id);
        Task<List<InspectionRequest>> GetAllRequestsAsync();
        Task<OperationResult> CreateRequestAsync(InspectionRequest request);
        Task<OperationResult> UpdateRequestAsync(InspectionRequest request);
        Task<OperationResult> RemoveRequestAsync(int id);
    }
}
