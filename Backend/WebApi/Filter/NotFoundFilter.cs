using BusinessLayer.Abstract;
using DtoLayer.CustomResponseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filter;

public class NotFoundFilter<T> :IAsyncActionFilter where T:class,new()
{
    private readonly IProductService _genericService;
    
    public NotFoundFilter(IProductService genericService)
    {
        _genericService = genericService;
    }
    public  async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var idValue = context.ActionArguments.Values.FirstOrDefault();
        if (idValue==null)
        {
            await next.Invoke();
            return;
        }
        var id =(int)idValue;
        var anyEntity = await _genericService.GetByIdAsync(id);
        if (anyEntity!=null)
        {
            await next.Invoke();
            return;
        }
        context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail("Not Found",404));
       
    }
}