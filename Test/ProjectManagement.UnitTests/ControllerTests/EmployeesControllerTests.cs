using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.Application.Features.Employee.Commands.AddEmployee;
using ProjectManagement.Application.Features.Employee.Queries.GetAllEmployees;
using ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesByDepartment;
using ProjectManagement.Application.Features.Employee.Queries.GetEmployeeWith;
using ProjectManagement.WebAPI.Controllers;

namespace ProjectManagement.UnitTests.ControllerTests
{
    public class EmployeesControllerTests
    {
        private Mock<IMediator> _mock;
        private EmployeesController controller;

        public EmployeesControllerTests()
        {
            _mock = new Mock<IMediator>();
            controller = new EmployeesController(_mock.Object);

        }

        [Fact]
        public async Task Employees_Should_ReturnOkOkObjectResult()
        {
            // Arrange
            List<GetAllEmployeesQueryResponse> response = new()
            {
                new GetAllEmployeesQueryResponse
                {
                    Id = "7f0e00cf-aa22-4be4-a1fa-1cc220bc5c73",
                    EmployeeName = "Ahmet",
                    EmployeeLastname = "Koşar",
                    EmployeePicture = "This is picture",
                    EmployeeBirthDate = "1999-02-15"
                }
            };

            GetAllEmployeesQueryRequest request = new();

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(response);
            var result = await controller.Employees();

            // Assert
            Assert.NotNull(result);
            OkObjectResult returnResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnResult.StatusCode);

        }

        [Theory]
        [InlineData("7f0e00cf-aa22-4be4-a1fa-1cc220bc5c73")]
        public async Task EmployeesByDepartmentId_ShouldBe_ReturnOkObjectResult(string id)
        {
            // Arrange

            GetAllEmployeesByDepartmentQueryRequest request = new(id);
            GetAllEmployeesByDepartmentQueryResponse response = new()
            {
                EmployeeName = "Ahmet",
                EmployeeLastname = "Koşar",
                EmployeePicture = "This is picture",
                EmployeeBirthDate = "1999-02-15",
                DepartmentName = "IT",
                EmployeeId = "19ca3930-7ffe-4f58-a023-8bd2959158f0"
            };


            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None));
            var result = await controller.EmployeesByDepartmentId(id);

            // Assert
            OkObjectResult returnResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnResult.StatusCode);

        }

        [Theory]
        [InlineData("25fc55da-5b1d-4780-b6aa-d1c5cc53c50a")]
        public async Task EmployeeDetails_ShouldBe_ReturnOkObjectResult(Guid id)
        {
            // Arrange
            string Id = id.ToString();

            GetEmployeeWithQueryRequest request = new(Id);
            GetEmployeeWithQueryResponse response = new()
            {
                Id = Id,
                EmployeeName = "Ali",
                EmployeeLastname = "Kartal",
                EmployeePicture = "Ali's picture",
                EmployeeBirthDate = "1999-02-15",
                EmailAddress = "ali.kartal@mail.com",
                Address = "Merkez Mah.",
                City = "İzmir",
                PhoneNumber = "05647549854",
                Department = new Guid("7f79caed-732c-4637-a9c8-031388fade15").ToString(),

            };

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(response);
            var result = await controller.EmployeeDetails(Id);

            // Assert
            OkObjectResult returnResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnResult.StatusCode);

        }

        [Fact]
        public async Task EmployeeAdd_WhenModelStateIsValid_ReturnOkReturnResponseMessage()
        {

            // Arrange
            AddEmployeeCommandRequest request = new()
            {
                DepartmentId = new Guid("7f79caed-732c-4637-a9c8-031388fade15").ToString(),
                EmployeeName = "John",
                EmployeeLastname = "Doe",
                EmployeeBirthDate = new DateTime(1999, 02, 15),
                EmployeePicture = "John's picture"
            };

            AddEmployeeCommandResponse response = new()
            {
                IsValid = true,
                ResponseMessages = new List<string>() { "Employee is added successfully." }
            };

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(response);
            var result = await controller.EmployeeAdd(request);

            // Assert
            OkObjectResult returnResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnResult.StatusCode);
          
        }


    }
}
