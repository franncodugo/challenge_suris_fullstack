namespace Reservation_Suris.Domain.Models;

public class Reservation
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}
