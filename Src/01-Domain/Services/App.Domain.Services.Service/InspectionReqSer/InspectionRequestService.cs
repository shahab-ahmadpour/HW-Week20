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

        public async Task<InspectionRequest> GetRequestByIdAsync(int id)
        {
            return await _requestRepository.GetByIdAsync(id);
        }


        public async Task<List<InspectionRequest>> GetAllRequestsAsync()
        {
            return await _requestRepository.GetAllAsync();
        }

        public async Task<OperationResult> AddRequestAsync(InspectionRequest request)
        {
            if (System.DateTime.Now.Year - request.Car.ProductionYear > 5)
                return OperationResult.Failure("Car is older than 5 years.");

            return await _requestRepository.AddAsync(request);
        }

        public async Task<OperationResult> UpdateRequestAsync(InspectionRequest request)
        {
            return await _requestRepository.UpdateAsync(request);
        }

        public async Task<OperationResult> DeleteRequestAsync(int id)
        {
            return await _requestRepository.DeleteAsync(id);
        }
    }
}
