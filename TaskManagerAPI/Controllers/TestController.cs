using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace TaskManagerAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                return Ok(new { success = true, message = "Conexión ADO.NET exitosa." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}