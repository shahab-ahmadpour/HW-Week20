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
        Operator GetById(int id);
        Operator GetByUsername(string username);
        List<Operator> GetAll();
        OperationResult Add(Operator operatorEntity);
        OperationResult Update(Operator operatorEntity);
        OperationResult Delete(int id);
    }
}
