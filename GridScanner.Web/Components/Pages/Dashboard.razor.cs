using GridScanner.Web.Models;
using GridScanner.Web.Services;
using Microsoft.AspNetCore.Components;

namespace GridScanner.Web.Components.Pages;

public partial class Dashboard
{
	[Inject]
	public ElectricityPriceService ElectricityPriceService { get; set; }

	public DateTime StartDate { get; set; } = DateTime.Now;
	private EnergyResponse EnergyResponse { get; set; }
	private readonly DateTime Max = DateTime.Now.AddDays(1);
	private readonly DateTime Min = new DateTime(2022, 1, 1);
	private List<HourlyPrice> HourlyPrices = new List<HourlyPrice>(25);
	private IEnumerable<object> PriceList { get; set; }
	private int DebounceDelay { get; set; } = 200;
	private decimal Avarage { get; set; }
	private decimal DayHigh { get; set; }
	private decimal DayLow { get; set; }

	private const string Red = "red";
	private const string Orange = "orange";
	private const string Blue = "blue";
	private const string Green = "green";
	private object[] Hours =
		["00", "01", "02", "03", "04", "05", "06", "07",
		"08", "09", "10", "11", "12", "13", "14", "15", "16",
		"17", "18", "19", "20", "21", "22", "23", "00"];

	protected override async Task OnInitializedAsync()
	{
		EnergyResponse = await ElectricityPriceService.GetSameDayEnergyResponseAsync(DateOnly.FromDateTime(StartDate));
		ConvertPricesToCentsPerKilowatt();
		CalculateHighLowAvarage();

		for (var i = 0; i < EnergyResponse.Prices.Count; i++)
		{
			HourlyPrices.Add(new HourlyPrice() { Hour = i, Price = EnergyResponse.Prices[i] , Color = ColorFormula(i) });
		}

		PriceList = HourlyPrices.Select(x => x.Price).Cast<object>();
		StateHasChanged();
	}

	public async Task Update()
	{
		EnergyResponse = await ElectricityPriceService.GetSameDayEnergyResponseAsync(DateOnly.FromDateTime(StartDate));
		ConvertPricesToCentsPerKilowatt();
		CalculateHighLowAvarage();
		UpdatePrices();
		PriceList = HourlyPrices.Select(x => x.Price).Cast<object>();
		StateHasChanged();
	}

	private void UpdatePrices()
	{
		for (var i = 0; i < EnergyResponse.Prices.Count; i++)
		{
			HourlyPrices[i].Hour = i;
			HourlyPrices[i].Price = EnergyResponse.Prices[i];
			HourlyPrices[i].Color = ColorFormula(i);
		}
	}

	private void ConvertPricesToCentsPerKilowatt()
	{
		EnergyResponse.Prices = EnergyResponse.Prices.Select(x => Math.Round(x / 10, 2, MidpointRounding.AwayFromZero)).ToList();
	}

	private string ColorFormula(int index)
	{
		var value = EnergyResponse.Prices[index];

		if (value <= ((Avarage + (DayLow < 0 ? 0 : DayLow)) / 2M))
		{
			return Green;
		}
		else if (value <= Avarage)
		{
			return Blue;
		}
		else if (value < (Avarage * 1.5M))
		{
			return Orange;
		}
		return Red;
	}

	private void CalculateHighLowAvarage()
	{
		var prices = EnergyResponse.Prices;

		if(prices.Count > 0)
		{
			var sum = prices.Where(x => x > 0).Sum();
			var avg = sum / prices.Count();
			var min = prices.Min();
			DayLow = min > 0 ? min : 0;
			DayHigh = prices.Max();
			Avarage = avg;
		}
	}

	public class HourlyPrice
	{
		public int Hour { get; set; }
		public decimal Price { get; set; }
		public string Color { get; set; }
	}
}
