using App.Domain.Core.Cars.Data;
using App.Domain.Core.Cars.Entity;
using App.Infrastructure.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DbAccess.Repository.Ef.CarModelRepo
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarModelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CarModel>> GetAllAsync()
        {
            return await _dbContext.CarModels.ToListAsync();
        }

        public async Task<CarModel> GetByIdAsync(int id)
        {
            return await _dbContext.CarModels.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(CarModel carModel)
        {
           await _dbContext.CarModels.AddAsync(carModel);
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarModel carModel)
        {
            var existingCarModel = await _dbContext.CarModels.FirstOrDefaultAsync(c => c.Id == carModel.Id);

            if (existingCarModel != null) 
            {
                existingCarModel.Name = carModel.Name;
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var model = await _dbContext.CarModels.FindAsync(id);
            if (model != null)
            {
                _dbContext.CarModels.Remove(model);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<bool> IsCarModelUsedAsync(int carModelId)
        {
            var carModel = await _dbContext.CarModels.FirstOrDefaultAsync(c => c.Id == carModelId);

            if (carModel == null)
                return false;

            return await _dbContext.InspectionRequests.AnyAsync(r => r.Car.Model == carModel.Name);
        }

    }
}
