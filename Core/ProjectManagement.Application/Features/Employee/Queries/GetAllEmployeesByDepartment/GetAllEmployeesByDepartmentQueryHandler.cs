using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesByDepartment
{
    public class GetAllEmployeesByDepartmentQueryHandler : IRequestHandler<GetAllEmployeesByDepartmentQueryRequest, List<GetAllEmployeesByDepartmentQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetAllEmployeesByDepartmentQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<List<GetAllEmployeesByDepartmentQueryResponse>> Handle(GetAllEmployeesByDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await query.EmployeeQuery.GetAllWithIncludeAsync
                (false, e => e.DepartmentId == Guid.Parse(request.DepartmentId),e=>e.Department);

            if(employees == null)
            {
                throw new FileNotFoundException("Employee is not found!");
            }
           
            return mapper.Map<List<GetAllEmployeesByDepartmentQueryResponse>>(employees);

        }
    }
}
