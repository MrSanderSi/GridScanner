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
            var allPrices = new List<decimal>()
            {
                result.Hour1, result.Hour2, result.Hour3,
                result.Hour4, result.Hour5, result.Hour6,
                result.Hour7, result.Hour8, result.Hour9,
                result.Hour10, result.Hour11, result.Hour12,
                result.Hour13, result.Hour14, result.Hour15,
                result.Hour16, result.Hour17, result.Hour18,
                result.Hour19, result.Hour20, result.Hour21,
                result.Hour22, result.Hour23, result.Hour24 ?? 0,
                result.Hour25 ?? 0,
            };

            response.Prices.AddRange(allPrices);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.IsSuccess = true;
            response.ResultMessage = "Retreived from database";
        }

        return response;
    }
}
