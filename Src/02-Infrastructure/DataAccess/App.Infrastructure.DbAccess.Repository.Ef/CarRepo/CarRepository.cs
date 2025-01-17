using App.Domain.Core.Cars.Data;
using App.Infrastructure.Db.SqlServer.Ef;
using App.Domain.Core.OpResult;
using App.Domain.Core.Cars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DbAccess.Repository.Ef.CarRepo
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car GetById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public OperationResult Add(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return OperationResult.Success("Car added successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error adding car: {ex.Message}");
            }
        }

        public OperationResult Update(Car car)
        {
            try
            {
                _context.Cars.Update(car);
                _context.SaveChanges();
                return OperationResult.Success("Car updated successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error updating car: {ex.Message}");
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                var car = _context.Cars.FirstOrDefault(c => c.Id == id);
                if (car == null)
                    return OperationResult.Failure("Car not found.");

                _context.Cars.Remove(car);
                _context.SaveChanges();
                return OperationResult.Success("Car deleted successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error deleting car: {ex.Message}");
            }
        }

    }
}
