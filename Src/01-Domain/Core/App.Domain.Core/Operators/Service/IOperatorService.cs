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
        Operator GetOperatorById(int id);
        Operator GetOperatorByUsername(string username);
        List<Operator> GetAllOperators();
        OperationResult AddOperator(Operator operatorEntity);
        OperationResult UpdateOperator(Operator operatorEntity);
        OperationResult DeleteOperator(int id);
    }
}
