using App.Domain.Core.Operators.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operators.Service
{
    public interface IOperatorService
    {
        Task<Operator> GetOperatorByIdAsync(int id);
        Task<Operator> GetOperatorByUsernameAsync(string username);
        Task<List<Operator>> GetAllOperatorsAsync();
        Task<OperationResult> AddOperatorAsync(Operator operatorEntity);
        Task<OperationResult> UpdateOperatorAsync(Operator operatorEntity);
        Task<OperationResult> DeleteOperatorAsync(int id);
    }
}
