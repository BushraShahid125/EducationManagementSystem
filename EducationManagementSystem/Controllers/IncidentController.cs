using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Services;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    [HttpPost("add-incident")]
    public async Task<IActionResult> AddIncident(IncidentRequestViewModel model)
    {
        var incident = await _incidentService.AddIncidentAsync(model);

        if (incident == null)
            return BadRequest(new 
            { 
                Status = ResponseStatus.Error.ToString(), 
                Message = ResponseMessages.FailedToAddIncident
            });

        return Ok(new 
        { 
            Status = ResponseStatus.Success.ToString(), 
            Message =ResponseMessages.IncidentAddSuccessfully, 
            Data = incident
        });
    }

    [HttpGet("get-incident-list")]
    public async Task<IActionResult> GetIncidents([FromQuery] IncidentSearchRequestViewModel request)
    {
        var result = await _incidentService.GetIncidentsAsync(request);

        if (!result.Items.Any())
        {
            return NotFound(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.IncidentNotFound
            });
        }
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.GetIncidentSuccessfully,
            Data = result
        });
    }
}
