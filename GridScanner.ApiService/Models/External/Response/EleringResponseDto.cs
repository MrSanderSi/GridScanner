namespace GridScanner.ApiService.Models.External.Response;

public class EleringResponseDto
{
	public CountryDataHourly Data { get; set; }
	public bool Success { get; set; }
}

public class CountryDataHourly
{
	public IEnumerable<TimestampedPrice> Ee { get; set; }
}

public class TimestampedPrice
{
	public decimal Price { get; set; }
	public long Timestamp { get; set; }
}