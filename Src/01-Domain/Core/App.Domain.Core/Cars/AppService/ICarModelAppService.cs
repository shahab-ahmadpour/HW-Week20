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
        Task<List<CarModel>> GetAllModelsAsync();
        Task<CarModel> GetModelByIdAsync(int id);
        Task<ServiceResult> CreateModelAsync(CarModel carModel);
        Task<ServiceResult> UpdateModelAsync(CarModel carModel);
        Task<ServiceResult> DeleteModelAsync(int id);
    }
}
