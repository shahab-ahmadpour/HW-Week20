using App.Domain.Core.Operators.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operators.Data
{
    public interface IOperatorRepository
    {
        Task<Operator> GetByIdAsync(int id);
        Task<Operator> GetByUsernameAsync(string username);
        Task<List<Operator>> GetAllAsync();
        Task<OperationResult> AddAsync(Operator operatorEntity);
        Task<OperationResult> UpdateAsync(Operator operatorEntity);
        Task<OperationResult> DeleteAsync(int id);
    }
}
