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

        public Operator GetOperatorDetails(int id)
        {
            return _operatorService.GetOperatorById(id);
        }
        public List<Operator> GetAllOperators()
        {
            return _operatorService.GetAllOperators();
        }

        public OperationResult CreateOperator(Operator op)
        {
            return _operatorService.AddOperator(op);
        }

        public OperationResult UpdateOperator(Operator op)
        {
            return _operatorService.UpdateOperator(op);
        }

        public OperationResult RemoveOperator(int id)
        {
            return _operatorService.DeleteOperator(id);
        }
    }
}
