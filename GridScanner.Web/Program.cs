using GridScanner.Web;
using GridScanner.Web.Components;
using GridScanner.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add framework services.
builder.Services
	.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Add Kendo UI services to the services container
builder.Services.AddKendo();

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// TELERIK
builder.Services.AddTelerikBlazor();

builder.Services.AddOutputCache();
builder.Services.AddScoped<ElectricityPriceService>();

builder.Services.AddHttpClient<GridScannerApiClient>(client =>
    {
        client.BaseAddress = new("https+http://localhost:7417");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
