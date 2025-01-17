using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.OpResult;

namespace App.Domain.Core.Cars.Data
{
    public interface ICarRepository
    {
        Car GetById(int id);
        List<Car> GetAll();
        OperationResult Add(Car car);
        OperationResult Update(Car car);
        OperationResult Delete(int id);
    }
}
