using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.ViewModels;

namespace EducationManagementSystem.Services
{
    public class ExamBoardService : IExamBoardService
    {
        private readonly IExamBoardRepository _repository;

        public ExamBoardService(IExamBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExamBoardResponseViewModel> CreateAsync(ExamBoardRequestViewModel model)
        {
            var board = Mapper.MapRequestToExamBoard(model);
            var created = await _repository.CreateAsync(board);
            return Mapper.MapExamBoardToResponse(created);
        }

        public async Task<ExamBoardResponseViewModel> UpdateAsync(ExamBoardUpdateViewModel model)
        {
            var board = await _repository.GetByIdAsync(model.ExamBoardId);
            if (board == null) 
                return null;

            Mapper.MapUpdateToExamBoard(model, board);
            var updated = await _repository.UpdateAsync(board);
            return Mapper.MapExamBoardToResponse(updated);
        }

        public async Task<ExamBoardResponseViewModel> GetByIdAsync(Guid ExamBoardId)
        {
            var board = await _repository.GetByIdAsync(ExamBoardId);
            return Mapper.MapExamBoardToResponse(board);
        }

        public async Task<IEnumerable<ExamBoardResponseViewModel>> GetAllAsync()
        {
            var boards = await _repository.GetAllAsync();
            return boards.Select(Mapper.MapExamBoardToResponse);
        }
    }
}
