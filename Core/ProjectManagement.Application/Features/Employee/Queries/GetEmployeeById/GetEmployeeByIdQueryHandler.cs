using MediatR;
using ProjectManagement.Application.UnitOfWork;
using System.Security.Cryptography;

namespace ProjectManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQueryRequest, GetEmployeeByIdQueryResponse>
    {
        private readonly IQueryUnitOfWork query;

        public GetEmployeeByIdQueryHandler(IQueryUnitOfWork query)
        {
            this.query = query;
        }

        public async Task<GetEmployeeByIdQueryResponse> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var employee = await query.EmployeeQuery.GetByIdAsync(request.Id,false);

            if(employee is null)
            {
                return new GetEmployeeByIdQueryResponseMessage
                {
                    ResponseMessage = "Employee is not found!",
                    Id = String.Empty,
                    EmployeeName = String.Empty,
                    EmployeeLastname = String.Empty,
                    EmployeeBirthDate = String.Empty,
                    EmployeePicture = String.Empty
                };
            }

            GetEmployeeByIdQueryResponse response = new()
            {
                Id = employee.Id.ToString(),
                EmployeeName = employee.EmployeeName,
                EmployeeLastname = employee.EmployeeLastname,
                EmployeeBirthDate = employee.EmployeeBirthDate.ToShortDateString(),
                EmployeePicture = employee.EmployeePicture
            };

            return response;
        }
    }
}
