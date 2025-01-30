﻿using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Request.AppService;
using App.Domain.Core.Request.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.HW20.Controllers
{
    public class InspectionRequestController : Controller
    {
        private readonly IInspectionRequestAppService _requestAppService;
        private readonly ICarModelAppService _carModelAppService;

        public InspectionRequestController(
            IInspectionRequestAppService requestAppService,
            ICarModelAppService carModelAppService)
        {
            _requestAppService = requestAppService;
            _carModelAppService = carModelAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CarModels = await _carModelAppService.GetAllModelsAsync();
            return View(new InspectionRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create(InspectionRequest request)
        {
            ViewBag.CarModels = await _carModelAppService.GetAllModelsAsync();
            var result = await _requestAppService.CreateRequestAsync(request);

            if (!result.IsSuccess)
            {
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
    }
}
