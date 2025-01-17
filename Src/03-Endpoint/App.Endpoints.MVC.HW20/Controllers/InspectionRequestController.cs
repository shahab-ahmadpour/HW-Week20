using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Configurations;
using App.Domain.Core.Log.AppService;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.Request.AppService;
using App.Domain.Core.Request.Entity;
using App.Endpoints.MVC.HW20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using App.Endpoints.MVC.HW20.Helper;
using App.Domain.Core.Cars.AppService;

namespace App.Endpoints.MVC.HW20.Controllers
{
    public class InspectionRequestController : Controller
    {
        private readonly IInspectionRequestAppService _requestAppService;
        private readonly IInspectionLogAppService _logAppService;
        private readonly AppSettings _appSettings;
        private readonly ICarModelAppService _carModelAppService;

        public InspectionRequestController(
            IInspectionRequestAppService requestAppService,
            IInspectionLogAppService logAppService,
            IOptions<AppSettings> appSettings, ICarModelAppService carModelAppService)
        {
            _requestAppService = requestAppService;
            _logAppService = logAppService;
            _appSettings = appSettings.Value;
            _carModelAppService = carModelAppService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetCarModelsInViewBag();
            return View(new InspectionRequest());
        }

        [HttpPost]
        public IActionResult Create(InspectionRequest request)
        {
            SetCarModelsInViewBag();

            if (string.IsNullOrEmpty(request.Car.Manufacturers))
            {
                AddToLog(request, "شرکت سازنده انتخاب نشده است.");
                ViewBag.ErrorMessage = "لطفاً شرکت سازنده را انتخاب کنید.";
                return View(request);
            }

            var today = DateTime.Now;
            bool isEvenDay = DaysOfWeek.IsEvenDayOfWeek(today.DayOfWeek);

            if (isEvenDay && request.Car.Manufacturers != "IranKhodro")
            {
                AddToLog(request, "در روزهای زوج فقط خودروهای ایران‌خودرو می‌توانند ثبت درخواست کنند.");
                ViewBag.ErrorMessage = "در روزهای زوج فقط خودروهای ایران‌خودرو می‌توانند ثبت درخواست کنند.";
                return View(request);
            }
            else if (!isEvenDay && request.Car.Manufacturers != "Saipa")
            {
                AddToLog(request, "در روزهای فرد فقط خودروهای سایپا می‌توانند ثبت درخواست کنند.");
                ViewBag.ErrorMessage = "در روزهای فرد فقط خودروهای سایپا می‌توانند ثبت درخواست کنند.";
                return View(request);
            }

            var currentRequests = _requestAppService.GetAllRequests()
                .Count(r => r.Date.Date == today.Date);

            int capacity;
            if (isEvenDay)
            {
                capacity = _appSettings.CapacityForEvenDays;
            }
            else
            {
                capacity = _appSettings.CapacityForOddDays;
            }


            if (currentRequests >= capacity)
            {
                AddToLog(request, "ظرفیت امروز تکمیل شده است.");
                ViewBag.ErrorMessage = "ظرفیت امروز تکمیل شده است.";
                return View(request);
            }

            var carAge = today.Year - request.Car.ProductionYear;
            if (carAge > 5)
            {
                AddToLog(request, "خودرو بیش از 5 سال عمر دارد.");
                ViewBag.ErrorMessage = "خودرو شما به دلیل عمر بالای 5 سال نمی‌تواند ثبت درخواست کند.";
                return View(request);
            }

            var existingRequest = _requestAppService.GetAllRequests()
                .FirstOrDefault(r =>
                    r.Car != null &&
                    r.Car.LicensePlatePart1 == request.Car.LicensePlatePart1 &&
                    r.Car.LicensePlateLetter == request.Car.LicensePlateLetter &&
                    r.Car.LicensePlatePart2 == request.Car.LicensePlatePart2 &&
                    r.Car.LicensePlatePart3 == request.Car.LicensePlatePart3 &&
                    r.Date.Year == today.Year);

            if (existingRequest != null)
            {
                var message = $"این خودرو با پلاک : {request.Car.LicensePlatePart1} {request.Car.LicensePlateLetter} {request.Car.LicensePlatePart2} ایران {request.Car.LicensePlatePart3} قبلاً در سال جاری درخواست ثبت کرده است.";
                AddToLog(request, message);
                ViewBag.ErrorMessage = message;
                return View(request);
            }

            request.Date = today;
            var result = _requestAppService.CreateRequest(request);

            if (!result.IsSuccess)
            {
                AddToLog(request, result.Message);
                ViewBag.ErrorMessage = result.Message;
                return View(request);
            }

            ViewBag.SuccessMessage = "درخواست شما با موفقیت ثبت شد.";
            return RedirectToAction("Success");
        }



        public IActionResult Success()
        {
            return View();
        }

        void SetCarModelsInViewBag()
        {
            var carModels = _carModelAppService.GetAllModels();
            ViewBag.CarModels = carModels ?? new List<CarModel>();
        }

        void AddToLog(InspectionRequest request, string reason)
        {
            _logAppService.CreateLog(new InspectionLog
            {
                LicensePlate = $"{request.Car.LicensePlatePart1} {request.Car.LicensePlateLetter} {request.Car.LicensePlatePart2} ایران {request.Car.LicensePlatePart3}",
                Reason = reason,
                Date = DateTime.Now
            });
        }
    }
}
