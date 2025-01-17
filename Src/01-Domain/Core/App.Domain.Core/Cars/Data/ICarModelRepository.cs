using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.Data
{
    public interface ICarModelRepository
    {
        List<CarModel> GetAll();
        CarModel GetById(int id);
        void Add(CarModel carModel);
        void Update(CarModel carModel);
        void Delete(int id);
    }
}
