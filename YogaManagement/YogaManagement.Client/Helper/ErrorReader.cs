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
            ApiError content;
            if (ex.InnerException != null)
            {
                content = JsonConvert.DeserializeObject<ApiError>(ex.InnerException.Message);
            }
            else
            {
                content = JsonConvert.DeserializeObject<ApiError>(ex.Message);
            }

            return content.Error.Message;
        }
        catch
        {
            if (ex.InnerException != null)
            {
                return ex.InnerException.Message;
            }
            else
            {
                return ex.Message;
            }
        }
    }
}
