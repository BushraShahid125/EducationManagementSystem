using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class StudentGroupRepository : IStudentGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentGroup> AddStudentGroupAsync(StudentGroup studentGroup)
        {
            _context.StudentGroups.Add(studentGroup);
            await _context.SaveChangesAsync();  
            return 
                studentGroup;
        }
        public async Task<IEnumerable<StudentGroup>> GetAllStudentGroupAsync()
        {
            return 
                await _context.StudentGroups.ToListAsync();
        }

        public async Task<ICollection<StudentGroup>> GetStudentGroupsWithFilterAsync()
        {
            return 
                await _context.StudentGroups.ToListAsync();
        }
    }

}
