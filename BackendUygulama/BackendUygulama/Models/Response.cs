namespace BackendUygulama.Models;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public T Body { get; set; }
    public string Message { get; set; }

    private Response(bool isSuccess, T body, string message)
    {
        IsSuccess = isSuccess;
        Body = body;
        Message = message;
    }

    public static Response<T> Success(T body)
    {
        return new Response<T>(true, body, string.Empty);
    }

    public static Response<T> Fail(string message)
    {
        return new Response<T>(false, default(T), message);
    }
}