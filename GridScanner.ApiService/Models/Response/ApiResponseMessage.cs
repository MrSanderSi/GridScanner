using System.Net;

namespace GridScanner.ApiService.Models.Response;

public class ApiResponseMessage
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string ResultMessage { get; set; }

    public ApiResponseMessage(bool isSuccess, string resultMessage)
    {
        IsSuccess = isSuccess;
        ResultMessage = resultMessage;
    }

    public ApiResponseMessage(string resultMessage)
    {
        ResultMessage = resultMessage;
    }

    public ApiResponseMessage()
    {
        ResultMessage = string.Empty;
    }
}
