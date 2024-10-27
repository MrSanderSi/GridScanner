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

		var hourlyPrice = new HourlyPrice
		{
			DayDataId = dayData.Id
		};

		for (int i = 0; i < saveEnergyResponse.Prices.Count; i++)
        {
            var propertyName = $"Hour{i + 1}";
            var propertyInfo = typeof(HourlyPrice).GetProperty(propertyName);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(hourlyPrice, saveEnergyResponse.Prices[i]);
            }
        }

        _db.Add(dayData);
        _db.Add(hourlyPrice);
        await _db.SaveChangesAsync();
    }
}
