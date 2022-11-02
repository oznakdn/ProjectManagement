using MediatR;

namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjectsWith
{
    public class GetAllProjectsWithQueryRequest:IRequest<IEnumerable<GetAllProjectsWithQueryResponse>>
    {
    }
}
