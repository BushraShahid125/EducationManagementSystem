using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface ILessonNoteRepository
    {
        Task<LessonNote?> GetByLessonIdAsync(int lessonId);
        Task<LessonNote> AddAsync(LessonNote note);
        Task<LessonNote> UpdateAsync(LessonNote note);
    }
}