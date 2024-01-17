using System.Text.Json.Serialization;

namespace DtoLayer.CustomResponseDto;

public class CustomResponseDto<T>
{
    public T Data { get; set; }
    
    [JsonIgnore]
    public int StatusCode { get; set; }
    [JsonIgnore]
    public bool IsSuccess { get; set; }
    
    public List<string> Errors { get; set; }
    //Static factory methods
    public static CustomResponseDto<T> Success(T data, int statusCode)
    {
        return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
    }
    
    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T> { Data = default(T), StatusCode = statusCode, IsSuccess = true };
    }
    
    public static CustomResponseDto<T> Fail(List<string> errors, int statusCode)
    {
        return new CustomResponseDto<T> { Errors = errors, StatusCode = statusCode, IsSuccess = false };
    }
    
    public static CustomResponseDto<T> Fail(string error, int statusCode)
    {
        return new CustomResponseDto<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccess = false };
    }
}
