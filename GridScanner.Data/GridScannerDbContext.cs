using GridScanner.Models;
using Microsoft.EntityFrameworkCore;

namespace GridScanner.Data;

public class GridScannerDbContext : DbContext
{
    public DbSet<HourlyPrice> HourlyPrices { get; set; }
    public DbSet<DayData> DaysData { get; set; }

    public GridScannerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DayData>()
            .HasOne(x => x.HourlyPrices)
            .WithOne(x => x.DayData)
            .HasForeignKey<HourlyPrice>(x => x.DayDataId);
    }
}
