using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationManagementSystem.Repositories
{
    public class StudentProfileRepository : IStudentProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetStudentByIdAsync(string studentId)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task AddUpdateProfileAsync(ApplicationUser student)
        {
            _context.Users.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
