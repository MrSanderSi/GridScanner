using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridScanner.Models;

public class DayData
{
	public Guid Id { get; set; }
	public DateOnly Date { get; set; }
	public decimal DayHigh { get; set; }
	public decimal DayLow { get; set; }
	public decimal Avg { get; set; }
	public virtual HourlyPrice HourlyPrices { get; set; }
}
