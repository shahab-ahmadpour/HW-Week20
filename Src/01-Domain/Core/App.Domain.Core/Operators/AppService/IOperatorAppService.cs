using App.Domain.Core.Operators.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operators.AppService
{
    public interface IOperatorAppService
    {
        Task<Operator> GetOperatorDetailsAsync(int id);
        Task<List<Operator>> GetAllOperatorsAsync();
        Task<OperationResult> CreateOperatorAsync(Operator operatorEntity);
        Task<OperationResult> UpdateOperatorAsync(Operator operatorEntity);
        Task<OperationResult> RemoveOperatorAsync(int id);
    }
}
