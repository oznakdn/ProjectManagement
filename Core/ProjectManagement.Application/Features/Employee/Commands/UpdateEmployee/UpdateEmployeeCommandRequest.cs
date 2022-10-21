using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest:IRequest<UpdateEmployeeCommandResponse>
    {
      
        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeePicture { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string DepartmentId { get; set; }
    }
}
