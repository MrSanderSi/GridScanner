using GridScanner.ApiService.Commands.External;
using GridScanner.ApiService.Models.External.Request;
using GridScanner.ApiService.Models.Request;
using GridScanner.ApiService.Models.Response;
using GridScanner.Data;

namespace GridScanner.ApiService.Services;

public class EnergyPriceScannerService
{
    private readonly GridScannerDbContext _db;
    private readonly GetDayPricesFromElering _eleringCommand;

    public EnergyPriceScannerService(GridScannerDbContext db, GetDayPricesFromElering eleringCommand)
    {
        _db = db;
        _eleringCommand = eleringCommand;
    }

    public async Task<EnergyResponse> GetPriceForGivenDate(GetPricesRequest request)
    {

        var startDate = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day, 0, 0, 0);

		var eleringRequest = new GetDayPricesFromEleringRequest() { Start = startDate.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"), End = startDate.AddDays(1).ToString("yyyy-MM-dd'T'HH:mm:ss'Z'") };

		var result = await _eleringCommand.GetDayPricesAsync(eleringRequest);
        result.Date = DateOnly.FromDateTime(request.StartDate);

        if(result.Prices.Count > 0)
        {
            result.StatusCode = System.Net.HttpStatusCode.OK;
        }

        return result;
    }
}
