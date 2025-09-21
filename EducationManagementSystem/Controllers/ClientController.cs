using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EducationManagementSystem.Common.Enums;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    //   AddClient
    [HttpPost("add-client")]
    public async Task<IActionResult> AddClient([FromBody] ClientCreateViewModel dto)
    {
        var client = await _clientService.AddClientAsync(dto);

        if (client == null)
            return BadRequest(new { Status = ResponseStatus.Error.ToString(), Message = "Failed to Create Client" });
       var response = Mapper.MapClientToClientResponseViewModel(client);

        return Ok(new { Status = ResponseStatus.Success.ToString(), Message = "Client Created Successfully", Data = response });
    }

    //   GetClient
    [HttpGet("get-clients")]
    public async Task<IActionResult> GetClients()
    {
        var clients = await _clientService.GetAllClientsAsync();
        var response = clients.Select(a => Mapper.MapClientToClientResponseViewModel(a));
        return Ok(new { Status = "Success", Message = "Clients Fetched Successfully",Data=response});
    }

}
