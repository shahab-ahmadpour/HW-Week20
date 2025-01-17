using App.Domain.Core.Cars.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.AppService
{
    public interface ICarAppService
    {
        Car GetCarDetails(int id);
        List<Car> GetAllCars();
        OperationResult CreateCar(Car car);
        OperationResult UpdateCar(Car car);
        OperationResult DeleteCar(int id);

    }
}
