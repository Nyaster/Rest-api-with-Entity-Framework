using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Rest_Api_DBfirst.Models;
using Rest_Api_DBfirst.Services;

namespace Rest_Api_DBfirst.Controllers;

[ApiController]
[Route("/api/trips")]
public class TripsController : ControllerBase
{
    private const int DefaultPageSize = 10;
    private const int DefaultPage = 1;
    private TripService _tripService;

    public TripsController(TripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken, int pageSize = DefaultPageSize,
        int page = DefaultPage)
    {
        var trips = await _tripService.GetTrips(pageSize, page);
        return Ok(trips);
    }
    [HttpPost("{id:int}/clients")]
    public async Task<IActionResult> RegistratateClietnToTrip(TripRegistrationDTO tripRegistrationDto, int id)
    {
        return Ok();
    }
}