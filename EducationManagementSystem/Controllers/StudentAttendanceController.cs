using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Services;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IStudentAttendanceService _attendanceService;

        public AttendanceController(IStudentAttendanceService service)
        {
            _attendanceService = service;
        }

        [Authorize(Roles = "Tutor,Admin")]
        [HttpPost("mark-attendance")]
        public async Task<IActionResult> MarkAttendance(StudentAttendanceRequestViewModel model)
        {
            var inchargeId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _attendanceService.MarkAttendanceAsync(model, inchargeId);

            if (result == null)
                return BadRequest(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.NotAuthorizedOrAlreadyMarked
                });

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AttendanceMarkedSuccessfully,
                Data = result
            });
        }

        [Authorize(Roles = "Tutor,Admin")]
        [HttpGet("get-attendance-by-class/{classId}")]
        public async Task<IActionResult> GetAttendance(Guid classId)
        {
            var result = await _attendanceService.GetAttendanceByClassAsync(classId);
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AttendanceFetchedSuccessfully,
                Data = result
            });
        }
    }
}