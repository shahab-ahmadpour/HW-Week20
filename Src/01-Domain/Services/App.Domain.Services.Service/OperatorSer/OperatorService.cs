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

        public Operator GetOperatorById(int id)
        {
            return _operatorRepository.GetById(id);
        }

        public Operator GetOperatorByUsername(string username)
        {
            return _operatorRepository.GetByUsername(username);
        }

        public List<Operator> GetAllOperators()
        {
            return _operatorRepository.GetAll();
        }

        public OperationResult AddOperator(Operator op)
        {
            return _operatorRepository.Add(op);
        }

        public OperationResult UpdateOperator(Operator op)
        {
            return _operatorRepository.Update(op);
        }

        public OperationResult DeleteOperator(int id)
        {
            return _operatorRepository.Delete(id);
        }
    }
}
