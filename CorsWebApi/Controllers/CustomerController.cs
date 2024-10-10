using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CorsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")] // Apply specific policy
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CORS is enabled for this controller.");
        }
    }
}
