using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentSubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentSubject> AddAsync(StudentSubject entity)
        {
            _context.StudentSubjects.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<StudentSubject>> GetByStudentIdAsync(string studentId)
        {
            return await _context.StudentSubjects
                .Include(ss => ss.SubjectExamMapping)
                    .ThenInclude(se => se.Subject)
                .Include(ss => ss.SubjectExamMapping)
                    .ThenInclude(se => se.Exam)
                .Where(ss => ss.ApplicationUserId == studentId)
                .ToListAsync();
        }

        public async Task RemoveAsync(Guid studentSubjectId)
        {
            var entity = await _context.StudentSubjects.FindAsync(studentSubjectId);
            if (entity != null)
            {
                _context.StudentSubjects.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
