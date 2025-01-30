using App.Domain.Core.OpResult;
using App.Domain.Core.Request.AppService;
using App.Domain.Core.Request.Entity;
using App.Domain.Core.Request.Service;
using App.Domain.Core.Configurations;
using App.Domain.Core.Log.AppService;
using App.Domain.Core.Log.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Domain.Services.AppService.InspectionReqAppSer
{
    public class InspectionRequestAppService : IInspectionRequestAppService
    {
        private readonly IInspectionRequestService _requestService;
        private readonly IInspectionLogAppService _logAppService;
        private readonly AppSettings _appSettings;

        public InspectionRequestAppService(
            IInspectionRequestService requestService,
            IInspectionLogAppService logAppService,
            IOptions<AppSettings> appSettings)
        {
            _requestService = requestService;
            _logAppService = logAppService;
            _appSettings = appSettings.Value;
        }

        public async Task<InspectionRequest> GetRequestDetailsAsync(int id)
        {
            return await _requestService.GetRequestByIdAsync(id);
        }

        public async Task<List<InspectionRequest>> GetAllRequestsAsync()
        {
            return await _requestService.GetAllRequestsAsync();
        }

        public async Task<OperationResult> CreateRequestAsync(InspectionRequest request)
        {
            var today = DateTime.Now;
            bool isEvenDay = today.Day % 2 == 0;

            if (string.IsNullOrEmpty(request.Car.Manufacturers))
            {
                return await ErrorResultAsync(request, "شرکت سازنده انتخاب نشده است.");
            }

            if ((isEvenDay && request.Car.Manufacturers != "IranKhodro") ||
                (!isEvenDay && request.Car.Manufacturers != "Saipa"))
            {
                return await ErrorResultAsync(request, $"در روزهای {(isEvenDay ? "زوج" : "فرد")} فقط خودروهای {(isEvenDay ? "ایران‌خودرو" : "سایپا")} می‌توانند ثبت درخواست کنند.");
            }

            var allRequests = await _requestService.GetAllRequestsAsync();
            int capacity = isEvenDay ? _appSettings.CapacityForEvenDays : _appSettings.CapacityForOddDays;
            int currentRequests = allRequests.Count(r => r.Date.Date == today.Date);

            if (currentRequests >= capacity)
            {
                return await ErrorResultAsync(request, "ظرفیت امروز تکمیل شده است.");
            }

            if ((today.Year - request.Car.ProductionYear) > 5)
            {
                return await ErrorResultAsync(request, "خودرو شما به دلیل عمر بالای 5 سال نمی‌تواند ثبت درخواست کند.");
            }

            bool existingRequest = allRequests.Any(r => r.Car.LicensePlate == request.Car.LicensePlate && r.Date.Year == today.Year);
            if (existingRequest)
            {
                return await ErrorResultAsync(request, $"این خودرو با پلاک {request.Car.LicensePlate} قبلاً در سال جاری درخواست ثبت کرده است.");
            }

            request.Date = today;
            return await _requestService.AddRequestAsync(request);
        }

        private async Task<OperationResult> ErrorResultAsync(InspectionRequest request, string message)
        {
            await _logAppService.CreateLogAsync(new InspectionLog
            {
                LicensePlate = request.Car.LicensePlate,
                Reason = message,
                Date = DateTime.Now
            });

            return new OperationResult(false, message);
        }

        public async Task<OperationResult> UpdateRequestAsync(InspectionRequest request)
        {
            return await _requestService.UpdateRequestAsync(request);
        }

        public async Task<OperationResult> RemoveRequestAsync(int id)
        {
            return await _requestService.DeleteRequestAsync(id);
        }

    }
}
