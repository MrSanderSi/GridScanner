using GridScanner.Web.Models;
using System.Text.Json;

namespace GridScanner.Web;

public class GridScannerApiClient(HttpClient httpClient)
{
    private static readonly string GetPricesForGivenDayUrl = "api/EnergyPrice/GetPricesForGivenDay";

    public async Task<EnergyResponse> GetEnergyResponseAsync(GetEnergyPriceForDate request)
    {

        HttpRequestMessage requestMessage = new(HttpMethod.Get, $"{GetPricesForGivenDayUrl}?startdate={request.Date}") { };

        var response = await httpClient.SendAsync(requestMessage);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        if (!string.IsNullOrWhiteSpace(responseBody))
        {
            var responseDeserialized = JsonSerializer.Deserialize<EnergyResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return responseDeserialized;
        }

        return new EnergyResponse();
    }
}
