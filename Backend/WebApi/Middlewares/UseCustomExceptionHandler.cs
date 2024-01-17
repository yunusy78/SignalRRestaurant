using BusinessLayer.Exceptions;
using DtoLayer.CustomResponseDto;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApi.Middlewares;

public static class UseCustomExceptionHandler
{
    
    public static void UserCustomException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var error = context.Features.Get<IExceptionHandlerFeature>();
                var statusCode = error.Error switch
                {
                    ClientSideException => 400,
                    NotFoundException => 404,
                    _ => 500
                };
                context.Response.StatusCode = statusCode;
                var response = CustomResponseDto<NoContentDto>.Fail(error.Error.Message, statusCode);
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });
        });
    }
    
}