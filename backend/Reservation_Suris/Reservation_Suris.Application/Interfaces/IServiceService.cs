using Reservation_Suris.Application.DTOs;

namespace Reservation_Suris.Application.Interfaces;

public interface IServiceService
{
    Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
}
