using EducationManagementSystem.Common;
using EducationManagementSystem.ViewModels;

public interface ILessonService
{
    Task<LessonResponseViewModel> CreateAsync(LessonRequestViewModel model);
    Task<LessonResponseViewModel> GetByIdAsync(int lessonId);
    Task<IEnumerable<LessonResponseViewModel>> GetAllAsync();
    Task<LessonResponseViewModel?> UpdateAsync(int lessonId, LessonUpdateViewModel model);
}
