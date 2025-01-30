using App.Domain.Core.Log.Data;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.OpResult;
using App.Infrastructure.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
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

        public async Task<InspectionLog> GetByIdAsync(int id)
        {
            return await _context.InspectionLogs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<InspectionLog>> GetAllAsync()
        {
            return await _context.InspectionLogs.ToListAsync();
        }

        public async Task<OperationResult> AddAsync(InspectionLog log)
        {
            try
            {
                await _context.InspectionLogs.AddAsync(log);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Log added successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error adding inspection log: {ex.Message}");
            }
        }

    }
}
