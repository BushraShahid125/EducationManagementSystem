using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface ITutorRepository
    {
        Task<ApplicationUser> CreateAsync(ApplicationUser tutor);
        Task<ApplicationUser> UpdateAsync(ApplicationUser tutor);
        Task<ApplicationUser> GetByIdAsync(string tutorId);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
    }
}
