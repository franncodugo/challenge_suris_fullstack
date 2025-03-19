﻿namespace Reservation_Suris.Domain.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsActive { get; set; }
}
