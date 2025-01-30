using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.OpResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpGet]
        [SwaggerOperation(Summary = "دریافت لیست مدل‌های خودرو", Description = "این متد تمام مدل‌های خودرو را برمی‌گرداند.")]
        [SwaggerResponse(200, "لیست مدل‌های خودرو", typeof(List<CarModel>))]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public async Task<IActionResult> GetAllModelsAsync([FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var carModels = await _carModelAppService.GetAllModelsAsync();
            return Ok(carModels);
        }

        /// <summary>
        /// دریافت اطلاعات یک مدل خودرو بر اساس ID
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "دریافت یک مدل خودرو", Description = "مدل خودرو مشخص‌شده را بر اساس ID برمی‌گرداند.")]
        [SwaggerResponse(200, "مدل خودرو یافت شد", typeof(CarModel))]
        [SwaggerResponse(404, "مدل خودرو یافت نشد")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public async Task<ActionResult<CarModel>> GetByIdAsync(int id, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var model = await _carModelAppService.GetModelByIdAsync(id);
            if (model == null)
                return NotFound("مدل خودرو یافت نشد!");

            return Ok(model);
        }

        /// <summary>
        /// ایجاد یک مدل خودرو جدید
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "ایجاد مدل خودرو", Description = "یک مدل خودرو جدید در سیستم اضافه می‌کند.")]
        [SwaggerResponse(200, "مدل خودرو با موفقیت اضافه شد.")]
        [SwaggerResponse(400, "ورودی نامعتبر")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public async Task<ActionResult> CreateAsync([FromBody] CarModel model, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var result = await _carModelAppService.CreateModelAsync(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok("مدل خودرو با موفقیت اضافه شد.");
        }

        /// <summary>
        /// ویرایش اطلاعات یک مدل خودرو
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "ویرایش مدل خودرو", Description = "مدل خودرو مشخص‌شده را بر اساس ID ویرایش می‌کند.")]
        [SwaggerResponse(200, "مدل خودرو با موفقیت ویرایش شد.")]
        [SwaggerResponse(400, "ورودی نامعتبر")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public async Task<ActionResult> EditAsync(int id, [FromBody] CarModel model, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            model.Id = id;
            var result = await _carModelAppService.UpdateModelAsync(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok("مدل خودرو با موفقیت ویرایش شد.");
        }

        /// <summary>
        /// حذف یک مدل خودرو بر اساس ID
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "حذف مدل خودرو", Description = "مدل خودرو مشخص‌شده را بر اساس ID حذف می‌کند.")]
        [SwaggerResponse(200, "مدل خودرو با موفقیت حذف شد.")]
        [SwaggerResponse(400, "این مدل خودرو در سیستم استفاده شده است و نمی‌توان آن را حذف کرد.")]
        [SwaggerResponse(401, "دسترسی غیرمجاز")]
        public async Task<ActionResult> DeleteAsync(int id, [FromHeader] string apiKey)
        {
            if (!IsAuthorized(apiKey))
                return Unauthorized("دسترسی غیرمجاز!");

            var result = await _carModelAppService.DeleteModelAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok("مدل خودرو با موفقیت حذف شد.");
        }
    }
}