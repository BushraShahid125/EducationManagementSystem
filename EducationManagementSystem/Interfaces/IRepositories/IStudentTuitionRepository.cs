using EducationManagementSystem.Models;

public interface IStudentTuitionRepository
{
    Task<ApplicationUser> AddOrUpdateStudentTuitionAsync(ApplicationUser student);
    Task<ApplicationUser?> GetStudentTuitionByIdAsync(string studentId);
}
