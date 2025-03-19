using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Reservation_Suris.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("Reservation_Suris_Db"));

        return services;
    }
}
