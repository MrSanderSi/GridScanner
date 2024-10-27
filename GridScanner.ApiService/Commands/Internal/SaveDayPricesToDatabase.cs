using GridScanner.ApiService.Models.Response;
using GridScanner.Data;
using GridScanner.Models;

namespace GridScanner.ApiService.Commands.Internal;

public class SaveDayPricesToDatabase
{
    private readonly GridScannerDbContext _db;

    public SaveDayPricesToDatabase(GridScannerDbContext db)
    {
        _db = db;
    }

    public async Task SaveDayPricesAsync(EnergyResponse saveEnergyResponse)
    {
        var dayData = new DayData()
        {
            Id = Guid.NewGuid(),
            Date = saveEnergyResponse.Date,
            DayLow = saveEnergyResponse.Prices.Min(),
            DayHigh = saveEnergyResponse.Prices.Max(),
            Avg = saveEnergyResponse.Prices.Average(),
        };

        var hourlyPrice  = new HourlyPrice()
        {
            DayDataId = dayData.Id,
            Hour1 = saveEnergyResponse.Prices[0],
            Hour2 = saveEnergyResponse.Prices[1],
            Hour3 = saveEnergyResponse.Prices[2],
            Hour4 = saveEnergyResponse.Prices[3],
            Hour5 = saveEnergyResponse.Prices[4],
            Hour6 = saveEnergyResponse.Prices[5],
            Hour7 = saveEnergyResponse.Prices[6],
            Hour8 = saveEnergyResponse.Prices[7],
            Hour9 = saveEnergyResponse.Prices[8],
            Hour10 = saveEnergyResponse.Prices[9],
            Hour11 = saveEnergyResponse.Prices[10],
            Hour12 = saveEnergyResponse.Prices[11],
            Hour13 = saveEnergyResponse.Prices[12],
            Hour14 = saveEnergyResponse.Prices[13],
            Hour15 = saveEnergyResponse.Prices[14],
            Hour16 = saveEnergyResponse.Prices[15],
            Hour17 = saveEnergyResponse.Prices[16],
            Hour18 = saveEnergyResponse.Prices[17],
            Hour19 = saveEnergyResponse.Prices[18],
            Hour20 = saveEnergyResponse.Prices[19],
            Hour21 = saveEnergyResponse.Prices[20],
            Hour22 = saveEnergyResponse.Prices[21],
            Hour23 = saveEnergyResponse.Prices[22],
            Hour24 = saveEnergyResponse.Prices.Count > 23 ? saveEnergyResponse.Prices[23] : null,
            Hour25 = saveEnergyResponse.Prices.Count > 24 ? saveEnergyResponse.Prices[24] : null,
        };

        _db.Add(dayData);
        _db.Add(hourlyPrice);
        await _db.SaveChangesAsync();
    }
}
