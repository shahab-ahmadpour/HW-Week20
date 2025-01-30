using App.Domain.Core.Operators.AppService;
using App.Domain.Core.Operators.Entity;
using App.Domain.Core.Operators.Service;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppService.OperatorAppSer
{
    public class OperatorAppService : IOperatorAppService
    {
        private readonly IOperatorService _operatorService;

        public OperatorAppService(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        public async Task<Operator> GetOperatorDetailsAsync(int id)
        {
            return await _operatorService.GetOperatorByIdAsync(id);
        }

        public async Task<List<Operator>> GetAllOperatorsAsync()
        {
            return await _operatorService.GetAllOperatorsAsync();
        }

        public async Task<OperationResult> CreateOperatorAsync(Operator op)
        {
            return await _operatorService.AddOperatorAsync(op);
        }

        public async Task<OperationResult> UpdateOperatorAsync(Operator op)
        {
            return await _operatorService.UpdateOperatorAsync(op);
        }

        public async Task<OperationResult> RemoveOperatorAsync(int id)
        {
            return await _operatorService.DeleteOperatorAsync(id);
        }
    }
}
