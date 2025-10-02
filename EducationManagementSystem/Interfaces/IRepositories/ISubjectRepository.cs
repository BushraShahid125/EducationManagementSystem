using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface ISubjectRepository
    {
        Task<Subject> CreateAsync(Subject subject);
        Task<Subject> UpdateAsync(Subject subject);
        Task<Subject> GetByIdAsync(Guid subjectId);
        Task<IEnumerable<Subject>> GetAllAsync();
    }
}
