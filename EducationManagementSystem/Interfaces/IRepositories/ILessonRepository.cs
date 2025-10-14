using EducationManagementSystem.Models;

public interface ILessonRepository
{
    Task <Lesson>AddAsync(Lesson lesson);
    Task<Lesson> GetByIdAsync(int id);
    Task<IEnumerable<Lesson>> GetAllAsync();
    Task <Lesson>UpdateAsync(Lesson lesson);
    Task<int> GetCompletedSessionsAsync(string studentId);
    Task<IEnumerable<Lesson>> GetLessonsByStudentIdAsync(string studentId);
}
