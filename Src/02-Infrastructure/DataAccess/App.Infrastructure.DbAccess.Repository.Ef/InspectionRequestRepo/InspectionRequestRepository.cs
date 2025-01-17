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

        public InspectionRequest GetById(int id)
        {
            return _context.InspectionRequests.FirstOrDefault(x => x.Id == id);
        }

        public List<InspectionRequest> GetAll()
        {
            return _context.InspectionRequests.Include(r => r.Car).ToList();
        }

        public OperationResult Add(InspectionRequest request)
        {
            try
            {
                _context.InspectionRequests.Add(request);
                _context.SaveChanges();
                return OperationResult.Success("Inspection request added successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error adding inspection request: {ex.Message}");
            }
        }

        public OperationResult Update(InspectionRequest request)
        {
            try
            {
                _context.InspectionRequests.Update(request);
                _context.SaveChanges();
                return OperationResult.Success("Inspection request updated successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error updating inspection request: {ex.Message}");
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                var request = _context.InspectionRequests.FirstOrDefault(r => r.Id == id);
                if (request == null)
                    return OperationResult.Failure("Inspection request not found.");

                _context.InspectionRequests.Remove(request);
                _context.SaveChanges();
                return OperationResult.Success("Inspection request deleted successfully.");
            }
            catch (System.Exception ex)
            {
                return OperationResult.Failure($"Error deleting inspection request: {ex.Message}");
            }
        }
    }
}
