using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class LessonNoteRepository : ILessonNoteRepository
    {
        public readonly ApplicationDbContext _context;
        public LessonNoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LessonNote?> GetByLessonIdAsync(int lessonId)
        {
            return await _context.LessonNotes
                .FirstOrDefaultAsync(n => n.LessonId == lessonId);
        }

        public async Task<LessonNote> AddAsync(LessonNote note)
        {
            await _context.LessonNotes.AddAsync(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<LessonNote> UpdateAsync(LessonNote note)
        {
            _context.LessonNotes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }
    }
}
