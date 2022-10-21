using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Repositories.Commands;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Persistence.Contexts;
using ProjectManagement.Persistence.Repositories.Commands.Base;

namespace ProjectManagement.Persistence.Repositories.Commands
{
    public class EmployeeCommandRepository : CommandRepository<Employee>, IEmployeeCommandRepository
    {
        public EmployeeCommandRepository(ProjectManagementDbContext context) : base(context)
        {
        }

        public async Task AddEmployeeContact(string employeeId, Contact contact)
        {
            var employee = await context.Employees.Where(e => e.Id == Guid.Parse(employeeId)).Include(e => e.EmployeeContract).SingleAsync();

            employee.EmployeeContract = contact;
            
            await context.Contacts.AddAsync(employee.EmployeeContract);
        }
    }
}
