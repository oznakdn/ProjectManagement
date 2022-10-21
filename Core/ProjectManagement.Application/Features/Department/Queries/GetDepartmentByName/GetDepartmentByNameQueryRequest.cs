using MediatR;

namespace ProjectManagement.Application.Features.Department.Queries.GetDepartmentByName
{
    public class GetDepartmentByNameQueryRequest:IRequest<GetDepartmentByNameQueryResponse>
    {
        public GetDepartmentByNameQueryRequest(string departmentName)
        {
            DepartmentName = departmentName;
        }
        public string DepartmentName { get; set; }
    }
}
