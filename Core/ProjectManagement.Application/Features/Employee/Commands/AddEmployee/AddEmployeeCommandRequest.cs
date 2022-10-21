using MediatR;

namespace ProjectManagement.Application.Features.Employee.Commands.AddEmployee
{
    public class AddEmployeeCommandRequest:IRequest<AddEmployeeCommandResponse>
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeePicture { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string DepartmentId { get; set; }
    }
}
