﻿namespace DtoLayer.CategoryDtos;

public class CreateCategoryDto
{
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}