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
        InspectionRequest GetRequestDetails(int id);
        List<InspectionRequest> GetAllRequests();
        OperationResult CreateRequest(InspectionRequest request);
        OperationResult UpdateRequest(InspectionRequest request);
        OperationResult RemoveRequest(int id);
    }
}
