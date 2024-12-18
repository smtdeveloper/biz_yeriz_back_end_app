namespace bizYeriz.Shared.Responses;

public interface IResponse
{
    bool Success { get; }
    string Message { get; }
}

public interface IDataResponse<T> : IResponse
{
    T Data { get; }
}


public class Response : IResponse
{
    public bool Success { get; private set; }
    public string Message { get; private set; }

    public Response(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static Response SuccessResponse(string message = "")
        => new Response(true, message);

    public static Response FailureResponse(string message)
        => new Response(false, message);
}


public class DataResponse<T> : IDataResponse<T>
{
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }

    public DataResponse(T data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }

    public static DataResponse<T> SuccessResponse(T data, string message = "")
        => new DataResponse<T>(data, true, message);

    public static DataResponse<T> FailureResponse(string message)
        => new DataResponse<T>(default, false, message);
}