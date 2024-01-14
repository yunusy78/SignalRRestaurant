﻿namespace DtoLayer.OrderDetailsDtos;

public class GetOrderDetailsDto
{
    public int OrderDetailsId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
    
}