using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface ISubjectService
    {
        Task<SubjectResponseViewModel> CreateSubjectAsync(SubjectRequestViewModel model);
        Task<SubjectResponseViewModel> UpdateSubjectAsync(SubjectUpdateViewModel model);
        Task<SubjectResponseViewModel> GetSubjectByIdAsync(Guid subjectId);
        Task<IEnumerable<SubjectResponseViewModel>> GetAllSubjectsAsync();
    }
}
