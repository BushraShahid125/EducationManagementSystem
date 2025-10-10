using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class StudentAttendanceRepository : IStudentAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentAttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAttendanceByClassAsync(Guid classId)
        {
            return await _context.Attendances
             .Include(a => a.Student)
             .Include(a => a.Class)
             .Where(a => a.ClassId == classId)
             .ToListAsync();
        }

        public async Task AddAttendanceAsync(List<Attendance> attendances)
        {
            await _context.Attendances.AddRangeAsync(attendances);
            await _context.SaveChangesAsync();
            foreach (var attendance in attendances)
            {
                _context.Entry(attendance).Reference(a => a.Student).Load();
                _context.Entry(attendance).Reference(a => a.Class).Load();
            }
        }

        public async Task<bool> IsAttendanceAlreadyMarkedAsync(Guid classId, DateTime date)
        {
            return await _context.Attendances.AnyAsync(a => a.ClassId == classId && a.Date == date);
        }

        public async Task<bool> IsClassOwnedByInchargeAsync(Guid classId, string inchargeId)
        {
            return await _context.Classes.AnyAsync(c => c.ClassId == classId && c.InchargeId == inchargeId);
        }
    }
}
