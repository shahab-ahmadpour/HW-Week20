using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Cars.Service;
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

        public void CreateModel(CarModel carModel)
        {
            _carModelService.CreateModel(carModel);
        }

        public void UpdateModel(CarModel carModel)
        {
            _carModelService.UpdateModel(carModel);
        }

        public void DeleteModel(int id)
        {
            _carModelService.DeleteModel(id);
        }
    }
}
