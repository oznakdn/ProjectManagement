using MediatR;

namespace ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesByDepartment
{
    public class GetAllEmployeesByDepartmentQueryRequest:IRequest<List<GetAllEmployeesByDepartmentQueryResponse>>
    {

        public GetAllEmployeesByDepartmentQueryRequest(string departmentId)
        {
            DepartmentId = departmentId;
        }

        public string DepartmentId { get; set; }
    }
}
