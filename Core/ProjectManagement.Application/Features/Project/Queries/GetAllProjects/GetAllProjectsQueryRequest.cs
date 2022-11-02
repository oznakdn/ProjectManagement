using MediatR;

namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjects
{
    public class GetAllProjectsQueryRequest:IRequest<List<GetAllProjectsQueryResponse>>
    {
    }
}
