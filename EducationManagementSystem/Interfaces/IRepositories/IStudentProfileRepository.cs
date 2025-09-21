using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IStudentProfileRepository
    {
        Task<ApplicationUser?> GetStudentByIdAsync(string studentId);
        Task AddUpdateProfileAsync(ApplicationUser student);
    }
}
