using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesWith
{
    public class GetAllEmployeesWithQueryHandler : IRequestHandler<GetAllEmployeesWithQueryRequest, IEnumerable<GetAllEmployeesWithQueryResponse>>
    {

        private readonly IQueryUnitOfWork query;

        public GetAllEmployeesWithQueryHandler(IQueryUnitOfWork query)
        {
            this.query = query;
        }

        public async Task<IEnumerable<GetAllEmployeesWithQueryResponse>> Handle(GetAllEmployeesWithQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await query.EmployeeQuery.GetAllWithIncludeAsync(false,null, e => e.Department);

            var result = employees.Select(employee => new GetAllEmployeesWithQueryResponse
            {
                Id = employee.Id.ToString(),
                EmployeeName = employee.EmployeeName,
                EmployeeLastname = employee.EmployeeLastname,
                EmployeePicture = employee.EmployeePicture,
                EmployeeBirthDate = employee.EmployeeBirthDate.ToShortDateString(),
                Department = employee.Department.DepartmentName,
                DepartmentId = employee.Department.Id.ToString()
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
