﻿namespace DtoLayer.BookingDtos;

public class CreateBookingDto
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsConfirmed { get; set; }
}