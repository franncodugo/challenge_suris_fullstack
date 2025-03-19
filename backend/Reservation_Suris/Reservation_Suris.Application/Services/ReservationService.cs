using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation_Suris.Application.DTOs;
using Reservation_Suris.Application.Interfaces;
using Reservation_Suris.Domain.Models;
using Reservation_Suris.Infrastructure.Persistence;

namespace Reservation_Suris.Application.Services;

public class ReservationService : IReservationService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ReservationService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> CreateReservationAsync(ReservationDto reservationDto)
    {
        var reservation = _mapper.Map<Reservation>(reservationDto);
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ReservationDto>> GetAllReservationsAsync()
    {
        var reservations = await _context.Reservations.ToListAsync();
        return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
    }
}
