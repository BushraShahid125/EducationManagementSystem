using EducationManagementSystem.ViewModels;

public interface IStudentTuitionService
{
    Task<StudentTuitionResponseViewModel?> GetStudentTuitionAsync(string studentId);
    Task<StudentTuitionResponseViewModel> AddOrUpdateStudentTuitionAsync(StudentTuitionRequestViewModel model);
}
