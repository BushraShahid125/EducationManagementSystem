using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class SubjectExamMappingController : ControllerBase
{
    private readonly ISubjectExamMappingService _service;

    public SubjectExamMappingController(ISubjectExamMappingService service)
    {
        _service = service;
    }

    [HttpPost("create-subject-exam-mapping")]
    public async Task<IActionResult> CreateSubjectExamMapping(SubjectExamMappingRequestViewModel request)
    {
        var result = await _service.CreateAsync(request);
        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.FetchedSubjectExamMappingsSuccessfully, 
            Data = result 
        });
    }

    [HttpGet("get-all-subject-exam-mapping")]
    public async Task<IActionResult> GetAllSubjectExamMapping()
    {
        var result = await _service.GetAllAsync();
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.FetchedSubjectExamMappingsSuccessfully,
            Data = result 
        });
    }
}
