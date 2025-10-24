using Azure;
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
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonservice;
    private readonly ILessonNoteService _lessonNoteService;

    public LessonController(ILessonService lessonservice , ILessonNoteService lessonNoteService)
    {
        _lessonservice = lessonservice;
        _lessonNoteService = lessonNoteService;
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
        var response = await _lessonservice.AddAsync(model);

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
        var result = await _lessonservice.GetByIdAsync(lessonId);

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
        var response = await _lessonservice.UpdateAsync(lessonId, model);

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

    //    Lesson Note

    [Authorize(Roles = "Admin,Tutor")]
    [HttpPost("AddLessonNote")]
    public async Task<IActionResult> AddLessonNote(LessonNoteRequestViewModel model)
    {
        var result = await _lessonNoteService.AddAsync(model);
        if (result == null)
            return NotFound(new 
            { 
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonNotFound
            });
        return Ok(new
        { 
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.LessonNoteAddSuccessfully,
            Data = result
        });

       
    }

    [Authorize(Roles = "Admin,Tutor")]
    [HttpPut("UpdateLessonNote/{lessonId}")]
    public async Task<IActionResult> UpdateLessonNote(int lessonId, LessonNoteUpdateViewModel model)
    {
        var result = await _lessonNoteService.UpdateAsync(lessonId, model);
        if (result == null)
            return NotFound(new 
            { 
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonNoteNotFound
            });

        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(), 
            Message = ResponseMessages.LessonNoteUpdateSuccessfully, 
            Data = result 
        });
    }

    [Authorize(Roles = "Admin,Tutor,Student")]
    [HttpGet("GetLessonNote/{lessonId}")]
    public async Task<IActionResult> GetLessonNote(int lessonId)
    {
        var result = await _lessonNoteService.GetByLessonIdAsync(lessonId);
        if (result == null)
            return NotFound(new 
            { 
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.LessonNoteNotFound
            });

        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(),
            Message =  ResponseMessages.GetLessonNoteSuccessfully,
            Data = result 
        });
    }


}
