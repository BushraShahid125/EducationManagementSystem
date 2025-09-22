using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Services;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class StudentProfileController : ControllerBase
{
    private readonly IStudentProfileService _profileService;

    public StudentProfileController(IStudentProfileService profileService)
    {
        _profileService = profileService;
    }


    //  Add-Update/Profile
    [HttpPost("profile-Add-Update")]
    public async Task<IActionResult> AddUpdateProfile(StudentProfileViewModel model)
    {
        var result = await _profileService.AddUpdateProfileAsync(model);
        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(), 
            Message = "Profile Saved Successfully", 
            Data = result 
        });
    }


    // GET api/studentprofile/{studentId}
    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetProfile(string studentId)
    {
        var profile = await _profileService.GetProfileAsync(studentId);
        if (profile == null)
            return BadRequest(new 
            { 
                Status = ResponseStatus.Error.ToString(), 
                Message = "Profile not found"
            });
        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(), 
            Message = "StudentProfile Fetched Successfully", 
            Data = profile
        });
    }
}
