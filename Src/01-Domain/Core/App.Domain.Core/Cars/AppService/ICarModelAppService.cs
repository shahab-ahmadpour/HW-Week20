using App.Domain.Core.Cars.Entity;
using App.Domain.Core.SerResult;
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
        ServiceResult CreateModel(CarModel carModel);
        ServiceResult UpdateModel(CarModel carModel);
        ServiceResult DeleteModel(int id);
    }
}
