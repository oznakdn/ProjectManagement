using MediatR;

namespace ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesWith
{
    public class GetAllEmployeesWithQueryRequest:IRequest<IEnumerable<GetAllEmployeesWithQueryResponse>>
    {
    }
}
