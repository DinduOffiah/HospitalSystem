using Microsoft.AspNetCore.Mvc;
using NewProject.API.ViewModels;
using NewProject.Core.Services;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _services;

    public CustomerController(ICustomerService services)
    {
        _services = services;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var customer = await _services.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound(); // Return a 404 response if the customer is not found
            }

            var viewModel = new CustomerViewModel
            {
                AccountNumber = customer.AccountNumber,
                LastName = customer.LastName,
                FirstName = customer.FirstName,
            };

            return Ok(viewModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Return a 500 response for internal server error
        }
    }

    // Other action methods...

    private IActionResult InternalServerError(Exception ex)
    {
        // Your implementation for handling internal server errors
        return StatusCode(500, ex.Message);
    }
}
