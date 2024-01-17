using DtoLayer.ProductDtos;
using FluentValidation;

namespace BusinessLayer.Validations;

public class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required")
            .InclusiveBetween(1, int.MaxValue).WithMessage("Price must be between 1 and 1000000");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required")
            .InclusiveBetween(1, int.MaxValue).WithMessage("Price must be between 1 and 1000000");;
    }
    
}