using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

public class SubjectExamMappingRepository : ISubjectExamMappingRepository
{
    private readonly ApplicationDbContext _context;

    public SubjectExamMappingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SubjectExamMapping> AddAsync(SubjectExamMapping entity)
    {
        _context.SubjectExamMappings.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<SubjectExamMapping>> GetAllAsync()
    {
        return await _context.SubjectExamMappings.ToListAsync();
    }

    public async Task<SubjectExamMapping?> GetMappingAsync(Guid subjectId, Guid examBoardId)
    {
        return await _context.SubjectExamMappings
            .FirstOrDefaultAsync(x => x.SubjectId == subjectId && x.ExamId == examBoardId);
    }
}
