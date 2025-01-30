using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Entity;
using App.Endpoints.MVC.HW20.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Endpoints.MVC.HW20.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelAppService _carModelAppService;

        public CarModelController(ICarModelAppService carModelAppService)
        {
            _carModelAppService = carModelAppService;
        }

        /// <summary>
        /// نمایش لیست مدل‌های خودرو
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var carModels = await _carModelAppService.GetAllModelsAsync();

            var viewModel = new CarModelViewModel
            {
                CarModels = carModels ?? new List<CarModel>()
            };

            return View(viewModel);
        }

        /// <summary>
        /// نمایش فرم ایجاد مدل جدید
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// ایجاد مدل جدید خودرو
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CarModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "لطفاً اطلاعات را به درستی وارد کنید.";
                return View(model);
            }

            await _carModelAppService.CreateModelAsync(model);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// نمایش فرم ویرایش مدل خودرو
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _carModelAppService.GetModelByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        /// <summary>
        /// ویرایش مدل خودرو
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(CarModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "لطفاً اطلاعات را به درستی وارد کنید.";
                return View(model);
            }

            await _carModelAppService.UpdateModelAsync(model);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// نمایش فرم تأیید حذف مدل خودرو
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _carModelAppService.GetModelByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        /// <summary>
        /// حذف مدل خودرو
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carModelAppService.DeleteModelAsync(id);
            return RedirectToAction("Index");
        }
    }
}