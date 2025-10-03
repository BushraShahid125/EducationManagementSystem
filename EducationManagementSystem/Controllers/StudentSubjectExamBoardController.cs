using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/students/subjects")]
public class StudentSubjectExamBoardController : ControllerBase
{
    private readonly IStudentSubjectService _service;

    public StudentSubjectExamBoardController(IStudentSubjectService service)
    {
        _service = service;
    }

    [HttpPost("assign-subject-Examboard")]
    public async Task<IActionResult> AssignSubjectExamBoard(StudentSubjectRequestViewModel request)
    {
        var result = await _service.AssignAsync(request);
        if(result==null)
        {
            return BadRequest(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.FailedSubjectAssignment
            });
        }
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.AssignSubjectExamBoard,
            Data = result
        });
    }

    [HttpGet("get-subjects-examboard{studentId}")]
    public async Task<IActionResult> GetSubjectsExamBoard(string studentId)
    {
        var result = await _service.GetStudentSubjectsAsync(studentId);
        if(result==null)
        {
            return NotFound(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.SubjectExamNotFound,
                Data = studentId
            });
        }
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.GetSubjectsExamBoard,
            Data = result
        });
    }

    [HttpDelete("remove-subject{studentSubjectId}")]
    public async Task<IActionResult> RemoveSubject(Guid studentSubjectId)
    {
        await _service.RemoveAsync(studentSubjectId);

        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.RemoveSubjectSuccessfully,
            Data = studentSubjectId
        });
    }

}
