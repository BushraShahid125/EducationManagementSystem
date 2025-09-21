using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardiansController : ControllerBase
    {
        private readonly IGuardianService _guardianService;

        public GuardiansController(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        [HttpPost("add-guardian")]
        public async Task<IActionResult> AddGuardian(GuardianRequestViewModel model)
        {
            var response = await _guardianService.AddGuardianAsync(model);
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.AddGuardianSuccessfully,
                Data = response
            });
        }

        [HttpPut("update-guardian/{id}")]
        public async Task<IActionResult> UpdateGuardian(string Guardianid,GuardianUpdateViewModel model)
        {
            var response = await _guardianService.EditGuardianAsync(Guardianid, model);
            if (response == null)
                return NotFound(new
                {
                    Status = ResponseStatus.Error.ToString(),
                    Message = ResponseMessages.GuardianNotFound,
                    Data = Guardianid
                });

            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.UpdateGuardianSuccessfully,
                Data = response
            });
        }

        [HttpGet("get-all-guardian")]
        public async Task<IActionResult> GetAllGuardian ()
        {
            var response = await _guardianService.GetGuardianListAsync();
            return Ok(new
            {
                Status = ResponseStatus.Success.ToString(),
                Message = ResponseMessages.fetchedGuardianSuccessfully,
                Data= response
            });
        }
    }
}
