using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.OpResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace App.Endpoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelAppService _carModelAppService;
        private readonly string _apiKey;

        public CarModelController(ICarModelAppService carModelAppService, IConfiguration configuration)
        {
            _carModelAppService = carModelAppService;
            _apiKey = configuration["AppSettings:ApiKey"];
        }

        private bool IsAuthorized(string key)
        {
            return key == _apiKey;
        }


        /// <summary>
        /// دریافت لیست تمام مدل‌های خودرو
        /// </summary>
        /// <param name="apiKey">کلید API برای احراز هویت</param>
        /// <returns>لیست مدل‌های خودرو</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "دریافت لیست مدل‌های خودرو", Description = "این متد تمام مدل‌های خودرو را برمی‌گرداند.")]
        [SwaggerResponse(200, "لیست مدل‌های خودرو", typeof(List<CarModel>))]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public IActionResult GetAllModels([FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var carModels = _carModelAppService.GetAllModels();
            return Ok(carModels);
        }


        /// <summary>
        /// دریافت اطلاعات یک مدل خودرو بر اساس ID
        /// </summary>
        /// <param name="id">شناسه مدل خودرو</param>
        /// <param name="apiKey">کلید API برای احراز هویت</param>
        /// <returns>مدل خودرو مورد نظر</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "دریافت یک مدل خودرو", Description = "مدل خودرو مشخص‌شده را بر اساس ID برمی‌گرداند.")]
        [SwaggerResponse(200, "مدل خودرو یافت شد", typeof(CarModel))]
        [SwaggerResponse(404, "مدل خودرو یافت نشد")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public ActionResult<CarModel> GetById(int id, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var model = _carModelAppService.GetModelById(id);
            if (model == null)
                return NotFound("مدل خودرو یافت نشد!");

            return Ok(model);
        }

        /// <summary>
        /// ایجاد یک مدل خودرو جدید
        /// </summary>
        /// <param name="model">اطلاعات مدل خودرو</param>
        /// <param name="apiKey">کلید API برای احراز هویت</param>
        /// <returns>نتیجه عملیات</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "ایجاد مدل خودرو", Description = "یک مدل خودرو جدید در سیستم اضافه می‌کند.")]
        [SwaggerResponse(200, "مدل خودرو با موفقیت اضافه شد.")]
        [SwaggerResponse(400, "ورودی نامعتبر")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public ActionResult Create([FromBody] CarModel model, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var result = _carModelAppService.CreateModel(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok("مدل خودرو با موفقیت اضافه شد.");
        }

        /// <summary>
        /// ویرایش اطلاعات یک مدل خودرو
        /// </summary>
        /// <param name="id">شناسه مدل خودرو</param>
        /// <param name="model">اطلاعات جدید مدل خودرو</param>
        /// <param name="apiKey">کلید API برای احراز هویت</param>
        /// <returns>نتیجه عملیات</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "ویرایش مدل خودرو", Description = "مدل خودرو مشخص‌شده را بر اساس ID ویرایش می‌کند.")]
        [SwaggerResponse(200, "مدل خودرو با موفقیت ویرایش شد.")]
        [SwaggerResponse(400, "ورودی نامعتبر")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public ActionResult Edit(int id, [FromBody] CarModel model, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            model.Id = id;
            var result = _carModelAppService.UpdateModel(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok("مدل خودرو با موفقیت ویرایش شد.");
        }

        /// <summary>
        /// حذف یک مدل خودرو بر اساس ID
        /// </summary>
        /// <param name="id">شناسه مدل خودرو</param>
        /// <param name="apiKey">کلید API برای احراز هویت</param>
        /// <returns>نتیجه عملیات</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "حذف مدل خودرو", Description = "مدل خودرو مشخص‌شده را بر اساس ID حذف می‌کند.")]
        [SwaggerResponse(200, "مدل خودرو با موفقیت حذف شد.")]
        [SwaggerResponse(400, "این مدل خودرو در سیستم استفاده شده است و نمی‌توان آن را حذف کرد.")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public ActionResult Delete(int id, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var result = _carModelAppService.DeleteModel(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok("مدل خودرو با موفقیت حذف شد.");
        }
    }
}
