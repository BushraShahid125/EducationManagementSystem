using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IGuardianRepository
    {
        Task<ApplicationUser> AddGuardianAsync(ApplicationUser guardian);
        Task<ApplicationUser> UpdateGuardianAsync(ApplicationUser guardian);
        Task<ApplicationUser> GetGuardianByIdAsync(string Guardianid);
        Task<IEnumerable<ApplicationUser>> GetAllGuardiansAsync();
    }
} 