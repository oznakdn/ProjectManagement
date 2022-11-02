using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjectsWith
{
    public class GetAllProjectsWithQueryHandler : IRequestHandler<GetAllProjectsWithQueryRequest, IEnumerable<GetAllProjectsWithQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetAllProjectsWithQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProjectsWithQueryResponse>> Handle(GetAllProjectsWithQueryRequest request, CancellationToken cancellationToken)
        {
            var projectsWithEmployee = await query.ProjectQuery.GetAllWithIncludeAsync(false, null, p => p.Employees);


            return projectsWithEmployee.Select(project => new GetAllProjectsWithQueryResponse
            {
                Id = project.Id.ToString(),
                ProjectTitle = project.ProjectTitle,
                ProjectDetails = project.ProjectDetails,
                ProjectStartDate = project.ProjectStartDate.ToShortDateString(),
                ProjectEndDate = project.ProjectEndDate.ToShortDateString(),
                EmployeeId = project.Employees.Select(x=>x.Id.ToString()).ToList(),
                 EmployeeFullName = project.Employees.Select(x=>x.EmployeeName + " "+x.EmployeeLastname).ToList()
            }).ToList();

        }
    }
}
