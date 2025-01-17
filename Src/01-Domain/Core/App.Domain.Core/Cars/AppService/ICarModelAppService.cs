using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.AppService
{
    public interface ICarModelAppService
    {
        List<CarModel> GetAllModels();
        CarModel GetModelById(int id);
        void CreateModel(CarModel carModel);
        void UpdateModel(CarModel carModel);
        void DeleteModel(int id);
    }
}
