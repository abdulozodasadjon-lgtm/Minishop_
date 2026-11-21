using System.Net;

namespace Application.DTOs;

public class ApiResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = null!;
    public T? Data { get; set; }

    public ApiResponse(HttpStatusCode statusCode, string message, T? data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
}