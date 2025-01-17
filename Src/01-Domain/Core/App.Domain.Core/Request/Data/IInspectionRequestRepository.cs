using App.Domain.Core.OpResult;
using App.Domain.Core.Request.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.Data
{
    public interface IInspectionRequestRepository
    {
        InspectionRequest GetById(int id);
        List<InspectionRequest> GetAll();
        OperationResult Add(InspectionRequest request);
        OperationResult Update(InspectionRequest request);
        OperationResult Delete(int id);
    }
}
