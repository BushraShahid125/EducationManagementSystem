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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-subject")]
        public async Task<IActionResult> CreateSubject(SubjectRequestViewModel model)
        {
            var result = await _service.CreateSubjectAsync(model);
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AddSubjectSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-subject")]
        public async Task<IActionResult> UpdateSubject(SubjectUpdateViewModel model)
        {
            var result = await _service.UpdateSubjectAsync(model);
            if (result == null)
                return NotFound(new
                { 
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.SubjectNotFound 
                });
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.UpdateSubjectSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Admin,Student,Tutor")]
        [HttpGet("get-subject-by-{subjectId}")]
        public async Task<IActionResult> GetSubjectById(Guid subjectId)
        {
            var result = await _service.GetSubjectByIdAsync(subjectId);
            if (result == null)
                return NotFound(new 
                { 
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.SubjectNotFound 
                });
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.FetchedSubjectSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Admin,Student,Tutor")]
        [HttpGet("get-all-subjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var result = await _service.GetAllSubjectsAsync();
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.SubjectsFetchedSuccessfully,
                Data = result
            });
        }
    }
}
