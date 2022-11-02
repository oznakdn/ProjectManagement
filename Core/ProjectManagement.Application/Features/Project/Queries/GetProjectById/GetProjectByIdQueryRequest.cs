using MediatR;

namespace ProjectManagement.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQueryRequest:IRequest<GetProjectByIdQueryResponseMessage>
    {
        public GetProjectByIdQueryRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
