using Reservation_Suris.Application.DTOs;

namespace Reservation_Suris.Application.Interfaces;

public interface IReservationService
{
    Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
    Task<bool> CreateReservationAsync(ReservationDto reservationDto);
}
