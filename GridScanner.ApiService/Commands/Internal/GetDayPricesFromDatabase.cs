using GridScanner.ApiService.Models.Request;
using GridScanner.ApiService.Models.Response;
using GridScanner.Data;
using GridScanner.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace GridScanner.ApiService.Commands.Internal;

public class GetDayPricesFromDatabase
{
    private readonly GridScannerDbContext _db;

    public GetDayPricesFromDatabase(GridScannerDbContext db)
    {
        _db = db;
    }

    public async Task<EnergyResponse> GetEnergyResponseAsync(DateTime startDate)
    {
        var result = await _db.Set<DayData>()
            .Include(x => x.HourlyPrices)
            .Where(x => x.Date == DateOnly.FromDateTime(startDate))
            .Select(x => x.HourlyPrices)
            .FirstOrDefaultAsync();

        var response = new EnergyResponse();
        if (result != null)
        {
            var allPrices = new List<decimal>();

            for (int i = 1; i <= 25; i++)
            {
                var propertyName = $"Hour{i}";
                var propertyInfo = result.GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    var value = propertyInfo.GetValue(result) as decimal?;
                    allPrices.Add(value ?? 0);
                }
            }

            response.Prices.AddRange(allPrices);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.IsSuccess = true;
            response.ResultMessage = "Retreived from database";
        }

        return response;
    }
}
