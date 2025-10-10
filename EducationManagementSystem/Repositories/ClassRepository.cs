using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Class> AddClassAsync(Class entity)
        {
            await _context.Classes.AddAsync(entity);
            await _context.SaveChangesAsync();
            if (!string.IsNullOrEmpty(entity.InchargeId))
            {
                entity.Incharge = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == entity.InchargeId);
            }
            return entity;
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _context.Classes
                .Include(c => c.Incharge)
                .ToListAsync();
        }

        public async Task<Class> GetClassByInchargeIdAsync(string inchargeId)
        {
            return await _context.Classes
                .Include(c => c.Incharge)
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.InchargeId == inchargeId);
        }

        public async Task<Class> GetByIdAsync(Guid classId)
        {
            return await _context.Classes
                .Include(c => c.Incharge)
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.ClassId == classId);
        }
        public async Task<ApplicationUser?> GetStudentByIdAsync(string studentId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == studentId);
        }

        public async Task<Class> AddStudentToClassAsync(Guid classId, string studentId)
        {
            var classEntity = await _context.Classes
                .Include(c => c.Students)
                .Include(c => c.Incharge)
                .FirstOrDefaultAsync(c => c.ClassId == classId);

            var student = await _context.Users.FindAsync(studentId);

            if (classEntity == null || student == null)
                return null;

            student.ClassId = classId;
            classEntity.Students.Add(student);

            await _context.SaveChangesAsync();
            return classEntity;
        }
    }
}