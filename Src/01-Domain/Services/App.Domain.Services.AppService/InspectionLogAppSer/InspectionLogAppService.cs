using App.Domain.Core.Log.AppService;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.Log.Service;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppService.InspectionLogAppSer
{
    public class InspectionLogAppService : IInspectionLogAppService
    {
        private readonly IInspectionLogService _logService;

        public InspectionLogAppService(IInspectionLogService logService)
        {
            _logService = logService;
        }

        public InspectionLog GetLogDetails(int id)
        {
            return _logService.GetLogById(id);
        }

        public List<InspectionLog> GetAllLogs()
        {
            return _logService.GetAllLogs();
        }

        public OperationResult CreateLog(InspectionLog log)
        {
            return _logService.AddLog(log);
        }

    }
}
