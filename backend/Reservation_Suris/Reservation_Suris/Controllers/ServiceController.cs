using Microsoft.AspNetCore.Mvc;
using Reservation_Suris.Application.Interfaces;

namespace Reservation_Suris.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    =>  _serviceService = serviceService ?? 
            throw new ArgumentNullException(nameof(serviceService));

    // GET: api/services
    [HttpGet]
    public async Task<IActionResult> GetAllServices()
    {
        var services = await _serviceService.GetAllServicesAsync();
        return Ok(services);
    }
}
