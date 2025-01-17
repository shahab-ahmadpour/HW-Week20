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
        Operator GetOperatorDetails(int id);
        List<Operator> GetAllOperators();
        OperationResult CreateOperator(Operator operatorEntity);
        OperationResult UpdateOperator(Operator operatorEntity);
        OperationResult RemoveOperator(int id);
    }
}
