using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IStudentSubjectRepository
    {
        Task<StudentSubject> AddAsync(StudentSubject entity);
        Task<IEnumerable<StudentSubject>> GetByStudentIdAsync(string studentId);
        Task RemoveAsync(Guid studentSubjectId);
    }
}