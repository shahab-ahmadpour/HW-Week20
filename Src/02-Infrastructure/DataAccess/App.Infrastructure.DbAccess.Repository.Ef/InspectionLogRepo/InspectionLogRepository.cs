using App.Domain.Core.Log.Data;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using App.Infrastructure.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DbAccess.Repository.Ef.InspectionLogRepo
{
    public class InspectionLogRepository : IInspectionLogRepository
    {
        private readonly ApplicationDbContext _context;

        public InspectionLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public InspectionLog GetById(int id)
        {
            return _context.InspectionLogs.FirstOrDefault(x => x.Id == id);
        }

        public List<InspectionLog> GetAll()
        {
            return _context.InspectionLogs.ToList();
        }

        public OperationResult Add (InspectionLog log)
        {
            try
            {
                _context.InspectionLogs.Add(log);
                _context.SaveChanges();
                return OperationResult.Success("Log added successfully.");
            }
            catch(System.Exception ex)
            {
                return OperationResult.Failure($"Error adding inspection log: {ex.Message}");
            }


        }

    }
}
