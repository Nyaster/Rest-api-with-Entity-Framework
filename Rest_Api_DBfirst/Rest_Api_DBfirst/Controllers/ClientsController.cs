using Microsoft.AspNetCore.Mvc;
using Rest_Api_DBfirst.Services;

namespace Rest_Api_DBfirst.Controllers;

[ApiController]
[Route("/api/clients")]
public class ClientsController : ControllerBase
{
    private ClientService _clientService;

    public ClientsController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        await _clientService.DeleteClient(id);
        return Ok();
    }
}