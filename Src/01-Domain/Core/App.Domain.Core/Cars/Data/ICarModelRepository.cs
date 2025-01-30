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
        Task<List<CarModel>> GetAllAsync();
        Task<CarModel> GetByIdAsync(int id);
        Task AddAsync(CarModel carModel);
        Task UpdateAsync(CarModel carModel);
        Task DeleteAsync(int id);
        Task<bool> IsCarModelUsedAsync(int carModelId);
    }
}
