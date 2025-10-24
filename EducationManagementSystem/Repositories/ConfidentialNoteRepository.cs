using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

public class ConfidentialNoteRepository : IConfidentialNoteRepository
{
    private readonly ApplicationDbContext _context;

    public ConfidentialNoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ConfidentialNote>> GetByStudentIdAsync(string studentId)
    {
        return await _context.ConfidentialNotes
            .Include(x => x.Lesson).ThenInclude(l => l.Subject)
            .Include(x => x.Tutor)
            .Include(x => x.Incident)
            .Where(x => x.StudentId == studentId)
            .ToListAsync();
    }

    public async Task<ConfidentialNote> GetByNoteIdAsync(int ConfidentialNoteid)
    {
        return await _context.ConfidentialNotes
            .Include(x => x.Lesson).ThenInclude(l => l.Subject)
            .Include(x => x.Tutor)
            .Include(x => x.Incident)
            .FirstOrDefaultAsync(x => x.ConfidentialNoteId == ConfidentialNoteid);
    }

    public async Task<ConfidentialNote> AddNoteAsync(ConfidentialNote note)
    {
        _context.ConfidentialNotes.Add(note);
        await _context.SaveChangesAsync();
        return await _context.ConfidentialNotes
            .Include(n => n.Lesson)
                .ThenInclude(l => l.Subject)
            .Include(n => n.Tutor)
            .Include(n => n.Student)
            .FirstOrDefaultAsync(n => n.ConfidentialNoteId == note.ConfidentialNoteId);
    }

    public async Task<ConfidentialNote> UpdateNoteAsync(ConfidentialNote note)
    {
        _context.ConfidentialNotes.Update(note);
        await _context.SaveChangesAsync();
        return note;
    }
}