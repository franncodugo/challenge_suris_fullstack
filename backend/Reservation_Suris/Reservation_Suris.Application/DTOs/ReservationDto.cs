namespace Reservation_Suris.Application.DTOs;

public class ReservationDto
{
    public int ServiceId { get; set; }
    public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}
