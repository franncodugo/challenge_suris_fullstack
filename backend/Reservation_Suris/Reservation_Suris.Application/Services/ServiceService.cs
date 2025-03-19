using Reservation_Suris.Application.DTOs;
using Reservation_Suris.Application.Interfaces;

namespace Reservation_Suris.Application.Services;

public class ServiceService : IServiceService
{
    public Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
    {
        throw new NotImplementedException();
    }
}
