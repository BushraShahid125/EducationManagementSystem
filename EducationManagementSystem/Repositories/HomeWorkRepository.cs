using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

public class HomeWorkRepository : IHomeWorkRepository
{
    private readonly ApplicationDbContext _context;

    public HomeWorkRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HomeWork> AddHomeWorkAsync(HomeWork homework)
    {
        _context.HomeWorks.Add(homework);
        await _context.SaveChangesAsync();
        return homework;
    }

    public async Task<IEnumerable<HomeWork>> GetHomeWorksAsync()
    {
        return await _context.HomeWorks
            .Include(h => h.Subject)
            .Include(h => h.Tutor)
            .ToListAsync();
    }

    public async Task<HomeWork> GetHomeWorkByIdAsync(int homeworkId)
    {
        return await _context.HomeWorks
            .FirstOrDefaultAsync(a => a.HomeWorkId == homeworkId);
    }

    public async Task<HomeWork> UpdateHomeWorkAsync(HomeWork homeWork)
    {
        _context.HomeWorks.Update(homeWork);
        await _context.SaveChangesAsync();
        return homeWork;
    }
}
