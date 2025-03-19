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
        // Validacion reservas duplicadas para un servicio mismo día y horario.
        var isDuplicateRes = await _context.Reservations
            .AnyAsync(
                r => r.ServiceId == reservationDto.ServiceId
                && r.Date == reservationDto.Date
                && r.Time == reservationDto.Time);

        if (isDuplicateRes)
            throw new InvalidOperationException("There is already a reservation for this service on this date and time.");

        // Validación reservas para un cliente en un mismo día.
        var hasMultipleRes = await _context.Reservations
            .AnyAsync(
                r => r.ClientId == reservationDto.ClientId
                && r.Date == reservationDto.Date);

        if (hasMultipleRes)
            throw new InvalidOperationException("The client already has a reservation for this date.");

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
