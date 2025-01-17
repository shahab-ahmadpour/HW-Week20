using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.AppService
{
    public interface IInspectionLogAppService
    {
        InspectionLog GetLogDetails(int id);
        List<InspectionLog> GetAllLogs();
        OperationResult CreateLog(InspectionLog log);
    }
}
