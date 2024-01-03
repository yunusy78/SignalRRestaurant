﻿namespace DtoLayer.SocialMediaDtos;

public class UpdateSocialMediaDto
{
    public int SocialMediaId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string? Icon { get; set; }
    public DateTime CreatedAt { get; set; }
}