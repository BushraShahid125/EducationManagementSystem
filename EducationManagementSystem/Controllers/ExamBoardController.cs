using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamBoardController : ControllerBase
    {
        private readonly IExamBoardService _service;

        public ExamBoardController(IExamBoardService service)
        {
            _service = service;
        }

        
        [HttpPost("create-examboard")]
        public async Task<IActionResult> CreateExamBoard(ExamBoardRequestViewModel model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(new
            { 
               Status = ResponseStatus.Success.ToString(),
               Message = ResponseMessages.AddExamBoardSuccessfully,
               Data = result
            });
        }

        [HttpPut("update-examboard")]
        public async Task<IActionResult> UpdateExamBoard(ExamBoardUpdateViewModel model)
        {
            var result = await _service.UpdateAsync(model);
            if (result == null) 
                return NotFound(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.ExamBoardNotFound,
                });
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.UpdateExamBoardSuccessfully,
                Data = result
            });
        }

        [HttpGet("get-examboard-by{ExamboardId}")]
        public async Task<IActionResult> GetExamBoardById(Guid ExamboardId)
        {
            var result = await _service.GetByIdAsync(ExamboardId);
            if (result == null) 
                return NotFound(new 
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message= ResponseMessages.ExamBoardNotFound,
                });
            return Ok(new 
            { 
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.FetchedExamBoardSuccessfully,
                Data = result
            });

        }

        [HttpGet("get-all-examboard")]
        public async Task<IActionResult> GetAllExamBoard()
        {
            var result = await _service.GetAllAsync();
            if (result == null)
            {
                return NotFound(new 
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.ExamBoardNotFound,
                });
            }
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.FetchedExamBoardSuccessfully,
                Data = result
            });
        }
    }
}
