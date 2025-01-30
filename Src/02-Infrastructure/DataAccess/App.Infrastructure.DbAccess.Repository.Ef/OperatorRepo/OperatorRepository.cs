using App.Domain.Core.Operators.Data;
using App.Infrastructure.Db.SqlServer.Ef;
using App.Domain.Core.Operators.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.OpResult;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DbAccess.Repository.Ef.OperatorRepo
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly ApplicationDbContext _context;

        public OperatorRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<Operator> GetByIdAsync(int id)
        {
            return await _context.Operators.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Operator> GetByUsernameAsync(string username)
        {
            return await _context.Operators.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<Operator>> GetAllAsync()
        {
            return await _context.Operators.ToListAsync();
        }

        public async Task<OperationResult> AddAsync(Operator op)
        {
            try
            {
                await _context.Operators.AddAsync(op);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Operator added successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error adding operator: {ex.Message}");
            }
        }

        public async Task<OperationResult> UpdateAsync(Operator op)
        {
            try
            {
                _context.Operators.Update(op);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Operator updated successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error updating operator: {ex.Message}");
            }
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                var operatorEntity = await _context.Operators.FirstOrDefaultAsync(x => x.Id == id);
                if (operatorEntity == null)
                    return OperationResult.Failure("Operator not found.");

                _context.Operators.Remove(operatorEntity);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Operator deleted successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error deleting operator: {ex.Message}");
            }
        }
    }
}
