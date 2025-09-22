using EducationManagementSystem.Common;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class StudentTuitionController : ControllerBase
{
    private readonly IStudentTuitionService _service;

    public StudentTuitionController(IStudentTuitionService service)
    {
        _service = service;
    }

    [HttpPost("add-or-update")]
    public async Task<IActionResult> AddOrUpdateTuition(StudentTuitionRequestViewModel model)
    {
        var result = await _service.AddOrUpdateStudentTuitionAsync(model);
        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(), 
            Message = ResponseMessages.SaveProfile, 
            Data = result 
        });
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetTuition(string studentId)
    {
        var result = await _service.GetStudentTuitionAsync(studentId);
        if (result == null)
            return NotFound(new 
            { 
                Status = ResponseStatus.Error.ToString(), 
                Message = ResponseMessages.StudentNotFound
            });

        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.fetchedProfile,
            Data = result 
        });
    }
}
