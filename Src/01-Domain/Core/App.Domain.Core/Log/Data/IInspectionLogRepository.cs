using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.Data
{
    public interface IInspectionLogRepository
    {
        InspectionLog GetById(int id);
        List<InspectionLog> GetAll();
        OperationResult Add(InspectionLog log);
    }
}
