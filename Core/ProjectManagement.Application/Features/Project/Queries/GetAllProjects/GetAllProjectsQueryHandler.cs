using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQueryRequest, List<GetAllProjectsQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetAllProjectsQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<List<GetAllProjectsQueryResponse>> Handle(GetAllProjectsQueryRequest request, CancellationToken cancellationToken)
        {
            var projects = await query.ProjectQuery.GetAllAsync();
            return mapper.Map<List<GetAllProjectsQueryResponse>>(projects);
        }
    }
}
