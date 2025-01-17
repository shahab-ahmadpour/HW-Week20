using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.Service
{
    public interface IInspectionLogService
    {
        InspectionLog GetLogById(int id);
        List<InspectionLog> GetAllLogs();
        OperationResult AddLog(InspectionLog log);
    }
}
