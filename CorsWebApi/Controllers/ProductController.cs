using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CorsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")] // Apply CORS policy to this action only
        public IActionResult Get()
        {
            return Ok("CORS is enabled for this action.");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("CORS is not enabled for this action.");
        }
    }
}
