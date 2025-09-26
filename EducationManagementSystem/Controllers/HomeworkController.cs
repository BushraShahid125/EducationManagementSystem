using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeWorksController : ControllerBase
    {
        private readonly IHomeWorkService _homeWorkService;

        public HomeWorksController(IHomeWorkService homeWorkService)
        {
            _homeWorkService = homeWorkService;
        }

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPost("add-homework")]
        public async Task<IActionResult> AddHomeWork(HomeWorkRequestViewModel model)
        {
            var result = await _homeWorkService.AddHomeWorkAsync(model);

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AddHomeworkSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPut("update-homework/{homeworkid}")]
        public async Task<IActionResult> UpdateHomeWork(int homeworkid, HomeWorkUpdateViewModel model)
        {
            var result = await _homeWorkService.UpdateHomeWorkAsync(homeworkid, model);
            if (result==null)
                return BadRequest(new 
                { 
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.HomeworkNotFound,
                    Data = homeworkid
                });
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.UpdateHomeworkSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Teacher,Student,Guardian,Admin")]
        [HttpGet("get-all-homeworks")]
        public async Task<IActionResult> GetAllHomeWorks()
        {
            var response = await _homeWorkService.GetHomeWorksAsync();

            if (!response.Any())
            {
                return NotFound(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.HomeworkNotFound
                });
            }

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.FetchedHomeworkSuccessfully,
                Data = response
            });
        }
    }
}
