using EducationManagementSystem.Models;

public interface ISubjectExamMappingRepository
{
    Task<SubjectExamMapping> AddAsync(SubjectExamMapping entity);
    Task<IEnumerable<SubjectExamMapping>> GetAllAsync();
    Task<SubjectExamMapping?> GetMappingAsync(Guid subjectId, Guid examBoardId);
}
