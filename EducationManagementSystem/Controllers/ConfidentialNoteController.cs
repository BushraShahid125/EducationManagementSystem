using EducationManagementSystem.Common;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static EducationManagementSystem.Common.Enums;

[Route("api/[controller]")]
[ApiController]
public class ConfidentialNoteController : ControllerBase
{
    private readonly IConfidentialNoteService _service;

    public ConfidentialNoteController(IConfidentialNoteService service)
    {
        _service = service;
    }

    [HttpPost("AddConfidentialNote")]
    public async Task<IActionResult> AddConfidentialNote(ConfidentialNoteRequestViewModel model)
    {
        var result = await _service.AddNoteAsync(model);
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.ConfidentialNoteAddSuccessfully,
            Data = result
        });
    }

    [HttpGet("Get-note-by-student/{studentId}")]
    public async Task<IActionResult> GetByStudentId(string studentId)
    {
        var result = await _service.GetByStudentIdAsync(studentId);
        if(result == null) 
            return NotFound(new
            { 
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.ConfidentialNoteNotFound
            });
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.GetConfidentialNoteSuccessfully,
            Data = result
        });
    }

    [HttpPut("Update-ConfidentialNote-by-{noteId}")]
    public async Task<IActionResult> Update(int noteId,ConfidentialNoteUpdateViewModel model)
    {
        var result = await _service.UpdateNoteAsync(noteId, model);
        if (result == null)
            return NotFound(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.ConfidentialNoteNotFound
            });
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.ConfidentialNoteUpdateSuccessfully,
            Data = result
        });
    }
}