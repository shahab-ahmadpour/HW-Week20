using App.Domain.Core.Operators.Data;
using App.Infrastructure.Db.SqlServer.Ef;
using App.Domain.Core.Operators.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.OpResult;

namespace App.Infrastructure.DbAccess.Repository.Ef.OperatorRepo
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly ApplicationDbContext _context;

        public OperatorRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public Operator GetById(int id)
        {
            return _context.Operators.FirstOrDefault(x => x.Id == id);
        }

        public Operator GetByUsername(string username)
        {
            return _context.Operators.FirstOrDefault(x => x.Username == username);
        }

        public List<Operator> GetAll()
        {
            return _context.Operators.ToList();
        }

        public OperationResult Add(Operator op)
        {
            try
            {
                _context.Operators.Add(op);
                _context.SaveChanges();
                return OperationResult.Success("Operator added successfully.");
            }
            catch(System.Exception ex)
            {
                return OperationResult.Failure($"Error adding operator: {ex.Message}");
            }
        }

        public OperationResult Update (Operator op)
        {
            try
            {
                _context.Operators.Update(op);
                _context.SaveChanges();
                return OperationResult.Success("Operator updated successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error updating operator: {ex.Message}");
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                var operatorEntity = _context.Operators.FirstOrDefault(x => x.Id == id);
                if (operatorEntity == null)
                    return OperationResult.Failure("Operator not found.");
                _context.Operators.Remove(operatorEntity);
                _context.SaveChanges();
                return OperationResult.Success("Operator deleted successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error deleting operator: {ex.Message}");
            }
        }

    }
}
