using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IExamBoardRepository
    {
        Task<ExamBoard> CreateAsync(ExamBoard board);
        Task<ExamBoard> UpdateAsync(ExamBoard board);
        Task<ExamBoard> GetByIdAsync(Guid ExamBoardId);
        Task<IEnumerable<ExamBoard>> GetAllAsync();
    }
}
