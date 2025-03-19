using Microsoft.EntityFrameworkCore;
using Reservation_Suris.Domain.Models;

namespace Reservation_Suris.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Service> Services { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Client> Clients { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Service)
                .WithMany()
                .HasForeignKey(r => r.ServiceId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Client)
            .WithMany()
            .HasForeignKey(r => r.ClientId);
    }
}
