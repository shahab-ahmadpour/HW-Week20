using App.Domain.Core.OpResult;
using App.Domain.Core.Request.Data;
using App.Domain.Core.Request.Entity;
using App.Domain.Core.Request.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service.InspectionReqSer
{
    public class InspectionRequestService : IInspectionRequestService
    {
        private readonly IInspectionRequestRepository _requestRepository;

        public InspectionRequestService(IInspectionRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public InspectionRequest GetRequestById(int id)
        {
            return _requestRepository.GetById(id);
        }

        public List<InspectionRequest> GetAllRequests()
        {
            return _requestRepository.GetAll();
        }

        public OperationResult AddRequest(InspectionRequest request)
        {
            if(System.DateTime.Now.Year - request.Car.ProductionYear > 5)
                return OperationResult.Failure("Car is older than 5 years.");

            return _requestRepository.Add(request);
        }
        public OperationResult UpdateRequest(InspectionRequest request)
        {
            return _requestRepository.Update(request);
        }

        public OperationResult DeleteRequest(int id)
        {
            return _requestRepository.Delete(id);
        }
    }
}
