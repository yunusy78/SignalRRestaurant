using DtoLayer.BookingDtos;
using DtoLayer.ShoppingCartDtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebUI.Models;

public class ShoppingCartListModel
{
    [ValidateNever]
    public IEnumerable<ResultShoppingCartWithDiningTableDto> Carts { get; set; }
    
    [ValidateNever]
    public ResultReservationDto Order { get; set; }
}