using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Entity;
using App.Endpoints.MVC.HW20.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.HW20.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelAppService _carModelAppService;

        public CarModelController(ICarModelAppService carModelAppService)
        {
            _carModelAppService = carModelAppService;
        }

        public IActionResult Index()
        {
            var carModels = _carModelAppService.GetAllModels();

            if (carModels == null)
            {
                carModels = new List<CarModel>();
            }

            var viewModel = new CarModelViewModel
            {
                CarModels = carModels
            };

            return View(viewModel);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "لطفاً اطلاعات را به درستی وارد کنید.";
                return View(model);
            }

            _carModelAppService.CreateModel(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = _carModelAppService.GetModelById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CarModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "لطفاً اطلاعات را به درستی وارد کنید.";
                return View(model);
            }

            _carModelAppService.UpdateModel(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _carModelAppService.GetModelById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _carModelAppService.DeleteModel(id);
            return RedirectToAction("Index");
        }
    }
}
