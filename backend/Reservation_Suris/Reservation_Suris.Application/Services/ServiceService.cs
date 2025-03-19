using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation_Suris.Application.DTOs;
using Reservation_Suris.Application.Interfaces;
using Reservation_Suris.Infrastructure.Persistence;

namespace Reservation_Suris.Application.Services;

public sealed class ServiceService : IServiceService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ServiceService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
    {
        var services = await _context.Services.ToListAsync();
        return _mapper.Map<IEnumerable<ServiceDto>>(services);
    }
}
