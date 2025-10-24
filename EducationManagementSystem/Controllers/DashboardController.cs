using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("summary")]
    public IActionResult GetDashboardSummary()
    {
        var summary = _dashboardService.GetDashboardSummary();
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.GetDashboardSummarySuccessfully,
            Data = summary
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("today-lessons")]
    public IActionResult GetTodayLessons()
    {
        var result = _dashboardService.GetTodayLessons();
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = ResponseMessages.GetTodayLessonsSuccessfully,
            Data = result
        });
    }
}