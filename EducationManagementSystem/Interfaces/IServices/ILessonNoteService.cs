using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Interfaces.IServices
{
    public interface ILessonNoteService
    {
        Task<LessonNoteResponseViewModel> AddAsync(LessonNoteRequestViewModel model);
        Task<LessonNoteResponseViewModel> UpdateAsync(int lessonId, LessonNoteUpdateViewModel model);
        Task<LessonNoteResponseViewModel> GetByLessonIdAsync(int lessonId);
    }
}