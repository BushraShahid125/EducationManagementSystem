using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface IExamBoardService
    {
        Task<ExamBoardResponseViewModel> CreateAsync(ExamBoardRequestViewModel model);
        Task<ExamBoardResponseViewModel> UpdateAsync(ExamBoardUpdateViewModel model);
        Task<ExamBoardResponseViewModel> GetByIdAsync(Guid ExamBoardId);
        Task<IEnumerable<ExamBoardResponseViewModel>> GetAllAsync();
    }
}
