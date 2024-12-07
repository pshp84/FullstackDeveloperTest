using FlightManagementSystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceAlertsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPriceAlerts()
        {
            List<FlightPrice> res = new();
            res.Add(new FlightPrice
            {
                Id = 1,
                FlightNumber = "XY123",
                Origin = "New York",
                Destination = "Los Angeles",
                Price = 299.99m,
                Timestamp = DateTime.UtcNow
            });

            res.Add(new FlightPrice
            {
                Id = 2,
                FlightNumber = "AB456",
                Origin = "Chicago",
                Destination = "Miami",
                Price = 199.99m,
                Timestamp = DateTime.UtcNow
            });
            return Ok(new CommonResponse { Status = Status.Success, Data = res });
        }
    }
}
