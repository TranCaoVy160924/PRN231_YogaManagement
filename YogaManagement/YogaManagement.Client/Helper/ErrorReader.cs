using Newtonsoft.Json;
using Refit;

namespace YogaManagement.Client.Helper;

public class ApiError
{
    public ApiErrorContent Error { get; set; }
}

public class ApiErrorContent
{
    public string Message { get; set; }
}

public static class ErrorReader
{
    public static string ReadApiErrorMessage(this ApiException ex)
    {
        var content = JsonConvert.DeserializeObject<ApiErrorContent>(ex.Content);
        return content.Message;
    }

    public static string ReadOdataErrorMessage(this InvalidOperationException ex)
    {
        try
        {
            var content = JsonConvert.DeserializeObject<ApiError>(ex.InnerException.Message);
            return content.Error.Message;
        }
        catch
        {
            return ex.InnerException.Message;
        }
    }
}
