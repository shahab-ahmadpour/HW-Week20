using App.Domain.Core.Request.Data;
using App.Infrastructure.Db.SqlServer.Ef;
using App.Domain.Core.Request.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.OpResult;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DbAccess.Repository.Ef.InspectionRequestRepo
{
    public class InspectionRequestRepository : IInspectionRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public InspectionRequestRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<InspectionRequest> GetByIdAsync(int id)
        {
            return await _context.InspectionRequests
                .Include(r => r.Car)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<InspectionRequest>> GetAllAsync()
        {
            return await _context.InspectionRequests
                .Include(r => r.Car)
                .ToListAsync();
        }

        public async Task<OperationResult> AddAsync(InspectionRequest request)
        {
            try
            {
                await _context.InspectionRequests.AddAsync(request);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Inspection request added successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error adding inspection request: {ex.Message}");
            }
        }

        public async Task<OperationResult> UpdateAsync(InspectionRequest request)
        {
            try
            {
                _context.InspectionRequests.Update(request);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Inspection request updated successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error updating inspection request: {ex.Message}");
            }
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                var request = await _context.InspectionRequests.FirstOrDefaultAsync(r => r.Id == id);
                if (request == null)
                    return OperationResult.Failure("Inspection request not found.");

                _context.InspectionRequests.Remove(request);
                await _context.SaveChangesAsync();
                return OperationResult.Success("Inspection request deleted successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error deleting inspection request: {ex.Message}");
            }
        }
    }
}
