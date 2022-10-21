using MediatR;

namespace ProjectManagement.Application.Features.Employee.Queries.GetEmployeeWith
{
    public class GetEmployeeWithQueryRequest:IRequest<GetEmployeeWithQueryResponse>
    {
        public GetEmployeeWithQueryRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
