using App.Domain.Core.Log.Data;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.Log.Service;
using App.Domain.Core.OpResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service.InspectionLogSer
{
    public class InspectionLogService : IInspectionLogService
    {
        private readonly IInspectionLogRepository _logRepository;

        public InspectionLogService(IInspectionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public InspectionLog GetLogById(int id)
        {
            return _logRepository.GetById(id);
        }

        public List<InspectionLog> GetAllLogs()
        {
            return _logRepository.GetAll();
        }

        public OperationResult AddLog(InspectionLog log)
        {
            return _logRepository.Add(log);
        }

    }
}
