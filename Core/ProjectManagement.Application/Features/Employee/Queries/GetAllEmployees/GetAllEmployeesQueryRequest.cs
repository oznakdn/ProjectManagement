using MediatR;

namespace ProjectManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryRequest:IRequest<List<GetAllEmployeesQueryResponse>>
    {

    }
}
