using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Services;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    //  AddStudentDetails
    [Authorize(Roles ="Admin")]
    [HttpPost("add-student-detail")]
    public async Task<IActionResult> AddStudentDetail(StudentCreateViewModel dto)
    {
        var student = await _studentService.AddStudentDetailsAsync(dto);

        if (student == null)
            return BadRequest(new { Status = ResponseStatus.Error.ToString(), Message = "Failed to Create Student" });

        var response = Mapper.MapStudentToStudentResponseViewModel(student);
        return Ok(new { Status = ResponseStatus.Success.ToString(), Message = "Student Created Successfully", Data = response });
    }
}
