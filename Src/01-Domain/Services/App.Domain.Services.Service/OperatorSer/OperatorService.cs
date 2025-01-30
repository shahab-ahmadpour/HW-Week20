using App.Domain.Core.Operators.Data;
using App.Domain.Core.Operators.Service;
using App.Domain.Core.Operators.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.OpResult;

namespace App.Domain.Services.Service.OperatorSer
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorService(IOperatorRepository operatorRepository)
        {
           _operatorRepository = operatorRepository;
        }

        public async Task<Operator> GetOperatorByIdAsync(int id)
        {
            return await _operatorRepository.GetByIdAsync(id);
        }

        public async Task<Operator> GetOperatorByUsernameAsync(string username)
        {
            return await _operatorRepository.GetByUsernameAsync(username);
        }

        public async Task<List<Operator>> GetAllOperatorsAsync()
        {
            return await _operatorRepository.GetAllAsync();
        }

        public async Task<OperationResult> AddOperatorAsync(Operator op)
        {
            return await _operatorRepository.AddAsync(op);
        }

        public async Task<OperationResult> UpdateOperatorAsync(Operator op)
        {
            return await _operatorRepository.UpdateAsync(op);
        }

        public async Task<OperationResult> DeleteOperatorAsync(int id)
        {
            return await _operatorRepository.DeleteAsync(id);
        }
    }
}
