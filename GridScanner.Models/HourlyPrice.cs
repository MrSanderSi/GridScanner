namespace GridScanner.Models;

public class HourlyPrice
{
	public Guid Id { get; set; }
	public Guid DayDataId { get; set; }
	public decimal Hour1 { get; set; }
	public decimal Hour2 { get; set; }
	public decimal Hour3 { get; set; }
	public decimal Hour4 { get; set; }
	public decimal Hour5 { get; set; }
	public decimal Hour6 { get; set; }
	public decimal Hour7 { get; set; }
	public decimal Hour8 { get; set; }
	public decimal Hour9 { get; set; }
	public decimal Hour10 { get; set; }
	public decimal Hour11 { get; set; }
	public decimal Hour12 { get; set; }
	public decimal Hour13 { get; set; }
	public decimal Hour14 { get; set; }
	public decimal Hour15 { get; set; }
	public decimal Hour16 { get; set; }
	public decimal Hour17 { get; set; }
	public decimal Hour18 { get; set; }
	public decimal Hour19 { get; set; }
	public decimal Hour20 { get; set; }
	public decimal Hour21 { get; set; }
	public decimal Hour22 { get; set; }
	public decimal Hour23 { get; set; }
	public decimal? Hour24 { get; set; }
	public decimal? Hour25 { get; set; }
	public virtual DayData DayData { get; set; }
}
