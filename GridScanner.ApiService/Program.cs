using GridScanner.ApiService.Commands.External;
using GridScanner.ApiService.Services;
using GridScanner.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	builder.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<GridScannerDbContext>(options =>
{
	options.UseSqlServer("Server=localhost;Database=GridScannerDb;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddScoped<EnergyPriceScannerService>();
builder.Services.AddScoped<GetDayPricesFromElering>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseCors("AllowAll");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();