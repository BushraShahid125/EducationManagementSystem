using EducationManagementSystem.Models;

namespace EducationManagementSystem.Interfaces.IRepositories
{
    public interface IAttendanceRepository
    {
        Task<Lesson> AddAsync(Lesson lesson);
        Task<Lesson?> GetByLessonIdAsync(int lessonId);
        Task<Lesson> UpdateAsync(Lesson lesson);
    }
}
