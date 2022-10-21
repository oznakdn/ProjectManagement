using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.Employee.Queries.GetEmployeeWith
{
    public class GetEmployeeWithQueryHandler : IRequestHandler<GetEmployeeWithQueryRequest, GetEmployeeWithQueryResponse>
    {
        private readonly IQueryUnitOfWork query;

        public GetEmployeeWithQueryHandler(IQueryUnitOfWork query)
        {
            this.query = query;
        }

        public async Task<GetEmployeeWithQueryResponse> Handle(GetEmployeeWithQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await query.EmployeeQuery.GetAllWithIncludeAsync(false, null, e => e.Department, e => e.EmployeeContract);
            var employee = employees.Where(e => e.Id == Guid.Parse(request.Id)).SingleOrDefault();

            if (employee is null)
            {
                //throw new FileNotFoundException("Employee is not found");
               return new GetEmployeeWithQueryResponseMessage() { ResponseMessage = "Employee is not found!" };
            }
            if (employee.EmployeeContract is null)
            {
                return new GetEmployeeWithQueryResponseMessage()
                {
                    Id = employee.Id.ToString(),
                    EmployeeName = employee.EmployeeName,
                    EmployeeLastname = employee.EmployeeLastname,
                    EmployeeBirthDate = employee.EmployeeBirthDate.ToShortDateString(),
                    EmployeePicture = employee.EmployeePicture,
                    Department = employee.Department.DepartmentName,
                    ResponseMessage = "Employee's contact has no!",
                    Address = String.Empty,
                    City = String.Empty,
                    EmailAddress = String.Empty,
                    PhoneNumber = String.Empty
                };
            }


            GetEmployeeWithQueryResponse response = new GetEmployeeWithQueryResponse
            (
           employee.Id.ToString(),
           employee.EmployeeName,
           employee.EmployeeLastname,
           employee.EmployeeBirthDate.ToShortDateString(),
           employee.EmployeePicture,
           employee.Department.DepartmentName,
           employee.EmployeeContract.Address,
           employee.EmployeeContract.City,
           employee.EmployeeContract.EmailAddress,
           employee.EmployeeContract.PhoneNumber
            );
            return response;



        }
    }
}
