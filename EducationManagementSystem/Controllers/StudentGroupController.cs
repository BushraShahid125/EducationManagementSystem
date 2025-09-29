using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.Services;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController : ControllerBase
{
    private readonly IStudentGroupService _StudentGroupService;

    public StudentGroupController(IStudentGroupService StudentGroupService)
    {
        _StudentGroupService = StudentGroupService;
    }

    // Add/StudentGroup
    [Authorize(Roles = "Admin")]
    [HttpPost("add-student-group")]
    public async Task<IActionResult> AddStudentGroup(StudentGroupRequestViewModel model)
    {
        try
        {
            var result = await _StudentGroupService.AddStudentGroupAsync(model);
            return Ok(new
            {
                Status = "Success",
                Message = ResponseMessages.AddStudentGroupSuccessfully,
                Data = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ex.Message
            });
        }
    }

    //   Get/StudentGroups
    [Authorize(Roles = "Admin,Tutor")]
    [HttpGet("all-student-groups")]
    public async Task<IActionResult> GetAllStudentGroups([FromQuery] StudentGroupSearchViewModel filter)
    {
        var groups = await _StudentGroupService.GetAllStudentGroupsAsync(filter);

        if (!groups.Any())
        {
            return NotFound(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.StudentGroupNotFound,
            });
        }

        return Ok(new
        {
            Status = "Success",
            Message = ResponseMessages.fetchedStudentGroup,
            Data = groups
        });
    }
}