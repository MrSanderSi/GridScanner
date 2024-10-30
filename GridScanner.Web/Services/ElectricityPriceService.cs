using GridScanner.Web.Models;

namespace GridScanner.Web.Services;

public class ElectricityPriceService
{
	private readonly GridScannerApiClient _apiClient;

    public ElectricityPriceService(GridScannerApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<EnergyResponse> GetSameDayEnergyResponseAsync(DateOnly startDate)
    {
        var request = new GetEnergyPriceForDate() { Date = startDate };

        return await _apiClient.GetEnergyResponseAsync(request);
    }
}
