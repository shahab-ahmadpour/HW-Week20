using App.Domain.Core.Cars.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.Service
{
    public interface ICarService
    {
        Car GetCarById(int id);
        List<Car> GetAllCar();
        OperationResult AddCar(Car car);
        OperationResult UpdateCar(Car car);
        OperationResult DeleteCar(int id);

    }
}
