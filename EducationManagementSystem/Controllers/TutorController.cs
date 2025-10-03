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
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _service;
        public TutorController(ITutorService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-tutor")]
        public async Task<IActionResult> CreateTutor(TutorRequestViewModel model)
        {
            var result = await _service.CreateTutorAsync(model);
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AddTutorSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("tutors/{tutorId}")]
        public async Task<IActionResult> UpdateTutor(String tutorId, TutorUpdateViewModel model)
        {
            var result = await _service.UpdateTutorAsync(tutorId, model);
            if (result == null)
            {
                return NotFound(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.TutorNotFound
                });
            }

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.UpdateTutorSuccessfully,
                Data = result
            });
        }


        [Authorize(Roles = "Admin,Tutor")]
        [HttpGet("tutor-by-{tutorId}")]
        public async Task<IActionResult> GetTutorById(string tutorId)
        {
            var result = await _service.GetTutorByIdAsync(tutorId);
            if (result == null)
                return NotFound(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.TutorNotFound
                });

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.FetchedTutorSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("tutors/search")]
        public async Task<IActionResult> GetAllTutors(TutorSearchRequestViewModel? filter)
        {
            var result = await _service.GetAllTutorsAsync(filter);

            if (result == null || !result.Any())
            {
                return NotFound(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.TutorNotFound
                });
            }

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.TutorsFetchedSuccessfully,
                Data = result
            });
        }

    }
}
