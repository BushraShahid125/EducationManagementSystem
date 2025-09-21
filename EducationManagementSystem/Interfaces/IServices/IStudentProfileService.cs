using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IService
{
    public interface IStudentProfileService
    {
        Task<StudentProfileViewModel?> GetProfileAsync(string studentId);
        Task<StudentProfileViewModel> AddUpdateProfileAsync(StudentProfileViewModel model);
    }
}