using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Cars.Service;
using App.Domain.Core.SerResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppService.CarModelAppSer
{
    public class CarModelAppService : ICarModelAppService
    {
        private readonly ICarModelService _carModelService;

        public CarModelAppService(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        public async Task<List<CarModel>> GetAllModelsAsync()
        {
            return await _carModelService.GetAllModelsAsync();
        }

        public async Task<CarModel> GetModelByIdAsync(int id)
        {
            return await _carModelService.GetModelByIdAsync(id);
        }

        public async Task<ServiceResult> CreateModelAsync(CarModel carModel)
        {
            if (string.IsNullOrWhiteSpace(carModel.Name))
            {
                return new ServiceResult(false, "نام مدل خودرو نمی‌تواند خالی باشد.");
            }

            await _carModelService.CreateModelAsync(carModel);
            return new ServiceResult(true, "مدل خودرو با موفقیت اضافه شد.");
        }

        public async Task<ServiceResult> UpdateModelAsync(CarModel carModel)
        {
            if (await _carModelService.IsCarModelUsedAsync(carModel.Id))
            {
                return new ServiceResult(false, "این مدل خودرو در سیستم استفاده شده است و نمی‌توان آن را ویرایش کرد.");
            }

            await _carModelService.UpdateModelAsync(carModel);
            return new ServiceResult(true, "مدل خودرو ویرایش شد.");
        }

        public async Task<ServiceResult> DeleteModelAsync(int id)
        {
            if (await _carModelService.IsCarModelUsedAsync(id))
            {
                return new ServiceResult(false, "این مدل خودرو در سیستم استفاده شده است و نمی‌توان آن را حذف کرد.");
            }

            await _carModelService.DeleteModelAsync(id);
            return new ServiceResult(true, "مدل خودرو حذف شد.");
        }
    }
}
