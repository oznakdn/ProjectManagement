using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, IEnumerable<GetAllDepartmentsQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetAllDepartmentsQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<GetAllDepartmentsQueryResponse>> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var departments = await query.DepartmentQuery.GetAllAsync(false);
            var result = departments.ToList();

            return mapper.Map<IEnumerable<GetAllDepartmentsQueryResponse>>(result).ToList();

        }

    }
}
