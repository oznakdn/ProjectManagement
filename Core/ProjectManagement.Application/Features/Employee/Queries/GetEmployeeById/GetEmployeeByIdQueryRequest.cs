using MediatR;

namespace ProjectManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryRequest:IRequest<GetEmployeeByIdQueryResponse>
    {
        public GetEmployeeByIdQueryRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
