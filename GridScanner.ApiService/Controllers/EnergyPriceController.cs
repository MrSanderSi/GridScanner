using GridScanner.ApiService.Models.Request;
using GridScanner.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace GridScanner.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnergyPriceController : ControllerBase
{
    private readonly EnergyPriceScannerService _energyPriceScannerService;

    public EnergyPriceController(EnergyPriceScannerService service)
    {
        _energyPriceScannerService = service;
    }

    [HttpGet("GetPricesForGivenDay")]
    public async Task<IActionResult> PostAsync([FromQuery]GetPricesRequest request)
    {
        var result = await _energyPriceScannerService.GetPriceForGivenDate(request);

        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        else
        {
            return Problem(statusCode: (int)result.StatusCode);
        }
    }
}
