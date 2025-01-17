using App.Domain.Core.Cars.Data;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Cars.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service.CarModelSer
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public List<CarModel> GetAllModels()
        {
            return _carModelRepository.GetAll();
        }

        public CarModel GetModelById(int id)
        {
            return _carModelRepository.GetById(id);
        }

        public void CreateModel(CarModel carModel)
        {
            _carModelRepository.Add(carModel);
        }

        public void UpdateModel(CarModel carModel)
        {
            _carModelRepository.Update(carModel);
        }

        public void DeleteModel(int id)
        {
            _carModelRepository.Delete(id);
        }
    }
}
