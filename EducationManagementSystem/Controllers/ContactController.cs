using EducationManagementSystem.Common;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;
using System.Threading.Tasks;
using EducationManagementSystem.Interfaces.IService;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // Add Contact
    [HttpPost("add-contact")]
    public async Task<IActionResult> AddContact([FromBody] ContactCreateViewModel model)
    {
        var contact = await _contactService.AddContactAsync(model);
        if (contact == null)
            return BadRequest(new { Status = ResponseStatus.Error.ToString(), Message = "Failed to Create Contact" });

        var response = Mapper.MapContactToContactResponseViewModel(contact);
        return Ok(new { Status = ResponseStatus.Success.ToString(), Message = "Contact Created Successfully", Data = response });
    }

    // Get All Contacts
    [HttpGet("all")]
    public async Task<IActionResult> GetAllContacts()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        var response = contacts.Select(a => Mapper.MapContactToContactResponseViewModel(a));
        return Ok(new { Status = ResponseStatus.Success.ToString(), Message = "Contacts fetched successfully",Data = response});
    }

    // Get Contacts By Student
    [HttpGet("by-student/{studentId}")]
    public async Task<IActionResult> GetContactsByStudent(string studentId)
    {
        var contacts = await _contactService.GetContactsByStudentAsync(studentId);
        var response = contacts.Select(c => Mapper.MapContactToContactResponseViewModel(c));

        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = "Contacts fetched successfully for student",
            Data = response
        });
    }

    [HttpPost("assign-contact-to-student")]
    public async Task<IActionResult> AssignContactsToStudent([FromBody] AddContactsToStudentViewModel model)
    {
        await _contactService.AssignContactsToStudentAsync(model.StudentId, model.Contacts);
        return Ok(new
        {
            Status = ResponseStatus.Success.ToString(),
            Message = "Contacts assigned successfully"
        });
    }

}
