using App.Domain.Core.Cars.Data;
using App.Domain.Core.Cars.Entity;
using App.Infrastructure.Db.SqlServer.Ef;
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

        public List<CarModel> GetAll()
        {
            return _dbContext.CarModels.ToList();
        }

        public CarModel GetById(int id)
        {
            return _dbContext.CarModels.FirstOrDefault(x => x.Id == id);
        }
        public void Add(CarModel carModel)
        {
            _dbContext.CarModels.Add(carModel);
            _dbContext.SaveChanges();
        }

        public void Update(CarModel carModel)
        {
            var existingCarModel = _dbContext.CarModels.FirstOrDefault(c => c.Id == carModel.Id);

            if (existingCarModel != null) 
            {
                existingCarModel.Name = carModel.Name;
                _dbContext.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            var model = _dbContext.CarModels.Find(id);
            if (model != null)
            {
                _dbContext.CarModels.Remove(model);
                _dbContext.SaveChanges();
            }
        }
        public bool IsCarModelUsed(int carModelId)
        {
            var carModel = _dbContext.CarModels.FirstOrDefault(c => c.Id == carModelId);

            if (carModel == null)
                return false;

            return _dbContext.InspectionRequests.Any(r => r.Car.Model == carModel.Name);
        }

    }
}
