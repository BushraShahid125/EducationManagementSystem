using EducationManagementSystem.Common;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly IVenueService _venueService;

    public VenueController(IVenueService venueService)
    {
        _venueService = venueService;
    }

    // Add/Venue
    [HttpPost("add-venue")]
    public async Task<IActionResult> AddVenue(VenueRequestViewModel model)
    {
        try
        {
            var result = await _venueService.AddVenueAsync(model);
            return Ok(new
            {
                Status = "Success",
                Message = ResponseMessages.AddVenueSuccessfully,
                Data = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.VenueAlreadyExist
            });
        }
    }

    //    Update/Venue
    [HttpPut("update-venue-{id}")]
    public async Task<IActionResult> UpdateVenue(Guid id,VenueRequestViewModel model)
    {
        var result = await _venueService.UpdateVenueAsync(id, model);
        if (result == null) 
            return NotFound(new 
            {
                Status = ResponseStatus.Error.ToString(),
                Messages = ResponseMessages.VenueNotFound,
                Data = id
            });
        return Ok(new { Status = ResponseStatus.Success.ToString(), Message = ResponseMessages.UpdateVenueSuccessfully, Data = result });
    }

    //   Get/Venue
    [HttpGet("all-venues")]
    public async Task<IActionResult> GetAllVenues(string? searchTerm)
    {
        var venues = await _venueService.GetAllVenuesAsync(searchTerm);
        if (!venues.Any())
        {
            return NotFound(new
            {
                Status = ResponseStatus.Error.ToString(),
                Message = ResponseMessages.VenueNotFound,
            });
        }
        return Ok(new { Status = "Success", Message = ResponseMessages.fetchedVenueSuccessfully, Data = venues });
    }
}