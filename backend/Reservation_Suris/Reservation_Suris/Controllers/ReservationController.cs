using Microsoft.AspNetCore.Mvc;
using Reservation_Suris.Application.DTOs;
using Reservation_Suris.Application.Interfaces;

namespace Reservation_Suris.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    =>  _reservationService = reservationService 
            ?? throw new ArgumentNullException(nameof(reservationService));

    // GET: api/reservations
    [HttpGet]
    public async Task<IActionResult> GetAllReservations()
    {
        var reservations = await _reservationService.GetAllReservationsAsync();
        return Ok(reservations);
    }

    // POST: api/reservations
    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] ReservationDto reservationDto)
    {
        if (reservationDto is null)
            return BadRequest("Invalid reservation data.");

        var result = await _reservationService.CreateReservationAsync(reservationDto);

        if (!result)
            return BadRequest("Failed to create reservation.");

        return Ok("Reservation created successfully.");
    }
}
