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

        public List<CarModel> GetAllModels()
        {
            return _carModelService.GetAllModels();
        }

        public CarModel GetModelById(int id)
        {
            return _carModelService.GetModelById(id);
        }
        public ServiceResult CreateModel(CarModel carModel)
        {
            if (string.IsNullOrWhiteSpace(carModel.Name))
            {
                return new ServiceResult(false, "نام مدل خودرو نمی‌تواند خالی باشد.");
            }

            _carModelService.CreateModel(carModel);
            return new ServiceResult(true, "مدل خودرو با موفقیت اضافه شد.");
        }

        public ServiceResult UpdateModel(CarModel carModel)
        {
            if (_carModelService.IsCarModelUsed(carModel.Id))
            {
                return new ServiceResult(false, "این مدل خودرو در سیستم استفاده شده است و نمی‌توان آن را ویرایش کرد.");
            }

            _carModelService.UpdateModel(carModel);
            return new ServiceResult(true, "مدل خودرو ویرایش شد.");
        }

        public ServiceResult DeleteModel(int id)
        {
            if (_carModelService.IsCarModelUsed(id))
            {
                return new ServiceResult(false, "این مدل خودرو در سیستم استفاده شده است و نمی‌توان آن را حذف کرد.");
            }

            _carModelService.DeleteModel(id);
            return new ServiceResult(true, "مدل خودرو حذف شد.");
        }
    }
}
