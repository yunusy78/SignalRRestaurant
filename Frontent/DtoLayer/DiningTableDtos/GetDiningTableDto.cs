﻿namespace DtoLayer.DiningTableDtos;

public class GetDiningTableDto
{
    public int DiningTableId { get; set; }
    public string? TableName { get; set; }
    public int Capacity { get; set; }
    public bool Status { get; set; }
}