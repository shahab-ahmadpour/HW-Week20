using App.Domain.Core.OpResult;
using App.Domain.Core.Request.AppService;
using App.Domain.Core.Request.Entity;
using App.Domain.Core.Request.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppService.InspectionReqAppSer
{
    public class InspectionRequestAppService : IInspectionRequestAppService
    {
        private readonly IInspectionRequestService _requestService;

        public InspectionRequestAppService(IInspectionRequestService requestService)
        {
            _requestService = requestService;
        }

        public InspectionRequest GetRequestDetails(int id)
        {
            return _requestService.GetRequestById(id);
        }

        public List<InspectionRequest> GetAllRequests()
        {
            return _requestService.GetAllRequests();
        }

        public OperationResult CreateRequest (InspectionRequest request)
        {
            return _requestService.AddRequest(request);
        }

        public OperationResult UpdateRequest (InspectionRequest request)
        {
            return _requestService.UpdateRequest(request);
        }

        public OperationResult RemoveRequest (int id)
        {
            return _requestService.DeleteRequest(id);
        }
    }
}
