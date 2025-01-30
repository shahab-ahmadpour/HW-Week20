using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.Service
{
    public interface ICarModelService
    {
        Task<List<CarModel>> GetAllModelsAsync();
        Task<CarModel> GetModelByIdAsync(int id);
        Task CreateModelAsync(CarModel carModel);
        Task UpdateModelAsync(CarModel carModel);
        Task DeleteModelAsync(int id);
        Task<bool> IsCarModelUsedAsync(int id);

    }
}
