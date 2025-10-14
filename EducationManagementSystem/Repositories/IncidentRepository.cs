using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ApplicationDbContext _context;

        public IncidentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Incident> AddIncidentAsync(Incident model)
        {
            await _context.Incidents.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Incident>> GetAllAsync()
        {
            return await _context.Incidents
                .Include(i => i.Tutor)
                .Include(i => i.Student)
                .OrderByDescending(i => i.Date)
                .ToListAsync();
        }
    }
}