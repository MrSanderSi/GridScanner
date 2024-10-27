using GridScanner.ApiService.Models.External.Request;
using GridScanner.ApiService.Models.External.Response;
using GridScanner.ApiService.Models.Response;
using System.Text;
using System.Text.Json;

namespace GridScanner.ApiService.Commands.External;

public class GetDayPricesFromElering
{
    private static readonly HttpClient Client = new HttpClient();
    private static readonly string GetEleringPricesUrl = "https://dashboard.elering.ee/api/nps/price";


    public GetDayPricesFromElering()
    {
    }

    public async Task<EnergyResponse> GetDayPricesAsync(GetDayPricesFromEleringRequest request)
    {
        var uriBuilder = new UriBuilder(GetEleringPricesUrl);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
        query["start"] = request.Start;
        query["end"] = request.End;
        uriBuilder.Query = query.ToString();
        var url = uriBuilder.ToString();

        HttpRequestMessage requestMessage = new(HttpMethod.Get, url) {};

        var response = await Client.SendAsync(requestMessage);
        var result = new EnergyResponse();

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var responseMessage = JsonSerializer.Deserialize<EleringResponseDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            result.Prices = responseMessage.Data.Ee.Select(x => x.Price).ToList();
            result.ResultMessage = "Retreived from Elering";
        }

        return result;
    }
}
