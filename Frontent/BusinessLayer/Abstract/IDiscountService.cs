using DtoLayer.DiscountDtos;
using DtoLayer.FeatureDtos;

namespace BusinessLayer.Abstract;

public interface IDiscountService : IGenericService<ResultDiscountDto>
{
    Task<bool> AddAsync(CreateDiscountDto categoryDto);
    Task<bool> UpdateAsync(UpdateDiscountDto categoryDto);
}