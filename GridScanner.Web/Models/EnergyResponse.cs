using System.Net;

namespace GridScanner.Web.Models;

public class EnergyResponse
{
	public DateOnly Date { get; set; }
	public List<decimal> Prices { get; set; } = new List<decimal>(24);
	public HttpStatusCode StatusCode { get; set; }
	public bool IsSuccess { get; set; }
	public string ResultMessage { get; set; }
}
