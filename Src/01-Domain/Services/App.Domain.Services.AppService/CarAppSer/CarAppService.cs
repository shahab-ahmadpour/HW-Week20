using App.Domain.Core.Cars.Service;
using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Cars.AppService;
using App.Domain.Core.OpResult;

namespace App.Domain.Services.AppService.CarAppSer
{
    public class CarAppService : ICarAppService
    {
        private readonly ICarService _carService;

        public CarAppService(ICarService carService)
        {
            _carService = carService;
        }

        public Car GetCarDetails(int id)
        {
            return _carService.GetCarById(id);
        }

        public List<Car> GetAllCars()
        {
            return _carService.GetAllCar();
        }

        public OperationResult CreateCar (Car car)
        {
            return _carService.AddCar(car);
        }

        public OperationResult UpdateCar (Car car)
        {
            return _carService.UpdateCar(car);
        }

        public OperationResult DeleteCar(int id)
        {
            return _carService.DeleteCar(id);
        }
    }
}
