using GridScanner.ApiService.Commands.External;
using GridScanner.ApiService.Commands.Internal;
using GridScanner.ApiService.Models.External.Request;
using GridScanner.ApiService.Models.Request;
using GridScanner.ApiService.Models.Response;
using GridScanner.Data;

namespace GridScanner.ApiService.Services;

public class EnergyPriceScannerService
{
    private readonly GetDayPricesFromElering _eleringCommand;
    private readonly GetDayPricesFromDatabase _getDayPrices;
    private readonly SaveDayPricesToDatabase _saveDayPrices;

    public EnergyPriceScannerService(
        GetDayPricesFromElering eleringCommand,
        GetDayPricesFromDatabase getDayPrices,
        SaveDayPricesToDatabase saveDayPrices)
    {
        _eleringCommand = eleringCommand;
        _getDayPrices = getDayPrices;
        _saveDayPrices = saveDayPrices;
    }

    public async Task<EnergyResponse> GetPriceForGivenDate(GetPricesRequest request)
    {
        var startDate = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day, 0, 0, 0);

        var result = await _getDayPrices.GetEnergyResponseAsync(startDate);

        if (!result.IsSuccess)
        {
            var eleringRequest = new GetDayPricesFromEleringRequest()
            {
                Start = startDate.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"),
                End = startDate.AddDays(1).ToString("yyyy-MM-dd'T'HH:mm:ss'Z'")
            };

            result = await _eleringCommand.GetDayPricesAsync(eleringRequest);
            result.Date = DateOnly.FromDateTime(request.StartDate);

            if (result.Prices.Count > 0)
            {
                result.StatusCode = System.Net.HttpStatusCode.OK;
                result.IsSuccess = true;
                try
                {
                    await _saveDayPrices.SaveDayPricesAsync(result);
                }
                catch
                {
                    result.ResultMessage = "Failed to save data to database";
                }
            }
        }

        return result;
    }
}
