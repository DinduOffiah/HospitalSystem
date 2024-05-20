using ConsultService.Models;
using ConsultService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }

        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor)
        {
            try
            {
                await _service.AddDoctorAsync(doctor);
                return Ok(doctor);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
