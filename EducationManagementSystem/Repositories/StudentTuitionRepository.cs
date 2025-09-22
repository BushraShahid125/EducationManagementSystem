using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;


public class StudentTuitionRepository : IStudentTuitionRepository
{
    private readonly ApplicationDbContext _context;

    public StudentTuitionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> GetStudentTuitionByIdAsync(string studentId)
    {
        return await _context.Users
            .Include(s => s.Venue)
            .Include(s => s.Guardian)
            .FirstOrDefaultAsync(s => s.Id == studentId);
    }

    public async Task<ApplicationUser> AddOrUpdateStudentTuitionAsync(ApplicationUser student)
    {
        _context.Users.Update(student); 
        await _context.SaveChangesAsync();
        return student;
    }
}
