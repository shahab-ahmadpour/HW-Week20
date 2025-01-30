using App.Domain.Core.Cars.Data;
using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Cars.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service.CarModelSer
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public async Task<List<CarModel>> GetAllModelsAsync()
        {
            return await _carModelRepository.GetAllAsync();
        }

        public async Task<CarModel> GetModelByIdAsync(int id)
        {
            return await _carModelRepository.GetByIdAsync(id);
        }

        public async Task CreateModelAsync(CarModel carModel)
        {
            await _carModelRepository.AddAsync(carModel);
        }

        public async Task UpdateModelAsync(CarModel carModel)
        {
            await _carModelRepository.UpdateAsync(carModel);
        }

        public async Task DeleteModelAsync(int id)
        {
            await _carModelRepository.DeleteAsync(id);
        }

        public async Task<bool> IsCarModelUsedAsync(int id)
        {
            return await _carModelRepository.IsCarModelUsedAsync(id);
        }
    }
}
