using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Repositories
{
    public class GuardianRepository : IGuardianRepository
    {
        private readonly ApplicationDbContext _context;

        public GuardianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> AddGuardianAsync(ApplicationUser guardian)
        {
            _context.Users.Add(guardian);
            await _context.SaveChangesAsync();
            return guardian;
        }

        public async Task<ApplicationUser> GetGuardianByIdAsync(string guardianId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(a => a.Id == guardianId);
        }


        public async Task<ApplicationUser> UpdateGuardianAsync(ApplicationUser guardian)
        {
            _context.Users.Update(guardian);
            await _context.SaveChangesAsync();
            return guardian;
        }

        public async Task<List<ApplicationUser>> GetAllGuardiansAsync()
        {
            var guardians = await _context.Users 
                .Where(g => g.ApplicationUserTypeId == (int)ApplicationUserTypeEnum.Guardian)
                .Include(g => g.Students)
                .ToListAsync();
            return guardians;
        }
    }
}
