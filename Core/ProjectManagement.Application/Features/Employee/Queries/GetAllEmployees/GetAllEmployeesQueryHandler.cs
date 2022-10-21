using MediatR;
using ProjectManagement.Application.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, List<GetAllEmployeesQueryResponse>>
    {

        private readonly IQueryUnitOfWork query;

        public GetAllEmployeesQueryHandler(IQueryUnitOfWork query)
        {
            this.query = query;
        }

        public async Task<List<GetAllEmployeesQueryResponse>> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
           var employees = await query.EmployeeQuery.GetAllAsync(false);
            var result = employees.Select(employee => new GetAllEmployeesQueryResponse
            {
                 Id = employee.Id.ToString(),
                 EmployeeName = employee.EmployeeName,
                 EmployeeLastname = employee.EmployeeLastname,
                 EmployeePicture = employee.EmployeePicture,
                 EmployeeBirthDate = employee.EmployeeBirthDate.ToShortTimeString()
            }).ToList();

            return result;
        }
    }
}
