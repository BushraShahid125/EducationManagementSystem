using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationDbContext _context;

    public LessonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Lesson> GetByIdAsync(int id) =>
        await _context.Lessons
        .Include(x => x.Subject)
        .Include(x => x.Venue)
        .Include(x => x.Tutor)
        .Include(x => x.Student)
        .FirstOrDefaultAsync(x => x.LessonId == id);

    public async Task<IEnumerable<Lesson>> GetAllAsync() =>
        await _context.Lessons
            .Include(x => x.Subject)
            .Include(x => x.Venue)
            .Include(x => x.Tutor)
            .Include(x => x.Student)
            .ToListAsync();

    public async Task<Lesson> AddAsync(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();

        return await _context.Lessons
            .Include(x => x.Subject)
            .Include(x => x.Venue)
            .Include(x => x.Tutor)
            .Include(x => x.Student)
            .FirstOrDefaultAsync(x => x.LessonId == lesson.LessonId);
    }

    public async Task<Lesson> UpdateAsync(Lesson lesson)
    {
        _context.Lessons.Update(lesson);
        await _context.SaveChangesAsync();

        return await _context.Lessons
            .Include(x => x.Subject)
            .Include(x => x.Venue)
            .Include(x => x.Tutor)
            .Include(x => x.Student)
            .FirstOrDefaultAsync(x => x.LessonId == lesson.LessonId);
    }

    public async Task DeleteAsync(Lesson lesson)
    {
        _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync();
    }
}
