using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryRequest, GetProjectByIdQueryResponseMessage>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetProjectByIdQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<GetProjectByIdQueryResponseMessage> Handle(GetProjectByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var existProject = await query.ProjectQuery.GetByIdAsync(request.Id);
            if (existProject == null)
                return new GetProjectByIdQueryResponseMessage { ResponseMessage= "Project not found" };

            return mapper.Map<GetProjectByIdQueryResponseMessage>(existProject);
        }
    }
}
