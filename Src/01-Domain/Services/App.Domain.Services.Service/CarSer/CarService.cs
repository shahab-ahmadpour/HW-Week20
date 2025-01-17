using App.Domain.Core.Cars.Data;
using App.Domain.Core.Cars.Service;
using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.OpResult;

namespace App.Domain.Services.Service.CarSer
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Car GetCarById(int id)
        {
            return _carRepository.GetById(id);
        }

        public List<Car> GetAllCar ()
        {
            return _carRepository.GetAll();
        }

        public OperationResult AddCar (Car car)
        {
            var fullLicensePlate = $"{car.LicensePlatePart1} {car.LicensePlateLetter} {car.LicensePlatePart2} ایران {car.LicensePlatePart3}";
            var existingCar = _carRepository.GetAll().Find(x => x.LicensePlate == fullLicensePlate);
            if (existingCar != null)
                return OperationResult.Failure("Car with the same license plate already exists.");

            return _carRepository.Add(car);
        }

        public OperationResult UpdateCar (Car car)
        {
            var existingCar = _carRepository.GetById (car.Id);
            if (existingCar == null)
                return OperationResult.Failure("Car not found.");

            return _carRepository.Update(car);
        }

        public OperationResult DeleteCar(int id)
        {
            var existingCar = _carRepository.GetById(id);
            if (existingCar == null)
                return OperationResult.Failure("Car not found.");

            return _carRepository.Delete(id);
        }
    }
}
