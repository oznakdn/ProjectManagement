using MediatR;
using Moq;
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

       
    }
}
