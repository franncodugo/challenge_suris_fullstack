using Microsoft.Extensions.DependencyInjection;
using Reservation_Suris.Application.Interfaces;
using Reservation_Suris.Application.Services;
using System.Reflection;

namespace Reservation_Suris.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IReservationService, ReservationService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
