using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NewProject.API.Controllers;
using NewProject.API.ViewModels;
using NewProject.Core.Models;
using NewProject.Core.Services;
using Xunit;

public class CustomerControllerTests
{
    [Fact]
    public async Task Get_ValidCustomerId_ReturnsOkResultWithCustomerViewModel()
    {
        // Arrange
        int customerId = 1;
        var mockCustomerService = new Mock<ICustomerService>();
        var expectedCustomer = new Customer
        {
            Id = customerId,
            AccountNumber = 123456,
            LastName = "Doe",
            FirstName = "John",
            // Add other properties as needed
        };

        mockCustomerService.Setup(service => service.GetByIdAsync(customerId))
            .ReturnsAsync(expectedCustomer);

        var controller = new CustomerController(mockCustomerService.Object);

        // Act
        var result = await controller.Get(customerId);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var viewModel = okResult.Value.Should().BeAssignableTo<CustomerViewModel>().Subject;

        viewModel.AccountNumber.Should().Be(expectedCustomer.AccountNumber);
        viewModel.LastName.Should().Be(expectedCustomer.LastName);
        viewModel.FirstName.Should().Be(expectedCustomer.FirstName);
        // Add other assertions for properties

        // Additional assertions or verifications can be added as needed
    }

    // Add more test cases for other scenarios, such as a non-existent customer, error handling, etc.
}
