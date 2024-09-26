using System;
namespace  LibraryToDo.Models.Responses;

public class ApiResponse<T> where T : new()
{
    public bool Success { get; set; }

    public dynamic Data { get; set; }

    public int StatusCode { get; set; }

    public int ErrorCode { get; set; }

    public string Message { get; set; }
}

