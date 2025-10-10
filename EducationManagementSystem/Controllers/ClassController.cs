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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-class")]
        public async Task<IActionResult> AddClass(ClassRequestViewModel model)
        {
            var result = await _classService.AddClassAsync(model);

            if(result==null)
            {
                return BadRequest(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.FailedToAddClass
                });
            }

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AddClassSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet("get-all-classes")]
        public async Task<IActionResult> GetAllClasses()
        {
            var result = await _classService.GetAllClassesAsync();
            if (!result.Any())
            { 
                return NotFound(new 
                { 
                    Status = ResponseStatus.Error.ToString(), 
                    Message = ResponseMessages.ClassNotFound 
                });
            }

            return Ok(new 
            { 
                Status = ResponseStatus.Success.ToString(), 
                Message = ResponseMessages.FetchedClassSuccessfully, 
                Data = result 
            });
        }

        [Authorize(Roles = "Teacher,Admin")]
        [HttpGet("get-class-by-incharge/{inchargeId}")]
        public async Task<IActionResult> GetClassByInchargeId(string inchargeId)
        {
            var result = await _classService.GetClassByInchargeIdAsync(inchargeId);
            if (result == null)
                return NotFound(new 
                { 
                    Status = ResponseStatus.Error.ToString(), 
                    Message = ResponseMessages.ClassNotFound 
                });

            return Ok(new 
            { 
                Status = ResponseStatus.Success.ToString(), 
                Message = ResponseMessages.FetchedClassSuccessfully, 
                Data = result 
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudentToClass(AddStudentToClassViewModel model)
        {
            var result = await _classService.AddStudentToClassAsync(model);
            if (result == null)
                return BadRequest(new 
                { 
                    Status = ResponseStatus.Error.ToString(), 
                    Message = ResponseMessages.FailedToAddStudent
                });

            return Ok(new 
            { 
                Status = ResponseStatus.Success.ToString(), 
                Message = ResponseMessages.StudentAddedSuccessfully, 
                Data = result 
            });
        }
    }
}
