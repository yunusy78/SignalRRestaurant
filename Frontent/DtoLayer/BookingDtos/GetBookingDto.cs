﻿namespace DtoLayer.BookingDtos;

public class GetBookingDto
{
    public int BookingId { get; set; }
    public int FullName { get; set; }
    public int Phone { get; set; }
    public int Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsConfirmed { get; set; }
}