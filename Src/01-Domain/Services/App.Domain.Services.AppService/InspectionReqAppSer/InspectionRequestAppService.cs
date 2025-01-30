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

        public InspectionRequest GetRequestDetails(int id)
        {
            return _requestService.GetRequestById(id);
        }

        public List<InspectionRequest> GetAllRequests()
        {
            return _requestService.GetAllRequests();
        }

        public OperationResult CreateRequest(InspectionRequest request)
        {
            var today = DateTime.Now;
            bool isEvenDay = today.Day % 2 == 0;

            if (string.IsNullOrEmpty(request.Car.Manufacturers))
            {
                return ErrorResult(request, "شرکت سازنده انتخاب نشده است.");
            }

            if ((isEvenDay && request.Car.Manufacturers != "IranKhodro") ||
                (!isEvenDay && request.Car.Manufacturers != "Saipa"))
            {
                return ErrorResult(request, $"در روزهای {(isEvenDay ? "زوج" : "فرد")} فقط خودروهای {(isEvenDay ? "ایران‌خودرو" : "سایپا")} می‌توانند ثبت درخواست کنند.");
            }

            int capacity = isEvenDay ? _appSettings.CapacityForEvenDays : _appSettings.CapacityForOddDays;
            int currentRequests = _requestService.GetAllRequests().Count(r => r.Date.Date == today.Date);

            if (currentRequests >= capacity)
            {
                return ErrorResult(request, "ظرفیت امروز تکمیل شده است.");
            }

            if ((today.Year - request.Car.ProductionYear) > 5)
            {
                return ErrorResult(request, "خودرو شما به دلیل عمر بالای 5 سال نمی‌تواند ثبت درخواست کند.");
            }

            bool existingRequest = _requestService.GetAllRequests()
                .Any(r => r.Car.LicensePlate == request.Car.LicensePlate && r.Date.Year == today.Year);

            if (existingRequest)
            {
                return ErrorResult(request, $"این خودرو با پلاک {request.Car.LicensePlate} قبلاً در سال جاری درخواست ثبت کرده است.");
            }

            request.Date = today;
            return _requestService.AddRequest(request);
        }

        private OperationResult ErrorResult(InspectionRequest request, string message)
        {
            _logAppService.CreateLog(new InspectionLog
            {
                LicensePlate = request.Car.LicensePlate,
                Reason = message,
                Date = DateTime.Now
            });

            return new OperationResult(false, message);
        }

        public OperationResult UpdateRequest(InspectionRequest request)
        {
            return _requestService.UpdateRequest(request);
        }

        public OperationResult RemoveRequest(int id)
        {
            return _requestService.DeleteRequest(id);
        }


    }
}
