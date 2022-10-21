using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Features.Department.Queries.GetDepartmentByName
{
    public class GetDepartmentByNameQueryHandler : IRequestHandler<GetDepartmentByNameQueryRequest, GetDepartmentByNameQueryResponse>
    {
        private readonly IQueryUnitOfWork query;
   

        public GetDepartmentByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
        }

        public async Task<GetDepartmentByNameQueryResponse> Handle(GetDepartmentByNameQueryRequest request, CancellationToken cancellationToken)
        {
            if(request.DepartmentName == null || request.DepartmentName == String.Empty)
            {
                return new GetDepartmentByNameQueryResponseMessage("Department Name is required!") 
                { Id = String.Empty, DepartmentName = String.Empty };
            }

            var department = await query.DepartmentQuery.GetAsync(d => d.DepartmentName.ToLower() == request.DepartmentName.ToLower());

          
            if(department == null)
            {
                return new GetDepartmentByNameQueryResponseMessage("Department is not found!") { Id=String.Empty,DepartmentName=String.Empty};
            }

            return new GetDepartmentByNameQueryResponse
            {
                DepartmentName = department.DepartmentName,
                Id = department.Id.ToString()
            };
        }
    }
}
