using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterService.Models;

namespace RegisterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterPatient([FromBody] Patient patient)
        {
            // Code to register the patient goes here

            return Ok();
        }
    }
}
