using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IService
{
    public interface ISubjectExamMappingService
    {
        Task<SubjectExamMappingResponseViewModel> CreateAsync(SubjectExamMappingRequestViewModel request);
        Task<IEnumerable<SubjectExamMappingResponseViewModel>> GetAllAsync();
    }
}
