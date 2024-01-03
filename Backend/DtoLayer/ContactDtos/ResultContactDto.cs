﻿namespace DtoLayer.ContactDtos;

public class ResultContactDto
{
    public int ContactId { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string FooterDescription { get; set; }
    public DateTime CreatedAt { get; set; }
}