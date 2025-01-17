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
        InspectionRequest GetRequestById(int id);
        List<InspectionRequest> GetAllRequests();
        OperationResult AddRequest(InspectionRequest request);
        OperationResult UpdateRequest(InspectionRequest request);
        OperationResult DeleteRequest(int id);
    }
}
