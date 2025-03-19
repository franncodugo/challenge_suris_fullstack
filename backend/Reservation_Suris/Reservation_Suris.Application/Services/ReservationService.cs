using Reservation_Suris.Application.DTOs;
using Reservation_Suris.Application.Interfaces;

namespace Reservation_Suris.Application.Services;

public class ReservationService : IReservationService
{
    public Task<bool> CreateReservationAsync(ReservationDto reservationDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ReservationDto>> GetAllReservationsAsync()
    {
        throw new NotImplementedException();
    }
}
