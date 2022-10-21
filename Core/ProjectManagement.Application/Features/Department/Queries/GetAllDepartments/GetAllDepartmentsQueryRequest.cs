using MediatR;

namespace ProjectManagement.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryRequest:IRequest<IEnumerable<GetAllDepartmentsQueryResponse>>
    {

    }
}
