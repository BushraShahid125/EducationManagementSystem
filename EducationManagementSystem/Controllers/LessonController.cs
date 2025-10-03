using Azure;
using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonservice;
    private readonly IAttendanceService _attendanceService;

    public LessonController(ILessonService lessonservice , IAttendanceService attendanceService )
    {
        _lessonservice = lessonservice;
        _attendanceService = attendanceService;
    }

    //   LessonDetail

    [Authorize(Roles = "Admin,Tutor")]
    [HttpPost("create-lesson-details")]
    public async Task<IActionResult> CreateLessonDetails(LessonRequestViewModel model)
    {
        var response = await _lessonservice.CreateAsync(model);
        if(response==null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonAlreadyExist,
            });
        }
        return Ok(new 
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.AddLessonSuccessfully,
            Data = response
        });
    }

    [Authorize(Roles = "Admin,Tutor,Student")]
    [HttpGet("get-lesson-details-by-{lessonId}")]
    public async Task<IActionResult> GetById(int lessonId)
    {
        var result = await _lessonservice.GetByIdAsync(lessonId);
        if (result==null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonNotFound,
            });
        }
        return Ok(new
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.FetchedLessonSuccessfully,
            Data = result
        });
    }

    [Authorize(Roles = "Admin,Tutor")]
    [HttpGet("all-Lessons-details")]
    public async Task<IActionResult> GetAllLessonsDetails()
    {
        var result = await _lessonservice.GetAllAsync();
        if (result==null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonNotFound,
            });
        }
        return Ok(new
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.FetchedLessonSuccessfully,
            Data = result
        });
    }

    [Authorize(Roles = "Admin,Tutor")]
    [HttpPut("update-lesson-detail-by-{lessonId}")]
    public async Task<IActionResult> UpdateLesson(int lessonId, LessonUpdateViewModel model)
    {
        var response = await _lessonservice.UpdateAsync(lessonId, model);
        if (response==null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonNotFound,
            });
        }
        return Ok(new
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.UpdateLessonSuccessfully,
            Data = response
        });
    }

    //   LessonAttendance

    [Authorize(Roles = "Admin,Tutor")]
    [HttpPost("add-attendance")]
    public async Task<IActionResult> AddAttendance(AttendanceRequestViewModel model)
    {
        var response = await _attendanceService.AddAsync(model);

        if (response == null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.AttendanceNotAdded
            });
        }

        return Ok(new
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.AttendanceAddedSuccessfully,
            Data = response
        });
    }

    [Authorize(Roles = "Admin,Tutor,Student")]
    [HttpGet("get-attendance-by-{lessonId}")]
    public async Task<IActionResult> GetAttendanceByLessonId(int lessonId)
    {
        var result = await _attendanceService.GetByLessonIdAsync(lessonId);

        if (result == null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.AttendanceNotFound
            });
        }

        return Ok(new
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.FetchedAttendanceSuccessfully,
            Data = result
        });
    }

    [Authorize(Roles = "Admin,Tutor")]
    [HttpPut("update-attendance-by-{lessonId}")]
    public async Task<IActionResult> UpdateAttendance(int lessonId,AttendanceUpdateViewModel model)
    {
        var response = await _attendanceService.UpdateAsync(lessonId, model);

        if (response == null)
        {
            return BadRequest(new
            {
                Error = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.AttendanceNotFound
            });
        }

        return Ok(new
        {
            Error = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.UpdateAttendanceSuccessfully,
            Data = response
        });
    }
}
