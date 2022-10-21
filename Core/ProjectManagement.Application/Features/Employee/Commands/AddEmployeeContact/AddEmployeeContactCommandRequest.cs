using MediatR;

namespace ProjectManagement.Application.Features.Employee.Commands.AddEmployeeContact
{
    public class AddEmployeeContactCommandRequest:IRequest<AddEmployeeContactCommandResponse>
    {
        public string EmployeeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

    }
}
