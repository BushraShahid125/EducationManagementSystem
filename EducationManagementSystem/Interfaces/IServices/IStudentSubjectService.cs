using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IService
{
    public interface IStudentSubjectService
    {
        Task<StudentSubjectResponseViewModel> AssignAsync(StudentSubjectRequestViewModel request);
        Task<IEnumerable<StudentSubjectResponseViewModel>> GetStudentSubjectsAsync(string studentId);
        Task RemoveAsync(Guid studentSubjectId);
    }
}