using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Models;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Repositories
{
    public class ExamBoardRepository : IExamBoardRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamBoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExamBoard> CreateAsync(ExamBoard board)
        {
            _context.ExamBoards.Add(board);
            await _context.SaveChangesAsync();
            return board;
        }

        public async Task<ExamBoard> UpdateAsync(ExamBoard board)
        {
            _context.ExamBoards.Update(board);
            await _context.SaveChangesAsync();
            return board;
        }

        public async Task<ExamBoard> GetByIdAsync(Guid ExamBoardId)
        {
            return await _context.ExamBoards.FindAsync(ExamBoardId);
        }

        public async Task<IEnumerable<ExamBoard>> GetAllAsync()
        {
            return await _context.ExamBoards.ToListAsync();
        }
    }
}
