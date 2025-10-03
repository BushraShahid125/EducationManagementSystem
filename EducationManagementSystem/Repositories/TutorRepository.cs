using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly ApplicationDbContext _context;
        public TutorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser tutor)
        {
            _context.Users.Add(tutor);
            await _context.SaveChangesAsync();
            return tutor;
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser tutor)
        {
            _context.Users.Update(tutor);
            await _context.SaveChangesAsync();
            return tutor;
        }

        public async Task<ApplicationUser> GetByIdAsync(string tutorId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == tutorId && !x.IsArchived);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _context.Users
                .Where(x => !x.IsArchived) 
                .ToListAsync();
        }
    }
}
