namespace GridScanner.ApiService.Models.Response;

public class EnergyResponse : ApiResponseMessage
{
	public DateOnly Date { get; set; }
	public List<decimal> Prices { get; set; } = new List<decimal>(24);
}
